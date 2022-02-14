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