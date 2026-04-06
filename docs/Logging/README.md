# Postgre Logger для PostgreSQL

## Оглавление

- [Назначение](#назначение)
- [Быстрый старт](#быстрый-старт)
- [Варианты регистрации](#варианты-регистрации)
- [Выбор реализации](#выбор-реализации)
- [Фильтрация](#фильтрация)
- [Хранение логов в PostgreSQL](#хранение-логов-в-postgresql)
- [Правила формирования имени таблицы из scope](#правила-формирования-имени-таблицы-из-scope)
- [Примеры автоматически создаваемых таблиц](#примеры-автоматически-создаваемых-таблиц)
- [Пример использования scope](#пример-использования-scope)
- [Рекомендации по именованию scope](#рекомендации-по-именованию-scope)
- [Что выбрать](#что-выбрать)
- [FAQ](#faq)

## Назначение

`Postgre`-логгер сохраняет записи логирования в PostgreSQL и автоматически создаёт необходимые объекты базы данных при первой записи в целевую таблицу.

Поддерживаются:

- регистрация через `ILoggingBuilder`;
- отдельная регистрация источника данных только для логгера;
- выбор реализации логгера:
	- `UseDataFlow()`
- фильтрация по уровню и категории;
- использование `scope` для маршрутизации записей в разные таблицы.

---

## Быстрый старт

```csharp
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PP.Integrator.Logging;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Logging
	.AddPostgreLogger(csb =>
	{
		csb.Host = "localhost";
		csb.Port = 5432;
		csb.Database = "logs";
		csb.Username = "postgres";
		csb.Password = "postgres";
	})
	.UseDataFlow()
	.AddPostgreLoggerFilter(null, LogLevel.Information);

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Логгер Postgre подключён");

app.Run();
```

---

## Варианты регистрации

### Через `NpgsqlConnectionStringBuilder`

```csharp
builder.Logging
	.AddPostgreLogger(csb =>
	{
		csb.Host = "localhost";
		csb.Port = 5432;
		csb.Database = "logs";
		csb.Username = "postgres";
		csb.Password = "postgres";
	})
	.AddPostgreLoggerFilter(null, LogLevel.Information);
```

### Через строку подключения

```csharp
var connectionString = "Host=localhost;Port=5432;Database=logs;Username=postgres;Password=postgres";

builder.Logging
	.AddPostgreLogger(connectionString)
	.AddPostgreLoggerFilter(null, LogLevel.Information);
```

### Через строку подключения и `NpgsqlDataSourceBuilder`

```csharp
var connectionString = "Host=localhost;Port=5432;Database=logs;Username=postgres;Password=postgres";

builder.Logging
	.AddPostgreLogger(connectionString, dsb =>
	{
		// Дополнительная настройка NpgsqlDataSourceBuilder.
	})
	.AddPostgreLoggerFilter(null, LogLevel.Information);
```

### Отдельная регистрация источника данных

```csharp
builder.Services.AddPostgreLoggingDataSource(csb =>
{
	csb.Host = "localhost";
	csb.Port = 5432;
	csb.Database = "logs";
	csb.Username = "postgres";
	csb.Password = "postgres";
});

builder.Logging
	.AddPostgreLogger()
	.AddPostgreLoggerFilter(null, LogLevel.Information);
```

---

## Выбор реализации

### `UseDataFlow()`

```csharp
builder.Logging
	.AddPostgreLogger(csb =>
	{
		csb.Host = "localhost";
		csb.Database = "logs";
		csb.Username = "postgres";
		csb.Password = "postgres";
	})
	.UseDataFlow()
	.AddPostgreLoggerFilter(null, LogLevel.Information);
```


```csharp
builder.Logging
	.AddPostgreLogger(csb =>
	{
		csb.Host = "localhost";
		csb.Database = "logs";
		csb.Username = "postgres";
		csb.Password = "postgres";
	})
	.UseDataFlow()
	.AddPostgreLoggerFilter(null, LogLevel.Information);
```

### Режим обратной совместимости

```csharp
builder.Logging
	.AddPostgreLogger(csb =>
	{
		csb.Host = "localhost";
		csb.Database = "logs";
		csb.Username = "postgres";
		csb.Password = "postgres";
	}, backCompatibility: true)
	.AddPostgreLoggerFilter(null, LogLevel.Information);
```

---

## Фильтрация

### Через helper-метод

```csharp
builder.Logging.AddPostgreLoggerFilter(null, LogLevel.Information);
```

### По категории

```csharp
builder.Logging.AddPostgreLoggerFilter("MyApp.Services", LogLevel.Debug);
```

### Через стандартный `AddFilter<TProvider>()`

Если реальный тип провайдера называется `PostgreLogProvider`, то фильтр нужно вешать именно на него:

```csharp
builder.Logging.AddFilter<PostgreLogProvider>(null, LogLevel.Warning);
```

Если в проекте класс провайдера переименован в `PostgreLoggerProvider`, допустим такой вариант:

```csharp
builder.Logging.AddFilter<PostgreLoggerProvider>(null, LogLevel.Warning);
```

> `AddFilter<PostgreLoggerProvider>(...)` корректен только в том случае, если реальный тип провайдера действительно называется `PostgreLoggerProvider`.

---

## Хранение логов в PostgreSQL

Логгер сохраняет записи в таблицы схемы `logs`.

При первой записи в целевую таблицу логгер автоматически:

- создаёт схему `logs`, если она ещё не существует;
- создаёт таблицу логов, если она ещё не существует;
- создаёт `BRIN`-индекс по полю `timestamp`, если он ещё не существует.

### Структура таблицы

```sql
CREATE SCHEMA IF NOT EXISTS logs;

CREATE UNLOGGED TABLE IF NOT EXISTS logs.<table_name>
(
	timestamp TIMESTAMPTZ,
	loglevel text,
	category TEXT NOT NULL,
	message text,
	eventid integer,
	exception JSONB,
	originalformat text,
	state JSONB
);

CREATE INDEX IF NOT EXISTS logs_<table_name>_timestamp_brin_idx
	ON logs.<table_name> USING brin (timestamp);
```

### Особенности

- все таблицы создаются в схеме `logs`;
- таблицы создаются как `UNLOGGED`;
- для поля `timestamp` автоматически создаётся `BRIN`-индекс;
- имя индекса формируется из полного имени таблицы заменой `.` на `_` и добавлением суффикса `_timestamp_brin_idx`.

Примеры:

- `logs.log` → `logs_log_timestamp_brin_idx`
- `logs.import` → `logs_import_timestamp_brin_idx`
- `logs.import_jira_issues` → `logs_import_jira_issues_timestamp_brin_idx`

### SQL, используемый для инициализации таблицы

```csharp
var indexName = qualifiedTableName.Replace('.', '_') + "_timestamp_brin_idx";
using var command = DataSource.CreateCommand(
	$"CREATE SCHEMA IF NOT EXISTS logs; " +
	$"CREATE unlogged TABLE IF NOT EXISTS {qualifiedTableName} " +
	"(timestamp TIMESTAMPTZ, " +
	"loglevel text, " +
	"category TEXT NOT NULL, " +
	"message text, " +
	"eventid integer, " +
	"exception JSONB, " +
	"originalformat text, " +
	"state JSONB); " +
	$"CREATE INDEX IF NOT EXISTS {indexName} " +
	$"ON {qualifiedTableName} USING brin (timestamp);");
```

---

## Правила формирования имени таблицы из scope

Имя таблицы всегда строится в схеме `logs`.

### 1. Scope не задан

Используется таблица:

```text
logs.log
```

Пример:

```csharp
logger.LogInformation("Приложение запущено");
```

### 2. Задан один scope

Используется таблица:

```text
logs.<scope>
```

Пример:

```csharp
using var scope = logger.BeginScope("import");
logger.LogInformation("Начат импорт");
```

Результат:

```text
logs.import
```

### 3. Используются вложенные scope

Значения scope объединяются через `_`.

Формат:

```text
logs.<scope>_<subScope>_<sub_Scope>
```

Пример:

```csharp
using var scope1 = logger.BeginScope("import");
using var scope2 = logger.BeginScope("jira");
using var scope3 = logger.BeginScope("issues");

logger.LogInformation("Обработка задач");
```

Результат:

```text
logs.import_jira_issues
```

### Примеры формирования имён таблиц

| Scope | Таблица |
|---|---|
| нет scope | `logs.log` |
| `import` | `logs.import` |
| `tracker` | `logs.tracker` |
| `import` → `jira` | `logs.import_jira` |
| `import` → `jira` → `issues` | `logs.import_jira_issues` |
| `sync` → `users` → `full` | `logs.sync_users_full` |

---

## Примеры автоматически создаваемых таблиц

### Без scope

```csharp
logger.LogInformation("Старт приложения");
```

```sql
CREATE SCHEMA IF NOT EXISTS logs;

CREATE UNLOGGED TABLE IF NOT EXISTS logs.log
(
	timestamp TIMESTAMPTZ,
	loglevel text,
	category TEXT NOT NULL,
	message text,
	eventid integer,
	exception JSONB,
	originalformat text,
	state JSONB
);

CREATE INDEX IF NOT EXISTS logs_log_timestamp_brin_idx
	ON logs.log USING brin (timestamp);
```

### Один scope

```csharp
using var scope = logger.BeginScope("import");
logger.LogInformation("Начат импорт данных");
```

```sql
CREATE SCHEMA IF NOT EXISTS logs;

CREATE UNLOGGED TABLE IF NOT EXISTS logs.import
(
	timestamp TIMESTAMPTZ,
	loglevel text,
	category TEXT NOT NULL,
	message text,
	eventid integer,
	exception JSONB,
	originalformat text,
	state JSONB
);

CREATE INDEX IF NOT EXISTS logs_import_timestamp_brin_idx
	ON logs.import USING brin (timestamp);
```

### Вложенные scope

```csharp
using var scope1 = logger.BeginScope("import");
using var scope2 = logger.BeginScope("jira");

logger.LogInformation("Чтение задач");
```

```sql
CREATE SCHEMA IF NOT EXISTS logs;

CREATE UNLOGGED TABLE IF NOT EXISTS logs.import_jira
(
	timestamp TIMESTAMPTZ,
	loglevel text,
	category TEXT NOT NULL,
	message text,
	eventid integer,
	exception JSONB,
	originalformat text,
	state JSONB
);

CREATE INDEX IF NOT EXISTS logs_import_jira_timestamp_brin_idx
	ON logs.import_jira USING brin (timestamp);
```

---

## Пример использования scope

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging
	.AddPostgreLogger(csb =>
	{
		csb.Host = "localhost";
		csb.Database = "logs";
		csb.Username = "postgres";
		csb.Password = "postgres";
	})
	.AddPostgreLoggerFilter(null, LogLevel.Information);

var app = builder.Build();

app.MapGet("/process", (ILogger<Program> logger) =>
{
	using var scope = logger.BeginScope(new Dictionary<string, object?>
	{
		["ChatId"] = 123456789L,
		["UserId"] = 777L,
		["TraceId"] = Guid.NewGuid().ToString("N")
	});

	logger.LogInformation("Начата обработка команды {CommandName}", "import");
	return "done";
});

app.Run();
```

---

## Рекомендации по именованию scope

Рекомендуется использовать короткие и понятные значения scope, так как они участвуют в формировании имени таблицы.

Подходящие примеры:

- `import`
- `jira`
- `sync`
- `users`
- `telegram`
- `commands`

Подходящие вложенные цепочки:

- `import` → `jira`
- `sync` → `users`
- `telegram` → `commands` → `admin`

Результирующие таблицы:

- `logs.import_jira`
- `logs.sync_users`
- `logs.telegram_commands_admin`

---

## Что выбрать

### `AddPostgreLogger(...)`

Используй, когда нужно сразу:

- зарегистрировать источник данных для логгера;
- подключить провайдер логирования.

### `AddPostgreLoggingDataSource(...)` + `AddPostgreLogger()`

Используй, когда нужно:

- разделить регистрацию источника данных и провайдера;
- отдельно контролировать инфраструктуру.

### `UseDataFlow()`

Используй, когда требуется классическая реализация логгера.



### `AddPostgreLoggerFilter(...)`

Используй, когда нужно ограничить уровень или категорию логирования именно для Postgre-провайдера.

---

## FAQ

### В какую схему сохраняются таблицы логов?

Во всех случаях используется схема:

```text
logs
```

### Какая таблица используется по умолчанию?

Если scope отсутствует, используется таблица:

```text
logs.log
```

### Что происходит при использовании вложенных scope?

Имена scope объединяются через символ `_` и формируют имя таблицы в схеме `logs`.

Пример:

```text
import → jira → issues
```

Результат:

```text
logs.import_jira_issues
```

### Какой индекс создаётся автоматически?

Для каждой таблицы создаётся `BRIN`-индекс по полю `timestamp`.

### Почему таблица создаётся как `UNLOGGED`?

Это уменьшает накладные расходы на интенсивную запись логов.

