/*
Navicat SQLite Data Transfer

Source Server         : Electrosur
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2018-12-16 19:57:09
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for Historico
-- ----------------------------
DROP TABLE IF EXISTS "main"."Historico";
CREATE TABLE [Historico] (
[Id] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
[NumImport] INTEGER  NOT NULL,
[Mes] VARCHAR(5)  NULL,
[CodigoEmpresa] VARCHAR(5)  NULL,
[CodigoSuministro] VARCHAR(12)  NULL,
[CodigoBarraCompra] VARCHAR(20)  NULL,
[FechaHora] VARCHAR(13)  NULL,
[EA] VARCHAR(50)  NULL
);
