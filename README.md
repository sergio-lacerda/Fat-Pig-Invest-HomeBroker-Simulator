# Home Broker Simulator

_**[English]**_ This is a self-study application simulating an e-trading platform to operate on Brazilian stock market. It contains two projects: a REST API to simulate the stock exchange service and a web application to allow the user to interact with the API, buying and selling stocks. 

_**[Português]**_ Este é um aplicativo de autoestudo simulando um home broker para operar no mercado de ações brasileiro. Ele contém dois projetos: uma API REST para simular o serviço de bolsa de valores e uma aplicação web para permitir que o usuário interaja com a API, comprando e vendendo ações. 

_**[Español]**_ Esta es una aplicación de autoaprendizaje que simula un sistema de e-trading para la bolsa de valores brasileña. El software contiene dos proyectos: una API REST para simular el servicio de la bolsa y una aplicación web para el usuario interactuar con la API, comprando y vendiendo acciones.


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
- MySQL Connector
- Google Charts


## Installation

Please, follow the instructions below in order to install and run this project:


### 1. Clone the repository

```console
git clone https://github.com/sergio-lacerda/2022-01-HomeBroker-Simulator.git
```


### 2. Create API and Client Databases

For this project, a MySQL Database Server is required. If you don't have it, you can use a XAMPP distribution containing MariaDB.

The scripts for both, API and Client databases are available at the folder "Database Scripts". Just execute these scripts in order to create the databases.


### 3. Settings for HomeBrokerAPI project

- **Project properties -> Outup -> XML documentation file path:** Set the path to the folder you'd like to have the API documentation file.
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