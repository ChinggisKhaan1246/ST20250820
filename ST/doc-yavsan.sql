-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jan 10, 2024 at 01:24 PM
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
-- Table structure for table `doc-yavsan`
--

CREATE TABLE `docyavsan` (
  `id` int(11) NOT NULL,
  `projectID` int(11) NOT NULL,
  `Bnumber` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `haashaa` varchar(150) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Utga` varchar(250) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ognooDoc` date NOT NULL,
  `ognoo` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `doc-yavsan`
--

INSERT INTO `docyavsan` (`id`, `projectID`, `Bnumber`, `haashaa`, `Utga`, `ognooDoc`, `ognoo`) VALUES
(1, 26, '№2023/75', 'Сангийн Яаманд', 'Манай компани нь Цагааннуур сумын Эрүүл Мэндийн төвийн барилгын ажлыг дуусган 2023 оны 12-р сарын 11-ний өдөр хүлээлгэн өгсөн байх тул үлдэгдэл санхүүжилтыг олгоно уу. ', '2024-01-10', '2024-01-10');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `doc-yavsan`
--
ALTER TABLE `docyavsan`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `doc-yavsan`
--
ALTER TABLE `docyavsan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
