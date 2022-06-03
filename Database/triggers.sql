USE asleep_db;

# update the last connection timestamp
DROP TRIGGER IF EXISTS update_lastC;
CREATE TRIGGER update_lastC
AFTER INSERT ON users
FOR EACH ROW
	UPDATE last_connection SET last_connection = CURRENT_TIMESTAMP();

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
FOR EACH ROW 
BEGIN
	CALL num_timesP(levels.id_level);
	UPDATE levels.times_played SET levels.times_played = RETURN_STATUS;
END$$