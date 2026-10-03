-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 22/06/2026 às 00:22
-- Versão do servidor: 8.4.7
-- Versão do PHP: 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `petshop`
--
CREATE DATABASE IF NOT EXISTS `petshop`;
USE `petshop`;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tutor`
--

DROP TABLE IF EXISTS `tutor`;
CREATE TABLE IF NOT EXISTS `tutor` (
  `Nome_tutor` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CPF_tutor` char(11) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Celular_tutor` char(11) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Email_tutor` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`CPF_tutor`),
  UNIQUE KEY `Celular_tutor` (`Celular_tutor`),
  UNIQUE KEY `Email_tutor` (`Email_tutor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `pet`
--

DROP TABLE IF EXISTS `pet`;
CREATE TABLE IF NOT EXISTS `pet` (
  `Codigo_pet` int NOT NULL AUTO_INCREMENT,
  `CPF_tutor` char(11) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Nasc_pet` date DEFAULT NULL,
  `Genero_pet` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Nome_pet` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Raca_pet` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Especie_pet` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Foto_pet` blob,
  PRIMARY KEY (`Codigo_pet`),
  KEY `fk_pet_tutor` (`CPF_tutor`),
  -- CHAVE ESTRANGEIRA COM O TUTOR
  CONSTRAINT `fk_pet_tutor` FOREIGN KEY (`CPF_tutor`) REFERENCES `tutor` (`CPF_tutor`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `servicos`
--

DROP TABLE IF EXISTS `servicos`;
CREATE TABLE IF NOT EXISTS `servicos` (
  `codigo_pet` int NOT NULL,
  `data_servico` datetime NOT NULL,
  `valor_servico` decimal(10,2) NOT NULL,
  `id_servico` int NOT NULL AUTO_INCREMENT,
  `tipo_servico` varchar(100) NOT NULL,
  PRIMARY KEY (`id_servico`),
  KEY `codigo_pet` (`codigo_pet`),
  -- CHAVE ESTRANGEIRA COM O PET
  CONSTRAINT `fk_servicos_pets` FOREIGN KEY (`codigo_pet`) REFERENCES `pet` (`Codigo_pet`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


-- --------------------------------------------------------
-- Estrutura para tabela `consulta`
-- --------------------------------------------------------
DROP TABLE IF EXISTS `consulta`;
CREATE TABLE IF NOT EXISTS `consulta` (
  `id_consulta` int NOT NULL AUTO_INCREMENT,
  `codigo_pet` int NOT NULL,
  `data_consulta` datetime NOT NULL,
  `prescricao_consulta` text NOT NULL,
  PRIMARY KEY (`id_consulta`),
  KEY `codigo_pet` (`codigo_pet`),
  CONSTRAINT `fk_consultas_pets` FOREIGN KEY (`codigo_pet`) REFERENCES `pet` (`Codigo_pet`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;