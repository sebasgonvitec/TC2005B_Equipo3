USE asleep_db;

# update the last connection timestamp, cambiar a update en vez de after en vez times_login
DELIMITER $$
DROP TRIGGER IF EXISTS update_connections;
CREATE TRIGGER update_connections ON users
AFTER UPDATE users.last_connection AS
BEGIN
	CALL add_connections(users.times_login);
	UPDATE users.times_login SET users.times_login = RETURN_STATUS;
END$$

# update the number of times a level has been played
DELIMITER $$
DROP TRIGGER IF EXISTS update_timesP;
CREATE TRIGGER update_timesP
AFTER INSERT ON gameplays
FOR EACH ROW 
BEGIN
	CALL num_timesP(levels.id_level);
	UPDATE levels.times_played SET levels.times_played = RETURN_STATUS;
END$$

# update the number of levels a user has created
#checar el user_id de la tabla levels y aumentar en la fila de ese usuario el # de niveles creados
DELIMITER $$
DROP TRIGGER IF EXISTS update_levelsC;
CREATE TRIGGER update_levelsC
AFTER INSERT ON levels
BEGIN
	SET @levelUser = NEW.id_user;  
    #SET @numLevels = 
    SELECT num_levels_created FROM users WHERE id_user = levelUser;
	UPDATE #donde num_levels_created = num_levels_created
END$$