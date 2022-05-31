DESC asleep_db.users;
DESC asleep_db.levels;
DESC ratings;

SELECT username, level_name FROM asleep_db.users INNER JOIN asleep_db.levels 
	ON users.id_user = levels.id_user 
    WHERE users.num_levels_created > 0
    ORDER BY num_levels_created DESC;

SELECT username, level_name, rating FROM asleep_db.users INNER JOIN asleep_db.levels 
		ON users.id_user = levels.id_user 
    INNER JOIN asleep_db.ratings 
		ON levels.id_user = ratings.id_user
	 ORDER BY rating DESC;

