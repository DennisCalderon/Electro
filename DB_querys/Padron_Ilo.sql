/*
Navicat SQLite Data Transfer

Source Server         : Electro
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2018-12-27 15:32:59
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for Padron_Ilo
-- ----------------------------
DROP TABLE IF EXISTS "main"."Padron_Ilo";
CREATE TABLE [Padron_Ilo] (
[NumImport] INTEGER  NOT NULL,
[Item] INTEGER  NOT NULL,
[CodigoRutaSuministro] VARCHAR(40)  NULL,
[CodigoSuministro] VARCHAR(30)  NULL,
[NombreSuministro] VARCHAR(70)  NULL,
[DireccionPredio] VARCHAR(100)  NULL,
[NombreSector] VARCHAR(15)  NULL,
[Tension] VARCHAR(10)  NULL,
[Tarifa] VARCHAR(5)  NULL,
[SistemaElectrico] VARCHAR(30)  NULL,
[ActividadEconomica] VARCHAR(150)  NULL,
[FactorTension] VARCHAR(10)  NULL,
[FactorCorriente] VARCHAR(10)  NULL,
[FactorTransformacionEA] VARCHAR(30)  NULL,
[MarcaDelMedidor] VARCHAR(20)  NULL,
[Modelo] VARCHAR(15)  NULL,
[Serie] VARCHAR(15)  NULL,
[1] VARCHAR(15)  NULL,
[2] VARCHAR(15)  NULL,
[3] VARCHAR(15)  NULL,
[Fecha] VARCHAR(20)  NULL,
[5] VARCHAR(10)  NULL,
[6] VARCHAR(15)  NULL,
[7] VARCHAR(15)  NULL,
[10] VARCHAR(15)  NULL,
PRIMARY KEY ([NumImport],[Item],[CodigoRutaSuministro])
);
