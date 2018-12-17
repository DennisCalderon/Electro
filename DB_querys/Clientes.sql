/*
Navicat SQLite Data Transfer

Source Server         : Electrosur
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2018-12-16 19:57:16
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for Clientes
-- ----------------------------
DROP TABLE IF EXISTS "main"."Clientes";
CREATE TABLE [Clientes] (
[NumImport] INTEGER  NOT NULL,
[Item] INTEGER  NOT NULL,
[CodigoRutaSuministro] VARCHAR(40)  NULL,
[CodigoSuministro] VARCHAR(30)  NULL,
[NombreSuministro] VARCHAR(70)  NULL,
[DireccionPredio] VARCHAR(100)  NULL,
[PotenciaContratadaHFP] VARCHAR(10)  NULL,
[FechaInicio] VARCHAR(20)  NULL,
[DireccionElectrica] VARCHAR(15)  NULL,
[NumeroDNI] VARCHAR(12)  NULL,
[NumeroRUC] VARCHAR(15)  NULL,
[Telefono] VARCHAR(40)  NULL,
[NombreSector] VARCHAR(15)  NULL,
[TipoAlimentacion] VARCHAR(20)  NULL,
[PuntoConexion] VARCHAR(15)  NULL,
[SimboloImpresionRecibo] VARCHAR(10)  NULL,
[TipoRedElectrica] VARCHAR(15)  NULL,
[TipoSistema] VARCHAR(10)  NULL,
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
[AnoFabricacion] VARCHAR(10)  NULL,
[Hilos] VARCHAR(3)  NULL,
[Fases] VARCHAR(3)  NULL,
[ConstanteRotacion] VARCHAR(8)  NULL,
[IP] VARCHAR(16)  NULL,
[Blanco1] VARCHAR(10)  NULL,
[Blanco2] VARCHAR(10)  NULL,
[Blanco3] VARCHAR(10)  NULL,
[1] VARCHAR(15)  NULL,
[2] VARCHAR(15)  NULL,
[3] VARCHAR(15)  NULL,
[4] VARCHAR(20)  NULL,
[5] VARCHAR(10)  NULL,
[6] VARCHAR(15)  NULL,
[7] VARCHAR(15)  NULL,
[10] VARCHAR(15)  NULL,
PRIMARY KEY ([NumImport],[Item],[CodigoRutaSuministro])
);
