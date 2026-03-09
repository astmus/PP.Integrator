
CREATE TABLE EventTriggers
(
	id               SERIAL PRIMARY KEY,
	name             VARCHAR(32)      NOT NULL,
	description      VARCHAR(64)      NOT NULL,
	isenabled        BOOLEAN DEFAULT TRUE NOT NULL,
	startat          DATE,
	runat            TIME WITHOUT TIME ZONE,
	endat            TIME WITHOUT TIME ZONE,
	delay            INTERVAL,
	interval 		 INTERVAL
);

CREATE OR REPLACE FUNCTION on_eventtrigger_changed() RETURNS TRIGGER AS
$trigger$
DECLARE
	wil EVENTTRIGGERS;
	was EVENTTRIGGERS;
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

	PERFORM pg_notify('eventtrigger', payload);

	RETURN wil;
END;
$trigger$ LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER eventtrigger_changed
	AFTER INSERT OR UPDATE OR DELETE
	ON eventtriggers
	FOR EACH ROW
EXECUTE PROCEDURE on_eventtrigger_changed();