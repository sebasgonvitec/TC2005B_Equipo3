USE asleep_db;
SHOW TABLES;
SELECT * FROM users;
SELECT * FROM levels;
SELECT * FROM ratings;
SELECT * FROM gameplays;
SELECT num_levels_created FROM users;

select * from levels_view where id_level= 6;

-- CALL num_timesPlayed (1);
-- CALL updt_lastConnection (1);