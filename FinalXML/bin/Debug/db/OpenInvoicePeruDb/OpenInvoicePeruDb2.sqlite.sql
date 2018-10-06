BEGIN TRANSACTION;
CREATE TABLE "TipoPrecios" ([Id] INTEGER, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `TipoPrecios` (Id,Codigo,Descripcion) VALUES (1,'01','Precio unitario (incluye el IGV)'),
 (2,'02','Valor referencial unitario en operaciones no onerosas');
CREATE TABLE "TipoOperaciones" ([Id] INTEGER, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `TipoOperaciones` (Id,Codigo,Descripcion) VALUES (1,'01','Venta lnterna'),
 (2,'02','Exportación'),
 (3,'03','No Domiciliados'),
 (4,'04','Venta Interna – Anticipos'),
 (5,'05','Venta Itinerante'),
 (6,'06','Factura Guía'),
 (7,'07','Venta Arroz Pilado'),
 (8,'08','Factura - Comprobante de Percepción');
CREATE TABLE "TipoImpuestos" ([Id] INTEGER, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `TipoImpuestos` (Id,Codigo,Descripcion) VALUES (1,'10','Gravado - Operación Onerosa'),
 (2,'11','Gravado – Retiro por premio'),
 (3,'12','Gravado – Retiro por donación'),
 (4,'13','Gravado – Retiro'),
 (5,'14','Gravado – Retiro por publicidad'),
 (6,'15','Gravado – Bonificaciones'),
 (7,'16','Gravado – Retiro por entrega a trabajadores'),
 (8,'17','Gravado – IVAP'),
 (9,'20','Exonerado - Operación Onerosa'),
 (10,'21','Exonerado – Transferencia Gratuita'),
 (11,'30','Inafecto - Operación Onerosa'),
 (12,'31','Inafecto – Retiro por Bonificación'),
 (13,'32','Inafecto – Retiro'),
 (14,'33','Inafecto – Retiro por Muestras Médicas'),
 (15,'34','Inafecto - Retiro por Convenio Colectivo'),
 (16,'35','Inafecto – Retiro por premio'),
 (17,'36','Inafecto - Retiro por publicidad'),
 (18,'40','Exportación');
CREATE TABLE "TipoDocumentos" ([Id] INTEGER, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `TipoDocumentos` (Id,Codigo,Descripcion) VALUES (1,'01','Factura'),
 (2,'03','Boleta'),
 (3,'07','Nota de Crédito'),
 (4,'08','Nota de Débito');
CREATE TABLE "TipoDocumentoRelacionados" ([Id] INTEGER, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `TipoDocumentoRelacionados` (Id,Codigo,Descripcion) VALUES (1,'01','FACTURA'),
 (2,'03','BOLETA DE VENTA'),
 (3,'07','NOTA DE CREDITO'),
 (4,'08','NOTA DE DEBITO'),
 (5,'09','GUIA DE REMISIÓN REMITENTE'),
 (6,'13','DOCUMENTO EMITIDO POR BANCOS II.FF. CREDITICIAS Y DE SEGUROS'),
 (7,'18','DOCUMENTOS EMITIDOS POR LAS AFP'),
 (8,'31','GUIA DE REMISIÓN TRANSPORTISTA'),
 (9,'56','COMPROBANTE DE PAGO SEAE');
CREATE TABLE "TipoDocumentoContribuyentes" ([Id] INTEGER, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `TipoDocumentoContribuyentes` (Id,Codigo,Descripcion) VALUES (1,'0','DOC.TRIB.NO.DOM.SIN.RUC'),
 (2,'1','DOC. NACIONAL DE IDENTIDAD'),
 (3,'4','CARNET DE EXTRANJERIA'),
 (4,'6','REG. UNICO DE CONTRIBUYENTES'),
 (5,'7','PASAPORTE'),
 (6,'A','CED. DIPLOMATICA DE IDENTIDAD');
CREATE TABLE "TipoDocumentoAnticipos" ([Id] INTEGER, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `TipoDocumentoAnticipos` (Id,Codigo,Descripcion) VALUES (1,'01','Factura – emitida para corregir error en el RUC'),
 (2,'02','Factura – emitida por anticipos'),
 (3,'03','Boleta de Venta – emitida por anticipos'),
 (4,'04','Ticket de Salida - ENAPU'),
 (5,'05','Código SCOP'),
 (6,'99','Otros');
CREATE TABLE "TipoDiscrepancias" ([Id] INTEGER, [DocumentoAplicado] nvarchar (2) NOT NULL, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `TipoDiscrepancias` (Id,DocumentoAplicado,Codigo,Descripcion) VALUES (1,'07','01','Anulación de la operación'),
 (2,'07','02','Anulación por error en el RUC'),
 (3,'07','03','Corrección por error en la descripción'),
 (4,'07','04','Descuento global'),
 (5,'07','05','Descuento por ítem'),
 (6,'07','06','Devolución total'),
 (7,'07','07','Devolución por ítem'),
 (8,'07','08','Bonificación'),
 (9,'07','09','Disminución en el valor'),
 (10,'07','10','Otros Conceptos'),
 (11,'08','01','Intereses por mora'),
 (12,'08','02','Aumento en el valor'),
 (13,'08','03','Penalidades/otros conceptos');
CREATE TABLE "TipoDatoAdicionales" ([Id] INTEGER, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `TipoDatoAdicionales` (Id,Codigo,Descripcion) VALUES (1,'3000','Detracciones: CODIGO DE BB Y SS SUJETOS A DETRACCION'),
 (2,'3001','Detracciones: NUMERO DE CTA EN EL BN'),
 (3,'3002','Detracciones: Recursos Hidrobiológicos - Nombre y matrícula de la embarcación'),
 (4,'3003','Detracciones: Recursos Hidrobiológicos - Tipo y cantidad de especie vendida'),
 (5,'3004','Detracciones: Recursos Hidrobiológicos - Lugar de descarga'),
 (6,'3005','Detracciones: Recursos Hidrobiológicos - Fecha de descarga'),
 (7,'3006','Detracciones: Transporte Bienes vía terrestre – Numero Registro MTC'),
 (8,'3007','Detracciones: Transporte Bienes vía terrestre – configuración vehicular'),
 (9,'3008','Detracciones: Transporte Bienes vía terrestre – punto de origen'),
 (10,'3009','Detracciones: Transporte Bienes vía terrestre – punto destino'),
 (11,'3010','Detracciones: Transporte Bienes vía terrestre – valor referencial preliminar'),
 (12,'4000','Beneficio hospedajes: Código País de emisión del pasaporte'),
 (13,'4001','Beneficio hospedajes: Código País de residencia del sujeto no domiciliado'),
 (14,'4002','Beneficio Hospedajes: Fecha de ingreso al país'),
 (15,'4003','Beneficio Hospedajes: Fecha de ingreso al establecimiento'),
 (16,'4004','Beneficio Hospedajes: Fecha de salida del establecimiento'),
 (17,'4005','Beneficio Hospedajes: Número de días de permanencia'),
 (18,'4006','Beneficio Hospedajes: Fecha de consumo'),
 (19,'4007','Beneficio Hospedajes: Paquete turístico - Nombres y Apellidos del Huésped'),
 (20,'4008','Beneficio Hospedajes: Paquete turístico – Tipo documento identidad del huésped'),
 (21,'4009','Beneficio Hospedajes: Paquete turístico – Numero de documento identidad de huésped'),
 (22,'5000','Proveedores Estado: Número de Expediente'),
 (23,'5001','Proveedores Estado: Código de unidad ejecutora'),
 (24,'5002','Proveedores Estado: N° de proceso de selección'),
 (25,'5003','Proveedores Estado: N° de contrato'),
 (26,'6000','Comercialización de Oro: Código Único Concesión Minera'),
 (27,'6001','Comercialización de Oro: N° declaración compromiso'),
 (28,'6002','Comercialización de Oro: N° Reg. Especial .Comerci. Oro'),
 (29,'6003','Comercialización de Oro: N° Resolución que autoriza Planta de Beneficio'),
 (30,'6004','Comercialización de Oro: Ley Mineral (% concent. oro)');
CREATE TABLE "Monedas" ([Id] INTEGER, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `Monedas` (Id,Codigo,Descripcion) VALUES (1,'PEN','Soles'),
 (2,'USD','Dólares Americanos'),
 (3,'EUR','Euro');
CREATE TABLE "ModalidadTransportes" ([Id] INTEGER, [Codigo] nvarchar (5) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `ModalidadTransportes` (Id,Codigo,Descripcion) VALUES (1,'01','Transporte público'),
 (2,'02','Transporte privado');
CREATE TABLE "History_82c009b41631-48579635f1ff64eb62d9" ([Id] INTEGER, [Hash] nvarchar NOT NULL, [Context] nvarchar, [CreateDate] datetime NOT NULL, PRIMARY KEY(Id));
INSERT INTO `History_82c009b41631-48579635f1ff64eb62d9` (Id,Hash,Context,CreateDate) VALUES (1,'X5Z7zvNxDNOmdYBW70H5vL/USz+qpqzCTdnWr8a6xd9ZAOAY3PFNKoHZRqCSRzh1QPRNx8x4ZGqPsvQlDgDAPw==','FinalXML.OpenInvoicePeruDb','2016-10-29 01:02:32.4930266Z');
CREATE TABLE "DireccionesSunat" ([Id] INTEGER, [Codigo] nvarchar (50) NOT NULL, [Descripcion] nvarchar (250) NOT NULL, PRIMARY KEY(Id));
INSERT INTO `DireccionesSunat` (Id,Codigo,Descripcion) VALUES (1,'Desarrollo','https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService'),
 (2,'Homologación','https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService'),
 (3,'Producción','https://www.sunat.gob.pe/ol-ti-itcpfegem/billService'),
 (4,'Retención/Percepción Desarrollo','https://e-beta.sunat.gob.pe/ol-ti-itemision-otroscpe-gem-beta/billService'),
 (5,'Retención/Percepción Produccion','https://www.sunat.gob.pe:443/ol-ti-itemision-otroscpe-gem/billService');
COMMIT;
