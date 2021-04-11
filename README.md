# ReCap Project Backend

## Using
[![C-Sharp](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Asp-net](https://img.shields.io/badge/ASP.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![MSSQL](https://img.shields.io/badge/MSSQL-004880?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server/sql-server-2019?rtc=2)
[![Entity-Framework](https://img.shields.io/badge/Entity%20Framework-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/en-us/ef/)
[![Autofac](https://img.shields.io/badge/Autofac-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://autofac.org/)


## Project's Youtube Video ↓↓↓

<div>
  <a href="https://www.youtube.com/watch?v=9xFsYmzSpTo"><img src="https://i.hizliresim.com/aPI8DV.jpg" alt="IMAGE ALT TEXT"></a>
</div>

**Click It ↑↑↑**


## Layers
#### Business, Core, DataAccsess, Entities, WebApi

<details>
  <summary>Details</summary>

### Business

Business Layer created to process or control the incoming information according to the required conditions.

### Core

Core layer containing various particles independent of the project.

### DataAccess

Data Access Layer created to perform database CRUD operations.

### Entities

Entities Layer created for database tables.

### WebAPI

Web API Layer that opens the business layer to the internet.

</details><p></p>

#Data Base

## Tables

<details>
  <summary>Details</summary>

### Brands

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| Name | nvarchar(25) | False       |         |

### Car Images

| Name      | Data Type     | Allow Nulls | Default |
| :-------- | :------------ | :---------- | :------ |
| Id        | int           | False       |         |
| CarId     | int           | False       |         |
| ImagePath | nvarchar(MAX) | False       |         |
| Date      | datetime      | False       |         |

### Car

| Name            | Data Type     | Allow Nulls | Default |
| :-------------- | :------------ | :---------- | :------ |
| Id              | int           | False       |         |
| Name            | nvarchar(50)  | False       |         |
| BrandId         | int           | False       |         |
| ColorId         | int           | False       |         |
| DailyPrice      | int           | False       |         |
| ModelYear       | int           | False       |         |
| Description     | nvarchar(50)  | True        |         |
| MinFindeksPoint | smallint      | False       | ((0))   |

### Color

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| Name | nvarchar(25) | False       |         |

### Credit Card (Test)

| Name        | Data Type     | Allow Nulls | Default |
| :---------- | :------------ | :---------- | :------ |
| Id          | int           | False       |         |
| CustomerId  | int           | False       |         |
| CardHash    | nvarchar(100) | False       |         |
| CardNumber  | nvarchar(25)  | False       |         |
| ExpMonth    | tinyint       | False       |         |
| ExpYear     | tinyint       | False       |         |
| Cvc         | nvarchar(3)   | False       |         |

### Customer

| Name        | Data Type    | Allow Nulls | Default |
| :---------- | :----------- | :---------- | :------ |
| Id          | int          | False       |         |
| UserId      | int          | False       |         |
| CompanyName | nvarchar(50) | True        |         |
| FindeksPoint| int          | False       |         |


### OperationClaims

| Name | Data Type    | Allow Nulls | Default |
| :--- | :----------- | :---------- | :------ |
| Id   | int          | False       |         |
| Name | varchar(250) | False       |         |

### Rental

| Name          | Data Type | Allow Nulls | Default |
| :------------ | :-------- | :---------- | :------ |
| Id            | int       | False       |         |
| CarId         | int       | False       |         |
| CustomerId    | int       | False       |         |
| RentDate      | datetime  | False       |         ||
| ReturnDate    | datetime  | True        |         |

### UserOperationClaims

| Name             | Data Type | Allow Nulls | Default |
| :--------------- | :-------- | :---------- | :------ |
| Id               | int       | False       |         |
| UserId           | int       | False       |         |
| OperationClaimId | int       | False       |         |

### Users

| Name         | Data Type      | Allow Nulls | Default |
| :----------- | :------------- | :---------- | :------ |
| Id           | int            | False       |         |
| FirstName    | nvarchar(50)   | False       |         |
| LastName     | nvarchar(50)   | False       |         |
| Email        | nvarchar(50)   | False       |         |
| PasswordHash | varbinary(500) | False       |         |
| PasswordSalt | varbinary(500) | False       |         |
| Status       | bit            | False       |         |

</details><p></p>



#### Contact me: *erhangocenn@gmail.com - https://www.linkedin.com/in/erhan-göcen-0854bb206/*

#### Thanks for that <a href="https://github.com/engindemirog"><b>Engin Demiroğ</b></a>
