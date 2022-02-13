/***************************************************************
	Database for the Home Broker Simulator Application.
					API Side Database
    By Sérgio Lacerda: https://github.com/sergio-lacerda
***************************************************************/

/* --- Creating Database & Tables --- */
Drop Database If Exists dbhomebrokerapi;
Create Database dbhomebrokerapi;
Use dbhomebrokerapi;

Create Table Empresas (
	Id Int Unsigned Not Null Auto_Increment Primary Key,
    Nome Varchar(50) Not Null
);

Create Table Corretoras (
	Id Int Unsigned Not Null Auto_Increment Primary Key,
    Nome Varchar(50) Not Null
);

Create Table Acoes (
	Id Int Unsigned Not Null Auto_Increment Primary Key,
    Ticker Varchar(10) Not Null Unique,
    IdEmpresa Int Unsigned Not Null,
    PrecoBaseSimulacao Decimal(7,2) Not Null Default 12.53
);	

Alter Table Acoes
Add Constraint fk_Acao_Empresa Foreign Key (IdEmpresa) References Empresas (Id);

Create Table Ofertas (
	Id Int Unsigned Not Null Auto_Increment Primary Key,
    Tipo Char(1) Not Null,
    IdAcao Int Unsigned Not Null,
    IdCorretora Int Unsigned Not Null,
    Quantidade Int Unsigned Not Null,
    PrecoUnitario Decimal(7,2) Not Null,
    DataHora DateTime Not Null Default Now()
);

Alter Table Ofertas
Add Constraint fk_Oferta_Acao Foreign Key (IdAcao) References Acoes (Id),
Add Constraint fk_Oferta_Corretora Foreign Key (IdCorretora) References Corretoras (Id);

Create table Investidores (
	Cpf Int Unsigned Not Null Primary Key,
    Nome Varchar(50) Not Null
);

Create table Contas (
	Id Int Unsigned Not Null Auto_Increment Primary Key,
    IdCorretora Int Unsigned Not Null,
    Agencia Int Unsigned Not Null Default 1,
    Conta Int Unsigned Not Null,
    IdCliente Int Unsigned Not Null,
    
    
    Saldo Decimal(12, 2) Not Null,
    AssinaturaEletronica Varchar(15) Not Null
);

Alter Table Contas
Add Constraint fk_Conta_Corretora Foreign Key (IdCorretora) References Corretoras (Id),
Add Constraint fk_Conta_Cliente Foreign Key (IdCliente) References Clientes (Id);






/* --- Adding Data Into Tables --- */
Insert Into Empresas (Id, Nome) Values (1, '3M Company');
Insert Into Empresas (Id, Nome) Values (2, '3R Petroleum');
Insert Into Empresas (Id, Nome) Values (3, 'Abbott Laboratories');
Insert Into Empresas (Id, Nome) Values (4, 'Accenture plc');
Insert Into Empresas (Id, Nome) Values (5, 'Adobe Systems Incorporated');
Insert Into Empresas (Id, Nome) Values (6, 'Aeris');
Insert Into Empresas (Id, Nome) Values (7, 'AES Brasil');
Insert Into Empresas (Id, Nome) Values (8, 'Afluente T');
Insert Into Empresas (Id, Nome) Values (9, 'AirBnb');
Insert Into Empresas (Id, Nome) Values (10, 'Aliansce Sonae');
Insert Into Empresas (Id, Nome) Values (11, 'Alliar');
Insert Into Empresas (Id, Nome) Values (12, 'Allied Tecnologia');
Insert Into Empresas (Id, Nome) Values (13, 'Allpark');
Insert Into Empresas (Id, Nome) Values (14, 'Alpargatas');
Insert Into Empresas (Id, Nome) Values (15, 'Alper');
Insert Into Empresas (Id, Nome) Values (16, 'Alphabet');
Insert Into Empresas (Id, Nome) Values (17, 'Alphaville S.A.');
Insert Into Empresas (Id, Nome) Values (18, 'Altria Group, Inc.');
Insert Into Empresas (Id, Nome) Values (19, 'Alupar Investimento');
Insert Into Empresas (Id, Nome) Values (20, 'Amazon.com Inc');
Insert Into Empresas (Id, Nome) Values (21, 'Ambipar');
Insert Into Empresas (Id, Nome) Values (22, 'American Express');
Insert Into Empresas (Id, Nome) Values (23, 'American International Group, Inc.');
Insert Into Empresas (Id, Nome) Values (24, 'Anima');
Insert Into Empresas (Id, Nome) Values (25, 'Apple Inc');
Insert Into Empresas (Id, Nome) Values (26, 'Arcelor');
Insert Into Empresas (Id, Nome) Values (27, 'Arezzo');
Insert Into Empresas (Id, Nome) Values (28, 'Assaí');
Insert Into Empresas (Id, Nome) Values (29, 'AT&T Inc.');
Insert Into Empresas (Id, Nome) Values (30, 'Athena Saúde');
Insert Into Empresas (Id, Nome) Values (31, 'Atma Participações');
Insert Into Empresas (Id, Nome) Values (32, 'Automatic Data Processing Inc.');
Insert Into Empresas (Id, Nome) Values (33, 'Avon');
Insert Into Empresas (Id, Nome) Values (34, 'Banco do Brasil');
Insert Into Empresas (Id, Nome) Values (35, 'Banco Inter');
Insert Into Empresas (Id, Nome) Values (36, 'Banco Mercantil de Investimentos');
Insert Into Empresas (Id, Nome) Values (37, 'Banco Modal');
Insert Into Empresas (Id, Nome) Values (38, 'Banco Pan');
Insert Into Empresas (Id, Nome) Values (39, 'Bank of America Corporation');
Insert Into Empresas (Id, Nome) Values (40, 'Banpara');
Insert Into Empresas (Id, Nome) Values (41, 'Banrisul');
Insert Into Empresas (Id, Nome) Values (42, 'Bardella');
Insert Into Empresas (Id, Nome) Values (43, 'Battistella');
Insert Into Empresas (Id, Nome) Values (44, 'Baumer');
Insert Into Empresas (Id, Nome) Values (45, 'BB Seguridade');
Insert Into Empresas (Id, Nome) Values (46, 'Bemobi');
Insert Into Empresas (Id, Nome) Values (47, 'Berkshire Hathaway Inc.');
Insert Into Empresas (Id, Nome) Values (48, 'Beyond Meat');
Insert Into Empresas (Id, Nome) Values (49, 'Biomm');
Insert Into Empresas (Id, Nome) Values (50, 'Biosev');
Insert Into Empresas (Id, Nome) Values (51, 'Biotoscana');
Insert Into Empresas (Id, Nome) Values (52, 'Blau Farmacêutica');
Insert Into Empresas (Id, Nome) Values (53, 'BM Brascam Lajes Corporativas');
Insert Into Empresas (Id, Nome) Values (54, 'BMG');
Insert Into Empresas (Id, Nome) Values (55, 'Boa Safra');
Insert Into Empresas (Id, Nome) Values (56, 'Boa Vista SCPC');
Insert Into Empresas (Id, Nome) Values (57, 'Boeing');
Insert Into Empresas (Id, Nome) Values (58, 'BR Partners');
Insert Into Empresas (Id, Nome) Values (59, 'BR Properties');
Insert Into Empresas (Id, Nome) Values (60, 'Bradesco');
Insert Into Empresas (Id, Nome) Values (61, 'Bradespar');
Insert Into Empresas (Id, Nome) Values (62, 'Brasil Brokers');
Insert Into Empresas (Id, Nome) Values (63, 'Brasilagro');
Insert Into Empresas (Id, Nome) Values (64, 'Braskem');
Insert Into Empresas (Id, Nome) Values (65, 'BRB Banco');
Insert Into Empresas (Id, Nome) Values (66, 'BRF');
Insert Into Empresas (Id, Nome) Values (67, 'Bristolmyers');
Insert Into Empresas (Id, Nome) Values (68, 'brMalls');
Insert Into Empresas (Id, Nome) Values (69, 'C&A');
Insert Into Empresas (Id, Nome) Values (70, 'Caesars Entt');
Insert Into Empresas (Id, Nome) Values (71, 'Caixa Seguridade');
Insert Into Empresas (Id, Nome) Values (72, 'CAMIL');
Insert Into Empresas (Id, Nome) Values (73, 'Carrefour');
Insert Into Empresas (Id, Nome) Values (74, 'Casan');
Insert Into Empresas (Id, Nome) Values (75, 'Caterpillar');
Insert Into Empresas (Id, Nome) Values (76, 'CEB');
Insert Into Empresas (Id, Nome) Values (77, 'Cedro');
Insert Into Empresas (Id, Nome) Values (78, 'CEEE-D');
Insert Into Empresas (Id, Nome) Values (79, 'Ceee-gt');
Insert Into Empresas (Id, Nome) Values (80, 'CEG');
Insert Into Empresas (Id, Nome) Values (81, 'Celesc');
Insert Into Empresas (Id, Nome) Values (82, 'Celpe');
Insert Into Empresas (Id, Nome) Values (83, 'Celulose Irani');
Insert Into Empresas (Id, Nome) Values (84, 'Cemig');
Insert Into Empresas (Id, Nome) Values (85, 'CESP');
Insert Into Empresas (Id, Nome) Values (86, 'Chevron');
Insert Into Empresas (Id, Nome) Values (87, 'Churchill Dw');
Insert Into Empresas (Id, Nome) Values (88, 'Cia Hering');
Insert Into Empresas (Id, Nome) Values (89, 'Cisco Systems Inc');
Insert Into Empresas (Id, Nome) Values (90, 'Citigroup');
Insert Into Empresas (Id, Nome) Values (91, 'CM Hospitalar');
Insert Into Empresas (Id, Nome) Values (92, 'Coca-Cola');
Insert Into Empresas (Id, Nome) Values (93, 'Coelce');
Insert Into Empresas (Id, Nome) Values (94, 'Cogna');
Insert Into Empresas (Id, Nome) Values (95, 'Colgate');
Insert Into Empresas (Id, Nome) Values (96, 'Comcast Corporation');
Insert Into Empresas (Id, Nome) Values (97, 'Comgás');
Insert Into Empresas (Id, Nome) Values (98, 'Compass');
Insert Into Empresas (Id, Nome) Values (99, 'Copel');
Insert Into Empresas (Id, Nome) Values (100, 'Cophillips');
Insert Into Empresas (Id, Nome) Values (101, 'Coteminas');
Insert Into Empresas (Id, Nome) Values (102, 'CPFL Energia');
Insert Into Empresas (Id, Nome) Values (103, 'CPFL Renovav');
Insert Into Empresas (Id, Nome) Values (104, 'Cruzeiro Do Sul Educacional');
Insert Into Empresas (Id, Nome) Values (105, 'CSN');
Insert Into Empresas (Id, Nome) Values (106, 'CSN Mineração');
Insert Into Empresas (Id, Nome) Values (107, 'CSU CardSyst');
Insert Into Empresas (Id, Nome) Values (108, 'Cury');
Insert Into Empresas (Id, Nome) Values (109, 'CVC');
Insert Into Empresas (Id, Nome) Values (110, 'Cyrela Realty');
Insert Into Empresas (Id, Nome) Values (111, 'Cyrusone Inc');
Insert Into Empresas (Id, Nome) Values (112, 'd1000');
Insert Into Empresas (Id, Nome) Values (113, 'Devant Recebíveis Imobiliários');
Insert Into Empresas (Id, Nome) Values (114, 'Dexxos Part');
Insert Into Empresas (Id, Nome) Values (115, 'Dimed');
Insert Into Empresas (Id, Nome) Values (116, 'Direcional');
Insert Into Empresas (Id, Nome) Values (117, 'Dommo');
Insert Into Empresas (Id, Nome) Values (118, 'Dotz');
Insert Into Empresas (Id, Nome) Values (119, 'Draftkings');
Insert Into Empresas (Id, Nome) Values (120, 'eBay');
Insert Into Empresas (Id, Nome) Values (121, 'Eletromídia');
Insert Into Empresas (Id, Nome) Values (122, 'Enauta Part');
Insert Into Empresas (Id, Nome) Values (123, 'Energisa MT');
Insert Into Empresas (Id, Nome) Values (124, 'Engie Brasil');
Insert Into Empresas (Id, Nome) Values (125, 'Enjoei');
Insert Into Empresas (Id, Nome) Values (126, 'Espaçolaser');
Insert Into Empresas (Id, Nome) Values (127, 'Estrela');
Insert Into Empresas (Id, Nome) Values (128, 'Eucatex');
Insert Into Empresas (Id, Nome) Values (129, 'Even');
Insert Into Empresas (Id, Nome) Values (130, 'Exxon Mobil');
Insert Into Empresas (Id, Nome) Values (131, 'Ez Tec');
Insert Into Empresas (Id, Nome) Values (132, 'Facebook Inc');
Insert Into Empresas (Id, Nome) Values (133, 'Fedex Corp');
Insert Into Empresas (Id, Nome) Values (134, 'Ferbasa');
Insert Into Empresas (Id, Nome) Values (135, 'Fleury');
Insert Into Empresas (Id, Nome) Values (136, 'Focus Energia');
Insert Into Empresas (Id, Nome) Values (137, 'Ford Motors');
Insert Into Empresas (Id, Nome) Values (138, 'Freeport');
Insert Into Empresas (Id, Nome) Values (139, 'Gafisa');
Insert Into Empresas (Id, Nome) Values (140, 'GE');
Insert Into Empresas (Id, Nome) Values (141, 'General Shopping');
Insert Into Empresas (Id, Nome) Values (142, 'Ger Paranapanema');
Insert Into Empresas (Id, Nome) Values (143, 'Gerdau');
Insert Into Empresas (Id, Nome) Values (144, 'GetNinjas');
Insert Into Empresas (Id, Nome) Values (145, 'Goldman Sachs');
Insert Into Empresas (Id, Nome) Values (146, 'Gradiente');
Insert Into Empresas (Id, Nome) Values (147, 'Grazziotin');
Insert Into Empresas (Id, Nome) Values (148, 'Grendene');
Insert Into Empresas (Id, Nome) Values (149, 'Grupo JSL');
Insert Into Empresas (Id, Nome) Values (150, 'Grupo Mateus');
Insert Into Empresas (Id, Nome) Values (151, 'Grupo Soma');
Insert Into Empresas (Id, Nome) Values (152, 'Grupos GPS');
Insert Into Empresas (Id, Nome) Values (153, 'Halliburton');
Insert Into Empresas (Id, Nome) Values (154, 'HBR Realty');
Insert Into Empresas (Id, Nome) Values (155, 'Hedge Investiments');
Insert Into Empresas (Id, Nome) Values (156, 'Helbor');
Insert Into Empresas (Id, Nome) Values (157, 'Hidrovias do Brasil');
Insert Into Empresas (Id, Nome) Values (158, 'Home Depot');
Insert Into Empresas (Id, Nome) Values (159, 'Honeywell');
Insert Into Empresas (Id, Nome) Values (160, 'Hospital Care Caledonia');
Insert Into Empresas (Id, Nome) Values (161, 'Hoteis Othon');
Insert Into Empresas (Id, Nome) Values (162, 'HP Company');
Insert Into Empresas (Id, Nome) Values (163, 'Hypera Pharma');
Insert Into Empresas (Id, Nome) Values (164, 'IBM');
Insert Into Empresas (Id, Nome) Values (165, 'Iguatemi');
Insert Into Empresas (Id, Nome) Values (166, 'Inepar');
Insert Into Empresas (Id, Nome) Values (167, 'Infracommerce');
Insert Into Empresas (Id, Nome) Values (168, 'Instituto Hermes Pardini SA');
Insert Into Empresas (Id, Nome) Values (169, 'Intel Corporation');
Insert Into Empresas (Id, Nome) Values (170, 'Intelbras SA');
Insert Into Empresas (Id, Nome) Values (171, 'Iochpe-Maxion');
Insert Into Empresas (Id, Nome) Values (172, 'IRB Brasil RE');
Insert Into Empresas (Id, Nome) Values (173, 'ISA CTEEP');
Insert Into Empresas (Id, Nome) Values (174, 'Itaú Unibanco');
Insert Into Empresas (Id, Nome) Values (175, 'Itaúsa');
Insert Into Empresas (Id, Nome) Values (176, 'Jalles Machado');
Insert Into Empresas (Id, Nome) Values (177, 'JBS');
Insert Into Empresas (Id, Nome) Values (178, 'JHSF');
Insert Into Empresas (Id, Nome) Values (179, 'Johnson');
Insert Into Empresas (Id, Nome) Values (180, 'JPMorgan');
Insert Into Empresas (Id, Nome) Values (181, 'Karsten');
Insert Into Empresas (Id, Nome) Values (182, 'Kingsoft Chl');
Insert Into Empresas (Id, Nome) Values (183, 'Klabin S/A');
Insert Into Empresas (Id, Nome) Values (184, 'Kora Saúde');
Insert Into Empresas (Id, Nome) Values (185, 'Lavvi Incorporadora');
Insert Into Empresas (Id, Nome) Values (186, 'Le Lis Blanc');
Insert Into Empresas (Id, Nome) Values (187, 'Linx');
Insert Into Empresas (Id, Nome) Values (188, 'Localiza');
Insert Into Empresas (Id, Nome) Values (189, 'Locamerica');
Insert Into Empresas (Id, Nome) Values (190, 'Locaweb');
Insert Into Empresas (Id, Nome) Values (191, 'Lockheed');
Insert Into Empresas (Id, Nome) Values (192, 'Log');
Insert Into Empresas (Id, Nome) Values (193, 'Lojas Americanas');
Insert Into Empresas (Id, Nome) Values (194, 'Lojas Renner');
Insert Into Empresas (Id, Nome) Values (195, 'LPS Brasil');
Insert Into Empresas (Id, Nome) Values (196, 'Lupatech');
Insert Into Empresas (Id, Nome) Values (197, 'Magazine Luiza');
Insert Into Empresas (Id, Nome) Values (198, 'Marfrig');
Insert Into Empresas (Id, Nome) Values (199, 'Marisa');
Insert Into Empresas (Id, Nome) Values (200, 'Mastercard');
Insert Into Empresas (Id, Nome) Values (201, 'Mater Dei');
Insert Into Empresas (Id, Nome) Values (202, 'MC Donald`s');
Insert Into Empresas (Id, Nome) Values (203, 'MDiasBranco');
Insert Into Empresas (Id, Nome) Values (204, 'Medical P Tr');
Insert Into Empresas (Id, Nome) Values (205, 'Méliuz');
Insert Into Empresas (Id, Nome) Values (206, 'Melnick');
Insert Into Empresas (Id, Nome) Values (207, 'Mercantil do Brasil Financeira');
Insert Into Empresas (Id, Nome) Values (208, 'Merck');
Insert Into Empresas (Id, Nome) Values (209, 'Mérito Investimentos');
Insert Into Empresas (Id, Nome) Values (210, 'Metal Leve');
Insert Into Empresas (Id, Nome) Values (211, 'Microsoft Corporation');
Insert Into Empresas (Id, Nome) Values (212, 'Minerva');
Insert Into Empresas (Id, Nome) Values (213, 'Mitre Realty');
Insert Into Empresas (Id, Nome) Values (214, 'MMX Mineração');
Insert Into Empresas (Id, Nome) Values (215, 'Mobly');
Insert Into Empresas (Id, Nome) Values (216, 'Morgan Stanley');
Insert Into Empresas (Id, Nome) Values (217, 'Mosaico');
Insert Into Empresas (Id, Nome) Values (218, 'Moura Dubeux');
Insert Into Empresas (Id, Nome) Values (219, 'Movida');
Insert Into Empresas (Id, Nome) Values (220, 'MRV Engenharia');
Insert Into Empresas (Id, Nome) Values (221, 'Multiplan');
Insert Into Empresas (Id, Nome) Values (222, 'Mundial');
Insert Into Empresas (Id, Nome) Values (223, 'Natura');
Insert Into Empresas (Id, Nome) Values (224, 'Neoenergia');
Insert Into Empresas (Id, Nome) Values (225, 'Neogrid');
Insert Into Empresas (Id, Nome) Values (226, 'Netflix');
Insert Into Empresas (Id, Nome) Values (227, 'Nike');
Insert Into Empresas (Id, Nome) Values (228, 'OceanPact');
Insert Into Empresas (Id, Nome) Values (229, 'OdontoPrev');
Insert Into Empresas (Id, Nome) Values (230, 'OI');
Insert Into Empresas (Id, Nome) Values (231, 'Oracle');
Insert Into Empresas (Id, Nome) Values (232, 'Orizon');
Insert Into Empresas (Id, Nome) Values (233, 'OSX Brasil');
Insert Into Empresas (Id, Nome) Values (234, 'Ourofino S/A');
Insert Into Empresas (Id, Nome) Values (235, 'PagSeguro');
Insert Into Empresas (Id, Nome) Values (236, 'Pague Menos');
Insert Into Empresas (Id, Nome) Values (237, 'Pão de Açúcar');
Insert Into Empresas (Id, Nome) Values (238, 'Paranapanema');
Insert Into Empresas (Id, Nome) Values (239, 'PDG Realty');
Insert Into Empresas (Id, Nome) Values (240, 'Penn Nationl');
Insert Into Empresas (Id, Nome) Values (241, 'PepsiCo Inc');
Insert Into Empresas (Id, Nome) Values (242, 'Pet Manguinhos');
Insert Into Empresas (Id, Nome) Values (243, 'Petrobras');
Insert Into Empresas (Id, Nome) Values (244, 'Petrobras Distribuidora');
Insert Into Empresas (Id, Nome) Values (245, 'PetroRecôncavo Geral SA');
Insert Into Empresas (Id, Nome) Values (246, 'PETRORIO');
Insert Into Empresas (Id, Nome) Values (247, 'Petz');
Insert Into Empresas (Id, Nome) Values (248, 'Pfizer');
Insert Into Empresas (Id, Nome) Values (249, 'Plano & Plano');
Insert Into Empresas (Id, Nome) Values (250, 'Porto Seguro');
Insert Into Empresas (Id, Nome) Values (251, 'Positivo Inf');
Insert Into Empresas (Id, Nome) Values (252, 'Procter Gamble');
Insert Into Empresas (Id, Nome) Values (253, 'Qualcomm');
Insert Into Empresas (Id, Nome) Values (254, 'Qualicorp');
Insert Into Empresas (Id, Nome) Values (255, 'Quero-Quero');
Insert Into Empresas (Id, Nome) Values (256, 'Randon Part');
Insert Into Empresas (Id, Nome) Values (257, 'RD');
Insert Into Empresas (Id, Nome) Values (258, 'Real Estate Capital');
Insert Into Empresas (Id, Nome) Values (259, 'Renaova');
Insert Into Empresas (Id, Nome) Values (260, 'Renova');
Insert Into Empresas (Id, Nome) Values (261, 'Rio Alto Energias Renováveis');
Insert Into Empresas (Id, Nome) Values (262, 'Riva 9');
Insert Into Empresas (Id, Nome) Values (263, 'Rodobens');
Insert Into Empresas (Id, Nome) Values (264, 'Rossi Resid');
Insert Into Empresas (Id, Nome) Values (265, 'Sabesp');
Insert Into Empresas (Id, Nome) Values (266, 'Sanepar');
Insert Into Empresas (Id, Nome) Values (267, 'Santander BR');
Insert Into Empresas (Id, Nome) Values (268, 'Santos - Brasil');
Insert Into Empresas (Id, Nome) Values (269, 'Sao Carlos');
Insert Into Empresas (Id, Nome) Values (270, 'São Martinho');
Insert Into Empresas (Id, Nome) Values (271, 'Saraiva Livr');
Insert Into Empresas (Id, Nome) Values (272, 'Schlumberger');
Insert Into Empresas (Id, Nome) Values (273, 'Sea Ltd');
Insert Into Empresas (Id, Nome) Values (274, 'Sequoia');
Insert Into Empresas (Id, Nome) Values (275, 'Ser Educacional');
Insert Into Empresas (Id, Nome) Values (276, 'Shopify Inc');
Insert Into Empresas (Id, Nome) Values (277, 'Simpar');
Insert Into Empresas (Id, Nome) Values (278, 'Smiles');
Insert Into Empresas (Id, Nome) Values (279, 'Snowflake');
Insert Into Empresas (Id, Nome) Values (280, 'Square Inc');
Insert Into Empresas (Id, Nome) Values (281, 'Starbucks');
Insert Into Empresas (Id, Nome) Values (282, 'Sun Commun');
Insert Into Empresas (Id, Nome) Values (283, 'Suzano Holding');
Insert Into Empresas (Id, Nome) Values (284, 'Suzano Papel');
Insert Into Empresas (Id, Nome) Values (285, 'Taesa');
Insert Into Empresas (Id, Nome) Values (286, 'Tecnisa');
Insert Into Empresas (Id, Nome) Values (287, 'Teladochealt');
Insert Into Empresas (Id, Nome) Values (288, 'Telebras');
Insert Into Empresas (Id, Nome) Values (289, 'Telefônica Brasil S.A');
Insert Into Empresas (Id, Nome) Values (290, 'The Bank of New York Mellon Corporation');
Insert Into Empresas (Id, Nome) Values (291, 'Tim Participações');
Insert Into Empresas (Id, Nome) Values (292, 'Totvs');
Insert Into Empresas (Id, Nome) Values (293, 'Track & Field');
Insert Into Empresas (Id, Nome) Values (294, 'Trade Desk');
Insert Into Empresas (Id, Nome) Values (295, 'TREND CHINA');
Insert Into Empresas (Id, Nome) Values (296, 'Triple Play');
Insert Into Empresas (Id, Nome) Values (297, 'Ultrapar');
Insert Into Empresas (Id, Nome) Values (298, 'Unipar');
Insert Into Empresas (Id, Nome) Values (299, 'Unity Softwr');
Insert Into Empresas (Id, Nome) Values (300, 'UPS');
Insert Into Empresas (Id, Nome) Values (301, 'Urca Prime');
Insert Into Empresas (Id, Nome) Values (302, 'Vale');
Insert Into Empresas (Id, Nome) Values (303, 'Vamos');
Insert Into Empresas (Id, Nome) Values (304, 'Verizon');
Insert Into Empresas (Id, Nome) Values (305, 'Via Varejo');
Insert Into Empresas (Id, Nome) Values (306, 'Visa');
Insert Into Empresas (Id, Nome) Values (307, 'Vittia Fertilizantes');
Insert Into Empresas (Id, Nome) Values (308, 'Vivara');
Insert Into Empresas (Id, Nome) Values (309, 'Walmart');
Insert Into Empresas (Id, Nome) Values (310, 'Wells Fargo');
Insert Into Empresas (Id, Nome) Values (311, 'Westwing');
Insert Into Empresas (Id, Nome) Values (312, 'Whirlpool');
Insert Into Empresas (Id, Nome) Values (313, 'Whirpool');
Insert Into Empresas (Id, Nome) Values (314, 'Xerox');
Insert Into Empresas (Id, Nome) Values (315, 'YDUQS');
Insert Into Empresas (Id, Nome) Values (316, 'Zynga Inc');

Insert Into Corretoras (Id, Nome) Values (1, 'AGORA CTVM S/A');
Insert Into Corretoras (Id, Nome) Values (2, 'ATIVA INVESTIMENTOS S.A. CTCV');
Insert Into Corretoras (Id, Nome) Values (3, 'BANCO ABN AMRO S/A');
Insert Into Corretoras (Id, Nome) Values (4, 'BANRISUL S/A CVMC');
Insert Into Corretoras (Id, Nome) Values (5, 'BB BANCO DE INVESTIMENTO S/A');
Insert Into Corretoras (Id, Nome) Values (6, 'BGC LIQUIDEZ DTVM');
Insert Into Corretoras (Id, Nome) Values (7, 'BRADESCO S/A CTVM');
Insert Into Corretoras (Id, Nome) Values (8, 'BTG PACTUAL CTVM S.A.');
Insert Into Corretoras (Id, Nome) Values (9, 'C6 CTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (10, 'CITIGROUP GMB CCTVM S.A.');
Insert Into Corretoras (Id, Nome) Values (11, 'CLEAR CORRETORA - GRUPO XP');
Insert Into Corretoras (Id, Nome) Values (12, 'CM CAPITAL MARKETS CCTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (13, 'CREDIT SUISSE BRASIL S.A. CTVM');
Insert Into Corretoras (Id, Nome) Values (14, 'ELITE CCVM LTDA.');
Insert Into Corretoras (Id, Nome) Values (15, 'FATOR S.A. CV');
Insert Into Corretoras (Id, Nome) Values (16, 'GENIAL INSTITUCIONAL CCTVM S.A.');
Insert Into Corretoras (Id, Nome) Values (17, 'GENIAL INVESTIMENTOS CVM S.A.');
Insert Into Corretoras (Id, Nome) Values (18, 'GOLDMAN SACHS DO BRASIL CTVM');
Insert Into Corretoras (Id, Nome) Values (19, 'GUIDE INVESTIMENTOS S.A. CV');
Insert Into Corretoras (Id, Nome) Values (20, 'H.COMMCOR DTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (21, 'ICAP DO BRASIL CTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (22, 'IDEAL CTVM SA');
Insert Into Corretoras (Id, Nome) Values (23, 'ITAU CV S/A');
Insert Into Corretoras (Id, Nome) Values (24, 'J. P. MORGAN CCVM S.A.');
Insert Into Corretoras (Id, Nome) Values (25, 'J. SAFRA CVC LTDA.');
Insert Into Corretoras (Id, Nome) Values (26, 'MERC. DO BRASIL COR. S.A. CTVM');
Insert Into Corretoras (Id, Nome) Values (27, 'MERRILL LYNCH S/A CTVM');
Insert Into Corretoras (Id, Nome) Values (28, 'MIRAE ASSET WEALTH MANAGEMENT (BRASIL) CCTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (29, 'MODAL DTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (30, 'MORGAN STANLEY CTVM S/A');
Insert Into Corretoras (Id, Nome) Values (31, 'NECTON INVESTIMENTOS S.A. CVMC');
Insert Into Corretoras (Id, Nome) Values (32, 'NOVA FUTURA CTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (33, 'NU INVEST CORRETORA DE VALORES S.A');
Insert Into Corretoras (Id, Nome) Values (34, 'ÓRAMA DTVM S.A.');
Insert Into Corretoras (Id, Nome) Values (35, 'PLANNER CV S.A');
Insert Into Corretoras (Id, Nome) Values (36, 'RB CAPITAL DTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (37, 'RENASCENÇA DTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (38, 'SANTANDER CCVM S/A');
Insert Into Corretoras (Id, Nome) Values (39, 'SINGULARE CTVM S/A');
Insert Into Corretoras (Id, Nome) Values (40, 'STONEX DISTRIBUIDORA DE TITULOS E VALORES MOBILIARIOS LTDA');
Insert Into Corretoras (Id, Nome) Values (41, 'TERRA INVESTIMENTOS DTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (42, 'TORO CVTM LTDA');
Insert Into Corretoras (Id, Nome) Values (43, 'TULLETT PREBON BRASIL CVC LTDA');
Insert Into Corretoras (Id, Nome) Values (44, 'UBS BRASIL CCTVM S/A');
Insert Into Corretoras (Id, Nome) Values (45, 'VOTORANTIM CTVM LTDA');
Insert Into Corretoras (Id, Nome) Values (46, 'XP INVESTIMENTOS CCTVM S/A');
Insert Into Corretoras (Id, Nome) Values (47, 'FATPIG INVEST DVTM LTDA');

Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (1, 'AALR3', 11, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (2, 'AAPL34', 25, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (3, 'ABTT34', 3, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (4, 'ACNB34', 4, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (5, 'ADBE34', 5, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (6, 'ADPR34', 32, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (7, 'AERI3', 6, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (8, 'AESB3', 7, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (9, 'AFLT3', 8, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (10, 'AGRO3', 63, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (11, 'AIGB34', 23, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (12, 'AIRB34', 9, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (13, 'ALLD3', 12, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (14, 'ALPA3', 14, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (15, 'ALPA4', 14, 30.11);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (16, 'ALPK3', 13, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (17, 'ALSO3', 10, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (18, 'ALUP11', 19, 24.76);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (19, 'ALUP3', 19, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (20, 'ALUP4', 19, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (21, 'AMAR3', 199, 3.28);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (22, 'AMBP3', 21, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (23, 'AMZO34', 20, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (24, 'ANIM3', 24, 7.58);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (25, 'APER3', 15, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (26, 'ARMT34', 26, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (27, 'ARZZ3', 27, 75.11);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (28, 'ASAI3', 28, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (29, 'ATEA3', 30, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (30, 'ATMP3', 31, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (31, 'ATTB34', 29, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (32, 'ATTB34 ', 29, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (33, 'AVLL3', 17, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (34, 'AVON34', 33, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (35, 'AXPB34', 22, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (36, 'B2YN34', 48, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (37, 'BALM3', 44, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (38, 'BALM4', 44, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (39, 'BBAS11', 34, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (40, 'BBAS12', 34, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (41, 'BBAS3', 34, 31.1);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (42, 'BBDC3', 60, 17.54);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (43, 'BBDC4', 60, 20.83);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (44, 'BBRK3', 62, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (45, 'BBSE3', 45, 20.57);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (46, 'BDLL3', 42, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (47, 'BDLL4', 42, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (48, 'BEEF11', 212, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (49, 'BEEF3', 212, 9.83);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (50, 'BIDI11', 35, 25.35);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (51, 'BIDI3', 35, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (52, 'BIDI4', 35, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (53, 'BIOM3', 49, 13.99);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (54, 'BLAU3', 52, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (55, 'BMGB4', 54, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (56, 'BMIN3', 36, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (57, 'BMLC11', 53, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (58, 'BMOB3', 46, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (59, 'BMYB34', 67, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (60, 'BOAC34', 39, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (61, 'BOAS3', 56, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (62, 'BOEI34', 57, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (63, 'BONY34', 290, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (64, 'BPAN4', 38, 10.24);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (65, 'BPAR3', 40, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (66, 'BRAP3', 61, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (67, 'BRAP4', 61, 27.7);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (68, 'BRBI11', 58, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (69, 'BRDT3', 244, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (70, 'BRFS3', 66, 22.66);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (71, 'BRK.B', 47, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (72, 'BRKM3', 64, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (73, 'BRKM5', 64, 48.28);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (74, 'BRKM6', 64, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (75, 'BRML3', 68, 9.24);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (76, 'BRPR3', 59, 6.98);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (77, 'BRSR3', 41, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (78, 'BRSR5', 41, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (79, 'BRSR6', 41, 10.36);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (80, 'BSEV3', 50, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (81, 'BSLI3', 65, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (82, 'BSLI4', 65, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (83, 'BTTL3', 43, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (84, 'C2HD34', 87, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (85, 'C2ON34', 111, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (86, 'C2ZR34', 70, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (87, 'CAML3', 72, 9.15);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (88, 'CARD3', 107, 13.59);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (89, 'CASH3', 205, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (90, 'CASN3', 74, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (91, 'CASN4', 74, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (92, 'CATP34', 75, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (93, 'CEAB3', 69, 5.6);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (94, 'CEBR3', 76, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (95, 'CEBR5', 76, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (96, 'CEBR6', 76, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (97, 'CEDO3', 77, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (98, 'CEDO4', 77, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (99, 'CEED3', 78, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (100, 'CEED4', 78, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (101, 'CEGR3', 80, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (102, 'CEPE3', 82, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (103, 'CEPE5', 82, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (104, 'CEPE6', 82, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (105, 'CESP3', 85, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (106, 'CESP5', 85, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (107, 'CESP6', 85, 22.69);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (108, 'CGAS3', 97, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (109, 'CGAS5', 97, 134.05);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (110, 'CGRA3', 147, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (111, 'CGRA4', 147, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (112, 'CHVX34', 86, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (113, 'CJCT11', 155, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (114, 'CLSC3', 81, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (115, 'CLSC4', 81, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (116, 'CMCS34', 96, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (117, 'CMIG3', 84, 17.67);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (118, 'CMIG4', 84, 12.96);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (119, 'CMIN3', 106, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (120, 'COCA34', 92, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (121, 'COCE3', 93, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (122, 'COCE5', 93, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (123, 'COCE6', 93, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (124, 'COGN3', 94, 2.37);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (125, 'COLG34', 95, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (126, 'CONX3', 296, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (127, 'COPH34', 100, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (128, 'CPFE3', 102, 27.07);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (129, 'CPLE3', 99, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (130, 'CPLE5', 99, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (131, 'CPLE6', 99, 6.71);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (132, 'CPRE3', 103, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (133, 'CRFB3', 73, 14.87);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (134, 'CSCO34', 89, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (135, 'CSED3', 104, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (136, 'CSNA3', 105, 25.85);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (137, 'CTGP34', 90, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (138, 'CTKA3', 181, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (139, 'CTKA4', 181, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (140, 'CTNM3', 101, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (141, 'CTNM4', 101, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (142, 'CURY3', 108, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (143, 'CVCB3', 109, 12.71);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (144, 'CXSE3', 71, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (145, 'CYRE3', 110, 15.75);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (146, 'D2KN34', 119, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (147, 'DEVA11', 113, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (148, 'DEXP3', 114, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (149, 'DEXP4', 114, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (150, 'DIRR3', 116, 12.08);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (151, 'DMMO11', 117, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (152, 'DMMO3', 117, 0.69);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (153, 'DMVF3', 112, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (154, 'DOTZ3', 118, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (155, 'EBAY34', 120, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (156, 'EEEL3', 79, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (157, 'EEEL4', 79, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (158, 'EGIE3', 124, 39.3);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (159, 'ELMD3', 121, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (160, 'ENAT3', 122, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (161, 'ENJU3', 125, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (162, 'ENMT3', 123, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (163, 'ENMT4', 123, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (164, 'ESPA3', 126, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (165, 'ESTR3', 127, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (166, 'ESTR4', 127, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (167, 'EUCA3', 128, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (168, 'EUCA4', 128, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (169, 'EVEN3', 129, 6.61);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (170, 'EXXO34', 130, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (171, 'EZTC3', 131, 20.51);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (172, 'FBOK34', 132, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (173, 'FCXO34', 138, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (174, 'FDMO34', 137, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (175, 'FDXB34', 133, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (176, 'FESA3', 134, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (177, 'FESA4', 134, 45.14);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (178, 'FLRY3', 135, 19.12);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (179, 'GBIO33', 51, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (180, 'GEOO34', 140, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (181, 'GEPA3', 142, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (182, 'GEPA4', 142, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (183, 'GFSA3', 139, 1.82);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (184, 'GGPS3', 152, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (185, 'GMAT3', 150, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (186, 'GOAU4', 143, 11.45);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (187, 'GOGL35', 16, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (188, 'GRND3', 148, 8.69);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (189, 'GSGI34', 145, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (190, 'GSHP3', 141, 30.4);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (191, 'HALI34', 153, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (192, 'HBOR3', 156, 4.05);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (193, 'HBRE3', 154, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (194, 'HBSA3', 157, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (195, 'HCAR3', 160, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (196, 'HGTX3', 88, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (197, 'HOME34', 158, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (198, 'HONB34', 159, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (199, 'HOOT4', 161, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (200, 'HPQB34', 162, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (201, 'HYPE3', 163, 29.46);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (202, 'IBMB34', 164, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (203, 'IFCM3', 167, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (204, 'IGBR3', 146, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (205, 'IGTA3', 165, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (206, 'INEP4', 166, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (207, 'INTB3', 170, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (208, 'IRBR3', 172, 3.35);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (209, 'ITLC34', 169, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (210, 'ITSA3', 175, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (211, 'ITSA4', 175, 9.56);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (212, 'ITUB3', 174, 20.49);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (213, 'ITUB4', 174, 23.25);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (214, 'JALL3', 176, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (215, 'JBSS3', 177, 36.25);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (216, 'JHSF3', 178, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (217, 'JNJB34', 179, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (218, 'JPMC34', 180, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (219, 'JSLG3', 149, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (220, 'K2CG34', 182, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (221, 'KLBN11', 183, 24.79);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (222, 'KLBN3', 183, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (223, 'KLBN4', 183, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (224, 'KRSA3', 184, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (225, 'LAME3', 193, 6.6);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (226, 'LAME4', 193, 6.57);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (227, 'LAVV3', 185, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (228, 'LCAM3', 189, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (229, 'LEVE3', 210, 30.63);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (230, 'LINX3', 187, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (231, 'LJQQ3', 255, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (232, 'LLIS3', 186, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (233, 'LMTB34', 191, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (234, 'LOGG3', 192, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (235, 'LPSB3', 195, 2.5);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (236, 'LREN3', 194, 26.4);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (237, 'LUPA3', 196, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (238, 'LWSA3', 190, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (239, 'M2PW34', 204, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (240, 'MATD3', 201, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (241, 'MBLY3', 215, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (242, 'MCDC34', 202, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (243, 'MDIA3', 203, 22.96);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (244, 'MDNE3', 218, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (245, 'MELK3', 206, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (246, 'MERC4', 207, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (247, 'MFAI11', 209, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (248, 'MGLU3', 197, 6.93);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (249, 'MMMC34', 1, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (250, 'MMXM11', 214, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (251, 'MMXM3', 214, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (252, 'MNDL3', 222, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (253, 'MODL11', 37, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (254, 'MODL3', 37, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (255, 'MODL4', 37, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (256, 'MOOO34', 18, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (257, 'MOSI3', 217, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (258, 'MOVI3', 219, 15.37);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (259, 'MRCK34', 208, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (260, 'MRFG3', 198, 22.42);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (261, 'MRVE3', 220, 12.02);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (262, 'MSBR34', 216, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (263, 'MSCD34', 200, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (264, 'MSFT34', 211, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (265, 'MTRE3', 213, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (266, 'MULT3', 221, 20.08);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (267, 'MYPK3', 171, 14.32);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (268, 'NEMO3', 283, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (269, 'NEMO5', 283, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (270, 'NEMO6', 283, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (271, 'NEOE3', 224, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (272, 'NFLX34', 226, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (273, 'NGRD3', 225, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (274, 'NIKE34', 227, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (275, 'NINJ3', 144, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (276, 'NTCO3', 223, 23.17);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (277, 'ODPV3', 229, 12.48);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (278, 'OFSA3', 234, 23.14);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (279, 'OIBR3', 230, 0.87);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (280, 'OIBR4', 230, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (281, 'OPCT3', 228, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (282, 'ORCL34', 231, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (283, 'ORVR3', 232, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (284, 'OSXB3', 233, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (285, 'P2EN34', 240, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (286, 'PAGS34', 235, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (287, 'PARD3', 168, 19.83);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (288, 'PASS3', 98, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (289, 'PCAR3', 237, 19.47);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (290, 'PDGR3', 239, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (291, 'PEPB34', 241, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (292, 'PETR3', 243, 34.5);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (293, 'PETR4', 243, 31.9);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (294, 'PETZ3', 247, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (295, 'PFIZ34', 248, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (296, 'PGCO34', 252, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (297, 'PGMN3', 236, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (298, 'PLPL3', 249, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (299, 'PMAM3', 238, 7.73);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (300, 'PNVL3', 115, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (301, 'PNVL4', 115, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (302, 'POSI3', 251, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (303, 'POWE3', 136, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (304, 'PRIO3', 246, 23.6);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (305, 'PSSA3', 250, 19.25);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (306, 'QCOM34', 253, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (307, 'QUAL3', 254, 17.1);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (308, 'RADL3', 257, 20.89);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (309, 'RANI3', 83, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (310, 'RANI4', 83, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (311, 'RAPT3', 256, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (312, 'RDNI3', 263, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (313, 'RECR11', 258, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (314, 'RECV3', 245, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (315, 'RENT3', 188, 54.8);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (316, 'RIOS3', 261, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (317, 'RIVA3', 262, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (318, 'RNEW11', 259, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (319, 'RNEW3', 260, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (320, 'RNEW4', 260, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (321, 'RPMG3', 242, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (322, 'RRRP3', 2, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (323, 'RSID3', 264, 8.65);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (324, 'S2EA34', 273, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (325, 'S2HO34', 276, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (326, 'S2NW34', 279, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (327, 'S2QU34', 280, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (328, 'S2UI34', 282, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (329, 'SANB11', 267, 31.63);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (330, 'SANB3', 267, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (331, 'SANB4', 267, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (332, 'SAPR11', 266, 18.66);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (333, 'SAPR3', 266, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (334, 'SAPR4', 266, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (335, 'SBSP3', 265, 35.9);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (336, 'SBUB34', 281, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (337, 'SCAR3', 269, 39);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (338, 'SEER3', 275, 10.82);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (339, 'SEQL3', 274, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (340, 'SIMH3', 277, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (341, 'SLBG34', 272, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (342, 'SLED3', 271, 9.42);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (343, 'SLED4', 271, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (344, 'SMLS3', 278, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (345, 'SMTO3', 270, 36.76);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (346, 'SOJA3', 55, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (347, 'SOMA3', 151, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (348, 'STBP3', 268, 6.08);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (349, 'SUZB3', 284, 59.74);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (350, 'T2DH34', 287, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (351, 'T2TD34', 294, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (352, 'TAEE11', 285, 37.99);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (353, 'TAEE3', 285, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (354, 'TAEE4', 285, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (355, 'TCSA3', 286, 3.12);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (356, 'TELB3', 288, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (357, 'TELB4', 288, 15.4);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (358, 'TFCO4', 293, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (359, 'TIMS3', 291, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (360, 'TOTS3', 292, 26.8);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (361, 'TRPL3', 173, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (362, 'TRPL4', 173, 24.24);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (363, 'U2ST34', 299, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (364, 'UGPA3', 297, 13.85);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (365, 'UNIP3', 298, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (366, 'UNIP5', 298, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (367, 'UNIP6', 298, 89.95);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (368, 'UPSS34', 300, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (369, 'URPR11', 301, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (370, 'VALE5', 302, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (371, 'VAMO3', 303, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (372, 'VERZ34', 304, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (373, 'VISA34', 306, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (374, 'VITT3', 307, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (375, 'VIVA3', 308, 23.27);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (376, 'VIVT3', 289, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (377, 'VIVT4', 289, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (378, 'VVAR3', 305, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (379, 'VVEO3', 91, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (380, 'WALM34', 309, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (381, 'WEST3', 311, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (382, 'WFCO34', 310, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (383, 'WHRL3', 313, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (384, 'WHRL4', 312, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (385, 'XINA11', 295, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (386, 'XRXB34', 314, 12.53);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (387, 'YDUQ3', 315, 20.36);
Insert Into Acoes (Id, Ticker, IdEmpresa, PrecoBaseSimulacao) Values (388, 'Z2NG34', 316, 12.53);


/*============== Procedures & Functions ==============*/

/* --- Getting random Id for Corretora --- */
DELIMITER $$
Create Function IdAleatorio_Corretora()
Returns Int Unsigned
Begin  
    Set @Corretora = (
		Select  Id    
		From	Corretoras
		Order By Rand()
		Limit 1
    );    
    return @Corretora;
End $$
DELIMITER ;

/* --- Getting random anount of stocks for order simulation --- */
DELIMITER $$
Create Function QuantidadeAcoes_Simulacao()
Returns Int Unsigned
Begin  
    Set @Quantidade = Floor(Rand()*(2000-100+1))+100;   
    Set @Resto = Mod(@Quantidade, 100);
    Set @Quantidade = @Quantidade - @Resto;
    return @Quantidade;    
End $$
DELIMITER ;

/* --- Getting stock price for simulation --- */
DELIMITER $$
Create Function PrecoSimulacao_Acao(pTicker Varchar(10), pTipo Char(1))
Returns Decimal(7,2)
Begin  
	Set @IdAcao = (
		Select	Id    
		From	Acoes
		Where	Ticker = pTicker
		Limit	1
    );
    
    Set @PrecoBase = (
		Select  PrecoBaseSimulacao    
		From	Acoes
		Where	Ticker = pTicker
		Limit 1
    );    
    
    Set @UltimoPreco = (
		Select  PrecoUnitario
		From	Ofertas
		Where	IdAcao = @IdAcao And
				Tipo = pTipo
		Limit 1
    );  
    
    If (IsNull(@UltimoPreco)) Then
		Set @UltimoPreco = @PrecoBase;
	End If;    
    
    Set @Aleatorio = Rand();    
    
    If (@Aleatorio > 0.5) Then
		Set @Aleatorio = Rand();
        If (@Aleatorio > 0.5) Then
			Set @UltimoPreco = @UltimoPreco + Rand()/100;
		Else 
			Set @UltimoPreco = @UltimoPreco - Rand()/100;
		End If;
	End If;
    
    If (IsNull(@UltimoPreco)) Then
		Set @UltimoPreco = 0.0;
	End If;
   
    Return @UltimoPreco;
End $$
DELIMITER ;

/* --- Simulating stock offers (buy & sell) --- */
DELIMITER $$
Create Procedure Simular_Ofertas(IN pTicker Varchar(10))
Begin
	Set @Qtd_Ofertas = 0;
    Set @IdAcao = -1;
    
    Select	Id
    Into 	@IdAcao
    From	Acoes
    Where	Ticker = pTicker
    Limit	1;
    
    If (IsNull(@IdAcao)) Then
		Set @IdAcao = -1;
	End If;
        
    If (@IdAcao <> -1) Then
    
		Select 	Count(Id)
		Into 	@Qtd_Ofertas
		From 	Ofertas			
		Where	date_format(DataHora, "%Y%m%d") <> date_format(Now(), "%Y%m%d");
        
        If (@Qtd_Ofertas <> 0) Then
			Delete From Ofertas Where Id >= 0;             
		End If;
        
        Select 	Count(Id)
		Into 	@Qtd_Ofertas
		From 	Ofertas			
		Where	IdAcao = @IdAcao And
				date_format(DataHora, "%Y%m%d") = date_format(Now(), "%Y%m%d");
		
		If (IsNull(@Qtd_Ofertas)) Then
			Set @Qtd_Ofertas = 0;
		End If;
        
        If (@Qtd_Ofertas < 5) Then        
			While (@Qtd_Ofertas < 5) Do
				Insert 	Into Ofertas (Tipo, IdAcao, IdCorretora, Quantidade, PrecoUnitario)
				Values  ('C', @IdAcao, IdAleatorio_Corretora(), QuantidadeAcoes_Simulacao(), PrecoSimulacao_Acao(pTicker, 'C')),
						('V', @IdAcao, IdAleatorio_Corretora(), QuantidadeAcoes_Simulacao(), PrecoSimulacao_Acao(pTicker, 'V'));  
						
				Set @Qtd_Ofertas = @Qtd_Ofertas + 1;
			End While;
		Else
			Insert 	Into Ofertas (Tipo, IdAcao, IdCorretora, Quantidade, PrecoUnitario)
			Values  ('C', @IdAcao, IdAleatorio_Corretora(), QuantidadeAcoes_Simulacao(), PrecoSimulacao_Acao(pTicker, 'C')),
					('V', @IdAcao, IdAleatorio_Corretora(), QuantidadeAcoes_Simulacao(), PrecoSimulacao_Acao(pTicker, 'V'));  
        End If;    	
		
	End If;    
End $$
DELIMITER ;
