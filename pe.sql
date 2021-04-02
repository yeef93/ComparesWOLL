/*
SQLyog Community v13.1.6 (64 bit)
MySQL - 10.4.14-MariaDB : Database - pe
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
  PRIMARY KEY (`model_No`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_ll` */

insert  into `tbl_ll`(`model_No`,`process_Name`,`model_detail`,`machine`,`pwb_Type`,`prog_No`,`rev`,`pcb_No`,`part_Count`) values 
('522J19C10000','SMT-A','XM-522J19C10000 SB  MASTER (SMT-A)','NXT3-D15MCLB (LINE #07H-LB)','J19C SB (1 PNL : 16 PCS)','7HLB-52J19CJSB-A','03','352J19SP1A9X',0);

/*Table structure for table `tbl_lldetail` */

DROP TABLE IF EXISTS `tbl_lldetail`;

CREATE TABLE `tbl_lldetail` (
  `model_No` varchar(100) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `reel` varchar(15) DEFAULT NULL,
  `choice1` varchar(15) DEFAULT NULL,
  `choice2` varchar(15) DEFAULT NULL,
  `choice3` varchar(15) DEFAULT NULL,
  `choice4` varchar(15) DEFAULT NULL,
  `choice5` varchar(15) DEFAULT NULL,
  `choice6` varchar(15) DEFAULT NULL,
  `choice7` varchar(15) DEFAULT NULL,
  `choice8` varchar(15) DEFAULT NULL,
  `qty` int(20) DEFAULT NULL,
  `loc` mediumtext NOT NULL,
  `f_Type` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_lldetail` */

insert  into `tbl_lldetail`(`model_No`,`process_Name`,`reel`,`choice1`,`choice2`,`choice3`,`choice4`,`choice5`,`choice6`,`choice7`,`choice8`,`qty`,`loc`,`f_Type`) values 
('522J19C10000','SMT-A','110','22DB1EA1019C','','','','','','','',2,'C109, C102','8 X 2 P'),
('522J19C10000','SMT-A','209','22DB1EA3309C','','','','','','','',3,'C108, C106, C100','8 X 2 P'),
('522J19C10000','SMT-A','308','23D0000MA025','23D000RNA002','','','','','','',2,'R108, R106','8 X 2 P'),
('522J19C10000','SMT-A','522','24050000179X','24050000169X','','','','','','',2,'B103, B102','8 X 2 P'),
('522J19C10000','SMT-A','524','22BKYAC1049A','','','','','','','',1,'C112','8 X 2 P'),
('522J19C10000','SMT-A','621','24050000199X','24050000189X','','','','','','',1,'R103','8 X 2 P'),
('522J19C10000','SMT-A','623','240500001L9X','240500001K9X','','','','','','',2,'R110, R152','8 X 2 P'),
('522J19C10000','SMT-A','710','40110000169X','40110000179X','','','','','','',2,'ANT107, ANT106','12 X 4 E'),
('522J19C10000','SMT-A','809','23C0000MA025','23B000RNA002','','','','','','',2,'B104, B101','8 X 4 P'),
('522J19C10000','SMT-A','1009','22BK1HC105AD','22BK1HC1052D','','','','','','',1,'C113','8 X 4 P'),
('522J19C10000','SMT-A','1011','40110000109X','40110000119X','','','','','','',2,'ANT104, ANT103','12 X 4 E'),
('522J19C10000','SMT-A','1113','21AG00027068','21AG020330A9','','','','','','',1,'D107','8 X 4 E'),
('522J19C10000','SMT-A','1435','4002F1623063','4003000005AF','','','','','','',1,'J101','24 X 12 E'),
('522J19C10000','SMT-A','pcb','352J19SP1A9X',NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'','');

/*Table structure for table `tbl_lldetail_copy` */

DROP TABLE IF EXISTS `tbl_lldetail_copy`;

CREATE TABLE `tbl_lldetail_copy` (
  `model_No` varchar(100) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `reel` varchar(15) NOT NULL,
  `partcode` varchar(15) NOT NULL,
  `alt_No` varchar(15) NOT NULL,
  `qty` int(20) DEFAULT NULL,
  `loc` mediumtext NOT NULL,
  `f_Type` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_lldetail_copy` */

insert  into `tbl_lldetail_copy`(`model_No`,`process_Name`,`reel`,`partcode`,`alt_No`,`qty`,`loc`,`f_Type`) values 
('522J19C10000','SMT-A','110','22DB1EA1019C','1',2,'C109, C102','8 X 2 P'),
('522J19C10000','SMT-A','209','22DB1EA3309C','1',3,'C108, C106, C100','8 X 2 P'),
('522J19C10000','SMT-A','308','23D0000MA025','1',2,'R108, R106','8 X 2 P'),
('522J19C10000','SMT-A','522','24050000179X','1',2,'B103, B102','8 X 2 P'),
('522J19C10000','SMT-A','524','22BKYAC1049A','1',1,'C112','8 X 2 P'),
('522J19C10000','SMT-A','621','24050000199X','1',1,'R103','8 X 2 P'),
('522J19C10000','SMT-A','623','240500001L9X','1',2,'R110, R152','8 X 2 P'),
('522J19C10000','SMT-A','710','40110000169X','1',2,'ANT107, ANT106','12 X 4 E'),
('522J19C10000','SMT-A','809','23C0000MA025','1',2,'B104, B101','8 X 4 P'),
('522J19C10000','SMT-A','1009','22BK1HC105AD','1',1,'C113','8 X 4 P'),
('522J19C10000','SMT-A','1011','40110000109X','1',2,'ANT104, ANT103','12 X 4 E'),
('522J19C10000','SMT-A','1113','21AG00027068','1',1,'D107','8 X 4 E'),
('522J19C10000','SMT-A','1435','4002F1623063','1',1,'J101','24 X 12 E'),
('522J19C10000','SMT-A','pcb','352J19SP1A9X','',1,'',''),
('522J19C10000','SMT-A','308','23D000RNA002','2',2,'R108, R106','8 X 2 P'),
('522J19C10000','SMT-A','522','24050000169X','1',2,'B103, B102','8 X 2 P'),
('522J19C10000','SMT-A','621','24050000189X','2',1,'R103','8 X 2 P'),
('522J19C10000','SMT-A','623','240500001K9X','2',2,'R110, R152','8 X 2 P'),
('522J19C10000','SMT-A','710','40110000179X','2',2,'ANT107, ANT106','12 X 4 E'),
('522J19C10000','SMT-A','809','23B000RNA002','2',2,'B104, B101','8 X 4 P'),
('522J19C10000','SMT-A','1009','22BK1HC1052D','2',1,'C113','8 X 4 P'),
('522J19C10000','SMT-A','1011','40110000119X','2',2,'ANT104, ANT103','12 X 4 E'),
('522J19C10000','SMT-A','1113','21AG020330A9','2',1,'D107','8 X 4 E'),
('522J19C10000','SMT-A','1435','4003000005AF','2',1,'J101','24 X 12 E');

/*Table structure for table `tbl_model` */

DROP TABLE IF EXISTS `tbl_model`;

CREATE TABLE `tbl_model` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `model_No` varchar(100) NOT NULL,
  PRIMARY KEY (`model_No`),
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_model` */

insert  into `tbl_model`(`id`,`model_No`) values 
(1,'522J19C10000');

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

insert  into `tbl_partcodedetail`(`model_No`,`process_Name`,`partcode`,`tp`,`dec`) values 
('522J19C10000','SMT-A','22DB1EA1019C',2,'Capacitor_General capacitor_0201_0.33 mm_100_pF_25V_±10%_COG'),
('522J19C10000','SMT-A','22DB1EA3309C',2,'Capacitor_General capacitor_0201_0.33 mm_33_pF_25V_±10%_COG('),
('522J19C10000','SMT-A','23D0000MA025',2,'Resistor_General resistor_0201_0.26 mm_0 ohm_±5%_1/20W_25V_N'),
('522J19C10000','SMT-A','23D000RNA002',2,'Resistor_General resistor_0201_0.26 mm_0 ohm_±5%_1/20W_25V_200_RC0201JR-070RL_YAGEO\r\n'),
('522J19C10000','SMT-A','24050000179X',2,'Inductor_Bead_0402_0.55 mm_1000 O_300 O_0.9 O_200_Murata+HQ1'),
('522J19C10000','SMT-A','24050000169X',2,'Inductor_Bead_0402_0.6 mm_1000 O_100 O_1 O_200_Jiabang+HQ11540427000_MCB1005B102EBP_Huaqin\r\n'),
('522J19C10000','SMT-A','24050000159X',2,'Inductor_Bead_0402_0.65 mm_1000 O_300 O_1.2 O_100_Sunlord+HQ11540160297_GZ1005D102TF_Huaqin\r\n'),
('522J19C10000','SMT-A','22BKYAC1049A',2,'Capacitor_General capacitor_0201_0.33 mm_100_nF_10V_±10%_X5R'),
('522J19C10000','SMT-A','24050000199X',2,'Inductor_Bead_0402_0.5 mm_1000 O_2000 O_1.25 O_250_Murata+HQ'),
('522J19C10000','SMT-A','24050000189X',2,'Inductor_Bead_0402_0.65 mm_1000 O_2200 O_1.25 O_250_Sunlord+HQ11540026000_HZ1005K102TFB01_Huaqin\r\n'),
('522J19C10000','SMT-A','240500001A9X',2,'Inductor_Bead_0402_0.6 mm_1000 O_2000 O_1.25 O_250_INPAQ+HQ11540447000_MGB1005G102YBP_Huaqin\r\n'),
('522J19C10000','SMT-A','240500001L9X',2,'Inductor_Bead_0402_0.65 mm_30 O_60 O_0.05 O_2200_MURATA+HQ11'),
('522J19C10000','SMT-A','240500001K9X',2,'Inductor_Bead_0402_0.65 mm_30 O_65 O_0.06 O_1100_MICROGATE+HQ11540533000_MGLB1005M300T1R1-LF_Huaqin\r\n'),
('522J19C10000','SMT-A','240500001G9X',2,'Inductor_Bead_0402_0.65 mm_30 O_50 O_0.06 O_1200_Sunlord+HQ11540535000_PZ1005E300-1R2TF_Huaqin\r\n'),
('522J19C10000','SMT-A','40110000169X',2,'Connector_Spring_Top press_0.8mm_COPPER ALLOY,T=0.08mm_ECT_H'),
('522J19C10000','SMT-A','40110000179X',2,'Connector_Spring_Top press_0.8mm_YCUT-FX-EH,T=0.08mm_JT_HQ12060386000_3.1.29.0736_Huaqin_J19S'),
('522J19C10000','SMT-A','23C0000MA025',2,'Resistor_General resistor_0603_0.55 mm_0 ohm_±5%_1/10W_75V_N'),
('522J19C10000','SMT-A','23B000RNA002',2,'Resistor_General resistor_0603_0.55 mm_0 ohm_±5%_1/10W_75V_200_RC0603JR-070RL_YAGEO\r\n'),
('522J19C10000','SMT-A','22BK1HC105AD',2,'Capacitor_General capacitor_0603_1.0 mm_1_uF_50V_±10%_X5R_CL'),
('522J19C10000','SMT-A','22BK1HC1052D',2,'Capacitor_General capacitor_0603_1_µF_50V_±10%_X5R_UMK107BJ105KA-T_Taiyo Yuden'),
('522J19C10000','SMT-A','40110000109X',2,'Connector_Spring_Top press_1.6mm_STAINLESS STEEL,T=0.08mm_EC'),
('522J19C10000','SMT-A','40110000119X',2,'Connector_Spring_Top press_1.6mm_SUS301,T=0.08±0.005mm_KEIRAKU_HQ12060304000_KSN-A23000104R-0400_Huaqin_J19S'),
('522J19C10000','SMT-A','21AG00027068',2,'TVS,protect USB port,24V 180A surge, DFN2.0×2.0-3'),
('522J19C10000','SMT-A','21AG020330A9',2,'DIODE-ESD BLK 033 0 Will S:2020 MSL:3 P:TRAY'),
('522J19C10000','SMT-A','4002F1623063',2,'USB TYPE-C-Connector (16PIN)'),
('522J19C10000','SMT-A','4003000005AF',2,'Connector_MicroUSB TypeC_Type C_Sink Borad_16_8A_IPX4_UC40-0B0104R0_HRD');

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
('XM21032208','202104-55K-SB','522J19C10000','J19C (SB)','10000','3520C3LM0A9T','1 SIDE');

/*Table structure for table `tbl_wodetail` */

DROP TABLE IF EXISTS `tbl_wodetail`;

CREATE TABLE `tbl_wodetail` (
  `model_No` varchar(20) NOT NULL,
  `part_No` varchar(15) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `qty` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_wodetail` */

insert  into `tbl_wodetail`(`model_No`,`part_No`,`process_Name`,`qty`) values 
('522J19C10000','512J19C10000','SMT-A',1),
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
