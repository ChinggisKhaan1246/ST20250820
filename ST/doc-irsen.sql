-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jan 10, 2024 at 01:22 PM
-- Server version: 5.7.44
-- PHP Version: 8.1.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `rpfyvamz_etusul`
--

-- --------------------------------------------------------

--
-- Table structure for table `doc-irsen`
--

CREATE TABLE `docirsen` (
  `id` int(11) NOT NULL,
  `projectID` int(11) NOT NULL,
  `Bnumber` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `haanaas` varchar(150) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Utga` varchar(250) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ognooDoc` date NOT NULL,
  `ognoo` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `doc-irsen`
--

INSERT INTO `docirsen` (`id`, `projectID`, `Bnumber`, `haanaas`, `Utga`, `ognooDoc`, `ognoo`) VALUES
(1, 26, '№2022/21', 'Сэлэнгэ аймгийн ЗДТГ', 'Санхүүжилтийн хуваарьт өөрчилөлт орохгүй тухай ', '2022-05-15', '2024-01-10');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `doc-irsen`
--
ALTER TABLE `docirsen`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `doc-irsen`
--
ALTER TABLE `docirsen`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
