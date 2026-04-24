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

**<img src="https://cdn.jsdelivr.net/gh/hjnilsson/country-flags@master/svg/us.svg" width="20" style="display: inline; vertical-align: middle;" /> English**  
A self-study application that simulates a stock trading platform for the Brazilian market, including a REST API and a web client for trading interactions.

**<img src="https://cdn.jsdelivr.net/gh/hjnilsson/country-flags@master/svg/br.svg" width="20" style="display: inline; vertical-align: middle;" /> Português**  
Aplicação de estudo que simula um home broker para o mercado de ações brasileiro, composta por uma API REST e uma aplicação web para interação do usuário.

**<img src="https://cdn.jsdelivr.net/gh/hjnilsson/country-flags@master/svg/es.svg" width="20" style="display: inline; vertical-align: middle;" /> Español**  
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
   
### 2. Configure the Databases

This project requires a MySQL server (or MariaDB via XAMPP).
Navigate to the Database Scripts folder and execute the scripts bellow:
- dbhomebrokerapi
- dbhomebrokerclient

### 3. Configure the API Project
Update appsettings.json:

```json
"ConnectionStrings": {
        "DatabaseConnStr": "Server=localhost;Port=3306;Database=dbhomebrokerapi;Uid=root;Pwd=;"
    }
```
Also configure:
```console
Project properties -> Output -> XML documentation file path
```
   
### 4. Configure the Client Project
Update appsettings.json:

```json
"ConnectionStrings": {
  "DatabaseConnStr": "Server=localhost;Port=3306;Database=dbhomebrokerclient;Uid=root;Pwd=;"
}
```

### 5. API Endpoints Configuration
If needed, adjust API URLs:

```json
"ApiUris": {
    "Base": "https://localhost:5001",
    "OrdemList": "https://localhost:5001/api/v1/Ordem",
    "OfertaList": "https://localhost:5001/api/v1/Oferta",
    "CarteiraList": "https://localhost:5001/api/v1/Carteira",
    "OrdemPost": "https://localhost:5001/api/v1/Ordem"
  }
```

---

## 👤 Default User Configuration
User data is hardcoded in:

```json
"UsuarioLogado": {
    "IdInvestidor": 1,
    "IdCorretora": 47,
    "NumeroConta": 51001
  }
```

---

## 🚀 Usage Notes

⚠️ This project is a simulation only and has no connection to real financial markets.

### Limitations
- All market data is static and outdated
- No real-time updates
- Simplified tax rules
- No authentication system
- No balance validation (buy/sell without restrictions)
- Not Supported
  - Day trading
  - Fractional shares
  - Portfolio validation
  - Account balance control

---

## 🎯 Learning Goals

This project demonstrates:

- API design and architecture
- Integration between frontend and backend
- Financial system modeling (simplified)
- Database design with stored procedures
- Data visualization
---

## 📄 License

This project is intended for educational purposes only.
