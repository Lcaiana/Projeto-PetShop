-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 16/06/2026 às 22:09
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

CREATE DATABASE IF NOT EXISTS 'petshop';
use 'petshop';

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
  KEY `fk_pet_tutor` (`CPF_tutor`)
) ;

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
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
