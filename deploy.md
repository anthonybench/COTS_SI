# Deployment Information
### *Address to the database server found in the JSON object `ConnectionStrings` in `appsettings.json`*
### Previous App-Version Live URL *https://sscsdcweb-dev.ndc.nasa.gov/cotssi/*
### Application File Host *`\\sscsdcweb-dev\inetpub\sscsdcweb-dev\COTSSI`*

<br /><br />

## **Local Database Instance**

This App-Version `ConnectionString` <br />
*"COTSContext": "Server=(localdb)\\mssqllocaldb;Database=COTSContext;Trusted_Connection=True;MultipleActiveResultSets=true"*

<br />

## **Database Server Details**

Database Server Address: <br/>
> *sscsdcdb1-dev.ndc.nasa.gov,14344*

Database Name: <br />
> cotssi_dev

Previous App-Version `ConnectionString`: <br />
> *connectionString="Data Source=sscsdcdb1-dev.ndc.nasa.gov,14344;Initial Catalog=cotssi_dev;Integrated Security=True"*

This App-Version `ConnectionString`: <br />
> *"COTSContext": "Server=sscsdcdb1-dev.ndc.nasa.gov,14344;Database=cotssi_dev;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True"*

<br />

## **Deployment**

This project builds as a *netcoreapp3.1* build, which is the latest configuration at the time of writing (*8/6/2020*). To deploy a build, set the build configuration to *Release* on *Any CPU* to ensure portability, and used the Visual Studio *Publish* tool to build the final application. Since a build has already been published, also ensure that *Delete existing files* is set to `True`. When you publish a *.NET Core* web application, it will place the deployment file tree in `bin/Release/netcoreapp3.1/publish`, which you will copy and paste directly to the desired application file address (top of this document).