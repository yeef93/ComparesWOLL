/*
SQLyog Community v13.1.6 (64 bit)
MySQL - 10.4.18-MariaDB : Database - pe
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pe` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `pe`;

/*Table structure for table `tbl_customer` */

DROP TABLE IF EXISTS `tbl_customer`;

CREATE TABLE `tbl_customer` (
  `id` varchar(5) NOT NULL,
  `custname` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_customer` */

insert  into `tbl_customer`(`id`,`custname`) values 
('AS','Asus'),
('XM','Xiaomi');

/*Table structure for table `tbl_ll` */

DROP TABLE IF EXISTS `tbl_ll`;

CREATE TABLE `tbl_ll` (
  `model_No` varchar(20) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `model_detail` varchar(100) NOT NULL,
  `machine` varchar(100) NOT NULL,
  `pwb_Type` varchar(100) NOT NULL,
  `prog_No` varchar(50) NOT NULL,
  `rev` varchar(5) NOT NULL,
  `pcb_No` varchar(15) NOT NULL,
  `part_Count` int(20) NOT NULL,
  `remarks` longtext DEFAULT NULL,
  PRIMARY KEY (`model_No`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_ll` */

/*Table structure for table `tbl_lldetail` */

DROP TABLE IF EXISTS `tbl_lldetail`;

CREATE TABLE `tbl_lldetail` (
  `model_No` varchar(100) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `reel` varchar(15) NOT NULL,
  `partcode` varchar(15) NOT NULL,
  `alt_No` varchar(15) NOT NULL,
  `qty` int(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_lldetail` */

/*Table structure for table `tbl_model` */

DROP TABLE IF EXISTS `tbl_model`;

CREATE TABLE `tbl_model` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `model_No` varchar(100) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  PRIMARY KEY (`model_No`),
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_model` */

insert  into `tbl_model`(`id`,`model_No`,`process_Name`) values 
(6,'522J19C10000','SMT-A');

/*Table structure for table `tbl_partcodedetail` */

DROP TABLE IF EXISTS `tbl_partcodedetail`;

CREATE TABLE `tbl_partcodedetail` (
  `model_No` varchar(30) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `partcode` varchar(30) NOT NULL,
  `tp` int(1) NOT NULL,
  `dec` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_partcodedetail` */

/*Table structure for table `tbl_reel` */

DROP TABLE IF EXISTS `tbl_reel`;

CREATE TABLE `tbl_reel` (
  `model_No` varchar(100) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `reel` varchar(15) NOT NULL,
  `qty` int(20) DEFAULT NULL,
  `loc` mediumtext NOT NULL,
  `f_Type` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_reel` */

/*Table structure for table `tbl_resultcompare` */

DROP TABLE IF EXISTS `tbl_resultcompare`;

CREATE TABLE `tbl_resultcompare` (
  `model_No` varchar(20) DEFAULT NULL,
  `process_Name` varchar(15) DEFAULT NULL,
  `reel` varchar(15) DEFAULT NULL,
  `partcode` varchar(15) DEFAULT NULL,
  `alt_No` varchar(15) DEFAULT NULL,
  `tp` int(1) DEFAULT NULL,
  `qty` int(20) DEFAULT NULL,
  `loc` mediumtext DEFAULT NULL,
  `dec` longtext DEFAULT NULL,
  `f_Type` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_resultcompare` */

/*Table structure for table `tbl_wo` */

DROP TABLE IF EXISTS `tbl_wo`;

CREATE TABLE `tbl_wo` (
  `wo_PTSN` varchar(15) NOT NULL,
  `wo_No` varchar(100) NOT NULL,
  `model_No` varchar(100) NOT NULL,
  `model` varchar(100) NOT NULL,
  `wo_QTY` varchar(20) NOT NULL,
  `wo_Usage` int(15) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  PRIMARY KEY (`wo_PTSN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_wo` */

insert  into `tbl_wo`(`wo_PTSN`,`wo_No`,`model_No`,`model`,`wo_QTY`,`wo_Usage`,`process_Name`) values 
('XM21032208','202104-55K-SB','522J19C10000','J19C (SB)','10000',23,'SMT-A');

/*Table structure for table `tbl_wodetail` */

DROP TABLE IF EXISTS `tbl_wodetail`;

CREATE TABLE `tbl_wodetail` (
  `model_No` varchar(20) NOT NULL,
  `partcode` varchar(15) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `qty` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_wodetail` */

insert  into `tbl_wodetail`(`model_No`,`partcode`,`process_Name`,`qty`) values 
('522J19C10000','4002F1623063','SMT-A',1),
('522J19C10000','40110000169X','SMT-A',2),
('522J19C10000','22BK1HC105AD','SMT-A',1),
('522J19C10000','23C0000MA025','SMT-A',2),
('522J19C10000','24050000199X','SMT-A',1),
('522J19C10000','22DB1EA1019C','SMT-A',2),
('522J19C10000','24050000179X','SMT-A',2),
('522J19C10000','22DB1EA3309C','SMT-A',3),
('522J19C10000','40110000109X','SMT-A',2),
('522J19C10000','23D0000MA025','SMT-A',2),
('522J19C10000','21AG00027068','SMT-A',1),
('522J19C10000','240500001L9X','SMT-A',2),
('522J19C10000','22BKYAC1049A','SMT-A',1),
('522J19C10000','354J19SP1A9X','SMT-A',1);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
