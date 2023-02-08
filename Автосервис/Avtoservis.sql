-- -----------------------------------------------------
-- Database avtoservis
-- -----------------------------------------------------

CREATE DATABASE `avtoservis`;

USE `avtoservis` ;

-- -----------------------------------------------------
-- Table `avtoservis`.`avtorizacia`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `avtoservis`.`avtorizacia` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `login` VARCHAR(20) NOT NULL,
  `parol` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`id`));

-- -----------------------------------------------------
-- Dumping data for table `avtorizacia`
-- -----------------------------------------------------

INSERT INTO `avtorizacia` VALUES (1,'111','111'),(2,'222','222'),(3,'555','555');

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
-- Dumping data for table `clienti`
-- -----------------------------------------------------

INSERT INTO `clienti` VALUES (1,'Павлов Олег Эдуардович','+76545321321','А241МТ25','Hyundai Accent'),(2,'Осипов Антон Игоревич','+76512311322','У628КК72','Chery Very'),(3,'Белова Дина Дамировна','+73259845632','Х778УК36','Fiat Panda 4x4'),(4,'Рябов Артур Вениаминович','+75128654613','Т548МЕ50','Infiniti EX'),(5,'Белкина Виктория Никитична','+72599841258','Х216СН88','Daewoo Nexia');

-- -----------------------------------------------------
-- Table structure for table `mastera`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `avtoservis`.`Mastera` (
  `id_mastera` INT NOT NULL AUTO_INCREMENT,
  `fio_mastera` VARCHAR(50) NOT NULL,
  `telefon_mastera` VARCHAR(12) NOT NULL,
  PRIMARY KEY (`id_mastera`));

-- -----------------------------------------------------
-- Dumping data for table `mastera`
-- -----------------------------------------------------

INSERT INTO `mastera` VALUES (1,'Иванов Николай Андреевич','+79486603215'),(2,'Печкин Илья Николаевич','+75566845665'),(3,'Орлов Виталий Борисович','+75478922665'),(4,'Белкин Максим Евгеньевич','+71236548556');

-- -----------------------------------------------------
-- Table structure for table `uslugi`
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
-- Dumping data for table `uslugi`
-- -----------------------------------------------------

INSERT INTO `uslugi` VALUES (1,3,4,1,'2023-02-08','2023-02-09'),(2,1,3,3,'2023-02-08','2023-02-09'),(3,2,1,4,'2023-02-08','2023-02-09'),(4,3,2,3,'2023-02-09','2023-02-09'),(5,4,3,4,'2023-02-09','2023-02-09'),(6,2,1,5,'2023-02-09','2023-02-09'),(7,4,1,7,'2023-02-09','2023-02-09'),(9,4,2,9,'2023-02-09','2023-02-09'),(10,3,3,3,'2023-02-09',NULL);

-- -----------------------------------------------------
-- Table structure for table `vid_rabot`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `avtoservis`.`Vid_rabot` (
  `Id_rabot` INT NOT NULL AUTO_INCREMENT,
  `Naimenovanie_rabot` VARCHAR(70) NOT NULL,
  `Stoimost` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`Id_rabot`));

-- -----------------------------------------------------
-- Dumping data for table `vid_rabot`
-- -----------------------------------------------------

INSERT INTO `vid_rabot` VALUES (1,'Замена воздушного фильтра','300'),(2,'Замена салонного фильтра','300'),(3,'Замена салонного  фильтра со снятием педального узла','1200'),(4,'Промывка дроссельной заслонки  ( с учетом химии)','1500'),(5,'Замена охлаждающей жидкости','1200'),(6,'Регулировка ручника  (1 сторона)','400'),(7,'Замена масла ДВС','500'),(8,'Замена свечей зажигания без снятие коллектора','600'),(9,'Замена свечей зажигания со снятием впускного коллектора','2000');
