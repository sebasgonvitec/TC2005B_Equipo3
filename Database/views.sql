USE asleep_db;

DROP VIEW IF EXISTS user_view;
CREATE VIEW user_view AS
	SELECT username, num_levels_created FROM asleep_db.users 
    ORDER BY id_user ASC;
SELECT * FROM user_view;

DROP VIEW IF EXISTS user_log;
CREATE VIEW user_log AS
	SELECT username, first_connection, last_connection FROM asleep_db.users 
    ORDER BY first_connection;
SELECT * FROM user_log;

DROP VIEW IF EXISTS levels_view;
CREATE VIEW levels_view AS
	SELECT username, level_name, level_file, level_time, num_items FROM asleep_db.users INNER JOIN asleep_db.levels 
	ON users.id_user = levels.id_user 
    ORDER BY num_levels_created DESC;
SELECT * FROM levels_view;

DROP VIEW IF EXISTS levels_rating;
CREATE VIEW levels_rating AS
	SELECT username, level_name, rating FROM asleep_db.users INNER JOIN asleep_db.levels 
		ON users.id_user = levels.id_user 
    INNER JOIN asleep_db.ratings 
		ON levels.id_user = ratings.id_user
	 ORDER BY rating DESC;
SELECT * FROM levels_rating;

DROP VIEW IF EXISTS levels_gameplay;
CREATE VIEW levels_gameplay AS
	SELECT username, level_name, time_elapsed FROM asleep_db.users INNER JOIN asleep_db.levels 
		ON users.id_user = levels.id_user 
    INNER JOIN asleep_db.gameplays 
		ON levels.id_user = gameplays.id_user
	 ORDER BY time_elapsed ASC;
SELECT * FROM levels_gameplay;