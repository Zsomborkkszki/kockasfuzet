-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Jan 29. 08:13
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `kockasfuzet`
--
CREATE DATABASE IF NOT EXISTS `kockasfuzet` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `kockasfuzet`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamla`
--

CREATE TABLE `szamla` (
  `Id` int(11) NOT NULL,
  `SzolgaltatasAzon` int(11) NOT NULL,
  `SzolgaltatoRovid` varchar(32) NOT NULL,
  `Tol` date NOT NULL,
  `Ig` date NOT NULL,
  `Osszeg` int(11) NOT NULL,
  `Hatarido` date NOT NULL,
  `Befizetve` date DEFAULT NULL,
  `Megjegyzes` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `szamla`
--

INSERT INTO `szamla` (`Id`, `SzolgaltatasAzon`, `SzolgaltatoRovid`, `Tol`, `Ig`, `Osszeg`, `Hatarido`, `Befizetve`, `Megjegyzes`) VALUES
(1, 1, 'MVM Next', '2025-11-01', '2025-11-30', 9525, '2025-12-14', '2025-12-05', 'postán'),
(2, 2, 'MVM Next', '2025-11-01', '2025-11-30', 17321, '2025-12-14', '2025-12-05', 'postán'),
(3, 3, 'Telecom', '2025-11-06', '2025-12-06', 6800, '2025-12-20', '2025-12-13', 'online'),
(4, 4, 'Telecom', '2025-11-06', '2025-12-06', 5000, '2025-12-20', '2025-12-13', 'online'),
(5, 5, 'MiVíz', '2025-11-01', '2025-11-15', 7000, '2025-11-30', '2025-11-29', 'postán'),
(6, 5, 'ÉRV', '2025-11-16', '2025-11-30', 4500, '2025-12-10', '2025-12-10', 'email');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szolgaltatas`
--

CREATE TABLE `szolgaltatas` (
  `Id` int(11) NOT NULL,
  `Nev` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `szolgaltatas`
--

INSERT INTO `szolgaltatas` (`Id`, `Nev`) VALUES
(1, 'áram'),
(2, 'földgáz'),
(3, 'vezetékes telefon'),
(4, 'mobil'),
(5, 'víz');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szolgaltato`
--

CREATE TABLE `szolgaltato` (
  `RovidNev` varchar(32) NOT NULL,
  `Nev` varchar(256) NOT NULL,
  `Ugyfelszolgalat` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `szolgaltato`
--

INSERT INTO `szolgaltato` (`RovidNev`, `Nev`, `Ugyfelszolgalat`) VALUES
('ÉRV', 'ÉRV. Északmagyarországi Regionális Vízművek Zrt.', '3530 Miskolc, Corvin u. 2.'),
('MiVíz', 'MIVÍZ Kft.', '3530 Miskolc, Corvin u. 2.'),
('MVM Next', 'MVM Next Energiakereskedelmi Zrt.', '3530 Miskolc, Arany János utca 6-8.'),
('Telecom', 'Magyar Telekom Nyrt.', '3525 Miskolc, Szentpáli utca 2 - 6.');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `szamla`
--
ALTER TABLE `szamla`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `SzolgaltatasAzon` (`SzolgaltatasAzon`),
  ADD KEY `SzolgaltatoRovid` (`SzolgaltatoRovid`);

--
-- A tábla indexei `szolgaltatas`
--
ALTER TABLE `szolgaltatas`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `szolgaltato`
--
ALTER TABLE `szolgaltato`
  ADD PRIMARY KEY (`RovidNev`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `szamla`
--
ALTER TABLE `szamla`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT a táblához `szolgaltatas`
--
ALTER TABLE `szolgaltatas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `szamla`
--
ALTER TABLE `szamla`
  ADD CONSTRAINT `szamla_ibfk_1` FOREIGN KEY (`SzolgaltatasAzon`) REFERENCES `szolgaltatas` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `szamla_ibfk_2` FOREIGN KEY (`SzolgaltatoRovid`) REFERENCES `szolgaltato` (`RovidNev`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
