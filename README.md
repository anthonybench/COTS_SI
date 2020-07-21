# COTS Software Inventory Management Application
## Developed by _Isaac Yep_; Mentored by _Alex Elliot_ and _Mark Turowski_
-- _NASA, Stennis Space Center; June 2020_

<br>

Tech Stack
================
* `SQL Server Management Studio` for database exploration
* `Siteminder SSO` for Authentication
* `VS Code` recommended for *markdown* editing
* `Visual Studio 2019` for development
  * ASP.NET Core Support (web development)

_**Note**: An understanding of web application design architecture, and primarily `C#` and Visual Studio build tools for `.NET core` is pre-required. Please ensure that you are viewing this document in a `markdown` viewer. For `VS Code`, enter **\<ctrl> k v** while focused on this document._


Overview
================
## Purpose
Software liscence/invetory management is currently done by spreadsheets.
This is inefficient and not un-scalable! Thus the application COTS was requested.
COTS is an internal intranet-hosted tool with the following features:
* Database interface for vendor {id, name, phone number, email, website}
* Database interface for product {id, version, description, classification}
* Database interface for license {id, terms, procurement, ownership}
* Database interface for software installation {client machine, id, location, owner, product key, IT security plan, active status}
* General Interface for {searching, sorting, creating, updating, deleting} entries
* Generate reports detailing info for licenses set to expire "soon" (specified by user)
* Generate reports detailing utilization of a license, meaning number of remaining installations
* Generate reports detailing {date, time, location, results} of most recent tests performed on each installation
* Any given license number can't be installed on 2 separate machines
* Generate email to responsible party {90, 60, 30} days before expiration

## Schema
**ClientMachine**
* Id [int] **\<Pk>**
* Name [varchar(64)]
* Location [varchar(25)]
* Owner [varchar(30)]
* ITSecurityPlan [varchar(30)] (nullable)
* Active [varchar(10)] (nullable)

**Install**
* Id [int] **\<Pk>**
* CM_Id [int] **\<Fk>**
* SL_Id [int] **\<Fk>**
* SerialNumber [int] (nullable)
* Comment [varchar(MAX)] (nullable)

**Licence**
* Id [int] **\<Pk>**
* SP_Id [int] **\<Fk>**
* Type [varchar(25)]
* Servicer [varchar(30)]
* NumOfInstalls [int] (nullable)
* Cost [varchar(25)]
* ExpireDate [DateTime]
* PurchaseOrderNum [varchar(25)] (nullable)
* MRNumber [varchar(25)] (nullable)
* PurchaseAgent [varchar(30)] (nullable)
* Owner [varchar(30)]
* OwnerEmail [varchar(50)] (nullable)
* ActivationWebsite [varchar(50)] (nullable)
* ContractNumber [varchar(50)]
* Comment [varchar(MAX)] (nullable)

**Product**
* Id [int] **\<Pk>**
* SV_Id [int] **\<Fk>**
* Name [varchar(25)]
* Version [varchar(20)]
* VendorCatNum [varchar(20)] (nullable)
* Description [varchar(100)]
* NPRClassification [varchar(25)] (nullable)
* SafetyCriticalDetermin [varchar(10)] (nullable)

**Vendor**
* Id [int] **\<Pk>**
* Name [varchar(100)]
* Phone [varchar(20)] (nullable)
* Email [varchat(50)] (nullable)
* Website [varchat(50)] (nullable)
* Customer_Rep [varchat(50)] (nullable)

**Test**
* Id [int] **\<Pk>**
* SP_Id [int] **\<Fk>**
* TestPlan [varchar(25)] (nullable)
* WADocument [varchar(25)]
* TestDate [DateTime]
* PassResult [varchar(MAX)] (nullable)

About `ASP.NET Core`
================
If you are new to Microsoft's `.NET` framework, here is a short primer and list of references to make maintenance and development easier. <br /><br />
This application uses the *model-view-controller* design pattern, and each `SQL Server` table has it's own model, controller, and view directory containing the views for it's own *Index*, *Create*, *Detail*, and *Delete* functionalities. This application's home page will repeat some of the information in this document, for convenience. <br /><br />
To modify the underlying database structure, **do not** modify the database directly. `.NET Core` maintains the database through a mechanic called `Database Migrations`, which are interpreted by `Visual Studio`'s build tools from the models themselves. Therefore, the database is derived from those classes (models), which are referred to as "*Entities*", and the framework built on top of `.NET Core` for dealing with entities is called `Entity Framework (EF)`. In short, you must modify the entities and then perform a "*migration*" from the `NuGeT` package manager console. <br /><br />
Another framework built on top of `.NET Core` for querying the database directly while writing *C#* is called `LINQ`. The proper way to check for existence or to capture database entries/properties in your source code is to use the `LINQ` query that's right for your situation. Below is a short menu of documentation to guide development. <br />
* **.NET Core Tutorials** - https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1
* **EF Tutorials** - https://docs.microsoft.com/en-us/ef/
* **LINQ Docs** - https://docs.microsoft.com/en-us/dotnet/standard/using-linq
* **EF Migrations** - https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli


Project References
================
* Kristopher Mobbs -- general COTS assistance
* Charles Broussard -- database server manager
* Mark Turowski -- general COTS assistance
* John Pitalo -- installations
* Alex Elliot -- general COTS assistance


Terms
================
* E&TD | Engineering and Test Directorate
* SME | Software Subject Matter Expert
* NPR | NASA Procedural Requirements
* SOI | Stennis Operation Instruction
* MVC | model view controller
* SWE | SoftWare Engineering


Original Author
================
Isaac Yep : https://www.linkedin.com/in/anthonybench/
