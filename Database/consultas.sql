USE asleep_db;
SHOW TABLES;
SELECT * FROM users;
SELECT * FROM levels;
SELECT * FROM ratings;
SELECT * FROM gameplays;
SELECT COUNT(id_level) FROM gameplays WHERE (id_level=1);