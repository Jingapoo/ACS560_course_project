BEGIN TRANSACTION;
DROP TABLE IF EXISTS `preferences`;
CREATE TABLE IF NOT EXISTS `preferences` (
	`id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`key`	VARCHAR ( 32 ) UNIQUE,
	`value`	VARCHAR ( 32 )
);
INSERT INTO `preferences` (id,key,value) VALUES (35,'saved_user',''),
 (36,'saved_pass','');
DROP TABLE IF EXISTS `friends`;
CREATE TABLE IF NOT EXISTS `friends` (
	`ID`	INTEGER PRIMARY KEY AUTOINCREMENT,
	`login_username`	TEXT,
	`username`	TEXT
);
COMMIT;
