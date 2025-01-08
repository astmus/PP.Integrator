# PP.Integrator
## Logging

Буферизированный логгер для .NET приложений использующий bulk insert.<br> Запись элементов в базу данных происходит по наполению буффера или истечении определенного времени времени (в зависимости что произойдет раньше).<br> Основная цель - логирование больших объемов данных без излишнего выделения памяти GC и попадания объектов в LOH и Second Generation GC. Логирование осуществляется асинхронно и без использования ThreadPool. <br> Объектные элементы записи лога сохраняются как бинарный json (JSONB). Для доступа к базе данных используется библиотека [Npgsql](https://www.npgsql.org/index.html).


### Основные моменты

 * Логирование может осуществляться в несколько таблиц паралельно
 * Таблица в которую будет происходить запись регулируется скоупом логгера
 * При логировании Exception структура исключения логируется в JSON
 * Таблица для логирования должна соответствовать определенному формату 
 
### Структура таблицы

Структура таблицы есть надмножество классических полей логирования и полей для хранения данных. Создать таблица которая будет использоваться поумолчанию можно при помощи sql кода:

```sql
CREATE TABLE logs
(
	timestamp      TIMESTAMP,
	loglevel       CHAR(20),
	category       TEXT NOT NULL,
	message        TEXT,
	eventid        INTEGER,
	exception      JSONB,
	originalformat TEXT,
	state          JSONB
);
```
Также рекомендуется добавить индекс для ускорения записи и считывания на каждую из созданых таблиц.

```sql
CREATE INDEX logs_timestamp_index
	ON logs USING brin (timestamp);
```

### Описание полей

|Поле|Описание|
|----|--------|
|Timestamp      |Дата и время логируемого события|
|Loglevel       |Уровень лога|
|Category       |Контект (название класса) в котором проиходит логирование|
|Message        |Конечное сообщение сформированное из формата и переданных параметром|
|Exception      |JSON структура исключения (если было передано)|
|Eventid        |Идентификатор события (если было передано) |
|Originalformat |Оригинальный формат сообзения который используется для формирования message|
|State          |Параметры и обекты используемые при форматировании|

### Использование

Добавляем логгер при создании приложения
```csharp
public static void Main(string[] args)
{
	var builder = Host.CreateApplicationBuilder();
	builder.Logging.AddPostgreLogger(ConfigureConnectionString);
}
```

Функция конфигурирования строки подключения может выглядеть следующим образом
```csharp
		static void ConfigureConnectionString(NpgsqlConnectionStringBuilder builder)
		{
			builder.Host = "localhost";
			builder.Port = 5432;
			builder.Database = "master";
			builder.Password = "docker";
			builder.Username = "docker";
#if DEBUG
			builder.IncludeErrorDetail = true;
#endif
			builder.ConnectionIdleLifetime = 10;
			builder.ConnectionPruningInterval = 10;
			builder.Enlist = false;
		}
```

Если проект использует legacy способ вызова хранимых процедур и функций, то необходимо передать параметр backCompatibility = true, для совмнестимости старого способа вызова процедур и работы библиотеки [Npgsql](https://www.npgsql.org/index.html) версии >= 7.0.0
```csharp
public static void Main(string[] args)
{
	var builder = Host.CreateApplicationBuilder();
	builder.Logging.AddPostgreLogger(ConfigureConnectionString, true);
}
```
Получаем экземпляры логера
```csharp
public class LoggingExampleSecond : BackgroundService
{
  private ILogger<Status> statusLogger;
	private ILogger<Project> projectLogger;
  public int inta = 0;
	public LoggingExampleSecond(ILogger<Status> log, ILogger<Project> log2)
    {
        statusLogger = log;
        projectLogger = log2;

        var logEntry = new Status
        {
            Name = "Active",
            Display = "Активен",
            Version = inta,
            Description = "Описание статуса",
            Order = inta % 5
        };

        var projEntry = new Project
        {
            Name = "Test writting"+inta,
            Description = "проект номер "+inta,
            Version = inta,					
            LeftHours = inta*3
        }; 
    }
```
И можем производить запись используя дюбые стандартные методы расширений которые поддерживает класс ILogger

```csharp
//запись с кастомизированным форматирощиком, в результат попадет только строка с текстом
statusLogger.Log(level, inta, logEntry, level >= LogLevel.Error ? exc : default, (item, err) => "Loglevel");

//logEntry объект будет содержаться в поле таблицы State в виде JSONB
statusLogger.Log(level, exc, "Ошибка статуса {Status}", logEntry);

//Поле State таблицы логирования будет сожержать JSON из набора Key-Value переданных параметрами объектов
statusLogger.LogInformation(inta, "Status {Name} ({Display}) updated version {Version} with order {Order}", logEntry.Name,logEntry.Display, logEntry.Version, logEntry.Order);

//Поле State будет содержать Key-Value с именем проекта и полностью структуру projEntry в виде json
projectLogger.LogInformation(inta+1, "Проект {Name} {Project}", projEntry.Name, projEntry);

```

По умолчанию запись происходит в таблицу 'logs', если необходимо вести запись в другую таблицу, то для этого используются Scopes логера
```csharp
using var backgroundScope = statusLogger.BeginScope("statuslogs");
using var projectScope = projectLogger.BeginScope(new LogScope("projectlogs"));
```
Название scope есть имя таблицы которая должна присусттвовать в базе данных и иметь структуру описанную выше. Scope можно открывать несколько раз. При это старый удаляется и активным становится созданный. Класс LogScope так же позволяет настроить минимальный уровень логирования.

## Пример записи
![image](https://github.com/user-attachments/assets/fab33ebc-13cd-4bca-b29e-44e8f19bdd70)


