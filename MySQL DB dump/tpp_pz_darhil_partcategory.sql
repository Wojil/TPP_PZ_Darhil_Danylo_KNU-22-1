-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: tpp_pz_darhil
-- ------------------------------------------------------
-- Server version	8.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `partcategory`
--

DROP TABLE IF EXISTS `partcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `partcategory` (
  `categoryid` int NOT NULL AUTO_INCREMENT,
  `categoryname` varchar(80) NOT NULL,
  PRIMARY KEY (`categoryid`),
  UNIQUE KEY `XAK1partcategory` (`categoryname`)
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partcategory`
--

LOCK TABLES `partcategory` WRITE;
/*!40000 ALTER TABLE `partcategory` DISABLE KEYS */;
INSERT INTO `partcategory` VALUES (12,'Автоматична коробка передач'),(31,'Акумулятори'),(19,'Амортизатори'),(29,'Антиблокувальна система (ABS)'),(45,'Бампери'),(1,'Блок циліндрів'),(64,'Вентилятори охолодження'),(70,'Випаровувачи'),(42,'Вихлопні колектори'),(33,'Генератори'),(39,'Глушники'),(40,'Гнучкі труби'),(4,'Головка блоку циліндрів'),(25,'Гомілки'),(10,'Датчики'),(48,'Двері'),(49,'Дзеркала'),(16,'Диференціал'),(36,'Електронні блоки управління (ECU)'),(55,'Замки та ручки'),(13,'Зчеплення'),(47,'Капот'),(14,'Карданні вали'),(41,'Каталізатори'),(35,'Катушки запалювання'),(5,'Клапана та пружини клапанів'),(3,'Колінчасті вали'),(68,'Компресори кондиціонера'),(69,'Конденсатори'),(46,'Крила'),(54,'Кузовні панелі'),(38,'Лампи (освітлення)'),(7,'Ланцюги приводу'),(8,'Масляний насос'),(11,'Механічна коробка передач'),(65,'Насоси охолодження'),(73,'Нерухома частина гальмівного механізму'),(18,'Обертова частина гальмівного механізму'),(58,'Паливні баки'),(57,'Паливні насоси'),(59,'Паливні фільтра'),(56,'Паливні форсунки'),(28,'Підвіска'),(27,'Підвісні підрамники'),(67,'Підігрівачі салону'),(22,'Підшипники коліс'),(15,'Полуосі'),(2,'Поршні та кільця поршнів'),(37,'Проводка та роз\'єми'),(20,'Пружини'),(62,'Радіатори'),(60,'Регулятори тиску палива'),(6,'Ремені приводу'),(71,'Рефрижератори'),(26,'Розвал-сходження'),(24,'Рульові рейки'),(23,'Рульові тяги'),(34,'Свічки запалювання'),(30,'Система контролю тяги (TCS)'),(17,'Система перемикання передач'),(43,'Система рециркуляції вихлопних газів (EGR)'),(51,'Скло бічне'),(52,'Скло заднє'),(50,'Скло лобове'),(21,'Стабілізатори'),(32,'Стартери'),(63,'Термостати'),(66,'Трубопроводи охолодження'),(72,'Трубопроводи системи кондиціонування'),(44,'Трубопроводи та кріплення'),(61,'Трубопроводи та шланги паливної системи'),(53,'Фари'),(9,'Фільтри');
/*!40000 ALTER TABLE `partcategory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-05 23:09:24
