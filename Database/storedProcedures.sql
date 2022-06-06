# **stored procedure -> hacerlo para el número de veces que se jugo un nivel
# Trigger y stored procedure d rating

USE asleep_db;

DELIMITER $$
DROP PROCEDURE IF EXISTS num_timesP;
CREATE PROCEDURE num_timesP (IN idLevel INT)
BEGIN
	SELECT COUNT(id_level) FROM gameplays WHERE (id_level = idLevel);
    RETURN @times;
END$$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS add_levelsC;
CREATE PROCEDURE add_levelsC (IN levels_created INT)
BEGIN
	SET levels_created = levels_created + 1; #return
END$$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS add_connections;
CREATE PROCEDURE add_connections (IN times_log INT)
BEGIN
	SET @numberConnections = times_log + 1;
    RETURN @numberConnections;
END$$
DELIMITER ;