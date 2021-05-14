BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Developers" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"UniqueId"	TEXT UNIQUE,
	"Name"	TEXT,
	"Status"	INTEGER,
	PRIMARY KEY("Id" AUTOINCREMENT)
);
COMMIT;
