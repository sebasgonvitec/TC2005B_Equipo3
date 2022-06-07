USE asleep_db;

# GRAFICA 1: BARRAS 10 USUARIOS MAS ACTIVOS
# GRAFICA 2: TIMELINE CHART OF FIRST AND LAST CONNECTIONS
#view del user log 
DROP VIEW IF EXISTS user_log;
CREATE VIEW user_log AS
	SELECT username, times_login, first_connection, last_connection FROM asleep_db.users 
    ORDER BY times_login DESC 
    LIMIT 10;
SELECT username, times_login FROM user_log; #SELECT GRAFICA 1
SELECT username, first_connection, last_connection FROM user_log; #SELECT GRAFICA 2
#SELECT username, TIMESTAMPDIFF(DAY, first_connection, last_connection) FROM user_log;

#GRAFICA 3: PIE CHART -> QUE PORCENTAJE DEL TOTAL DE LOS NIVELES CREADOS POR USUARIO -> VER SI HACE FALTA UN COUNT
#basicamente es una view del username con el numero niveles que ha creado ordenados por username en orden alfabético
DROP VIEW IF EXISTS user_view;
CREATE VIEW user_view AS
	SELECT username, num_levels_created FROM asleep_db.users 
    ORDER BY username ASC;
SELECT * FROM user_view; #SELECT GRAFICA 3

#GRAFICA 4: DE BARRAS DE LOS 10 NIVELES MAS JUGADOS + poner el nombre de los creadores
#view of levels and times played
DROP VIEW IF EXISTS times_level;
CREATE VIEW times_level AS
	SELECT level_name, times_played, username FROM asleep_db.levels INNER JOIN asleep_db.users ON users.id_user = levels.id_user
	 ORDER BY times_played DESC
     LIMIT 10;
SELECT * FROM times_level; #SELECT GRAFICA 4

#GRAFICA 5: LOS 5 MEJORES TIEMPOS POR NIVEL
#view del usuario, el nombre del nivel, el tiempo total del nivel y cuanto se tardó el usuario en pasarlo
DROP VIEW IF EXISTS level_times;
CREATE VIEW level_times AS
	SELECT username, level_name, level_time, time_elapsed FROM asleep_db.users INNER JOIN asleep_db.levels 
		ON users.id_user = levels.id_user 
    INNER JOIN asleep_db.gameplays 
		ON levels.id_user = gameplays.id_user 
	 ORDER BY time_elapsed ASC;
SELECT * FROM level_times WHERE level_name = "First Real Test" LIMIT 5; #SELECT GRAFICA 5

-- UNITY
#view del username, con las especificaciones del nivel, sin las ids ordenados del usuario con más niveles creados a menos
DROP VIEW IF EXISTS levels_view;
CREATE VIEW levels_view AS
	SELECT username, levels.id_level, level_name, level_file, date_created FROM asleep_db.users INNER JOIN asleep_db.levels 
		ON users.id_user = levels.id_user 
    ORDER BY id_level ASC;
SELECT * FROM levels_view; 




-- ESTAS NO SE USAN
-- #view del username, con las especificaciones del nivel, sin las ids ordenados del usuario con más niveles creados a menos
-- DROP VIEW IF EXISTS levels_view2;
-- CREATE VIEW levels_view AS
-- 	SELECT username, levels.id_level, level_name, level_file, date_created FROM asleep_db.users INNER JOIN asleep_db.levels 
-- 		ON users.id_user = levels.id_user 
--     ORDER BY num_levels_created DESC;
-- SELECT * FROM levels_view; 

-- #view del usuario, y de los niveles que jugó
-- DROP VIEW IF EXISTS levels_gameplay;
-- CREATE VIEW levels_gameplay AS
-- 	SELECT username, level_name FROM asleep_db.users INNER JOIN asleep_db.levels 
-- 		ON users.id_user = levels.id_user
-- 	 ORDER BY username;
-- SELECT * FROM levels_gameplay;

-- #ranking view
-- DROP VIEW IF EXISTS ranking;
-- CREATE VIEW ranking AS
-- 	SELECT username, num_levels_created FROM asleep_db.users INNER JOIN asleep_db.levels
--     ON users.id_user = levels.id_user 
--     GROUP BY users.id_user
--     ORDER BY num_levels_created DESC
--     LIMIT 5;
-- SELECT * FROM ranking;