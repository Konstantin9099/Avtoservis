-- -----------------------------------------------------
-- Database avtoservis
-- -----------------------------------------------------

CREATE DATABASE `avtoservis` DEFAULT CHARACTER SET utf8 ;
USE `avtoservis` ;

-- -----------------------------------------------------
-- Table `avtoservis`.`Clienti`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `avtoservis`.`Clienti` (
  `id_clienti` INT NOT NULL AUTO_INCREMENT,
  `FIO` VARCHAR(20) NOT NULL,
  `Telefon_klienta` VARCHAR(12) NOT NULL,
  `Nomer_avto` VARCHAR(9) NOT NULL,
  `Marka_avto` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id_clienti`));


-- -----------------------------------------------------
-- Table `avtoservis`.`Vid_rabot`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `avtoservis`.`Vid_rabot` (
  `Id_rabot` INT NOT NULL AUTO_INCREMENT,
  `Naimenovanie_rabot` VARCHAR(70) NOT NULL,
  `Stoimost` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`Id_rabot`));


-- -----------------------------------------------------
-- Table `avtoservis`.`Mastera`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `avtoservis`.`Mastera` (
  `id_mastera` INT NOT NULL AUTO_INCREMENT,
  `fio_mastera` VARCHAR(50) NOT NULL,
  `telefon_mastera` VARCHAR(12) NOT NULL,
  PRIMARY KEY (`id_mastera`));


-- -----------------------------------------------------
-- Table `avtoservis`.`uslugi`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `avtoservis`.`uslugi` (
  `id_uslugi` INT NOT NULL AUTO_INCREMENT,
  `clien_id` INT NOT NULL,
  `mastera_id` INT NOT NULL,
  `rabot_id` INT NOT NULL,
  `data_1` DATE NULL,
  `data_2` DATE NULL,
  PRIMARY KEY (`id_uslugi`),
  CONSTRAINT `fk_uslugi_Clienti`
    FOREIGN KEY (`clien_id`)
    REFERENCES `avtoservis`.`Clienti` (`id_clienti`),
  CONSTRAINT `fk_uslugi_Mastera`
    FOREIGN KEY (`mastera_id`)
    REFERENCES `avtoservis`.`Mastera` (`id_mastera`),
  CONSTRAINT `fk_uslugi_Vid_rabot`
    FOREIGN KEY (`rabot_id`)
    REFERENCES `avtoservis`.`Vid_rabot` (`Id_rabot`));


-- -----------------------------------------------------
-- Table `avtoservis`.`avtorizacia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `avtoservis`.`avtorizacia` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `login` VARCHAR(20) NOT NULL,
  `parol` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`id`));

