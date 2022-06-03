USE asleep_db;

#por alguna razón no funciona el término delimiter
DROP TRIGGER IF EXISTS update_lastC;
CREATE TRIGGER update_lastC
AFTER INSERT ON users
FOR EACH ROW
	UPDATE last_connection SET last_connection = CURRENT_TIMESTAMP();

#Trigger y stored procedure d rating