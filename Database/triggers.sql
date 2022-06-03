USE asleep_db;

DROP TRIGGER IF EXISTS update_lastC;
CREATE TRIGGER update_lastC
AFTER INSERT ON users
FOR EACH ROW
	UPDATE last_connection SET last_connection = CURRENT_TIMESTAMP();

DROP TRIGGER IF EXISTS update_timesP;
DELIMITER $$
CREATE TRIGGER update_timesP
AFTER INSERT ON gameplays
FOR EACH ROW 
BEGIN
	CALL num_timesP(levels.id_level);
	UPDATE levels.times_played SET levels.times_played = RETURN_STATUS;
END$$
    