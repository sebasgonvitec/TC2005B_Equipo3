SET NAMES utf8mb4;
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

DROP SCHEMA IF EXISTS asleep_db;
CREATE SCHEMA asleep_db;
USE asleep_db;

CREATE TABLE users(
  id_user INT NOT NULL AUTO_INCREMENT,
  username VARCHAR(45) NOT NULL,
  user_password VARCHAR(45) NOT NULL,
  num_levels_created INT NOT NULL DEFAULT 0,
  first_connection TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  last_connection TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, #!!!!!!!!
  PRIMARY KEY (id_user)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE levels(
    id_level INT NOT NULL AUTO_INCREMENT,
    id_user INT NOT NULL, #esta es la foreign key
    level_name VARCHAR(255) NOT NULL,
    level_file TEXT NOT NULL,
    level_time INT NOT NULL,
    num_items INT NOT NULL,
    date_created TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, #agregar cosa a la dummy data y agregar en views 
    PRIMARY KEY (id_level),
    KEY idx_fk_user_id (id_user),
	CONSTRAINT `fk_level_id_user` FOREIGN KEY (id_user) REFERENCES users(id_user)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE ratings(
	id_rating INT NOT NULL AUTO_INCREMENT,
    id_user INT NOT NULL, #foreign key
    id_level INT NOT NULL, #foreign key
    rating FLOAT NOT NULL DEFAULT 0 COMMENT '1-5',
    PRIMARY KEY (id_rating),
    KEY idx_fk_user_id (id_user),
    CONSTRAINT `fk_rating_id_user` FOREIGN KEY (id_user) REFERENCES users(id_user),
	KEY idx_fk_level_id (id_level),
	CONSTRAINT `fk_rating_id_level` FOREIGN KEY (id_level) REFERENCES levels(id_level)
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE gameplays(
    id_gameplay INT NOT NULL AUTO_INCREMENT,
    id_user INT NOT NULL, #foreign key
    id_level INT NOT NULL, #foreign key
    time_elapsed INT NOT NULL,
    PRIMARY KEY (id_gameplay),
    KEY idx_fk_user_id (id_user),
    CONSTRAINT `fk_game_id_user` FOREIGN KEY (id_user) REFERENCES users(id_user),
	KEY idx_fk_level_id (id_level),
	CONSTRAINT `fk_game_id_level` FOREIGN KEY (id_level) REFERENCES levels(id_level)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;