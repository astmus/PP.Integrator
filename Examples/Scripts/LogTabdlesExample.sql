CREATE TABLE projectlogs
(
	timestamp      TIMESTAMP,
	loglevel       CHAR(20),
	category       TEXT NOT NULL,
	message        TEXT,
	exception      JSONB,
	eventid        INTEGER,
	originalformat TEXT,
	state          JSONB
);

ALTER TABLE projectlogs
	OWNER TO docker;

CREATE INDEX projectlogs_timestamp_index
	ON projectlogs USING brin (timestamp);

CREATE TABLE statuslogs
(
	timestamp      TIMESTAMP,
	loglevel       CHAR(20),
	category       TEXT NOT NULL,
	message        TEXT,
	exception      JSONB,
	eventid        INTEGER,
	originalformat TEXT,
	state          JSONB
);

ALTER TABLE statuslogs
	OWNER TO docker;

CREATE INDEX statuslogs_timestamp_index
	ON statuslogs USING brin (timestamp);

CREATE TABLE backgroundlogs
(
	timestamp      TIMESTAMP,
	loglevel       CHAR(20),
	category       TEXT NOT NULL,
	message        TEXT,
	exception      JSONB,
	eventid        INTEGER,
	originalformat TEXT,
	state          JSONB
);

ALTER TABLE backgroundlogs
	OWNER TO docker;

CREATE INDEX backgroundlogs_timestamp_index
	ON backgroundlogs USING brin (timestamp);

CREATE TABLE logs
(
	timestamp      TIMESTAMP,
	loglevel       CHAR(20),
	category       TEXT NOT NULL,
	message        TEXT,
	exception      JSONB,
	eventid        INTEGER,
	originalformat TEXT,
	state          JSONB
);

ALTER TABLE logs
	OWNER TO docker;

CREATE INDEX logs_timestamp_index
	ON logs USING brin (timestamp);