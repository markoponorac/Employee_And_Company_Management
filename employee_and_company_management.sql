CREATE DATABASE  IF NOT EXISTS `staff_and_structure_db` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `staff_and_structure_db`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: staff_and_structure_db
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20241217224752_DepartmentUpdate','8.0.2'),('20241218214737_WorkPlaceUpdate','8.0.2'),('20241219211251_WorkPlaseUpdate2','8.0.2'),('20250103150753_EmployeeUpdate','8.0.2'),('20250123203045_varcharLenUpdate','8.0.2');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `administrator`
--

DROP TABLE IF EXISTS `administrator`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `administrator` (
  `PERSON_PROFILE_ID` int NOT NULL,
  PRIMARY KEY (`PERSON_PROFILE_ID`),
  CONSTRAINT `fk_ADMINISTRATOR_PERSON1` FOREIGN KEY (`PERSON_PROFILE_ID`) REFERENCES `person` (`PROFILE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrator`
--

LOCK TABLES `administrator` WRITE;
/*!40000 ALTER TABLE `administrator` DISABLE KEYS */;
INSERT INTO `administrator` VALUES (1);
/*!40000 ALTER TABLE `administrator` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company` (
  `PROFILE_ID` int NOT NULL,
  `JIB` char(12) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Name` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Date_of_establishment` date NOT NULL,
  `Address` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`PROFILE_ID`),
  UNIQUE KEY `JIB_UNIQUE` (`JIB`),
  KEY `fk_COMPANY_PROFILE1_idx` (`PROFILE_ID`),
  CONSTRAINT `fk_COMPANY_PROFILE1` FOREIGN KEY (`PROFILE_ID`) REFERENCES `profile` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (2,'123456789012','Kompanija1','2020-06-09','Patre 5, Banja Luka'),(3,'098765432112','Kompanija2','2024-12-10','Patre 6, Banja Luka');
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `COMPANY_PROFILE_ID` int NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_DEPARTMENT_COMPANY1_idx` (`COMPANY_PROFILE_ID`),
  CONSTRAINT `fk_DEPARTMENT_COMPANY1` FOREIGN KEY (`COMPANY_PROFILE_ID`) REFERENCES `company` (`PROFILE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'Odjeljenje1',2,0),(2,'Odjeljenje2',2,0),(3,'Odjeljenje3',2,0),(4,'Prvo odjeljenje',3,0),(5,'Odjeljenje 4',2,0);
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `PERSON_PROFILE_ID` int NOT NULL,
  `Date_of_birth` date NOT NULL,
  `Is_employed` tinyint(1) NOT NULL,
  `QUALIFICATION_LEVEL_ID` int NOT NULL,
  PRIMARY KEY (`PERSON_PROFILE_ID`),
  KEY `fk_EMPLOYEE_QUALIFICATION_LEVEL1_idx` (`QUALIFICATION_LEVEL_ID`),
  CONSTRAINT `fk_EMPLOYEE_PERSON1` FOREIGN KEY (`PERSON_PROFILE_ID`) REFERENCES `person` (`PROFILE_ID`),
  CONSTRAINT `fk_EMPLOYEE_QUALIFICATION_LEVEL1` FOREIGN KEY (`QUALIFICATION_LEVEL_ID`) REFERENCES `qualification_level` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (4,'2002-06-11',0,1),(5,'1999-08-22',0,2),(6,'1999-06-16',0,2),(7,'2001-08-22',1,2),(8,'1990-07-03',0,2);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employment`
--

DROP TABLE IF EXISTS `employment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employment` (
  `Employed_from` date NOT NULL,
  `WORK_PLACE_ID` int NOT NULL,
  `COMPANY_PROFILE_ID` int NOT NULL,
  `EMPLOYEE_PERSON_PROFILE_ID` int NOT NULL,
  `Employed_to` date DEFAULT NULL,
  `Price_of_work` decimal(4,0) NOT NULL,
  `Number_of_days_off` int NOT NULL,
  PRIMARY KEY (`Employed_from`,`WORK_PLACE_ID`,`COMPANY_PROFILE_ID`,`EMPLOYEE_PERSON_PROFILE_ID`),
  KEY `fk_EMPLOYMENT_COMPANY1_idx` (`COMPANY_PROFILE_ID`),
  KEY `fk_EMPLOYMENT_EMPLOYEE1_idx` (`EMPLOYEE_PERSON_PROFILE_ID`),
  KEY `fk_EMPLOYMENT_WORK_PLACE1_idx` (`WORK_PLACE_ID`),
  CONSTRAINT `fk_EMPLOYMENT_COMPANY1` FOREIGN KEY (`COMPANY_PROFILE_ID`) REFERENCES `company` (`PROFILE_ID`),
  CONSTRAINT `fk_EMPLOYMENT_EMPLOYEE1` FOREIGN KEY (`EMPLOYEE_PERSON_PROFILE_ID`) REFERENCES `employee` (`PERSON_PROFILE_ID`),
  CONSTRAINT `fk_EMPLOYMENT_WORK_PLACE1` FOREIGN KEY (`WORK_PLACE_ID`) REFERENCES `work_place` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employment`
--

LOCK TABLES `employment` WRITE;
/*!40000 ALTER TABLE `employment` DISABLE KEYS */;
INSERT INTO `employment` VALUES ('2024-06-01',3,2,7,'2024-09-01',8,20),('2024-09-01',7,2,7,'2024-11-04',10,25),('2024-11-05',4,2,7,NULL,14,27);
/*!40000 ALTER TABLE `employment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `person`
--

DROP TABLE IF EXISTS `person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `person` (
  `PROFILE_ID` int NOT NULL,
  `JMB` char(13) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `First_name` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Last_name` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`PROFILE_ID`),
  KEY `fk_PERSON_PROFILE1_idx` (`PROFILE_ID`),
  CONSTRAINT `fk_PERSON_PROFILE1` FOREIGN KEY (`PROFILE_ID`) REFERENCES `profile` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (1,'2308001200043','Marko','Markovic'),(4,'1106002100032','Nikola','Nikolic'),(5,'2208999100029','Janko','Jankovic'),(6,'1606999100214','Jovana','Jovanovic'),(7,'2208001100032','Luka','Lukic'),(8,'0307990101876','Petar','Petrovic');
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profile`
--

DROP TABLE IF EXISTS `profile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profile` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Password` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Theme` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Language` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profile`
--

LOCK TABLES `profile` WRITE;
/*!40000 ALTER TABLE `profile` DISABLE KEYS */;
INSERT INTO `profile` VALUES (1,'admin','admin','OrangeTheme','sr-Latn-RS',1,0),(2,'kompanija1','kompanija1','OrangeTheme','sr-Latn-RS',1,0),(3,'kompanija2','kompanija2','GreenTheme','sr-Latn-RS',1,0),(4,'nikolanikolic','nikolanikolic','OrangeTheme','sr-Latn-RS',1,0),(5,'jankojankovic','jankojankovic','BlueTheme','en-US',1,0),(6,'jovanajovanovic','jovanajovanovic','BlueTheme','en-US',1,0),(7,'lukalukic','lukalukic','OrangeTheme','sr-Latn-RS',1,0),(8,'petarpetrovic','petarpetrovic','GreenTheme','sr-Latn-RS',1,0);
/*!40000 ALTER TABLE `profile` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qualification_level`
--

DROP TABLE IF EXISTS `qualification_level`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `qualification_level` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Qualification_code` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qualification_level`
--

LOCK TABLES `qualification_level` WRITE;
/*!40000 ALTER TABLE `qualification_level` DISABLE KEYS */;
INSERT INTO `qualification_level` VALUES (1,'Srednja strucna sprema','SSS'),(2,'Visoka strucna sprema','VSS'),(3,'Osnovno obrazovanje','OO');
/*!40000 ALTER TABLE `qualification_level` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salary`
--

DROP TABLE IF EXISTS `salary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salary` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Amount` decimal(4,0) NOT NULL,
  `Payment_date` date NOT NULL,
  `For_month` int NOT NULL,
  `For_year` int NOT NULL,
  `EMPLOYMENT_Employed_from` date NOT NULL,
  `EMPLOYMENT_WORK_PLACE_ID` int NOT NULL,
  `EMPLOYMENT_COMPANY_PROFILE_ID` int NOT NULL,
  `EMPLOYMENT_EMPLOYEE_PERSON_PROFILE_ID` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_SALARY_EMPLOYMENT1_idx` (`EMPLOYMENT_Employed_from`,`EMPLOYMENT_WORK_PLACE_ID`,`EMPLOYMENT_COMPANY_PROFILE_ID`,`EMPLOYMENT_EMPLOYEE_PERSON_PROFILE_ID`),
  CONSTRAINT `fk_SALARY_EMPLOYMENT1` FOREIGN KEY (`EMPLOYMENT_Employed_from`, `EMPLOYMENT_WORK_PLACE_ID`, `EMPLOYMENT_COMPANY_PROFILE_ID`, `EMPLOYMENT_EMPLOYEE_PERSON_PROFILE_ID`) REFERENCES `employment` (`Employed_from`, `WORK_PLACE_ID`, `COMPANY_PROFILE_ID`, `EMPLOYEE_PERSON_PROFILE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salary`
--

LOCK TABLES `salary` WRITE;
/*!40000 ALTER TABLE `salary` DISABLE KEYS */;
INSERT INTO `salary` VALUES (13,1760,'2024-10-01',9,2024,'2024-09-01',7,2,7),(14,1800,'2024-11-04',10,2024,'2024-09-01',7,2,7),(15,1450,'2024-07-01',6,2024,'2024-06-01',3,2,7),(16,1450,'2024-08-05',7,2024,'2024-06-01',3,2,7),(17,1400,'2024-08-30',8,2024,'2024-06-01',3,2,7);
/*!40000 ALTER TABLE `salary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `work_place`
--

DROP TABLE IF EXISTS `work_place`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `work_place` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `DepartmentId` int NOT NULL DEFAULT '0',
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `IX_work_place_DepartmentId` (`DepartmentId`),
  CONSTRAINT `fk_WORK_PLACE_DEPARTMENT` FOREIGN KEY (`DepartmentId`) REFERENCES `department` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `work_place`
--

LOCK TABLES `work_place` WRITE;
/*!40000 ALTER TABLE `work_place` DISABLE KEYS */;
INSERT INTO `work_place` VALUES (1,'Radno mjesto 1','Opis za radno mjesto 1',1,0),(2,'Radno mjesto 2','Opis za radno mjesto 2',1,0),(3,'Test 1','Radno mjesto 1 u odjeljenju 3',3,0),(4,'Test 2',NULL,2,0),(5,'Prvo radno mjesto',NULL,4,0),(6,'Drugo radno mjesto',NULL,4,0),(7,'Radno mjesto','Opis radnog mjesta',2,0);
/*!40000 ALTER TABLE `work_place` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-01-24 21:11:49
