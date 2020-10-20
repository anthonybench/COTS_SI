# COTS Software Inventory
*An inventory management intranet tool for commercial off-the-shelf software.*

<br />

### Welcome to COTS_SI!
<hr>

This application serves as a complete database management solution for keeping inventory of *COTS* software licenses and products. Provides convenience for viewing, editing, adding or deleting entires across it's relevant tables, and hosts a *quick-start* guide on the home page for accessible documentation.

<br />

### Table of Contents 📖
<hr>

  - [Welcome](#welcome-to-cots_si)
  - [**Get Started**](#get-started-)
  - [Usage](#usage-)
  - [Technologies](#technologies-)
  - [Contribute](#Contribute-)
  - [Acknowledgements](#acknowledgements-)
  - [License/Stats/Author](#license-stats-author-)

<br />

### Get Started 🚀
<hr>

Replace placeholder assets such as the *navbar brand* and the ***About** page icon* with any of your personal or corporate logos and information.



Once the template has been tailored to meet your needs and standards, instantiate a database as either a local instance, a specific debug enviornment or a production enviornment by adjusting the connection string in `COTS_Inventory/appsettings.json`, and run
```
PM> Update-Database
```
you can now deploy a *release publish* with

```
$ dotnet publish
```
and you're free to add personal or company data to the manager!

<br />

### Usage ⚙
<hr>

Right from the home page, your given a tldr on the application's functionality and site navigation, as well as a visual map to quickly explain the [cascade deletion](https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete) functionality of *Entity Framework Core* so that automatically upheld *referential integrity* is understood by anyone responsible for data entry.

![Imgur](https://i.imgur.com/kC3Zi1S.png)

From the navbar header, you can navigate to the different tables, where you can manage the database safely.

![Imgur](https://i.imgur.com/KjmQGmm.png)

The underlying relational database managed by *Entity Framework Core* is represented in the uml below

![Imgur](https://i.imgur.com/T2MI0OQ.png)

Thus essentially, after personalizing the styles and corporate assets on display, your team is ready to deploy this tool onto your company's intranet and begin managing your commercial off-the-shelf software inventory with ease!

<br />

### Technologies 🧰
<hr>

  - [LINQ](https://docs.microsoft.com/en-us/dotnet/standard/linq/)
  - [Entity Framework Core](https://docs.microsoft.com/en-us/ef/)
  - [Microsoft SQL Server](https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15)
  - [Windows Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/windowsauth?view=aspnetcore-3.1&tabs=visual-studio)


<br />

### Contribute 🤝
<hr>

I'm not currently evaluating *pull requests* for merging, but will be happy to take suggestions and feedback via *pull request*. If you have constructive feedback, I'm all ears!

<br />

### Acknowledgements 💙
<hr>

Thanks to **NASA; Stennis Space Center** for fueling my learning of full stack applications and their deployments through my *Summer 2020 Software Engineering Internship*. Without that experience, I wouldn't be where I am today.

<br />

### License, Stats, Author 📜
<hr>

<img align="right" alt="example image tag" src="https://i.imgur.com/jtNwEWu.png" width="200" />

<!-- badge cluster -->

![GitHub](https://img.shields.io/github/license/anthonybench/COTS_SI) ![GitHub language count](https://img.shields.io/github/languages/count/anthonybench/COTS_SI) ![GitHub repo size](https://img.shields.io/github/repo-size/anthonybench/COTS_SI)

Microsoft.AspNet.Mvc ![Nuget](https://img.shields.io/nuget/v/Microsoft.AspNet.Mvc)

Microsoft.EntityFrameworkCore ![Nuget](https://img.shields.io/nuget/v/Microsoft.EntityFrameworkCore)

LINQ ![Nuget](https://img.shields.io/nuget/v/System.Linq)

<!-- / -->
See [License](https://opensource.org/licenses/MIT) for the full license text.

This repository was authored by *Isaac Yep*.

[Back to Table of Contents](#table-of-contents-)
