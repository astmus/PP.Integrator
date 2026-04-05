# Postgre Logger РґР»СЏ PostgreSQL

## РћРіР»Р°РІР»РµРЅРёРµ

- [РќР°Р·РЅР°С‡РµРЅРёРµ](#РЅР°Р·РЅР°С‡РµРЅРёРµ)
- [Р‘С‹СЃС‚СЂС‹Р№ СЃС‚Р°СЂС‚](#Р±С‹СЃС‚СЂС‹Р№-СЃС‚Р°СЂС‚)
- [Р’Р°СЂРёР°РЅС‚С‹ СЂРµРіРёСЃС‚СЂР°С†РёРё](#РІР°СЂРёР°РЅС‚С‹-СЂРµРіРёСЃС‚СЂР°С†РёРё)
- [Р’С‹Р±РѕСЂ СЂРµР°Р»РёР·Р°С†РёРё](#РІС‹Р±РѕСЂ-СЂРµР°Р»РёР·Р°С†РёРё)
- [Р¤РёР»СЊС‚СЂР°С†РёСЏ](#С„РёР»СЊС‚СЂР°С†РёСЏ)
- [РҐСЂР°РЅРµРЅРёРµ Р»РѕРіРѕРІ РІ PostgreSQL](#С…СЂР°РЅРµРЅРёРµ-Р»РѕРіРѕРІ-РІ-postgresql)
- [РџСЂР°РІРёР»Р° С„РѕСЂРјРёСЂРѕРІР°РЅРёСЏ РёРјРµРЅРё С‚Р°Р±Р»РёС†С‹ РёР· scope](#РїСЂР°РІРёР»Р°-С„РѕСЂРјРёСЂРѕРІР°РЅРёСЏ-РёРјРµРЅРё-С‚Р°Р±Р»РёС†С‹-РёР·-scope)
- [РџСЂРёРјРµСЂС‹ Р°РІС‚РѕРјР°С‚РёС‡РµСЃРєРё СЃРѕР·РґР°РІР°РµРјС‹С… С‚Р°Р±Р»РёС†](#РїСЂРёРјРµСЂС‹-Р°РІС‚РѕРјР°С‚РёС‡РµСЃРєРё-СЃРѕР·РґР°РІР°РµРјС‹С…-С‚Р°Р±Р»РёС†)
- [РџСЂРёРјРµСЂ РёСЃРїРѕР»СЊР·РѕРІР°РЅРёСЏ scope](#РїСЂРёРјРµСЂ-РёСЃРїРѕР»СЊР·РѕРІР°РЅРёСЏ-scope)
- [Р РµРєРѕРјРµРЅРґР°С†РёРё РїРѕ РёРјРµРЅРѕРІР°РЅРёСЋ scope](#СЂРµРєРѕРјРµРЅРґР°С†РёРё-РїРѕ-РёРјРµРЅРѕРІР°РЅРёСЋ-scope)
- [Р§С‚Рѕ РІС‹Р±СЂР°С‚СЊ](#С‡С‚Рѕ-РІС‹Р±СЂР°С‚СЊ)
- [FAQ](#faq)

## РќР°Р·РЅР°С‡РµРЅРёРµ

`Postgre`-Р»РѕРіРіРµСЂ СЃРѕС…СЂР°РЅСЏРµС‚ Р·Р°РїРёСЃРё Р»РѕРіРёСЂРѕРІР°РЅРёСЏ РІ PostgreSQL Рё Р°РІС‚РѕРјР°С‚РёС‡РµСЃРєРё СЃРѕР·РґР°С‘С‚ РЅРµРѕР±С…РѕРґРёРјС‹Рµ РѕР±СЉРµРєС‚С‹ Р±Р°Р·С‹ РґР°РЅРЅС‹С… РїСЂРё РїРµСЂРІРѕР№ Р·Р°РїРёСЃРё РІ С†РµР»РµРІСѓСЋ С‚Р°Р±Р»РёС†Сѓ.

РџРѕРґРґРµСЂР¶РёРІР°СЋС‚СЃСЏ:

- СЂРµРіРёСЃС‚СЂР°С†РёСЏ С‡РµСЂРµР· `ILoggingBuilder`;
- РѕС‚РґРµР»СЊРЅР°СЏ СЂРµРіРёСЃС‚СЂР°С†РёСЏ РёСЃС‚РѕС‡РЅРёРєР° РґР°РЅРЅС‹С… С‚РѕР»СЊРєРѕ РґР»СЏ Р»РѕРіРіРµСЂР°;
- РІС‹Р±РѕСЂ СЂРµР°Р»РёР·Р°С†РёРё Р»РѕРіРіРµСЂР°:
	- `UseDataFlow()`
- С„РёР»СЊС‚СЂР°С†РёСЏ РїРѕ СѓСЂРѕРІРЅСЋ Рё РєР°С‚РµРіРѕСЂРёРё;
- РёСЃРїРѕР»СЊР·РѕРІР°РЅРёРµ `scope` РґР»СЏ РјР°СЂС€СЂСѓС‚РёР·Р°С†РёРё Р·Р°РїРёСЃРµР№ РІ СЂР°Р·РЅС‹Рµ С‚Р°Р±Р»РёС†С‹.

---

## Р‘С‹СЃС‚СЂС‹Р№ СЃС‚Р°СЂС‚

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
logger.LogInformation("Р›РѕРіРіРµСЂ Postgre РїРѕРґРєР»СЋС‡С‘РЅ");

app.Run();
```

---

## Р’Р°СЂРёР°РЅС‚С‹ СЂРµРіРёСЃС‚СЂР°С†РёРё

### Р§РµСЂРµР· `NpgsqlConnectionStringBuilder`

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

### Р§РµСЂРµР· СЃС‚СЂРѕРєСѓ РїРѕРґРєР»СЋС‡РµРЅРёСЏ

```csharp
var connectionString = "Host=localhost;Port=5432;Database=logs;Username=postgres;Password=postgres";

builder.Logging
	.AddPostgreLogger(connectionString)
	.AddPostgreLoggerFilter(null, LogLevel.Information);
```

### Р§РµСЂРµР· СЃС‚СЂРѕРєСѓ РїРѕРґРєР»СЋС‡РµРЅРёСЏ Рё `NpgsqlDataSourceBuilder`

```csharp
var connectionString = "Host=localhost;Port=5432;Database=logs;Username=postgres;Password=postgres";

builder.Logging
	.AddPostgreLogger(connectionString, dsb =>
	{
		// Р”РѕРїРѕР»РЅРёС‚РµР»СЊРЅР°СЏ РЅР°СЃС‚СЂРѕР№РєР° NpgsqlDataSourceBuilder.
	})
	.AddPostgreLoggerFilter(null, LogLevel.Information);
```

### РћС‚РґРµР»СЊРЅР°СЏ СЂРµРіРёСЃС‚СЂР°С†РёСЏ РёСЃС‚РѕС‡РЅРёРєР° РґР°РЅРЅС‹С…

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

## Р’С‹Р±РѕСЂ СЂРµР°Р»РёР·Р°С†РёРё

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

### Р РµР¶РёРј РѕР±СЂР°С‚РЅРѕР№ СЃРѕРІРјРµСЃС‚РёРјРѕСЃС‚Рё

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

## Р¤РёР»СЊС‚СЂР°С†РёСЏ

### Р§РµСЂРµР· helper-РјРµС‚РѕРґ

```csharp
builder.Logging.AddPostgreLoggerFilter(null, LogLevel.Information);
```

### РџРѕ РєР°С‚РµРіРѕСЂРёРё

```csharp
builder.Logging.AddPostgreLoggerFilter("MyApp.Services", LogLevel.Debug);
```

### Р§РµСЂРµР· СЃС‚Р°РЅРґР°СЂС‚РЅС‹Р№ `AddFilter<TProvider>()`

Р•СЃР»Рё СЂРµР°Р»СЊРЅС‹Р№ С‚РёРї РїСЂРѕРІР°Р№РґРµСЂР° РЅР°Р·С‹РІР°РµС‚СЃСЏ `PostgreLogProvider`, С‚Рѕ С„РёР»СЊС‚СЂ РЅСѓР¶РЅРѕ РІРµС€Р°С‚СЊ РёРјРµРЅРЅРѕ РЅР° РЅРµРіРѕ:

```csharp
builder.Logging.AddFilter<PostgreLogProvider>(null, LogLevel.Warning);
```

Р•СЃР»Рё РІ РїСЂРѕРµРєС‚Рµ РєР»Р°СЃСЃ РїСЂРѕРІР°Р№РґРµСЂР° РїРµСЂРµРёРјРµРЅРѕРІР°РЅ РІ `PostgreLoggerProvider`, РґРѕРїСѓСЃС‚РёРј С‚Р°РєРѕР№ РІР°СЂРёР°РЅС‚:

```csharp
builder.Logging.AddFilter<PostgreLoggerProvider>(null, LogLevel.Warning);
```

> `AddFilter<PostgreLoggerProvider>(...)` РєРѕСЂСЂРµРєС‚РµРЅ С‚РѕР»СЊРєРѕ РІ С‚РѕРј СЃР»СѓС‡Р°Рµ, РµСЃР»Рё СЂРµР°Р»СЊРЅС‹Р№ С‚РёРї РїСЂРѕРІР°Р№РґРµСЂР° РґРµР№СЃС‚РІРёС‚РµР»СЊРЅРѕ РЅР°Р·С‹РІР°РµС‚СЃСЏ `PostgreLoggerProvider`.

---

## РҐСЂР°РЅРµРЅРёРµ Р»РѕРіРѕРІ РІ PostgreSQL

Р›РѕРіРіРµСЂ СЃРѕС…СЂР°РЅСЏРµС‚ Р·Р°РїРёСЃРё РІ С‚Р°Р±Р»РёС†С‹ СЃС…РµРјС‹ `logs`.

РџСЂРё РїРµСЂРІРѕР№ Р·Р°РїРёСЃРё РІ С†РµР»РµРІСѓСЋ С‚Р°Р±Р»РёС†Сѓ Р»РѕРіРіРµСЂ Р°РІС‚РѕРјР°С‚РёС‡РµСЃРєРё:

- СЃРѕР·РґР°С‘С‚ СЃС…РµРјСѓ `logs`, РµСЃР»Рё РѕРЅР° РµС‰С‘ РЅРµ СЃСѓС‰РµСЃС‚РІСѓРµС‚;
- СЃРѕР·РґР°С‘С‚ С‚Р°Р±Р»РёС†Сѓ Р»РѕРіРѕРІ, РµСЃР»Рё РѕРЅР° РµС‰С‘ РЅРµ СЃСѓС‰РµСЃС‚РІСѓРµС‚;
- СЃРѕР·РґР°С‘С‚ `BRIN`-РёРЅРґРµРєСЃ РїРѕ РїРѕР»СЋ `timestamp`, РµСЃР»Рё РѕРЅ РµС‰С‘ РЅРµ СЃСѓС‰РµСЃС‚РІСѓРµС‚.

### РЎС‚СЂСѓРєС‚СѓСЂР° С‚Р°Р±Р»РёС†С‹

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

### РћСЃРѕР±РµРЅРЅРѕСЃС‚Рё

- РІСЃРµ С‚Р°Р±Р»РёС†С‹ СЃРѕР·РґР°СЋС‚СЃСЏ РІ СЃС…РµРјРµ `logs`;
- С‚Р°Р±Р»РёС†С‹ СЃРѕР·РґР°СЋС‚СЃСЏ РєР°Рє `UNLOGGED`;
- РґР»СЏ РїРѕР»СЏ `timestamp` Р°РІС‚РѕРјР°С‚РёС‡РµСЃРєРё СЃРѕР·РґР°С‘С‚СЃСЏ `BRIN`-РёРЅРґРµРєСЃ;
- РёРјСЏ РёРЅРґРµРєСЃР° С„РѕСЂРјРёСЂСѓРµС‚СЃСЏ РёР· РїРѕР»РЅРѕРіРѕ РёРјРµРЅРё С‚Р°Р±Р»РёС†С‹ Р·Р°РјРµРЅРѕР№ `.` РЅР° `_` Рё РґРѕР±Р°РІР»РµРЅРёРµРј СЃСѓС„С„РёРєСЃР° `_timestamp_brin_idx`.

РџСЂРёРјРµСЂС‹:

- `logs.log` в†’ `logs_log_timestamp_brin_idx`
- `logs.import` в†’ `logs_import_timestamp_brin_idx`
- `logs.import_jira_issues` в†’ `logs_import_jira_issues_timestamp_brin_idx`

### SQL, РёСЃРїРѕР»СЊР·СѓРµРјС‹Р№ РґР»СЏ РёРЅРёС†РёР°Р»РёР·Р°С†РёРё С‚Р°Р±Р»РёС†С‹

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

## РџСЂР°РІРёР»Р° С„РѕСЂРјРёСЂРѕРІР°РЅРёСЏ РёРјРµРЅРё С‚Р°Р±Р»РёС†С‹ РёР· scope

РРјСЏ С‚Р°Р±Р»РёС†С‹ РІСЃРµРіРґР° СЃС‚СЂРѕРёС‚СЃСЏ РІ СЃС…РµРјРµ `logs`.

### 1. Scope РЅРµ Р·Р°РґР°РЅ

РСЃРїРѕР»СЊР·СѓРµС‚СЃСЏ С‚Р°Р±Р»РёС†Р°:

```text
logs.log
```

РџСЂРёРјРµСЂ:

```csharp
logger.LogInformation("РџСЂРёР»РѕР¶РµРЅРёРµ Р·Р°РїСѓС‰РµРЅРѕ");
```

### 2. Р—Р°РґР°РЅ РѕРґРёРЅ scope

РСЃРїРѕР»СЊР·СѓРµС‚СЃСЏ С‚Р°Р±Р»РёС†Р°:

```text
logs.<scope>
```

РџСЂРёРјРµСЂ:

```csharp
using var scope = logger.BeginScope("import");
logger.LogInformation("РќР°С‡Р°С‚ РёРјРїРѕСЂС‚");
```

Р РµР·СѓР»СЊС‚Р°С‚:

```text
logs.import
```

### 3. РСЃРїРѕР»СЊР·СѓСЋС‚СЃСЏ РІР»РѕР¶РµРЅРЅС‹Рµ scope

Р—РЅР°С‡РµРЅРёСЏ scope РѕР±СЉРµРґРёРЅСЏСЋС‚СЃСЏ С‡РµСЂРµР· `_`.

Р¤РѕСЂРјР°С‚:

```text
logs.<scope>_<subScope>_<sub_Scope>
```

РџСЂРёРјРµСЂ:

```csharp
using var scope1 = logger.BeginScope("import");
using var scope2 = logger.BeginScope("jira");
using var scope3 = logger.BeginScope("issues");

logger.LogInformation("РћР±СЂР°Р±РѕС‚РєР° Р·Р°РґР°С‡");
```

Р РµР·СѓР»СЊС‚Р°С‚:

```text
logs.import_jira_issues
```

### РџСЂРёРјРµСЂС‹ С„РѕСЂРјРёСЂРѕРІР°РЅРёСЏ РёРјС‘РЅ С‚Р°Р±Р»РёС†

| Scope | РўР°Р±Р»РёС†Р° |
|---|---|
| РЅРµС‚ scope | `logs.log` |
| `import` | `logs.import` |
| `tracker` | `logs.tracker` |
| `import` в†’ `jira` | `logs.import_jira` |
| `import` в†’ `jira` в†’ `issues` | `logs.import_jira_issues` |
| `sync` в†’ `users` в†’ `full` | `logs.sync_users_full` |

---

## РџСЂРёРјРµСЂС‹ Р°РІС‚РѕРјР°С‚РёС‡РµСЃРєРё СЃРѕР·РґР°РІР°РµРјС‹С… С‚Р°Р±Р»РёС†

### Р‘РµР· scope

```csharp
logger.LogInformation("РЎС‚Р°СЂС‚ РїСЂРёР»РѕР¶РµРЅРёСЏ");
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

### РћРґРёРЅ scope

```csharp
using var scope = logger.BeginScope("import");
logger.LogInformation("РќР°С‡Р°С‚ РёРјРїРѕСЂС‚ РґР°РЅРЅС‹С…");
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

### Р’Р»РѕР¶РµРЅРЅС‹Рµ scope

```csharp
using var scope1 = logger.BeginScope("import");
using var scope2 = logger.BeginScope("jira");

logger.LogInformation("Р§С‚РµРЅРёРµ Р·Р°РґР°С‡");
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

## РџСЂРёРјРµСЂ РёСЃРїРѕР»СЊР·РѕРІР°РЅРёСЏ scope

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

	logger.LogInformation("РќР°С‡Р°С‚Р° РѕР±СЂР°Р±РѕС‚РєР° РєРѕРјР°РЅРґС‹ {CommandName}", "import");
	return "done";
});

app.Run();
```

---

## Р РµРєРѕРјРµРЅРґР°С†РёРё РїРѕ РёРјРµРЅРѕРІР°РЅРёСЋ scope

Р РµРєРѕРјРµРЅРґСѓРµС‚СЃСЏ РёСЃРїРѕР»СЊР·РѕРІР°С‚СЊ РєРѕСЂРѕС‚РєРёРµ Рё РїРѕРЅСЏС‚РЅС‹Рµ Р·РЅР°С‡РµРЅРёСЏ scope, С‚Р°Рє РєР°Рє РѕРЅРё СѓС‡Р°СЃС‚РІСѓСЋС‚ РІ С„РѕСЂРјРёСЂРѕРІР°РЅРёРё РёРјРµРЅРё С‚Р°Р±Р»РёС†С‹.

РџРѕРґС…РѕРґСЏС‰РёРµ РїСЂРёРјРµСЂС‹:

- `import`
- `jira`
- `sync`
- `users`
- `telegram`
- `commands`

РџРѕРґС…РѕРґСЏС‰РёРµ РІР»РѕР¶РµРЅРЅС‹Рµ С†РµРїРѕС‡РєРё:

- `import` в†’ `jira`
- `sync` в†’ `users`
- `telegram` в†’ `commands` в†’ `admin`

Р РµР·СѓР»СЊС‚РёСЂСѓСЋС‰РёРµ С‚Р°Р±Р»РёС†С‹:

- `logs.import_jira`
- `logs.sync_users`
- `logs.telegram_commands_admin`

---

## Р§С‚Рѕ РІС‹Р±СЂР°С‚СЊ

### `AddPostgreLogger(...)`

РСЃРїРѕР»СЊР·СѓР№, РєРѕРіРґР° РЅСѓР¶РЅРѕ СЃСЂР°Р·Сѓ:

- Р·Р°СЂРµРіРёСЃС‚СЂРёСЂРѕРІР°С‚СЊ РёСЃС‚РѕС‡РЅРёРє РґР°РЅРЅС‹С… РґР»СЏ Р»РѕРіРіРµСЂР°;
- РїРѕРґРєР»СЋС‡РёС‚СЊ РїСЂРѕРІР°Р№РґРµСЂ Р»РѕРіРёСЂРѕРІР°РЅРёСЏ.

### `AddPostgreLoggingDataSource(...)` + `AddPostgreLogger()`

РСЃРїРѕР»СЊР·СѓР№, РєРѕРіРґР° РЅСѓР¶РЅРѕ:

- СЂР°Р·РґРµР»РёС‚СЊ СЂРµРіРёСЃС‚СЂР°С†РёСЋ РёСЃС‚РѕС‡РЅРёРєР° РґР°РЅРЅС‹С… Рё РїСЂРѕРІР°Р№РґРµСЂР°;
- РѕС‚РґРµР»СЊРЅРѕ РєРѕРЅС‚СЂРѕР»РёСЂРѕРІР°С‚СЊ РёРЅС„СЂР°СЃС‚СЂСѓРєС‚СѓСЂСѓ.

### `UseDataFlow()`

РСЃРїРѕР»СЊР·СѓР№, РєРѕРіРґР° С‚СЂРµР±СѓРµС‚СЃСЏ РєР»Р°СЃСЃРёС‡РµСЃРєР°СЏ СЂРµР°Р»РёР·Р°С†РёСЏ Р»РѕРіРіРµСЂР°.



### `AddPostgreLoggerFilter(...)`

РСЃРїРѕР»СЊР·СѓР№, РєРѕРіРґР° РЅСѓР¶РЅРѕ РѕРіСЂР°РЅРёС‡РёС‚СЊ СѓСЂРѕРІРµРЅСЊ РёР»Рё РєР°С‚РµРіРѕСЂРёСЋ Р»РѕРіРёСЂРѕРІР°РЅРёСЏ РёРјРµРЅРЅРѕ РґР»СЏ Postgre-РїСЂРѕРІР°Р№РґРµСЂР°.

---

## FAQ

### Р’ РєР°РєСѓСЋ СЃС…РµРјСѓ СЃРѕС…СЂР°РЅСЏСЋС‚СЃСЏ С‚Р°Р±Р»РёС†С‹ Р»РѕРіРѕРІ?

Р’Рѕ РІСЃРµС… СЃР»СѓС‡Р°СЏС… РёСЃРїРѕР»СЊР·СѓРµС‚СЃСЏ СЃС…РµРјР°:

```text
logs
```

### РљР°РєР°СЏ С‚Р°Р±Р»РёС†Р° РёСЃРїРѕР»СЊР·СѓРµС‚СЃСЏ РїРѕ СѓРјРѕР»С‡Р°РЅРёСЋ?

Р•СЃР»Рё scope РѕС‚СЃСѓС‚СЃС‚РІСѓРµС‚, РёСЃРїРѕР»СЊР·СѓРµС‚СЃСЏ С‚Р°Р±Р»РёС†Р°:

```text
logs.log
```

### Р§С‚Рѕ РїСЂРѕРёСЃС…РѕРґРёС‚ РїСЂРё РёСЃРїРѕР»СЊР·РѕРІР°РЅРёРё РІР»РѕР¶РµРЅРЅС‹С… scope?

РРјРµРЅР° scope РѕР±СЉРµРґРёРЅСЏСЋС‚СЃСЏ С‡РµСЂРµР· СЃРёРјРІРѕР» `_` Рё С„РѕСЂРјРёСЂСѓСЋС‚ РёРјСЏ С‚Р°Р±Р»РёС†С‹ РІ СЃС…РµРјРµ `logs`.

РџСЂРёРјРµСЂ:

```text
import в†’ jira в†’ issues
```

Р РµР·СѓР»СЊС‚Р°С‚:

```text
logs.import_jira_issues
```

### РљР°РєРѕР№ РёРЅРґРµРєСЃ СЃРѕР·РґР°С‘С‚СЃСЏ Р°РІС‚РѕРјР°С‚РёС‡РµСЃРєРё?

Р”Р»СЏ РєР°Р¶РґРѕР№ С‚Р°Р±Р»РёС†С‹ СЃРѕР·РґР°С‘С‚СЃСЏ `BRIN`-РёРЅРґРµРєСЃ РїРѕ РїРѕР»СЋ `timestamp`.

### РџРѕС‡РµРјСѓ С‚Р°Р±Р»РёС†Р° СЃРѕР·РґР°С‘С‚СЃСЏ РєР°Рє `UNLOGGED`?

Р­С‚Рѕ СѓРјРµРЅСЊС€Р°РµС‚ РЅР°РєР»Р°РґРЅС‹Рµ СЂР°СЃС…РѕРґС‹ РЅР° РёРЅС‚РµРЅСЃРёРІРЅСѓСЋ Р·Р°РїРёСЃСЊ Р»РѕРіРѕРІ.

