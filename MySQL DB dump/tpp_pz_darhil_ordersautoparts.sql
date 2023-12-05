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
-- Table structure for table `ordersautoparts`
--

DROP TABLE IF EXISTS `ordersautoparts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ordersautoparts` (
  `autopartid` int NOT NULL,
  `orderid` int NOT NULL,
  `partcount` int NOT NULL,
  `price` decimal(9,2) NOT NULL,
  KEY `ordersautoparts_ibfk_2_idx` (`orderid`),
  KEY `ordersautoparts_ibfk_1_idx` (`autopartid`),
  CONSTRAINT `ordersautoparts_ibfk_1` FOREIGN KEY (`autopartid`) REFERENCES `autoparts` (`autopartid`),
  CONSTRAINT `ordersautoparts_ibfk_2` FOREIGN KEY (`orderid`) REFERENCES `orders` (`orderid`),
  CONSTRAINT `partcount` CHECK ((`partcount` >= 1)),
  CONSTRAINT `pricecheck` CHECK ((`price` >= 0))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordersautoparts`
--

LOCK TABLES `ordersautoparts` WRITE;
/*!40000 ALTER TABLE `ordersautoparts` DISABLE KEYS */;
INSERT INTO `ordersautoparts` VALUES (1,11,1,1700.00),(1,12,1,1700.00),(2,11,1,4500.00),(2,12,2,9000.00),(3,11,1,13500.00),(3,12,1,13500.00),(3,13,1,13500.00),(5,13,1,2500.00),(1,15,1,1700.00),(2,17,1,4500.00),(15,18,1,200.00),(1,19,3,5100.00),(1,29,1,170000.00),(2,29,2,900000.00),(1,29,3,510000.00),(2,43,3,13500.00),(3,43,2,27000.00);
/*!40000 ALTER TABLE `ordersautoparts` ENABLE KEYS */;
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
