![Fat Pig Invest - Home Broker Simulator Project Logo](https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator/blob/master/Preview/logo.png "Fat Pig Invest - Home Broker Simulator Project Logo")

# 🐷 Fat Pig Invest — Home Broker Simulator

## 📌 Overview

**Fat Pig Invest** is a self-driven project that simulates an electronic trading platform (home broker) for the Brazilian stock market.

The solution is composed of two main applications:

- **REST API** — simulates core stock exchange operations such as order processing and market data handling  
- **Web Client** — provides a user interface for placing buy/sell orders and interacting with the API  

This project was designed as a practical study of backend/frontend integration, financial system concepts, and API design.

---

## 🌎 Multilingual Description

**🇺🇸 English**  
A self-study application that simulates a stock trading platform for the Brazilian market, including a REST API and a web client for trading interactions.

**🇧🇷 Português**  
Aplicação de estudo que simula um home broker para o mercado de ações brasileiro, composta por uma API REST e uma aplicação web para interação do usuário.

**🇪🇸 Español**  
Aplicación de autoaprendizaje que simula un sistema de trading para la bolsa brasileña, con una API REST y una interfaz web para el usuario.

---

## 🖼️ Screenshots

### Main Page
![Home Broker Simulator Main Page](https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator/blob/master/Preview/index.png)

### Chart
![Home Broker Simulator Chart](https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator/blob/master/Preview/grafico.png)

### Trade Receipt
![Home Broker Orders Receipt](https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator/blob/master/Preview/NotaDeNegociacao.png)

### API Documentation
![Home Broker Simulator API](https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator/blob/master/Preview/Swagger.png)

---

## 🛠️ Tech Stack

### Backend
- .NET Core 5
- C#
- REST API
- LINQ & Lambda Expressions
- Swagger (API documentation)

### Frontend
- ASP.NET MVC
- HTML5
- CSS3
- Bootstrap
- JavaScript / jQuery
- Google Charts

### Database
- MySQL
- Stored Procedures & Functions
- MySQL Connector

---

## ⚙️ Installation & Setup

    
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
