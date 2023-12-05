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
-- Table structure for table `automodel`
--

DROP TABLE IF EXISTS `automodel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `automodel` (
  `automodelid` int NOT NULL,
  `automodelname` varchar(100) NOT NULL,
  PRIMARY KEY (`automodelid`),
  UNIQUE KEY `XAK1automodel` (`automodelname`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `automodel`
--

LOCK TABLES `automodel` WRITE;
/*!40000 ALTER TABLE `automodel` DISABLE KEYS */;
INSERT INTO `automodel` VALUES (1,'Acura'),(2,'Alfa Romeo'),(3,'Alpine'),(4,'Apollo'),(5,'Apple'),(6,'Aston Martin'),(7,'Audi'),(8,'Automobili Pininfarina'),(9,'Bentley'),(10,'BMW'),(11,'Bollinger'),(12,'Brilliance'),(13,'Bugatti'),(14,'Buick'),(15,'BYD'),(16,'Cadillac'),(17,'Chana'),(18,'Chery'),(19,'Chevrolet'),(20,'Chrysler'),(21,'Citroen'),(22,'Continental'),(23,'CUPRA'),(24,'Dacia'),(25,'Daewoo'),(26,'Daihatsu'),(27,'Datsun'),(28,'Detroit Electric'),(29,'Dodge'),(30,'DS Automobiles'),(31,'FAW'),(32,'Ferrari'),(33,'Fiat'),(34,'Fisker'),(35,'Ford'),(36,'Foxtron'),(37,'Geely'),(38,'Genesis'),(39,'GMC'),(40,'Great Wall'),(41,'Haval'),(42,'Honda'),(43,'Hummer'),(44,'Hyundai'),(45,'Ineos'),(46,'Infiniti'),(47,'Iran Khodro'),(48,'JAC'),(49,'Jaguar'),(50,'Jeep'),(51,'JETOUR'),(52,'Kia'),(53,'Koenigsegg'),(54,'Lada'),(55,'Lamborghini'),(56,'Lancia'),(57,'Land Rover'),(58,'Lexus'),(59,'Lifan'),(60,'Lincoln'),(61,'Lordstown'),(62,'Lotus'),(63,'Lucid'),(64,'LvChi'),(65,'Lynk & Co'),(66,'Maserati'),(67,'Maybach'),(68,'Mazda'),(69,'MCLaren'),(70,'Mercedes'),(71,'Mercedes - Benz'),(72,'MG'),(73,'MINI'),(74,'Mitsubishi'),(75,'Nikola'),(76,'NIO'),(77,'Nissan'),(78,'Opel'),(79,'Pagani'),(80,'Peugeot'),(81,'Polestar'),(82,'Porsche'),(83,'Qoros'),(84,'Range Rover'),(85,'Ravon'),(86,'Renault'),(87,'Rimac'),(88,'Rivian'),(89,'Rolls - Royce'),(90,'Saab'),(91,'Saipa'),(92,'SEAT'),(93,'Skoda'),(94,'smart'),(95,'SsangYong'),(96,'SSC North America'),(97,'Stellantis'),(98,'Subaru'),(99,'Suzuki'),(100,'Tata'),(101,'Tesla'),(102,'Torsus'),(103,'Toyota'),(104,'VinFast'),(105,'Volkswagen'),(106,'Volvo'),(107,'Xpeng'),(108,'Zotye'),(109,'ВАЗ'),(110,'ГАЗ'),(111,'ЗАЗ'),(112,'КрАЗ');
/*!40000 ALTER TABLE `automodel` ENABLE KEYS */;
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
