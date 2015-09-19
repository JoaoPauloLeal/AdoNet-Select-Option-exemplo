CREATE DATABASE  IF NOT EXISTS `autoresdb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `autoresdb`;

--
-- Table structure for table `cidades`
--

DROP TABLE IF EXISTS `cidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cidades` (
  `idCidade` int(11) NOT NULL,
  `nomeCidade` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCidade`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cidades`
--

LOCK TABLES `cidades` WRITE;
INSERT INTO `cidades` VALUES (1,'Torres'),(2,'Capão'),(3,'Arroio do Sal');




DROP TABLE IF EXISTS `autores`;

CREATE TABLE `autores` (
  `idAutor` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `endereco` varchar(100) DEFAULT NULL,
  `dataNasc` date DEFAULT NULL,
  `idCidade` int(11) NOT NULL,
  PRIMARY KEY (`idAutor`),
  KEY `fk_autores_Cidades_idx` (`idCidade`),
  CONSTRAINT `fk_autores_Cidades` FOREIGN KEY (`idCidade`) REFERENCES `cidades` (`idCidade`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;