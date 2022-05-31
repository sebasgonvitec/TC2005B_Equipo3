USE asleep_db;
CREATE VIEW levels_view AS
	SELECT username, level_name, level_file, level_time, num_items FROM asleep_db.users INNER JOIN asleep_db.levels 
	ON users.id_user = levels.id_user 
    WHERE users.num_levels_created > 0
    ORDER BY num_levels_created DESC;
SELECT * FROM levels_view;