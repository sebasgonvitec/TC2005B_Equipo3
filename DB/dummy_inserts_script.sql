SET NAMES utf8mb4;
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';
SET @old_autocommit=@@autocommit;

USE asleep_db;

-- Dummy data for table users
SET AUTOCOMMIT=0;
INSERT INTO users VALUES (1,'supremaciaTopo','eltoposiguevivo', 1, '2022-05-21 11:34:22', '2022-05-23 19:43:47'), 
(2,'testUser','userTest', 0, '2022-05-23 13:43:47', '2022-05-23 13:43:47'),
(3,'user123','computadora', 0, '2022-05-23 17:02:56', '2022-06-19 9:29:52'),
(4,'wtfIsAsleep','wtfIsRemi', 0, '2022-05-26 10:29:18', '2022-05-26 10:29:18'),
(5,'carlitos','clavoUnClavito', 3, '2022-05-27 16:18:06', '2022-06-08 13:01:47'),
(6,'Topo','quieroUnTopo', 0, '2022-05-27 20:26:01', '2022-05-27 20:26:01'),
(7,'tigres','tragaronTrigo', 5, '2022-05-27 18:56:57', '2022-06-14 22:16:20'),
(8,'andy1D','teamo1D', 2, '2022-06-03 15:45:51', '2022-06-06 23:06:24'),
(9,'JiminMiVaron','BTS2002', 2, '2022-06-04 00:33:11', '2022-06-09 16:37:43'),
(10,'Akemi', 'soyracista', 1, '2022-06-04 09:34:33', '2022-06-04 08:35:23');
COMMIT;

-- Dummy data for levels
SET AUTOCOMMIT=0;
INSERT INTO levels VALUES (1, 1, 'Donde esta el topo',"0,-25,-21,0<", 120, 150), 
(2, 5, 'New level', "0,-25,-21,0<0,-26,-21,0<", 90, 176), 
(3, 5, '3 stories level', "0,-25,-21,0<0,-26,-21,0<0,-27,-21,0<", 150, 224), 
(4, 7, 'Nivel 1: Facil', "0,-25,-21,0<0,-26,-21,0<0,-27,-21,0<0,-28,-21,0<", 120, 134),
(5, 7, 'Nivel 2: Dif Media', "0,-25,-21,0<0,-26,-21,0<0,-27,-21,0<0,-28,-21,0<", 150, 194),  
(6, 5, 'Sprint level', "0,-25,-21,0<0,-26,-21,0<0,-27,-21,0<0,-28,-21,0<0,-29,-21,0<", 100, 188), 
(7, 7, 'Nivel 3: Avanzado', "0,-25,-21,0<0,-26,-21,0<0,-27,-21,0<0,-28,-21,0<0,-29,-21,0<0,-30,-21,0<", 120, 189), 
(8, 7, 'Nivel 4: Difícil', "0,-25,-21,0<", 90, 197), 
(9, 7, 'Nivel 5: Nightmare', "0,-25,-21,0/0,-26,-21,0<", 45, 210), 
(10, 8, 'Basic', "0,-25,-21,0<0,-26,-21,0<0,-27,-21,0<", 120, 157), 
(11, 9, 'New Level', "0,-25,-21,0<0,-26,-21,0<0,-27,-21,0<0,-28,-21,0<", 200, 340), 
(12, 9, 'Nivel Laberinto', "0,-25,-21,0<0,-26,-21,0<0,-27,-21,0<0,-28,-21,0<0,-29,-21,0<", 180, 427), 
(13, 8, 'Nightmare', "0,-25,-21,0<0,-26,-21,0<0,-27,-21,0<0,-28,-21,0<0,-29,-21,0<0,-30,-21,0<", 30, 124), 
(14, 10, 'New Level', "0,-25,-21,0<0,-26,-21,0<0,-27,-21,0<0,-28,-21,0<0,-29,-21,0<0,-30,-21,0<0,-31,-21,0<", 100, 114);
COMMIT;

-- Dummy data for ratings
SET AUTOCOMMIT=0;
INSERT INTO ratings VALUES (1, 1, 1, 5.0),  #id, user id, level id, rating
(2, 1, 4, 5.0), 
(3, 7, 1, 3.2), 
(4, 7, 3, 2.7), 
(5, 7, 6, 4.6),  
(6, 7, 11, 1.2), 
(7, 7, 12, 5.0), 
(8, 7, 13, 4.8), 
(9, 7, 14, 2.1), 
(10, 9, 12, 4.5), 
(11, 9, 13, 4.2), 
(12, 10, 12, 4.9);
COMMIT;

-- Dummy data for gameplay
SET AUTOCOMMIT=0;
INSERT INTO gameplays VALUES (1, 1, 1, 170),  #id, user id, level id, time elapsed 
(2, 1, 4, 120), 
(3, 7, 1, 154), 
(4, 7, 3, 200), 
(5, 7, 6, 140),  
(6, 7, 11, 336), 
(7, 7, 12, 350), 
(8, 7, 13, 123), 
(9, 7, 14, 109), 
(10, 9, 12, 375), 
(11, 9, 13, 119), 
(12, 10, 12, 348);
COMMIT;