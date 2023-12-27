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
-- Table structure for table `autoparts`
--

DROP TABLE IF EXISTS `autoparts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autoparts` (
  `autopartid` int NOT NULL AUTO_INCREMENT,
  `code` varchar(50) NOT NULL,
  `automodelid` int NOT NULL,
  `categoryid` int NOT NULL,
  `typeid` int NOT NULL,
  `brandid` int NOT NULL,
  `countryid` int NOT NULL,
  `partname` varchar(100) NOT NULL,
  `price` decimal(9,2) NOT NULL,
  `partdescription` varchar(200) DEFAULT NULL,
  `quantity` int NOT NULL,
  PRIMARY KEY (`autopartid`),
  KEY `R_2` (`automodelid`),
  KEY `R_4` (`typeid`),
  KEY `R_6` (`countryid`),
  KEY `autoparts_ibfk_2_idx` (`categoryid`),
  KEY `autoparts_ibfk_4_idx` (`brandid`),
  CONSTRAINT `autoparts_ibfk_1` FOREIGN KEY (`automodelid`) REFERENCES `automodel` (`automodelid`),
  CONSTRAINT `autoparts_ibfk_2` FOREIGN KEY (`categoryid`) REFERENCES `partcategory` (`categoryid`),
  CONSTRAINT `autoparts_ibfk_3` FOREIGN KEY (`typeid`) REFERENCES `parttype` (`typeid`),
  CONSTRAINT `autoparts_ibfk_4` FOREIGN KEY (`brandid`) REFERENCES `manufacturerbrand` (`brandid`),
  CONSTRAINT `autoparts_ibfk_5` FOREIGN KEY (`countryid`) REFERENCES `manufacturercountry` (`countryid`),
  CONSTRAINT `price` CHECK ((`price` >= 0)),
  CONSTRAINT `quantity` CHECK ((`quantity` >= 0))
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autoparts`
--

LOCK TABLES `autoparts` WRITE;
/*!40000 ALTER TABLE `autoparts` DISABLE KEYS */;
INSERT INTO `autoparts` VALUES (1,'12137594596',10,35,2,101,147,'BMW X5 Котушка запалювання',1700.00,' ',10),(2,'34216776937',10,73,11,101,147,'BMW X5 Гальмівні колодки',4500.00,' ',10),(3,'32106771416',10,24,10,101,147,'BMW X5 Рулева рейка',13500.00,' ',10),(4,'64536972553',10,62,7,101,147,'BMW X5 Радіатор кондиціонера',2600.00,' ',10),(5,'31106778015',10,28,9,101,147,'BMW X5 Сайлентблок нижнього переднього важіля',2500.00,' ',21),(6,'31336778113',10,20,9,101,147,'BMW X5 Пружина задня',1900.00,' ',10),(15,'BFF8075',7,9,12,30,60,'Audi A7 Паливний фільтр BORG BFF8075',210.00,' ',200),(18,'1CF80AA53',93,54,1,77,95,'Scoda Octavia крило переднє ліве',5000.00,' ',6),(26,'fsd',12,16,4,40,19,'fd',5555.00,'sdfdasdasaaa123',555),(27,'521',1,16,4,55,18,'51',521.00,'521',521);
/*!40000 ALTER TABLE `autoparts` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-27 19:10:21
