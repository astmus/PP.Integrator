# PP.Integrator
## Change Tracking

Библиотека предназначается для наблюдения за изменениями данных в таблицах базы Postgre и может использоваться как актуализатор настроек или опций вычитанных при старте работы приложения. Функциональность библиотеки может так же использоваться для синхронизации данных между серверами в кластере без необходимости каждому запрашивать данные по отдельности. Для доступа к базе данных используется библиотека [Npgsql](https://www.npgsql.org/index.html) и функциональность postgre [Notify/Listen](https://www.postgresql.org/docs/current/sql-notify.html)


### Основные моменты

 * Для мониторинга изменений используется одно отдельное DB подключение
 * Уведомления об ихзменениях свойств 3 типов Изменено/Удалено/Добавлено
 * Для реализации реактивных изменений используется модель pub/sub с использованием стандартных .NET интерфейсов [IObservable<T>](https://learn.microsoft.com/ru-ru/dotnet/api/system.iobservable-1?view=net-9.0) и [IObserver<T>](https://learn.microsoft.com/ru-ru/dotnet/api/system.iobserver-1?view=net-9.0)
 * Подлкючение используется для прослушивания постоянно и выполняется в фоновом [BackgroundService](https://learn.microsoft.com/ru-ru/dotnet/api/system.iobserver-1?view=net-9.0)
 * Для уведомлений об изменениях в базе используется связь хранимой функции и триггера AFTER FOR EACH ROW
 * Для корректной работы предполагается номенклатурность названий таблицы, функции и триггера
 
### Номенклатура 
Для таблицы "jobs" предполагается наличие функции которая будет создана по следующему шаблону

```sql

CREATE OR REPLACE FUNCTION on_{jobs}_changed() RETURNS TRIGGER AS
$trigger$
DECLARE
	wil {jobs};
	was {jobs};
	payload TEXT;
BEGIN
	CASE tg_op
		WHEN 'UPDATE' THEN wil := new;
						   was := old;
		WHEN 'INSERT' THEN wil := new;
		WHEN 'DELETE' THEN was := old;
		ELSE RAISE EXCEPTION 'Unknown TG_OP: "%". Should not occur!', tg_op;
		END CASE;

	payload := JSON_BUILD_OBJECT('timestamp', CURRENT_TIMESTAMP, 'action', LOWER(tg_op),'database',current_database(), 'schema', tg_table_schema, 'table', tg_table_name, 'new', TO_JSON(wil), 'old', TO_JSON(was));

	PERFORM pg_notify('{jobs}', payload);

	RETURN wil;
END;
$trigger$ LANGUAGE plpgsql;
```
И триггера
```sql
CREATE OR REPLACE TRIGGER {jobs}_changed
	AFTER INSERT OR UPDATE OR DELETE
	ON {jobs}
	FOR EACH ROW
EXECUTE PROCEDURE on_{jobs}_changed();
```


Структура объекта который будет содержать изменения
```csharp
public abstract record DataChangeContext
{
	/// Время изменения
	public DateTime Timestamp { get; set; }

	/// Тип изменения
	public ChangeKind Action { get; set; }

	/// Название базы
	public string DataBase { get; set; } = null!;

	/// Название схемы
	public string Schema { get; set; } = null!;

	/// Название таблицы
	public string Table { get; set; } = null!;
}

public record ChangeItemInfo<Item> : DataChangeContext where Item : class
{	
	/// Обновленные значения данных	
	public Item New { get; set; }
	
	/// Предидущие значения данных	
	public Item Old { get; set; }
}
```

## Использование

```csharp
public class Program
{
	public static void Main(string[] args)
	{
		var builder = Host.CreateApplicationBuilder();

		// Добавляем прослушивание
		builder.Services.AddPostgreChangeTrackingService(ConfigureConnectionString, ConfigureTracking);

		var host = builder.Build();
		host.Run();
	}

	// Добавляем типы объектов за изменениями которых будем следить
	static void ConfigureTracking(IChangeDispatcherBuilder builder)
	{
		builder
			.TrackChangesOf<Project>()
			.TrackChangesOf<Status>()
			.TrackChangesOf<StringWriter>();
	}

	// Настраиваем подключение к БД
	static void ConfigureConnectionString(NpgsqlConnectionStringBuilder builder)
	{
		builder.Host = "localhost";
		builder.Port = 5432;
		builder.Database = "master";
		builder.Password = "docker";
		builder.Username = "docker";
	}
}
```
Далее определяем класс слушателя унаследовавшись от:

```csharp
ChangeConsumer<Item>
```
И переоперделяем необходимые для обработки методы
```csharp
public override void OnCompleted();
public override void OnError(Exception error);
public override void OnCreate(Item item);
public override void OnDelete(Item deleted);
public override void OnUpdate(Item current, Item old)
```

Во время работы приложения

```csharp
// Получаем объект диспетчера изменений
public Example(IChangeDispatcher dispatcher)
{	
    this.dispatcher = dispatcher;
    //Создаем объект который будет получать уведомления об изменениях
    vat listener = new ChangeConsumer<Item>();
    //Запрашиваем провайдер изменений
    var triggerChangesProvider = dispatcher.ChangesOf<EventTrigger>();
    //Подписываемся на его уведомления
    using var subscribe = triggerChangesProvider.Subscribe(settings);
}
```
После изменений значений обхекта в базе произойдет автоматическое срабатываение одного из соответствующих методов.
Наблюдателей (подписчиков) за изменениями может быть различное количество
