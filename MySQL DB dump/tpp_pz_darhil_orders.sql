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
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `orderid` int NOT NULL AUTO_INCREMENT,
  `statusid` int NOT NULL,
  `createdate` date NOT NULL,
  `updatedate` date NOT NULL,
  `comment` varchar(200) DEFAULT NULL,
  `clientid` int NOT NULL,
  `managerid` int NOT NULL,
  PRIMARY KEY (`orderid`),
  KEY `R_10` (`statusid`),
  KEY `orders_ibfk_1` (`managerid`),
  KEY `orders_ibfk_2_idx` (`clientid`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`managerid`) REFERENCES `manager` (`managerid`),
  CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`clientid`) REFERENCES `client` (`clientid`),
  CONSTRAINT `orders_ibfk_3` FOREIGN KEY (`statusid`) REFERENCES `orderstatus` (`statusid`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (11,1,'2023-05-20','2023-05-20','532',1,1),(12,1,'2023-05-20','2023-05-20',' ',1,1),(13,3,'2023-05-20','2023-06-04',' ',1,1),(15,3,'2023-05-20','2023-06-04',NULL,1,2),(17,3,'2004-06-20','2023-06-04',NULL,1,2),(18,3,'2023-06-04','2023-06-04',NULL,1,1),(19,5,'2023-06-04','2023-06-05',NULL,1,2),(29,1,'2023-12-05','2023-12-05','comment',1,1),(39,1,'2023-12-05','2023-12-05','comment',1,1),(40,1,'2023-12-05','2023-12-05','comment',1,1),(43,1,'2023-12-05','2023-12-05','comment',1,1),(45,1,'2023-12-05','2023-12-05','comment',1,1);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-05 23:09:23
