# **stored procedure -> hacerlo para el número de veces que se jugo un nivel
# Trigger y stored procedure d rating

USE asleep_db;

-- UNITY
DELIMITER $$
DROP PROCEDURE IF EXISTS num_timesPlayed;
CREATE PROCEDURE num_timesPlayed (IN idLevel INT)
BEGIN
	UPDATE levels SET times_played = times_played + 1 WHERE (id_level = idLevel);
END$$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS updt_lastConnection;
CREATE PROCEDURE updt_lastConnection (IN idUser INT)
BEGIN

UPDATE users SET last_connection = CURRENT_TIMESTAMP WHERE (id_user = idUser);

END$$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS updt_logTimes;
CREATE PROCEDURE updt_logTimes (IN idUser INT)
BEGIN

UPDATE users SET times_login = times_login + 1 WHERE (id_user = idUser);
END$$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS updt_createdLevels;
CREATE PROCEDURE updt_createdLevels (IN idUser INT)
BEGIN
	UPDATE users SET num_levels_created = num_levels_created + 1 WHERE (id_user = idUser);
END$$
DELIMITER ;

-- STATISTICS



-- AQUI
-- DELIMITER $$
-- DROP PROCEDURE IF EXISTS num_timesP;
-- CREATE PROCEDURE num_timesP (IN idLevel INT)
-- BEGIN
-- 	SELECT COUNT(id_level) FROM gameplays WHERE (id_level = idLevel);
--     RETURN @times;
-- END$$

-- DROP PROCEDURE IF EXISTS add_levelsC;
-- CREATE PROCEDURE add_levelsC (IN levels_created INT)
-- BEGIN
-- 	SET levels_created = levels_created + 1; #return
-- END$$

-- DROP PROCEDURE IF EXISTS add_connections;
-- CREATE PROCEDURE add_connections (IN times_log INT)
-- BEGIN
-- 	SET @numberConnections = times_log + 1;
--     RETURN @numberConnections;
-- END$$
-- DELIMITER ;
