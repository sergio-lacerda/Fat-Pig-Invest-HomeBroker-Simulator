/***************************************************************
	Database for the Home Broker Simulator Application.
					Client Side (homebroker) Database
    By Sérgio Lacerda: https://github.com/sergio-lacerda
***************************************************************/

/* --- Creating Database & Tables --- */
Drop Database If Exists dbhomebrokerclient;
Create Database dbhomebrokerclient;
Use dbhomebrokerclient;

Create Table Tarifas (
	Id Int Unsigned Not Null Auto_Increment Primary Key,
    InicioVigencia DateTime Not Null,
    FinalVigencia DateTime Not Null,
    Corretagem Decimal(5,2) Not Null,
    TaxaLiquidacao Decimal(8,6) Not Null,
    Emolumentos Decimal(8,6) Not Null,
    Iss Decimal(7,2) Not Null   
);

Insert Into Tarifas (Id, InicioVigencia, FinalVigencia, Corretagem, TaxaLiquidacao, Emolumentos, Iss)
Values (1, '2020-01-01', '2030-01-01', 0.5, 0.0275, 0.003020, 5.0);

Create table Investidores (
	Id Int Unsigned Not Null Primary Key,
	Cpf Varchar(15) Not Null Unique,
    Nome Varchar(50) Not Null
);

Create table Contas (	
	Id Int Unsigned Not Null Primary Key,
    IdInvestidor Int Unsigned Not Null,
    Agencia Int Unsigned Not Null Default 1,
    Conta Int Unsigned Not Null
);

Alter Table Contas
Add Constraint fk_Conta_Investidor Foreign Key (IdInvestidor) References Investidores (Id);


/* ???????????????????????? */
Create Table Acoes (
	Id Int Unsigned Not Null Auto_Increment Primary Key,
    Ticker Varchar(10) Not Null Unique,
    Empresa Varchar(50) Null    
);	

Create Table Ordens (
	Id Int Unsigned Not Null Auto_Increment Primary Key,
    DataHora DateTime Not Null Default Now(),    
    IdConta Int Unsigned Not Null,    
    Tipo Char(1) Not Null,
    IdAcao Int Unsigned Not Null,    
    Quantidade Int Unsigned Not Null,
    PrecoUnitario Decimal(7,2) Not Null,
    IdStatus Int Unsigned Not Null Default 1
);







