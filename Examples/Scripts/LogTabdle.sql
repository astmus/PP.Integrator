CREATE TABLE backgroundlog
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

ALTER TABLE backgroundlog
	OWNER TO docker;

CREATE INDEX backgroundlog_timestamp_index
	ON backgroundlog USING brin (timestamp);
