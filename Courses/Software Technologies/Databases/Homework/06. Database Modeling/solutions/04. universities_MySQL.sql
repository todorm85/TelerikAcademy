CREATE DATABASE  IF NOT EXISTS `universities` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `universities`;
-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: localhost    Database: universities
-- ------------------------------------------------------
-- Server version	5.6.27-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `courses` (
  `idCourses` int(11) NOT NULL AUTO_INCREMENT,
  `Coursescol` varchar(45) DEFAULT NULL,
  `Departments_idDepartments` int(11) NOT NULL,
  PRIMARY KEY (`idCourses`),
  UNIQUE KEY `idCourses_UNIQUE` (`idCourses`),
  KEY `fk_Courses_Departments1_idx` (`Departments_idDepartments`),
  CONSTRAINT `fk_Courses_Departments1` FOREIGN KEY (`Departments_idDepartments`) REFERENCES `departments` (`idDepartments`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departments` (
  `idDepartments` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `Faculties_idFaculties` int(11) NOT NULL,
  PRIMARY KEY (`idDepartments`),
  UNIQUE KEY `idDepartments_UNIQUE` (`idDepartments`),
  KEY `fk_Departments_Faculties_idx` (`Faculties_idFaculties`),
  CONSTRAINT `fk_Departments_Faculties` FOREIGN KEY (`Faculties_idFaculties`) REFERENCES `faculties` (`idFaculties`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faculties`
--

DROP TABLE IF EXISTS `faculties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faculties` (
  `idFaculties` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`idFaculties`),
  UNIQUE KEY `idFaculties_UNIQUE` (`idFaculties`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faculties`
--

LOCK TABLES `faculties` WRITE;
/*!40000 ALTER TABLE `faculties` DISABLE KEYS */;
/*!40000 ALTER TABLE `faculties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors`
--

DROP TABLE IF EXISTS `professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors` (
  `idProfessors` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Departments_idDepartments` int(11) NOT NULL,
  PRIMARY KEY (`idProfessors`),
  UNIQUE KEY `idProfessors_UNIQUE` (`idProfessors`),
  KEY `fk_Professors_Departments1_idx` (`Departments_idDepartments`),
  CONSTRAINT `fk_Professors_Departments1` FOREIGN KEY (`Departments_idDepartments`) REFERENCES `departments` (`idDepartments`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors`
--

LOCK TABLES `professors` WRITE;
/*!40000 ALTER TABLE `professors` DISABLE KEYS */;
/*!40000 ALTER TABLE `professors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professorscourses`
--

DROP TABLE IF EXISTS `professorscourses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professorscourses` (
  `Professors_idProfessors` int(11) NOT NULL,
  `Courses_idCourses` int(11) NOT NULL,
  PRIMARY KEY (`Professors_idProfessors`,`Courses_idCourses`),
  KEY `fk_Professors_has_Courses_Courses1_idx` (`Courses_idCourses`),
  KEY `fk_Professors_has_Courses_Professors1_idx` (`Professors_idProfessors`),
  CONSTRAINT `fk_Professors_has_Courses_Courses1` FOREIGN KEY (`Courses_idCourses`) REFERENCES `courses` (`idCourses`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_has_Courses_Professors1` FOREIGN KEY (`Professors_idProfessors`) REFERENCES `professors` (`idProfessors`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professorscourses`
--

LOCK TABLES `professorscourses` WRITE;
/*!40000 ALTER TABLE `professorscourses` DISABLE KEYS */;
/*!40000 ALTER TABLE `professorscourses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professorstitles`
--

DROP TABLE IF EXISTS `professorstitles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professorstitles` (
  `Titles_idTitles` int(11) NOT NULL,
  `Professors_idProfessors` int(11) NOT NULL,
  PRIMARY KEY (`Titles_idTitles`,`Professors_idProfessors`),
  KEY `fk_Titles_has_Professors_Professors1_idx` (`Professors_idProfessors`),
  KEY `fk_Titles_has_Professors_Titles1_idx` (`Titles_idTitles`),
  CONSTRAINT `fk_Titles_has_Professors_Professors1` FOREIGN KEY (`Professors_idProfessors`) REFERENCES `professors` (`idProfessors`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Titles_has_Professors_Titles1` FOREIGN KEY (`Titles_idTitles`) REFERENCES `titles` (`idTitles`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professorstitles`
--

LOCK TABLES `professorstitles` WRITE;
/*!40000 ALTER TABLE `professorstitles` DISABLE KEYS */;
/*!40000 ALTER TABLE `professorstitles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `idStudents` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `Faculties_idFaculties` int(11) NOT NULL,
  PRIMARY KEY (`idStudents`),
  UNIQUE KEY `idStudents_UNIQUE` (`idStudents`),
  KEY `fk_Students_Faculties1_idx` (`Faculties_idFaculties`),
  CONSTRAINT `fk_Students_Faculties1` FOREIGN KEY (`Faculties_idFaculties`) REFERENCES `faculties` (`idFaculties`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `studentscourses`
--

DROP TABLE IF EXISTS `studentscourses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `studentscourses` (
  `Students_idStudents` int(11) NOT NULL,
  `Courses_idCourses` int(11) NOT NULL,
  PRIMARY KEY (`Students_idStudents`,`Courses_idCourses`),
  KEY `fk_Students_has_Courses_Courses1_idx` (`Courses_idCourses`),
  KEY `fk_Students_has_Courses_Students1_idx` (`Students_idStudents`),
  CONSTRAINT `fk_Students_has_Courses_Courses1` FOREIGN KEY (`Courses_idCourses`) REFERENCES `courses` (`idCourses`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Students_has_Courses_Students1` FOREIGN KEY (`Students_idStudents`) REFERENCES `students` (`idStudents`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `studentscourses`
--

LOCK TABLES `studentscourses` WRITE;
/*!40000 ALTER TABLE `studentscourses` DISABLE KEYS */;
/*!40000 ALTER TABLE `studentscourses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `titles`
--

DROP TABLE IF EXISTS `titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `titles` (
  `idTitles` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idTitles`),
  UNIQUE KEY `idTitles_UNIQUE` (`idTitles`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `titles`
--

LOCK TABLES `titles` WRITE;
/*!40000 ALTER TABLE `titles` DISABLE KEYS */;
/*!40000 ALTER TABLE `titles` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-10-05 22:44:46
