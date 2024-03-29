![Fat Pig Invest - Home Broker Simulator Project Logo](https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator/blob/master/Preview/logo.png "Fat Pig Invest - Home Broker Simulator Project Logo")

# Fat Pig Invest - Home Broker Simulator

<img height="12px" src="https://github.com/hampusborgos/country-flags/blob/main/png250px/us.png"/> This is a self-study application simulating an e-trading platform to operate on Brazilian stock market. It contains two projects: a REST API to simulate the stock exchange service and a web application to allow the user to interact with the API, buying and selling stocks. 

<img height="12px" src="https://github.com/hampusborgos/country-flags/blob/main/png250px/br.png"/> Este é um aplicativo de autoestudo simulando um home broker para operar no mercado de ações brasileiro. Ele contém dois projetos: uma API REST para simular o serviço de bolsa de valores e uma aplicação web para permitir que o usuário interaja com a API, comprando e vendendo ações. 

<img height="12px" src="https://github.com/hampusborgos/country-flags/blob/main/png250px/es.png"/> Esta es una aplicación de autoaprendizaje que simula un sistema de e-trading para la bolsa de valores brasileña. El software contiene dos proyectos: una API REST para simular el servicio de la bolsa y una aplicación web para el usuario interactuar con la API, comprando y vendiendo acciones.

<br />

## Screenshots 
<br />

![Home Broker Simulator Main Page](https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator/blob/master/Preview/index.png "Home Broker Simulator Main Page")

![Home Broker Simulator Chart](https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator/blob/master/Preview/grafico.png "Home Broker Simulator Chart")

![Home Broker Simulator Chart](https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator/blob/master/Preview/NotaDeNegociacao.png "Home Broker Orders Receipt")

![Home Broker Simulator API](https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator/blob/master/Preview/Swagger.png "Home Broker Simulator API")

<br />

## Technologies 

- .Net Core 5
- C#
- API REST
- Swagger
- MVC
- Linq
- Lambda Expressions
- HTML 5
- CSS 3 (not fully responsive client interface sample)
- Bootstrap
- Javascript / JQuery
- MySQL Database
- Database procedures & functions
- MySQL Connector
- Google Charts

<br />

## Installation

Please, follow the instructions below in order to install and run this project:

    
### 1. Clone the repository

```console
git clone https://github.com/sergio-lacerda/Fat-Pig-Invest-HomeBroker-Simulator.git
```

   
### 2. Create API and Client Databases

For this project, a MySQL Database Server is required. If you don't have it, you can use a XAMPP distribution containing MariaDB.

The scripts for both, API and Client databases are available at the folder "Database Scripts". Just execute these scripts in order to create the databases.

   
### 3. Settings for HomeBrokerAPI project

- **Project properties -> Output -> XML documentation file path:** Set the path to the folder where you'd like to have the API documentation file.
- **appsettings.json:** Edit the key "DatabaseConnStr" and configure your connection string to the API database (dbhomebrokerapi).

```json
"ConnectionStrings": {
        "DatabaseConnStr": "Server=localhost;Port=3306;Database=dbhomebrokerapi;Uid=root;Pwd=;"
    }
```

   
### 4. Settings for HomeBrokerClient project

- **appsettings.json:** Edit the key "DatabaseConnStr" and configure your connection string to the Client database (dbhomebrokerclient).

```json
"ConnectionStrings": {
    "DatabaseConnStr": "Server=localhost;Port=3306;Database=dbhomebrokerclient;Uid=root;Pwd=;"
  }
```

- **API URIs:** The default URIs are also configured at "appsettings.json". If you start the API with a diferent URI or port number, you must set these information by editing the key "ApiUris".
    - "Base": API's base URI
    - "OrdemList": API's URI for order list - GET
    - "OfertaList": API's URI for offers list - GET
    - "CarteiraList": API's URI "my stocks" list - GET
    - "OrdemPost": API's URI for order post - POST

```json
"ApiUris": {
    "Base": "https://localhost:5001",
    "OrdemList": "https://localhost:5001/api/v1/Ordem",
    "OfertaList": "https://localhost:5001/api/v1/Oferta",
    "CarteiraList": "https://localhost:5001/api/v1/Carteira",
    "OrdemPost": "https://localhost:5001/api/v1/Ordem"
  }
```

<br />

## Usage instructions

- This API is just a SIMULATOR, so all values shown here are FICTITIOUS. The solution DOES NOT HAVE any kind of integration with the real stock market.
- The Tickers and Companies information are based in internet sources in a specific date and have no updates (they are out of date).
- Some of the taxes rules have been simplified, so there may be small differences when compared to a real scenario.
- This simulator doesn´t support day trade operations.
- This simulator doesn´t support fractional share operations.
- This simulator doesn´t control your stock wallet or your account credit. No verification is made about if you have enough money to buy or if you have the stocks you are selling.
- No login system has been implemented in this sample project, so user information are fixed at HomeBrokerClient project's appsettings.json file:
    - "IdInvestidor": Investor Id
    - "IdCorretora": Broker Id
    - "NumeroConta": Investor account number

```json
"UsuarioLogado": {
    "IdInvestidor": 1,
    "IdCorretora": 47,
    "NumeroConta": 51001
  }
```