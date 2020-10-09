This solution shows how to consume an EF6 library (written in .Net Framework 4.7.2) from newer .Net Core projects.

Project <b>OldEF6Library</b> is the original Entity Framework 6 project that we want to reuse in our .Net core projects. 
The EF project points to a database which contains just one sample table: "Users", which can be recreated like this:
    
    Create table Users ([Id] int primary key, [Name] varchar (200)). 
    
This "classic" library uses the DB first approach and generates an EDMX model.

Project <b>CoreConsoleApp</b> is a newer .Net core 3.1 console application. It consumes the OldEF6Library. 
To configure the connection string that the library will use, we insert it in an App.config file in the CoreConsoleApp project. 
The "Old" library will use this configuration file to configure the EF source. 

Project <b>CoreWebApp</b> in a .Net Core 3.1 MVC web application. As with the CoreConsolApp project, the EF configuration strings are in a file called App.config. 

Project <b>CoreFunction</b> is a .Net core 3.1 Azure function project, which you can run locally or deploy to Azure. Differently from the other two projects, the original EF library  needs a small refactoring to allow the function to use it. This is because the version v2 and v3 of Azure functions _don't_ support the ConfigurationManager API. 
The following statement in the EF library generates therefore an exception as it uses the ConfigurationManager and it cannot read the UserEntities entry in a configuration file:

    public UserEntities():base("name=UserEntities")
        {
        } // this won't work.

So, it is necessary to inject a connection string from the CoreFunction assembly to the old library, rather than using configuration files. 
An additional constructor becomes necessary to allow the client to inject a connection string in the class UserModel.Context.cs (generated by EF in the case of database - first EDMX):

     public UserEntities(string connectionString)
        : base(connectionString)
        {
        }
        
Unfortunately, the class where we need to create a new constructor is generated by a tool and could be overwritten the next time we regenerate the model. 
We could use the mechanism of partial classes to prevent the destruction of the new constructor when a new Model is created from the DB.

In order to configure the connection string in the .Net core function (client), we use environment variables (corresponding to app settings in Azure). 

_Locally_
![EnvironmentVariables in Visual Studio](/docs/ConnectionStringCoreFunction.PNG)

_Azure_
![EnvironmentVariables in Azure](/docs/ConnectionStringCoreFunction Azure.PNG)

In the client project, these variables are read (both locally and in Azure) with the this instruction:

     OldEF6Class.ConnectionString = Environment.GetEnvironmentVariable("UserEntitiesConnectionString");

Good luck!





