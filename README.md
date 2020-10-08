This solution shows how to consume an EF6 library (written in .Net Framework 4.7.2) from newer .Net Core projects.

Project <b>OldEF6Library</b> is the original API that we want to reuse in our .Net core projects. The EF refers to a database which contains just one sample table: "Users" (Id int primary key, Name varchar (200)). It uses the DB first approach with the EDMX model.

Project <b>CoreConsoleApp</b> is a .Net core 3.1 console application. It consumes the OldEF6Library. To configure the connection string that the library will use, we insert it in App.config file. The Old library will 

