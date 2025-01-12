/*
SQLyog Community v13.1.9 (64 bit)
MySQL - 10.4.21-MariaDB : Database - db_toko_alat_musik
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_toko_alat_musik` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `db_toko_alat_musik`;

/*Table structure for table `alatmusik` */

DROP TABLE IF EXISTS `alatmusik`;

CREATE TABLE `alatmusik` (
  `al_id` varchar(5) NOT NULL,
  `al_name` varchar(500) NOT NULL,
  `al_description` varchar(1024) NOT NULL,
  `al_price` double NOT NULL,
  `al_stock` int(10) NOT NULL,
  `al_status` int(10) NOT NULL,
  `al_br_id` varchar(5) NOT NULL,
  `al_in_id` varchar(5) NOT NULL,
  PRIMARY KEY (`al_id`),
  KEY `FKBRAND_ALATMUSIK` (`al_br_id`),
  KEY `FKINSTRUMENT_ALATMUSIK` (`al_in_id`),
  CONSTRAINT `FKBRAND_ALATMUSIK` FOREIGN KEY (`al_br_id`) REFERENCES `brand` (`br_id`),
  CONSTRAINT `FKINSTRUMENT_ALATMUSIK` FOREIGN KEY (`al_in_id`) REFERENCES `instrument` (`in_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `alatmusik` */

insert  into `alatmusik`(`al_id`,`al_name`,`al_description`,`al_price`,`al_stock`,`al_status`,`al_br_id`,`al_in_id`) values 
('AL001','UK550C Classic Series Flamed Maple Concert Ukulele','no description',2553435,8,1,'BR001','IN010'),
('AL002','UK770C Classic Series Spalted Maple Concert Ukulele','no description',2410785,10,1,'BR001','IN010'),
('AL003','PMP550M 500-Watt 5-Channel Powered Mixer','no description',4550000,27,1,'BR004','IN008'),
('AL004','MS40 Digital 40-Watt Stereo Near Field Monitor speaker','no description',3400000,8,1,'BR004','IN008'),
('AL005','SL 75C Cardioid Dynamic Microphone','no description',292000,57,1,'BR004','IN007'),
('AL006','XM8500 Ultravoice Dynamic Cardioid Vocal Microphone','no description',300000,62,1,'BR004','IN007'),
('AL007','SL 84C Dynamic Cardioid Microphone','no description',180000,39,1,'BR004','IN007'),
('AL008','CDPS350BK Black Portable Digital Piano','no description',7845750,9,1,'BR005','IN009'),
('AL009','Privia PX560BE 88-Key Black Portable Digital Piano','no description',18544357,27,1,'BR005','IN009'),
('AL010','Casiotone CTS300 Portable 61-Key Touch Responsive Digital Piano','no description',2139750,12,1,'BR005','IN009'),
('AL011','Celviano GP400BK Satin Black Digital Grand Hybrid','no description',50123175,76,1,'BR005','IN009'),
('AL012','Casiotone CT-S200 61-key Portable Keyboard','no description',1990000,47,1,'BR005','IN006'),
('AL013','Excel DC Semi-Hollow Electric Guitar w/Stairstep Tailpiece','no description',260000,6,1,'BR002','IN005'),
('AL014','AC422CE Accoustic Electric Guitar','no description',19341627,90,1,'BR006','IN005'),
('AL015','AC122-2CE Accoustic Electric Guitar','no description',9663697,34,1,'BR006','IN005'),
('AL016','11027 Nanoweb 80/20 Bronze Acoustic Guitar Strings 11-52','no description',210000,99,1,'BR007','IN001'),
('AL017','Earthwood Light Phosphor Bronze Acoustic Guitar Strings 11-52','no description',83000,94,1,'BR003','IN001'),
('AL018','CC60S Accoustic Guitar','no description',3415597,75,1,'BR008','IN005'),
('AL019','Player Jazz Bass Fretless Bass Guitar','no description',13200000,91,1,'BR008','IN002'),
('AL020','iRig Mic HD-A Handheld Digital Microphone','no description',20900,33,1,'BR014','IN007'),
('AL021','Irig Mic HD 2 Handheld Microphone','no description',20900,93,1,'BR014','IN007'),
('AL022','KA-SMHC Solid Mahogany Concert Ukulele','no description',3124035,65,1,'BR009','IN010'),
('AL023','KA-EBY-T-2006 Striped Ebony Tenor Ukulele','no description',2696085,45,1,'BR009','IN010'),
('AL024','K-300 48 Professional Upright Piano','no description',166098375,31,1,'BR010','IN009'),
('AL025','GX-2 BLAK 5\'11 Grand Piano','no description',1028520875,23,1,'BR010','IN009'),
('AL026','K15 44\" Continental Console Piano','no description',75850875,22,1,'BR010','IN009'),
('AL027','ST-1 46\" Institutional Upright Piano','no description',111195675,40,1,'BR010','IN009'),
('AL028','Electric Violin SDDS 1802','no description',3250000,34,1,'BR011','IN011'),
('AL029','4/4 Blue White Porcelain Colored Violin','no description',2450000,53,1,'BR011','IN011'),
('AL030','PJA1003','no description',1600000,63,1,'BR011','IN011'),
('AL031','Electric Guitar Stand ONE','no description',170000,56,1,'BR012','IN001'),
('AL032','KMC20 Microphone Cable 20ft Black','no description',185000,93,1,'BR012','IN001'),
('AL033','Clip On Tuner ONE','no description',115000,96,1,'BR012','IN001'),
('AL034','Percussion CAJ2GO-2 Backpacker Cajon Natural','no description',1550000,3,1,'BR013','IN003'),
('AL035','Electric Drum TD-17KVX','no description',18380000,26,1,'BR015','IN004'),
('AL036','VAD306 V-Drums Acoustic Design Electronic Drum Set','no description',37003707,20,1,'BR015','IN004'),
('AL037','CL52KRSP-GGP Superstar Classic Exotix 5-Piece Drum Shell Kit','no description',12200000,25,1,'BR016','IN004'),
('AL038','GS Mini Acoustic Guitar','no description',9250000,66,1,'BR017','IN005'),
('AL039','210ce Plus Dreadnought Acoustic Guitar','no description',20250000,53,1,'BR017','IN005'),
('AL040','GS Mini-e RW Acoustic Guitar','no description',11550000,70,1,'BR017','IN005'),
('AL041','Telstar Drum Set','no description',30000000,92,1,'BR018','IN004'),
('AL042','PSR-E273 61-key Portable Arranger','no description',2000000,50,1,'BR019','IN006'),
('AL043','Drum Electronic DTX-6K2X','no description',13050000,75,1,'BR019','IN004'),
('AL044','PSR-E373 61-key Portable Keyboard','no description',2950000,25,1,'BR019','IN006'),
('AL045','PAC112V Electric Guitar','no description',4411855,99,1,'BR019','IN005'),
('AL046','Storia I Small-Body Acoustic Guitar','no description',6404985,21,1,'BR019','IN005'),
('AL047','Drum Electronic DTX-6KX','no description',9500000,8,1,'BR019','IN004'),
('AL048','Rydeen Drum Set','no description',10300000,76,1,'BR019','IN004'),
('AL049','Storia III Small-Body Acoustic-Electric Guitar','no description',6404985,58,1,'BR019','IN005'),
('AL050','PAC311H Electric Guitar','no description',5977402,62,1,'BR019','IN005');

/*Table structure for table `brand` */

DROP TABLE IF EXISTS `brand`;

CREATE TABLE `brand` (
  `br_id` varchar(5) NOT NULL,
  `br_name` varchar(100) NOT NULL,
  PRIMARY KEY (`br_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `brand` */

insert  into `brand`(`br_id`,`br_name`) values 
('B5001','Amahi'),
('B5002','D Angelico'),
('B5003','Ernie Ball'),
('B5004','Behringer'),
('B5005','Casio'),
('B5006','Eastman'),
('B5007','Elixir'),
('B5008','Fender'),
('B5009','Kala'),
('BR010','Kawai'),
('BR011','Kinglos'),
('BR012','Koda Essential'),
('BR013','MEINL'),
('BR014','IK Multimedia'),
('BR015','Roland'),
('BR016','TAMA'),
('BR017','Taylor'),
('BR018','VOX'),
('BR019','Yamaha');

/*Table structure for table `color` */

DROP TABLE IF EXISTS `color`;

CREATE TABLE `color` (
  `co_id` varchar(5) NOT NULL,
  `co_name` varchar(50) NOT NULL,
  `co_hex` varchar(6) NOT NULL,
  PRIMARY KEY (`co_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `color` */

insert  into `color`(`co_id`,`co_name`,`co_hex`) values 
('CO001','Rosewood','65000B'),
('CO002','Mahogany','C04000'),
('CO003','Maple','780109'),
('CO004','Ebony','3C2005'),
('CO005','Sandrift','AE9072'),
('CO006','Cocobolo','914941'),
('CO007','Skyblue','88D0CE'),
('CO008','Dimgray','4D5564'),
('CO009','Sienna','994F40'),
('CO010','Cherry','CF0234'),
('CO011','Sandybrown','FAC267'),
('CO012','Black','000000'),
('CO013','Dark Slate Gray','3A3A3C'),
('CO014','White','FFFFFF'),
('CO015','Red','FF0000'),
('CO016','Teal','035A69'),
('CO017','Maroon','552125'),
('CO018','Cafe Noir','542F24'),
('CO019','Wheat','ECD6B4'),
('CO020','Metallic Silver','BCC6CC');

/*Table structure for table `discount` */

DROP TABLE IF EXISTS `discount`;

CREATE TABLE `discount` (
  `di_id` varchar(5) NOT NULL,
  `di_nama` varchar(255) NOT NULL,
  `di_value` double NOT NULL,
  `di_type` int(10) NOT NULL COMMENT '0 = Persen\n1 = Rupiah',
  PRIMARY KEY (`di_id`),
  CONSTRAINT `chk_discount` CHECK (`di_type` = 0 or `di_type` = 1)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `discount` */

insert  into `discount`(`di_id`,`di_nama`,`di_value`,`di_type`) values 
('DI001','Oktoberbahagia',25000,1),
('DI002','Cuci Gudang',45,0),
('DI003','Promo 11.11',11,0),
('DI004','Tahun Baru',22000,1);

/*Table structure for table `dtrans_beli` */

DROP TABLE IF EXISTS `dtrans_beli`;

CREATE TABLE `dtrans_beli` (
  `db_id` varchar(5) NOT NULL,
  `db_va_id` varchar(5) NOT NULL,
  `db_amount` int(10) NOT NULL,
  `db_hb_id` varchar(5) NOT NULL,
  `db_subtotal` double NOT NULL,
  PRIMARY KEY (`db_id`),
  KEY `FKHTRANS_DTRANSBELI` (`db_hb_id`),
  KEY `FKVARIANT_DTRANSBELI` (`db_va_id`),
  CONSTRAINT `FKHTRANS_DTRANSBELI` FOREIGN KEY (`db_hb_id`) REFERENCES `htrans_beli` (`hb_id`),
  CONSTRAINT `FKVARIANT_DTRANSBELI` FOREIGN KEY (`db_va_id`) REFERENCES `variant` (`va_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `dtrans_beli` */

insert  into `dtrans_beli`(`db_id`,`db_va_id`,`db_amount`,`db_hb_id`,`db_subtotal`) values 
('DB001','VA006',1,'HB001',300000),
('DB002','VA024',1,'HB002',20900),
('DB003','VA008',2,'HB003',15691500),
('DB004','VA006',1,'HB003',300000),
('DB005','VA056',3,'HB004',28500000),
('DB006','VA007',1,'HB004',180000),
('DB007','VA038',1,'HB005',10300000),
('DB008','VA016',1,'HB005',260000),
('DB009','VA027',2,'HB005',5392170),
('DB010','VA039',1,'HB006',115000),
('DB011','VA055',3,'HB007',19214955);

/*Table structure for table `dtrans_service` */

DROP TABLE IF EXISTS `dtrans_service`;

CREATE TABLE `dtrans_service` (
  `ds_id` varchar(5) NOT NULL,
  `ds_se_id` varchar(5) NOT NULL,
  `ds_hs_id` varchar(5) NOT NULL,
  `ds_subtotal` double NOT NULL,
  PRIMARY KEY (`ds_id`),
  KEY `FKSERVICE_DTRANSSERVICE` (`ds_se_id`),
  KEY `FKHTRANS_DTTRANSSERVICE` (`ds_hs_id`),
  CONSTRAINT `FKHTRANS_DTTRANSSERVICE` FOREIGN KEY (`ds_hs_id`) REFERENCES `htrans_service` (`hs_id`),
  CONSTRAINT `FKSERVICE_DTRANSSERVICE` FOREIGN KEY (`ds_se_id`) REFERENCES `service` (`se_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `dtrans_service` */

insert  into `dtrans_service`(`ds_id`,`ds_se_id`,`ds_hs_id`,`ds_subtotal`) values 
('DS001','SE005','HS001',100000),
('DS002','SE001','HS002',10000),
('DS003','SE002','HS002',150000),
('DS004','SE004','HS003',35000),
('DS005','SE002','HS004',150000),
('DS006','SE009','HS005',110000),
('DS007','SE004','HS005',35000);

/*Table structure for table `htrans_beli` */

DROP TABLE IF EXISTS `htrans_beli`;

CREATE TABLE `htrans_beli` (
  `hb_id` varchar(5) NOT NULL,
  `hb_date` date NOT NULL,
  `hb_invoice_number` varchar(10) NOT NULL,
  `hb_total` double NOT NULL,
  `hb_customerid` varchar(5) NOT NULL,
  `hb_status` int(10) NOT NULL,
  `hb_employeeid` varchar(5) NOT NULL,
  `hb_di_id` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`hb_id`),
  KEY `FKCUSTOMER_HTRANSBELI` (`hb_customerid`),
  KEY `FKDISCOUNT_HTRANSBELI` (`hb_di_id`),
  KEY `FKEMPLOYEE_HTRANSBELI` (`hb_employeeid`),
  CONSTRAINT `FKCUSTOMER_HTRANSBELI` FOREIGN KEY (`hb_customerid`) REFERENCES `users` (`us_id`),
  CONSTRAINT `FKDISCOUNT_HTRANSBELI` FOREIGN KEY (`hb_di_id`) REFERENCES `discount` (`di_id`),
  CONSTRAINT `FKEMPLOYEE_HTRANSBELI` FOREIGN KEY (`hb_employeeid`) REFERENCES `users` (`us_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `htrans_beli` */

insert  into `htrans_beli`(`hb_id`,`hb_date`,`hb_invoice_number`,`hb_total`,`hb_customerid`,`hb_status`,`hb_employeeid`,`hb_di_id`) values 
('HB001','2022-10-26','B221026001',275000,'US005',1,'US001','DI001'),
('HB002','2022-10-26','B221026002',20900,'US007',1,'US002',NULL),
('HB003','2022-10-28','B221028001',15991500,'US004',1,'US002',NULL),
('HB004','2022-11-02','B221102001',28680000,'US008',1,'US001',NULL),
('HB005','2022-11-11','B221111001',14197431,'US004',1,'US003','DI003'),
('HB006','2022-11-11','B221111002',102350,'US009',1,'US003','DI003'),
('HB007','2022-12-15','B221215001',10568225,'US010',1,'US001','DI002');

/*Table structure for table `htrans_service` */

DROP TABLE IF EXISTS `htrans_service`;

CREATE TABLE `htrans_service` (
  `hs_id` varchar(5) NOT NULL,
  `hs_date` date NOT NULL,
  `hs_invoice_number` varchar(255) NOT NULL,
  `hs_total` double NOT NULL,
  `hs_customerid` varchar(5) NOT NULL,
  `hs_status` int(10) NOT NULL,
  `hs_employeeid` varchar(5) NOT NULL,
  `hs_di_id` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`hs_id`),
  KEY `FKCUSTOMER_HTRANSSERVICE` (`hs_customerid`),
  KEY `FKDISCOUNT_HTRANSSERVICE` (`hs_di_id`),
  KEY `FKEMPLOYEE_HTRANSSERVICE` (`hs_employeeid`),
  CONSTRAINT `FKCUSTOMER_HTRANSSERVICE` FOREIGN KEY (`hs_customerid`) REFERENCES `users` (`us_id`),
  CONSTRAINT `FKDISCOUNT_HTRANSSERVICE` FOREIGN KEY (`hs_di_id`) REFERENCES `discount` (`di_id`),
  CONSTRAINT `FKEMPLOYEE_HTRANSSERVICE` FOREIGN KEY (`hs_employeeid`) REFERENCES `users` (`us_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `htrans_service` */

insert  into `htrans_service`(`hs_id`,`hs_date`,`hs_invoice_number`,`hs_total`,`hs_customerid`,`hs_status`,`hs_employeeid`,`hs_di_id`) values 
('HS001','2022-11-07','S221107001',100000,'US005',1,'US003',NULL),
('HS002','2022-12-11','S221211001',160000,'US008',1,'US003',NULL),
('HS003','2022-12-23','S221223001',35000,'US006',1,'US002',NULL),
('HS004','2023-01-02','S220102001',128000,'US009',1,'US002','DI004'),
('HS005','2023-01-04','S220104001',123000,'US004',1,'US001','DI004');

/*Table structure for table `instrument` */

DROP TABLE IF EXISTS `instrument`;

CREATE TABLE `instrument` (
  `in_id` varchar(5) NOT NULL,
  `in_name` varchar(100) NOT NULL,
  PRIMARY KEY (`in_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `instrument` */

insert  into `instrument`(`in_id`,`in_name`) values 
('IN001','Accessory'),
('IN002','Bass'),
('IN003','Cajoon'),
('IN004','Drum'),
('IN005','Guitar'),
('IN006','Keyboard'),
('IN007','Microphone'),
('IN008','Mixer'),
('IN009','Piano'),
('IN010','Ukulele'),
('IN011','Violin');

/*Table structure for table `review` */

DROP TABLE IF EXISTS `review`;

CREATE TABLE `review` (
  `re_id` varchar(5) NOT NULL,
  `re_description` varchar(500) DEFAULT NULL,
  `re_rating` int(10) NOT NULL,
  `re_al_id` varchar(5) NOT NULL,
  `re_us_id` varchar(5) NOT NULL,
  PRIMARY KEY (`re_id`),
  KEY `FKALATMUSIK_REVIEW` (`re_al_id`),
  KEY `FKCUSTOMER_REVIEW` (`re_us_id`),
  CONSTRAINT `FKALATMUSIK_REVIEW` FOREIGN KEY (`re_al_id`) REFERENCES `alatmusik` (`al_id`),
  CONSTRAINT `FKCUSTOMER_REVIEW` FOREIGN KEY (`re_us_id`) REFERENCES `users` (`us_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `review` */

insert  into `review`(`re_id`,`re_description`,`re_rating`,`re_al_id`,`re_us_id`) values 
('RE001','sudah bagus',5,'AL032','US004'),
('RE002','barangnya bagus banget',5,'AL006','US005'),
('RE003','kurang bagus bahannya',3,'AL033','US009'),
('RE004','lecet',1,'AL047','US008'),
('RE005','ok',2,'AL046','US010'),
('RE006','bagus banget',5,'AL020','US007');

/*Table structure for table `service` */

DROP TABLE IF EXISTS `service`;

CREATE TABLE `service` (
  `se_id` varchar(5) NOT NULL,
  `se_name` varchar(255) NOT NULL,
  `se_price` double NOT NULL,
  `se_sc_id` varchar(5) NOT NULL,
  `se_in_id` varchar(5) NOT NULL,
  PRIMARY KEY (`se_id`),
  KEY `FKINSTRUMENT_SERVICE` (`se_in_id`),
  KEY `FKCATEGORY_SERVICE` (`se_sc_id`),
  CONSTRAINT `FKCATEGORY_SERVICE` FOREIGN KEY (`se_sc_id`) REFERENCES `service_category` (`sc_id`),
  CONSTRAINT `FKINSTRUMENT_SERVICE` FOREIGN KEY (`se_in_id`) REFERENCES `instrument` (`in_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `service` */

insert  into `service`(`se_id`,`se_name`,`se_price`,`se_sc_id`,`se_in_id`) values 
('SE001','Tuning Gitar',10000,'SC001','IN005'),
('SE002','Tuning Piano',150000,'SC001','IN009'),
('SE003','Ganti Tuts Keyboard',30000,'SC002','IN006'),
('SE004','Ganti LCD Keyboard',35000,'SC002','IN006'),
('SE005','Ganti Snare Cajoon',100000,'SC002','IN003'),
('SE006','Ganti Tuning Head',80000,'SC002','IN005'),
('SE007','Ganti Tuning Head',80000,'SC002','IN002'),
('SE008','Ganti Senar Gitar',60000,'SC003','IN005'),
('SE009','Ganti Senar Violin',110000,'SC003','IN011'),
('SE010','Reparasi Software Keyboard',500000,'SC004','IN006');

/*Table structure for table `service_category` */

DROP TABLE IF EXISTS `service_category`;

CREATE TABLE `service_category` (
  `sc_id` varchar(5) NOT NULL,
  `sc_name` varchar(255) NOT NULL,
  PRIMARY KEY (`sc_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `service_category` */

insert  into `service_category`(`sc_id`,`sc_name`) values 
('SC001','Tuning'),
('SC002','Ganti Sparepart'),
('SC003','Ganti Senar'),
('SC004','Reparasi Software');

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `us_id` varchar(5) NOT NULL,
  `us_name` varchar(255) NOT NULL,
  `us_username` varchar(100) NOT NULL,
  `us_password` varchar(255) NOT NULL,
  `us_dateofbirth` date NOT NULL,
  `us_status` int(10) NOT NULL,
  `us_priv` int(10) NOT NULL COMMENT '0 = Customer\n1 = Employee',
  PRIMARY KEY (`us_id`),
  CONSTRAINT `chkpriv_user` CHECK (`us_priv` = 0 or `us_priv` = 1)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `users` */

insert  into `users`(`us_id`,`us_name`,`us_username`,`us_password`,`us_dateofbirth`,`us_status`,`us_priv`) values 
('US001','Cherilyn Eugenia','cheryle','cheryle','2002-05-12',1,1),
('US002','Mikhael Chris','mikhaelc09','mikhaelc09','2001-03-09',1,1),
('US003','Widean Nagari','wideann','wideann','2001-04-02',1,1),
('US004','Alexander Kevin','cbengineer','cbengineer','2001-12-11',1,0),
('US005','David Cahyadi','dtrone','dtrone','2001-12-22',1,0),
('US006','Jason Gerald','jasong2000','jasong2000','2000-11-03',1,0),
('US007','Charles Ciputra','chrls','chrls','2001-01-25',1,0),
('US008','Christian Chen','chrstchen','chrstchen','2001-02-24',1,0),
('US009','Jason Jonathan','jje','jje','2002-03-30',1,0),
('US010','Michael Kevin','tahucrispy','tahucrispy','2001-04-25',1,0);

/*Table structure for table `variant` */

DROP TABLE IF EXISTS `variant`;

CREATE TABLE `variant` (
  `va_id` varchar(5) NOT NULL,
  `va_al_id` varchar(5) NOT NULL,
  `va_co_id` varchar(5) NOT NULL,
  PRIMARY KEY (`va_id`),
  KEY `FKCOLOR_VARIANT` (`va_co_id`),
  KEY `FKALATMUSIK_VARIANT` (`va_al_id`),
  CONSTRAINT `FKALATMUSIK_VARIANT` FOREIGN KEY (`va_al_id`) REFERENCES `alatmusik` (`al_id`),
  CONSTRAINT `FKCOLOR_VARIANT` FOREIGN KEY (`va_co_id`) REFERENCES `color` (`co_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `variant` */

insert  into `variant`(`va_id`,`va_al_id`,`va_co_id`) values 
('VA001','AL001','CO011'),
('VA002','AL002','CO013'),
('VA003','AL003','CO012'),
('VA004','AL004','CO008'),
('VA005','AL005','CO020'),
('VA006','AL006','CO009'),
('VA007','AL007','CO020'),
('VA008','AL008','CO018'),
('VA009','AL008','CO001'),
('VA010','AL009','CO006'),
('VA011','AL010','CO010'),
('VA012','AL011','CO017'),
('VA013','AL011','CO004'),
('VA014','AL012','CO013'),
('VA015','AL012','CO008'),
('VA016','AL013','CO016'),
('VA017','AL014','CO019'),
('VA018','AL015','CO016'),
('VA019','AL016','CO004'),
('VA020','AL017','CO016'),
('VA021','AL018','CO009'),
('VA022','AL019','CO017'),
('VA023','AL019','CO010'),
('VA024','AL020','CO019'),
('VA025','AL021','CO020'),
('VA026','AL022','CO017'),
('VA027','AL023','CO017'),
('VA028','AL024','CO017'),
('VA029','AL025','CO012'),
('VA030','AL025','CO004'),
('VA031','AL026','CO020'),
('VA032','AL027','CO010'),
('VA033','AL027','CO001'),
('VA034','AL028','CO009'),
('VA035','AL029','CO009'),
('VA036','AL030','CO005'),
('VA037','AL031','CO020'),
('VA038','AL032','CO003'),
('VA039','AL033','CO019'),
('VA040','AL034','CO011'),
('VA041','AL035','CO004'),
('VA042','AL036','CO008'),
('VA043','AL036','CO010'),
('VA044','AL037','CO003'),
('VA045','AL038','CO016'),
('VA046','AL039','CO014'),
('VA047','AL040','CO020'),
('VA048','AL041','CO017'),
('VA049','AL041','CO016'),
('VA050','AL042','CO020'),
('VA051','AL043','CO019'),
('VA052','AL044','CO013'),
('VA053','AL045','CO011'),
('VA054','AL046','CO011'),
('VA055','AL046','CO017'),
('VA056','AL047','CO019'),
('VA057','AL048','CO017'),
('VA058','AL048','CO017'),
('VA059','AL049','CO001'),
('VA060','AL050','CO009');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
