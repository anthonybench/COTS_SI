# Deployment Information
### *Address to the database server found in the JSON object `ConnectionStrings` in `appsettings.json`*

<br /><br />

## **Local Database Instance**

This App-Version `ConnectionString` <br />
*"COTSContext": "Server=(localdb)\\mssqllocaldb;Database=cotssi_dev;Trusted_Connection=True;MultipleActiveResultSets=true"*

<br />

## **Database Server Details**

Database Server Address: <br/>
> *none*

Database Name: <br />
> cotssi_dev

This App-Version `ConnectionString`: <br />
> *None*

<br />

## **Deployment**

This project builds as a *netcoreapp3.1* build, which is the latest configuration at the time of writing (*8/6/2020*). To deploy a build, set the build configuration to *Release* on *Any CPU* to ensure portability, and used the Visual Studio *Publish* tool to build the final application. Since a build has already been published, also ensure that *Delete existing files* is set to `True`. When you publish a *.NET Core* web application, it will place the deployment file tree in `bin/Release/netcoreapp3.1/publish`, which you will copy and paste directly to the desired application file address (top of this document).