/*
Navicat SQLite Data Transfer

Source Server         : electro
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2019-01-19 13:58:22
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for Historico
-- ----------------------------
DROP TABLE IF EXISTS "main"."Historico";
CREATE TABLE "Historico" (
"Id"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"NumImport"  INTEGER NOT NULL,
"Sector"  VARCHAR(10),
"Mes"  VARCHAR(5),
"CodigoEmpresa"  VARCHAR(5),
"CodigoSuministro"  VARCHAR(12),
"CodigoBarraCompra"  VARCHAR(20),
"FechaHora"  VARCHAR(13),
"EA"  VARCHAR(50)
);

-- ----------------------------
-- Table structure for OpcionesDB
-- ----------------------------
DROP TABLE IF EXISTS "main"."OpcionesDB";
CREATE TABLE "OpcionesDB" (
"DataBaseGuardar"  TEXT(1)
);

-- ----------------------------
-- Table structure for Padron_General
-- ----------------------------
DROP TABLE IF EXISTS "main"."Padron_General";
CREATE TABLE [Padron_General] (
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
[10] VARCHAR(15)  NULL
);

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

-- ----------------------------
-- Table structure for Padron_Libres
-- ----------------------------
DROP TABLE IF EXISTS "main"."Padron_Libres";
CREATE TABLE [Padron_Libres] (
[NumImport] INTEGER  NOT NULL,
[Item] INTEGER  NOT NULL,
[CodigoRutaSuministro] VARCHAR(40)  NULL,
[CodigoSuministro] VARCHAR(30)  NULL,
[NombreSuministro] VARCHAR(70)  NULL,
[DireccionPredio] VARCHAR(100)  NULL DEFAULT "No existe",
[NombreSector] VARCHAR(15)  NULL,
[Tension] VARCHAR(10)  NULL,
[Tarifa] VARCHAR(5)  NULL,
[SistemaElectrico] VARCHAR(30)  NULL,
[ActividadEconomica] VARCHAR(150)  NULL DEFAULT "No existe",
[FactorTension] VARCHAR(10)  NULL DEFAULT "No existe",
[FactorCorriente] VARCHAR(10)  NULL DEFAULT "No existe",
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

-- ----------------------------
-- Table structure for Padron_Moquegua
-- ----------------------------
DROP TABLE IF EXISTS "main"."Padron_Moquegua";
CREATE TABLE [Padron_Moquegua] (
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

-- ----------------------------
-- Table structure for Padron_Tacna
-- ----------------------------
DROP TABLE IF EXISTS "main"."Padron_Tacna";
CREATE TABLE [Padron_Tacna] (
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

-- ----------------------------
-- Table structure for sqlite_sequence
-- ----------------------------
DROP TABLE IF EXISTS "main"."sqlite_sequence";
CREATE TABLE sqlite_sequence(name,seq);
