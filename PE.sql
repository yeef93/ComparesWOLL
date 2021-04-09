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
  `id` int(5) NOT NULL AUTO_INCREMENT,
  `model_No` varchar(20) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `model_detail` varchar(100) NOT NULL,
  `machine` varchar(100) NOT NULL,
  `pwb_Type` varchar(100) NOT NULL,
  `prog_No` varchar(50) NOT NULL,
  `rev` varchar(5) NOT NULL,
  `pcb_No` varchar(15) NOT NULL,
  `part_Count` int(20) NOT NULL,
  `stencil` varchar(50) DEFAULT NULL,
  `remarks` longtext DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_ll` */

insert  into `tbl_ll`(`id`,`model_No`,`process_Name`,`model_detail`,`machine`,`pwb_Type`,`prog_No`,`rev`,`pcb_No`,`part_Count`,`stencil`,`remarks`) values 
(34,'522J19C10000','SMT-A','XM-522J19C10000 SB  MASTER (SMT-A)','NXT3-D15MCLB (LINE #07H-LB)','J19C SB (1 PNL : 16 PCS)','7HLB-52J19CJSB-A','03','352J19SP1A9X',23,'SOLDERPASTE','USING SOLDER PASTE\r\n	MAIN PART :       * PART NAME   : ECOSOLDER PASTE\r\n	                          * PART NO.      : S70G-HF TYPE5 (Sn96.5/Ag3.0/Cu0.5)\r\n	                          * VENDOR        : SENJU (MALAYSIA) SDN. BHD.\r\n\r\n       * MYLAR COMPONENT : PART NO. : MYL001-001');

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

insert  into `tbl_lldetail`(`model_No`,`process_Name`,`reel`,`partcode`,`alt_No`,`qty`) values 
('522J19C10000','SMT-A','PCB','352J19SP1A9X','1',1),
('522J19C10000','SMT-A','PCB','354J19SP1A9X','2',1),
('522J19C10000','SMT-A','PCB','356J19SP1A9X','3',1),
('522J19C10000','SMT-A','110','22DB1EA1019C','1',2),
('522J19C10000','SMT-A','209','22DB1EA3309C','1',3),
('522J19C10000','SMT-A','308','23D0000MA025','1',2),
('522J19C10000','SMT-A','308','23D0000MA029','2',0),
('522J19C10000','SMT-A','308','23D0000MA021','3',0),
('522J19C10000','SMT-A','308','23D0000MA026','4',0),
('522J19C10000','SMT-A','308','23D000RNA002','5',0),
('522J19C10000','SMT-A','522','24050000179X','1',2),
('522J19C10000','SMT-A','522','24050000169X','2',0),
('522J19C10000','SMT-A','524','22BKYAC1049A','1',1),
('522J19C10000','SMT-A','621','24050000199X','1',1),
('522J19C10000','SMT-A','621','24050000189X','2',0),
('522J19C10000','SMT-A','623','240500001L9X','1',2),
('522J19C10000','SMT-A','623','240500001K9X','2',0),
('522J19C10000','SMT-A','710','40110000169X','1',2),
('522J19C10000','SMT-A','710','40110000179X','2',0),
('522J19C10000','SMT-A','809','23C0000MA025','1',2),
('522J19C10000','SMT-A','809','23B000RNA002','2',0),
('522J19C10000','SMT-A','1009','22BK1HC105AD','1',1),
('522J19C10000','SMT-A','1009','22BK1HC1052D','2',0),
('522J19C10000','SMT-A','1011','40110000109X','1',2),
('522J19C10000','SMT-A','1011','40110000119X','2',0),
('522J19C10000','SMT-A','1113','21AG00027068','1',1),
('522J19C10000','SMT-A','1113','21AG00027069','2',0),
('522J19C10000','SMT-A','1113','21AG020330A9','3',0),
('522J19C10000','SMT-A','1435','4002F1623063','1',1),
('522J19C10000','SMT-A','1435','4003000005AF','2',0);

/*Table structure for table `tbl_model` */

DROP TABLE IF EXISTS `tbl_model`;

CREATE TABLE `tbl_model` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `model_No` varchar(100) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  PRIMARY KEY (`model_No`),
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_model` */

insert  into `tbl_model`(`id`,`model_No`,`process_Name`) values 
(24,'522J19C10000','SMT-A');

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
('522J19C10000','SMT-A','23D0000MA029',2,'Resistor_General resistor_0201_0.26 mm_0 ohm_±5%_1/20W_25V_N'),
('522J19C10000','SMT-A','23D0000MA021',2,'Resistor_General resistor_0201_0.26 mm_0 ohm_±5%_1/20W_25V_N'),
('522J19C10000','SMT-A','23D0000MA026',2,'Resistor_General resistor_0201_0.26 mm_0 ohm_±5%_1/20W_25V_N'),
('522J19C10000','SMT-A','23D000RNA002',2,'Resistor_General resistor_0201_0.26 mm_0 ohm_±5%_1/20W_25V_200_RC0201JR-070RL_YAGEO\r\n'),
('522J19C10000','SMT-A','24050000179X',2,'Inductor_Bead_0402_0.55 mm_1000 O_300 O_0.9 O_200_Murata+HQ1'),
('522J19C10000','SMT-A','24050000169X',2,'Inductor_Bead_0402_0.6 mm_1000 O_100 O_1 O_200_Jiabang+HQ11540427000_MCB1005B102EBP_Huaqin\r\n'),
('522J19C10000','SMT-A','22BKYAC1049A',2,'Capacitor_General capacitor_0201_0.33 mm_100_nF_10V_±10%_X5R'),
('522J19C10000','SMT-A','24050000199X',2,'Inductor_Bead_0402_0.5 mm_1000 O_2000 O_1.25 O_250_Murata+HQ'),
('522J19C10000','SMT-A','24050000189X',2,'Inductor_Bead_0402_0.65 mm_1000 O_2200 O_1.25 O_250_Sunlord+HQ11540026000_HZ1005K102TFB01_Huaqin\r\n'),
('522J19C10000','SMT-A','240500001L9X',2,'Inductor_Bead_0402_0.65 mm_30 O_60 O_0.05 O_2200_MURATA+HQ11'),
('522J19C10000','SMT-A','240500001K9X',2,'Inductor_Bead_0402_0.65 mm_30 O_65 O_0.06 O_1100_MICROGATE+HQ11540533000_MGLB1005M300T1R1-LF_Huaqin\r\n'),
('522J19C10000','SMT-A','40110000169X',2,'Connector_Spring_Top press_0.8mm_COPPER ALLOY,T=0.08mm_ECT_H'),
('522J19C10000','SMT-A','40110000179X',2,'Connector_Spring_Top press_0.8mm_YCUT-FX-EH,T=0.08mm_JT_HQ12060386000_3.1.29.0736_Huaqin_J19S'),
('522J19C10000','SMT-A','23C0000MA025',2,'Resistor_General resistor_0603_0.55 mm_0 ohm_±5%_1/10W_75V_N'),
('522J19C10000','SMT-A','23B000RNA002',2,'Resistor_General resistor_0603_0.55 mm_0 ohm_±5%_1/10W_75V_200_RC0603JR-070RL_YAGEO\r\n'),
('522J19C10000','SMT-A','22BK1HC105AD',2,'Capacitor_General capacitor_0603_1.0 mm_1_uF_50V_±10%_X5R_CL'),
('522J19C10000','SMT-A','22BK1HC1052D',2,'Capacitor_General capacitor_0603_1_µF_50V_±10%_X5R_UMK107BJ105KA-T_Taiyo Yuden'),
('522J19C10000','SMT-A','40110000109X',2,'Connector_Spring_Top press_1.6mm_STAINLESS STEEL,T=0.08mm_EC'),
('522J19C10000','SMT-A','40110000119X',2,'Connector_Spring_Top press_1.6mm_SUS301,T=0.08±0.005mm_KEIRAKU_HQ12060304000_KSN-A23000104R-0400_Huaqin_J19S'),
('522J19C10000','SMT-A','21AG00027068',2,'TVS,protect USB port,24V 180A surge, DFN2.0×2.0-3'),
('522J19C10000','SMT-A','21AG00027069',2,''),
('522J19C10000','SMT-A','21AG020330A9',2,'DIODE-ESD BLK 033 0 Will S:2020 MSL:3 P:TRAY'),
('522J19C10000','SMT-A','4002F1623063',2,'USB TYPE-C-Connector (16PIN)'),
('522J19C10000','SMT-A','4003000005AF',2,'Connector_MicroUSB TypeC_Type C_Sink Borad_16_8A_IPX4_UC40-0B0104R0_HRD');

/*Table structure for table `tbl_reel` */

DROP TABLE IF EXISTS `tbl_reel`;

CREATE TABLE `tbl_reel` (
  `reel` varchar(15) NOT NULL,
  `model_No` varchar(100) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `qty` int(20) DEFAULT NULL,
  `loc` mediumtext NOT NULL,
  `f_Type` varchar(10) NOT NULL,
  PRIMARY KEY (`reel`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_reel` */

insert  into `tbl_reel`(`reel`,`model_No`,`process_Name`,`qty`,`loc`,`f_Type`) values 
('1009','522J19C10000','SMT-A',1,'C113','8 X 4 P'),
('1011','522J19C10000','SMT-A',2,'ANT104, ANT103','12 X 4 E'),
('110','522J19C10000','SMT-A',2,'C109, C102','8 X 2 P'),
('1113','522J19C10000','SMT-A',1,'D107','8 X 4 E'),
('1435','522J19C10000','SMT-A',1,'J101','24 X 12 E'),
('209','522J19C10000','SMT-A',3,'C108, C106, C100','8 X 2 P'),
('308','522J19C10000','SMT-A',2,'R108, R106','8 X 2 P'),
('522','522J19C10000','SMT-A',2,'B103, B102','8 X 2 P'),
('524','522J19C10000','SMT-A',1,'C112','8 X 2 P'),
('621','522J19C10000','SMT-A',1,'R103','8 X 2 P'),
('623','522J19C10000','SMT-A',2,'R110, R152','8 X 2 P'),
('710','522J19C10000','SMT-A',2,'ANT107, ANT106','12 X 4 E'),
('809','522J19C10000','SMT-A',2,'B104, B101','8 X 4 P');

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

insert  into `tbl_resultcompare`(`model_No`,`process_Name`,`reel`,`partcode`,`alt_No`,`tp`,`qty`,`loc`,`dec`,`f_Type`) values 
('522J19C10000','SMT-A','110','22DB1EA1019C','1',2,2,'C109, C102','Capacitor_General capacitor_0201_0.33 mm_100_pF_25V_±10%_COG','8 X 2 P'),
('522J19C10000','SMT-A','209','22DB1EA3309C','1',2,3,'C108, C106, C100','Capacitor_General capacitor_0201_0.33 mm_33_pF_25V_±10%_COG(','8 X 2 P'),
('522J19C10000','SMT-A','308','23D0000MA025','1',2,2,'R108, R106','Resistor_General resistor_0201_0.26 mm_0 ohm_±5%_1/20W_25V_N','8 X 2 P'),
('522J19C10000','SMT-A','522','24050000179X','1',2,2,'B103, B102','Inductor_Bead_0402_0.55 mm_1000 O_300 O_0.9 O_200_Murata+HQ1','8 X 2 P'),
('522J19C10000','SMT-A','524','22BKYAC1049A','1',2,1,'C112','Capacitor_General capacitor_0201_0.33 mm_100_nF_10V_±10%_X5R','8 X 2 P'),
('522J19C10000','SMT-A','621','24050000199X','1',2,1,'R103','Inductor_Bead_0402_0.5 mm_1000 O_2000 O_1.25 O_250_Murata+HQ','8 X 2 P'),
('522J19C10000','SMT-A','623','240500001L9X','1',2,2,'R110, R152','Inductor_Bead_0402_0.65 mm_30 O_60 O_0.05 O_2200_MURATA+HQ11','8 X 2 P'),
('522J19C10000','SMT-A','710','40110000169X','1',2,2,'ANT107, ANT106','Connector_Spring_Top press_0.8mm_COPPER ALLOY,T=0.08mm_ECT_H','12 X 4 E'),
('522J19C10000','SMT-A','809','23C0000MA025','1',2,2,'B104, B101','Resistor_General resistor_0603_0.55 mm_0 ohm_±5%_1/10W_75V_N','8 X 4 P'),
('522J19C10000','SMT-A','1009','22BK1HC105AD','1',2,1,'C113','Capacitor_General capacitor_0603_1.0 mm_1_uF_50V_±10%_X5R_CL','8 X 4 P'),
('522J19C10000','SMT-A','1011','40110000109X','1',2,2,'ANT104, ANT103','Connector_Spring_Top press_1.6mm_STAINLESS STEEL,T=0.08mm_EC','12 X 4 E'),
('522J19C10000','SMT-A','1113','21AG00027068','1',2,1,'D107','TVS,protect USB port,24V 180A surge, DFN2.0×2.0-3','8 X 4 E'),
('522J19C10000','SMT-A','1435','4002F1623063','1',2,1,'J101','USB TYPE-C-Connector (16PIN)','24 X 12 E');

/*Table structure for table `tbl_user` */

DROP TABLE IF EXISTS `tbl_user`;

CREATE TABLE `tbl_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(25) NOT NULL,
  `name` varchar(30) DEFAULT NULL,
  `pass` varchar(50) NOT NULL,
  `role` varchar(25) NOT NULL,
  PRIMARY KEY (`id`,`username`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_user` */

insert  into `tbl_user`(`id`,`username`,`name`,`pass`,`role`) values 
(1,'0339928','Yuninda Faranika','13012420314234138112108765216110414524878123','AE');

/*Table structure for table `tbl_wo` */

DROP TABLE IF EXISTS `tbl_wo`;

CREATE TABLE `tbl_wo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `wo_PTSN` varchar(15) NOT NULL,
  `wo_No` varchar(100) NOT NULL,
  `model_No` varchar(100) NOT NULL,
  `model` varchar(100) NOT NULL,
  `wo_QTY` varchar(20) NOT NULL,
  `wo_Usage` int(15) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_wo` */

insert  into `tbl_wo`(`id`,`wo_PTSN`,`wo_No`,`model_No`,`model`,`wo_QTY`,`wo_Usage`,`process_Name`) values 
(19,'XM21032208','202104-55K-SB','522J19C10000','J19C (SB)','23',10000,'SMT-A');

/*Table structure for table `tbl_wodetail` */

DROP TABLE IF EXISTS `tbl_wodetail`;

CREATE TABLE `tbl_wodetail` (
  `model_No` varchar(20) NOT NULL,
  `partcode` varchar(15) NOT NULL,
  `process_Name` varchar(15) NOT NULL,
  `qty` int(5) NOT NULL,
  `bom_Row` int(10) NOT NULL,
  `issue` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tbl_wodetail` */

insert  into `tbl_wodetail`(`model_No`,`partcode`,`process_Name`,`qty`,`bom_Row`,`issue`) values 
('522J19C10000','4002F1623063','SMT-A',1,20,10000),
('522J19C10000','40110000169X','SMT-A',2,30,20000),
('522J19C10000','22BK1HC105AD','SMT-A',1,40,10000),
('522J19C10000','23C0000MA025','SMT-A',2,50,20000),
('522J19C10000','24050000199X','SMT-A',1,60,10000),
('522J19C10000','22DB1EA1019C','SMT-A',2,70,20000),
('522J19C10000','24050000179X','SMT-A',2,80,20000),
('522J19C10000','22DB1EA3309C','SMT-A',3,90,30000),
('522J19C10000','40110000109X','SMT-A',2,100,20000),
('522J19C10000','23D0000MA025','SMT-A',2,110,20000),
('522J19C10000','21AG00027068','SMT-A',1,120,10000),
('522J19C10000','240500001L9X','SMT-A',2,130,20000),
('522J19C10000','22BKYAC1049A','SMT-A',1,140,10000),
('522J19C10000','354J19SP1A9X','SMT-A',1,130,10000);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
