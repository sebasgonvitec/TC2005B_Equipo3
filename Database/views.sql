USE asleep_db;

#basicamente es una view del username con los niveles que ha creado ordenados por username en orden alfabético
DROP VIEW IF EXISTS user_view;
CREATE VIEW user_view AS
	SELECT username, num_levels_created FROM asleep_db.users 
    ORDER BY username ASC;
SELECT * FROM user_view;

#view del user log
DROP VIEW IF EXISTS user_log;
CREATE VIEW user_log AS
	SELECT username, first_connection, last_connection FROM asleep_db.users 
    ORDER BY first_connection;
SELECT * FROM user_log;

#view del username, con las especificaciones del nivel, sin las ids ordenados del usuario con más niveles creados a menos
DROP VIEW IF EXISTS levels_view;
CREATE VIEW levels_view AS
	SELECT username, levels.id_level, level_name, level_file, date_created FROM asleep_db.users INNER JOIN asleep_db.levels 
		ON users.id_user = levels.id_user 
    ORDER BY num_levels_created DESC;
SELECT * FROM levels_view; 

#view de username, nombre del nivel y el rating del nivel ordenado del nivel con mayor rating al menor
DROP VIEW IF EXISTS levels_rating;
CREATE VIEW levels_rating AS
	SELECT username, level_name, rating FROM asleep_db.users INNER JOIN asleep_db.levels 
		ON users.id_user = levels.id_user 
    INNER JOIN asleep_db.ratings 
		ON levels.id_user = ratings.id_user
	 ORDER BY rating DESC;
SELECT * FROM levels_rating;

#view del usuario, y de los niveles que jugó
DROP VIEW IF EXISTS levels_gameplay;
CREATE VIEW levels_gameplay AS
	SELECT username, level_name FROM asleep_db.users INNER JOIN asleep_db.levels 
		ON users.id_user = levels.id_user
	 ORDER BY username;
SELECT * FROM levels_gameplay;

#view del usuario, el nombre del nivel, el tiempo total del nivel y cuanto se tardó el usuario en pasarlo
DROP VIEW IF EXISTS level_times;
CREATE VIEW level_times AS
	SELECT username, level_name, level_time, time_elapsed FROM asleep_db.users INNER JOIN asleep_db.levels 
		ON users.id_user = levels.id_user 
    INNER JOIN asleep_db.gameplays 
		ON levels.id_user = gameplays.id_user
	 ORDER BY time_elapsed ASC;
SELECT * FROM level_times;

#view of levels and times played
DROP VIEW IF EXISTS times_level;
CREATE VIEW times_level AS
	SELECT level_name, times_played FROM asleep_db.levels
	 ORDER BY times_played DESC;
SELECT * FROM times_level;

#ranking view
DROP VIEW IF EXISTS ranking;
CREATE VIEW ranking AS
	SELECT username, num_levels_created FROM asleep_db.users INNER JOIN asleep_db.levels
    ON users.id_user = levels.id_user 
    GROUP BY users.id_user
    ORDER BY num_levels_created DESC;
SELECT * FROM ranking;