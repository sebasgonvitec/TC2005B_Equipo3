# **stored procedure -> hacerlo para el número de veces que se jugo un nivel
# Trigger y stored procedure d rating

USE asleep_db;

DROP PROCEDURE IF EXISTS num_timesP;
DELIMITER $$
CREATE PROCEDURE num_timesP (IN idLevel INT)
	SELECT COUNT(id_level) FROM gameplays WHERE (id_level = idLevel);
    RETURN @times;
DELIMITER ;
