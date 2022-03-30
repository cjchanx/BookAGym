-- phpMyAdmin SQL Dump
-- version 4.9.5deb2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 30, 2022 at 03:55 AM
-- Server version: 8.0.27-0ubuntu0.20.04.1
-- PHP Version: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `GymDB`
--
CREATE DATABASE IF NOT EXISTS `GymDB` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `GymDB`;

-- --------------------------------------------------------

--
-- Table structure for table `Announcement`
--

CREATE TABLE `Announcement` (
  `Id` int NOT NULL,
  `Header` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Comment` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Announcement`
--

INSERT INTO `Announcement` (`Id`, `Header`, `Comment`) VALUES
(13, 'New announcement', 'test'),
(14, 'New announcement', 'test'),
(15, 'New announcement', 'test'),
(16, 'New announcement', 'test'),
(17, 'New announcement', 'test');

-- --------------------------------------------------------

--
-- Table structure for table `Bookings`
--

CREATE TABLE `Bookings` (
  `Id` int NOT NULL,
  `username` varchar(25) NOT NULL,
  `booktime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Bookings`
--

INSERT INTO `Bookings` (`Id`, `username`, `booktime`) VALUES
(6, 'Neeraj', '2022-03-28 03:00:00'),
(8, 'Neeraj', '2022-03-28 01:00:00'),
(12, 'Neeraj', '2022-03-28 23:00:00'),
(21, 'Neeraj', '2022-03-29 19:00:00'),
(24, 'Sean', '2022-03-29 20:00:00'),
(25, 'Balance', '2022-03-29 09:00:00'),
(26, 'Balance', '2022-03-29 00:00:00'),
(27, 'Balance', '2022-03-29 00:00:00'),
(30, 'Neeraj', '0001-01-01 00:00:00'),
(32, 'Neeraj', '0001-01-01 17:00:00'),
(33, 'Neeraj', '2022-04-01 17:00:00'),
(35, 'Neeraj', '0001-01-01 00:00:00'),
(37, 'Neeraj', '0001-01-01 00:00:00'),
(38, 'Neeraj', '0001-01-01 00:00:00'),
(39, 'Neeraj', '0001-01-01 00:00:00'),
(40, 'Neeraj', '0001-01-01 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `Configuration`
--

CREATE TABLE `Configuration` (
  `MAX_BOOKINGS_PER_HOUR` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Configuration`
--

INSERT INTO `Configuration` (`MAX_BOOKINGS_PER_HOUR`) VALUES
(10);

-- --------------------------------------------------------

--
-- Table structure for table `Users`
--

CREATE TABLE `Users` (
  `Id` int NOT NULL,
  `UserName` varchar(25) NOT NULL,
  `Password` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Users`
--

INSERT INTO `Users` (`Id`, `UserName`, `Password`) VALUES
(1, 'Admin', 'Admin@123'),
(2, 'Neeraj', 'newpassword'),
(3, 'Sean', 'password'),
(4, 'Balance', 'Zero');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Announcement`
--
ALTER TABLE `Announcement`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Bookings`
--
ALTER TABLE `Bookings`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Configuration`
--
ALTER TABLE `Configuration`
  ADD PRIMARY KEY (`MAX_BOOKINGS_PER_HOUR`);

--
-- Indexes for table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserName` (`UserName`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Announcement`
--
ALTER TABLE `Announcement`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `Bookings`
--
ALTER TABLE `Bookings`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `Users`
--
ALTER TABLE `Users`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
