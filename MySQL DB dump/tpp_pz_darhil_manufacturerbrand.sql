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
-- Table structure for table `manufacturerbrand`
--

DROP TABLE IF EXISTS `manufacturerbrand`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `manufacturerbrand` (
  `brandid` int NOT NULL AUTO_INCREMENT,
  `brandname` varchar(80) NOT NULL,
  PRIMARY KEY (`brandid`),
  UNIQUE KEY `XAK1manufacturerbrand` (`brandname`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacturerbrand`
--

LOCK TABLES `manufacturerbrand` WRITE;
/*!40000 ALTER TABLE `manufacturerbrand` DISABLE KEYS */;
INSERT INTO `manufacturerbrand` VALUES (52,'AISIN AI Co., Ltd.'),(6,'Aisin Seiki'),(21,'Akebono Brake Industry'),(11,'Aptiv'),(94,'ASAHI GLASS CO. LTD.'),(51,'Autoliv'),(45,'Benteler Automotive'),(30,'Borg Automotive'),(12,'BorgWarner'),(1,'Bosch'),(31,'Bosch Rexroth'),(28,'Bridgestone Corporation'),(87,'Brose Fahrzeugteile'),(50,'Calsonic Kansei Corporation'),(3,'Continental'),(57,'Continental Automotive Holding'),(40,'Continental Automotive Systems'),(55,'Continental Teves'),(67,'Continental Teves AG & Co. oHG'),(90,'Daido Kogyo Co. Ltd.'),(78,'Daido Metal Co. Ltd.'),(46,'Dana Incorporated'),(2,'Denso'),(32,'Denso Ten'),(54,'Denso Wave'),(69,'Dorman Products'),(93,'DuPont'),(58,'Eberspächer'),(79,'Eberspächer Exhaust Technology'),(8,'Faurecia'),(98,'Freudenberg Group'),(77,'FTE Automotive'),(96,'Furukawa Electric'),(76,'Gates Corporation'),(38,'GKN Automotive'),(59,'GMB Corporation'),(89,'GMB Korea Corp.'),(68,'GMB North America'),(22,'Hella KGaA Hueck & Co.'),(56,'Hengst SE'),(92,'Henkel AG & Co. KGaA'),(26,'Hitachi Automotive Systems'),(99,'Hitachi Cable'),(61,'Hitachi Metals'),(85,'Hutchinson SA'),(15,'Hyundai Mobis'),(41,'Hyundai WIA Corporation'),(42,'Iljin Bearing Co. Ltd.'),(70,'Johnson Controls'),(25,'JTEKT'),(82,'Kyocera Corporation'),(16,'Lear Corporation'),(4,'Magna International'),(14,'Mahle GmbH'),(23,'Mando Corporation'),(44,'MANN+HUMMEL'),(88,'Mannesmann Sachs AG'),(36,'Marelli Holdings Co. Ltd.'),(97,'Marquardt GmbH'),(91,'Metaldyne Performance Group'),(13,'Michelin'),(29,'Mitsubishi Electric'),(75,'NGK Ceramics'),(63,'NGK Insulators'),(43,'NGK Spark Plug'),(64,'NSK Europe'),(20,'NSK Ltd.'),(33,'NSK Steering Systems'),(39,'NTN Corporation'),(19,'Panasonic Automotive Systems'),(18,'Panasonic Corporation'),(60,'Remy International'),(83,'Röchling Automotive'),(100,'Sanden Holdings Corporation'),(9,'Schaeffler Group'),(80,'Schaeffler Technologies'),(72,'Schrader Electronics'),(49,'Schrader International'),(37,'Showa Corporation'),(71,'Showa Denko'),(35,'Sogefi'),(81,'Sogefi Group'),(48,'Stanley Electric'),(24,'Sumitomo Electric Industries'),(34,'Sumitomo Riko'),(10,'Tenneco'),(65,'Tenneco Automotive'),(27,'Thyssenkrupp'),(73,'TMD Friction'),(47,'Toyo Tire & Rubber Co. Ltd.'),(84,'Toyoda Gosei'),(62,'TRW Automotive'),(86,'Tsubaki Nakashima Co. Ltd.'),(7,'Valeo'),(74,'VDO (Continental)'),(95,'Victor Reinz'),(53,'Visteon Corporation'),(66,'Webasto Group'),(17,'Yazaki Corporation'),(5,'ZF Friedrichshafen'),(101,'Оригінал');
/*!40000 ALTER TABLE `manufacturerbrand` ENABLE KEYS */;
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
