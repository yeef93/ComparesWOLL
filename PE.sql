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
  `pcb_No` varchar(15) NOT NULL,
  PRIMARY KEY (`model_No`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_ll` */

/*Table structure for table `tbl_lldetail` */

DROP TABLE IF EXISTS `tbl_lldetail`;

CREATE TABLE `tbl_lldetail` (
  `part_Number` varchar(30) NOT NULL,
  `qty` int(10) NOT NULL,
  `loc_Code` varchar(100) NOT NULL,
  `choice1` varchar(25) NOT NULL,
  `choice2` varchar(25) DEFAULT NULL,
  `choice3` varchar(25) DEFAULT NULL,
  `choice4` varchar(25) DEFAULT NULL,
  `choice5` varchar(25) DEFAULT NULL,
  `choice6` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`part_Number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_lldetail` */

/*Table structure for table `tbl_wo` */

DROP TABLE IF EXISTS `tbl_wo`;

CREATE TABLE `tbl_wo` (
  `wo_PTSN` varchar(15) NOT NULL,
  `wo_No` varchar(100) NOT NULL,
  `model_No` varchar(100) NOT NULL,
  `model` varchar(100) NOT NULL,
  `wo_QTY` varchar(20) NOT NULL,
  `pcb_No` varchar(15) NOT NULL,
  `type` varchar(15) NOT NULL,
  PRIMARY KEY (`wo_PTSN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_wo` */

insert  into `tbl_wo`(`wo_PTSN`,`wo_No`,`model_No`,`model`,`wo_QTY`,`pcb_No`,`type`) values 
('XM21032308','202103-100K-MB','5210C3LN0000','C3L (2G+32G) 4G (MB)','1500','3520C3LM0A9T','1 SIDE');

/*Table structure for table `tbl_wodetail` */

DROP TABLE IF EXISTS `tbl_wodetail`;

CREATE TABLE `tbl_wodetail` (
  `model_No` varchar(20) NOT NULL,
  `part_No` varchar(15) NOT NULL,
  `qty` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_wodetail` */

insert  into `tbl_wodetail`(`model_No`,`part_No`,`qty`) values 
('5210C3LN0000','5110C3LN0000',1),
('5210C3LN0000','240300004H9T',1),
('5210C3LN0000','22010000C79T',2),
('5210C3LN0000','22010000BF9T',1),
('5210C3LN0000','23010000JA9T',1),
('5210C3LN0000','23010000J09T',2),
('5210C3LN0000','240300004P9T',2),
('5210C3LN0000','27520000059T',1),
('5210C3LN0000','23010000JR9T',2),
('5210C3LN0000','22010000BY9T',1),
('5210C3LN0000','24030000489T',1),
('5210C3LN0000','23010000J19T',1),
('5210C3LN0000','270300036053',1),
('5210C3LN0000','22010000C49T',39),
('5210C3LN0000','23010000JF9T',1),
('5210C3LN0000','275100000G9T',1),
('5210C3LN0000','23010000KY9T',6),
('5210C3LN0000','22010000C09T',1),
('5210C3LN0000','27410000049T',1),
('5210C3LN0000','22010000CR9T',7),
('5210C3LN0000','22010000AN9T',1),
('5210C3LN0000','270500000V9T',1),
('5210C3LN0000','40040000069T',1),
('5210C3LN0000','400600000K9T',1),
('5210C3LN0000','27430000069T',1),
('5210C3LN0000','22010000AU9T',2),
('5210C3LN0000','22010000DF9T',3),
('5210C3LN0000','240300004X9T',1),
('5210C3LN0000','240100001M9T',1),
('5210C3LN0000','240300004T9T',1),
('5210C3LN0000','23010000LY9T',1),
('5210C3LN0000','240100001I9T',1),
('5210C3LN0000','220100009S9T',2),
('5210C3LN0000','240500000Q9T',2),
('5210C3LN0000','22010000BQ9T',1),
('5210C3LN0000','240500000J9T',1),
('5210C3LN0000','240300004G9T',4),
('5210C3LN0000','220100009V9T',3),
('5210C3LN0000','240300004S9T',1),
('5210C3LN0000','240300004O9T',2),
('5210C3LN0000','270600000G9T',1),
('5210C3LN0000','22010000CB9T',1),
('5210C3LN0000','200100001A9T',1),
('5210C3LN0000','276100000O79',1),
('5210C3LN0000','23010000JG9T',1),
('5210C3LN0000','23010000L59T',3),
('5210C3LN0000','214100000T9T',1),
('5210C3LN0000','24030000479T',2),
('5210C3LN0000','23010000L19T',1),
('5210C3LN0000','240300004C9T',1),
('5210C3LN0000','23010000IX9T',7),
('5210C3LN0000','23010000JK9T',1),
('5210C3LN0000','270500000W9T',1),
('5210C3LN0000','22010000AP9T',3),
('5210C3LN0000','400600000J9T',2),
('5210C3LN0000','214100000R9T',1),
('5210C3LN0000','22010000AZ9T',5),
('5210C3LN0000','22010000DD9T',2),
('5210C3LN0000','22010000CZ9T',7),
('5210C3LN0000','240300004J9T',2),
('5210C3LN0000','240300004F9T',1),
('5210C3LN0000','22010000B89T',1),
('5210C3LN0000','22010000C29T',1),
('5210C3LN0000','22010000CK9T',3),
('5210C3LN0000','240300004R9T',2),
('5210C3LN0000','23010000JU9T',1),
('5210C3LN0000','21220000059T',1),
('5210C3LN0000','270700000D9T',1),
('5210C3LN0000','22010000BJ9T',7),
('5210C3LN0000','200100001B9T',1),
('5210C3LN0000','23010000JJ9T',1),
('5210C3LN0000','401100000O9T',4),
('5210C3LN0000','23010000K19T',6),
('5210C3LN0000','22010000CD9T',1),
('5210C3LN0000','240300004B9T',1),
('5210C3LN0000','23010000JL9T',5),
('5210C3LN0000','23010000JT9T',1),
('5210C3LN0000','270200000L9T',1),
('5210C3LN0000','22010000L29T',1),
('5210C3LN0000','22010000B59T',1),
('5210C3LN0000','20010000169T',1),
('5210C3LN0000','20050000159T',1),
('5210C3LN0000','22010000BB9T',1),
('5210C3LN0000','23030000039T',2),
('5210C3LN0000','277200001N7W',1),
('5210C3LN0000','270000134266',1),
('5210C3LN0000','22010000D59T',2),
('5210C3LN0000','240100001K9T',1),
('5210C3LN0000','240100001G9T',2),
('5210C3LN0000','240500000R9T',1),
('5210C3LN0000','22010000D89T',5),
('5210C3LN0000','22010000CW9T',1),
('5210C3LN0000','2707000530E6',1),
('5210C3LN0000','23010000JS9T',1),
('5210C3LN0000','240300004I9T',3),
('5210C3LN0000','40010000189T',1),
('5210C3LN0000','23010000JD9T',1),
('5210C3LN0000','277100000F7W',1),
('5210C3LN0000','22010000DN9T',1),
('5210C3LN0000','240300004Q9T',1),
('5210C3LN0000','240300004M9T',1),
('5210C3LN0000','23010000L39T',3),
('5210C3LN0000','401100000P9T',4),
('5210C3LN0000','22010000KH9T',1),
('5210C3LN0000','23010000RD9T',1),
('5210C3LN0000','23010000J39T',3),
('5210C3LN0000','20010000179T',1),
('5210C3LN0000','240300004A9T',1),
('5210C3LN0000','23010000JM9T',1),
('5210C3LN0000','23010000J29T',5),
('5210C3LN0000','22010000AE9T',3),
('5210C3LN0000','22010000AG9T',5),
('5210C3LN0000','27750000077W',1),
('5210C3LN0000','400600000H9T',1),
('5210C3LN0000','22010000B39T',11),
('5210C3LN0000','25310000089T',1),
('5210C3LN0000','22010000CI9T',2),
('5210C3LN0000','22010000A39T',1),
('5210C3LN0000','22010000EK9T',1),
('5210C3LN0000','22010000CL9T',1),
('5210C3LN0000','240300007K9T',1),
('5210C3LN0000','240100001S9T',1),
('5210C3LN0000','240500000M9T',1),
('5210C3LN0000','22010000CX9T',2),
('5210C3LN0000','22010000DA9T',4),
('5210C3LN0000','34010000FC9T',1),
('5210C3LN0000','34010000EX9T',1),
('5210C3LN0000','34010000F19T',1),
('5210C3LN0000','34010000F49T',1),
('5210C3LN0000','34010000F89T',1),
('5210C3LN0000','34010000EW9T',1),
('5210C3LN0000','40010000159T',1),
('5210C3LN0000','23010000JP9T',1),
('5210C3LN0000','240300004H9T',3),
('5210C3LN0000','22010000C79T',9),
('5210C3LN0000','22010000BF9T',1),
('5210C3LN0000','240300004D9T',1),
('5210C3LN0000','23010000JA9T',2),
('5210C3LN0000','240300004P9T',4),
('5210C3LN0000','22010000EF9T',1),
('5210C3LN0000','23010000J09T',1),
('5210C3LN0000','23010000JR9T',1),
('5210C3LN0000','240300004L9T',1),
('5210C3LN0000','214100000W9T',1),
('5210C3LN0000','24030000489T',6),
('5210C3LN0000','200200001C9T',1),
('5210C3LN0000','22010000KK9T',1),
('5210C3LN0000','22010000C49T',70),
('5210C3LN0000','200100001D9T',1),
('5210C3LN0000','20010000189T',1),
('5210C3LN0000','401100000S9T',4),
('5210C3LN0000','200200000V9T',1),
('5210C3LN0000','22010000CR9T',11),
('5210C3LN0000','3510C3LM0A9T',1),
('5210C3LN0000','23010000JI9T',1),
('5210C3LN0000','270300016053',1),
('5210C3LN0000','22010000DF9T',3),
('5210C3LN0000','23010000K69T',1),
('5210C3LN0000','200100002F9T',1),
('5210C3LN0000','240100001M9T',1),
('5210C3LN0000','240300004T9T',3),
('5210C3LN0000','240500000T9T',2),
('5210C3LN0000','22010000BQ9T',2),
('5210C3LN0000','240300004K9T',1),
('5210C3LN0000','23010000JN9T',2),
('5210C3LN0000','240300004G9T',2),
('5210C3LN0000','240300004S9T',1),
('5210C3LN0000','220100009V9T',3),
('5210C3LN0000','23010000IY9T',1),
('5210C3LN0000','240300004O9T',4),
('5210C3LN0000','23010000LI9T',1),
('5210C3LN0000','270600007053',1),
('5210C3LN0000','200200001B9T',1),
('5210C3LN0000','23010000L59T',3),
('5210C3LN0000','24030000479T',3),
('5210C3LN0000','214200001A9T',3),
('5210C3LN0000','240300004C9T',4),
('5210C3LN0000','20010000199T',1),
('5210C3LN0000','23010000IX9T',26),
('5210C3LN0000','200200000U9T',1),
('5210C3LN0000','21310000039T',1),
('5210C3LN0000','214100000R9T',1),
('5210C3LN0000','22010000AZ9T',7),
('5210C3LN0000','20010000159T',1),
('5210C3LN0000','253000000EE6',1),
('5210C3LN0000','240100001F9T',2),
('5210C3LN0000','24030000749T',1),
('5210C3LN0000','40070000039T',2),
('5210C3LN0000','23010000KG9T',1),
('5210C3LN0000','22010000DD9T',4),
('5210C3LN0000','240300006Z9T',1),
('5210C3LN0000','22010000CZ9T',12),
('5210C3LN0000','23010000J79T',1),
('5210C3LN0000','40010000179T',1),
('5210C3LN0000','240300004F9T',2),
('5210C3LN0000','251100000R9T',1),
('5210C3LN0000','22010000DQ9T',3),
('5210C3LN0000','23010000RE9T',3),
('5210C3LN0000','22010000CK9T',10),
('5210C3LN0000','240300004R9T',1),
('5210C3LN0000','23010000JU9T',3),
('5210C3LN0000','21220000059T',1),
('5210C3LN0000','240300004N9T',3),
('5210C3LN0000','23010000J49T',4),
('5210C3LN0000','22010000DJ9T',6),
('5210C3LN0000','22010000BJ9T',4),
('5210C3LN0000','24020000019T',1),
('5210C3LN0000','200200001E9T',1),
('5210C3LN0000','21440000069T',5),
('5210C3LN0000','23010000JJ9T',1),
('5210C3LN0000','40050000019T',1),
('5210C3LN0000','200200001A9T',1),
('5210C3LN0000','22010000A89T',2),
('5210C3LN0000','240300004B9T',4),
('5210C3LN0000','27240000049T',1),
('5210C3LN0000','20020000199T',1),
('5210C3LN0000','200200000X9T',1),
('5210C3LN0000','23010000JL9T',2),
('5210C3LN0000','22010000EG9T',2),
('5210C3LN0000','27570000029T',1),
('5210C3LN0000','22010000L29T',1),
('5210C3LN0000','23010000KI9T',1),
('5210C3LN0000','22010000D59T',2),
('5210C3LN0000','40070000049T',1),
('5210C3LN0000','240300004V9T',5),
('5210C3LN0000','23010000J59T',2),
('5210C3LN0000','200100002D9T',1),
('5210C3LN0000','22010000D89T',6),
('5210C3LN0000','240500000V9T',2),
('5210C3LN0000','251100000X9T',1),
('5210C3LN0000','23010000JS9T',1),
('5210C3LN0000','240300004E9T',2),
('5210C3LN0000','260200000J9T',1),
('5210C3LN0000','276300000E79',1),
('5210C3LN0000','22010000BS9T',5),
('5210C3LN0000','23010000JD9T',2),
('5210C3LN0000','22010000DN9T',1),
('5210C3LN0000','240300004Q9T',2),
('5210C3LN0000','23010000JO9T',1),
('5210C3LN0000','240300004M9T',1),
('5210C3LN0000','200200001D9T',1),
('5210C3LN0000','23010000L39T',1),
('5210C3LN0000','24030000499T',1),
('5210C3LN0000','252100000C9T',1),
('5210C3LN0000','214200000X9T',3),
('5210C3LN0000','22010000KH9T',1),
('5210C3LN0000','200100001C9T',1),
('5210C3LN0000','22010000AY9T',2),
('5210C3LN0000','240300004A9T',5),
('5210C3LN0000','200200000W9T',1),
('5210C3LN0000','22010000AG9T',30),
('5210C3LN0000','22010000B39T',16),
('5210C3LN0000','22010000CI9T',1),
('5210C3LN0000','23010000JQ9T',1),
('5210C3LN0000','240300007K9T',1),
('5210C3LN0000','23010000J89T',1),
('5210C3LN0000','240300004U9T',1),
('5210C3LN0000','240100001N9T',3),
('5210C3LN0000','200100002E9T',1),
('5210C3LN0000','277500000C7W',1),
('5210C3LN0000','240500000M9T',3),
('5210C3LN0000','22010000CX9T',3),
('5210C3LN0000','22010000DA9T',2),
('5210C3LN0000','220100009U9T',3),
('5210C3LN0000','34010000F79T',1),
('5210C3LN0000','34010000FG9T',1),
('5210C3LN0000','34010000FF9T',1),
('5210C3LN0000','34010000FA9T',1);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
