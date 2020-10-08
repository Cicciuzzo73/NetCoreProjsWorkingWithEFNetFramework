This solution shows how to use an EF6 library (written in .Net framework 4.7.2) with newer projects.

Project <b>OldEF6Library</b> is the original API that we want to reuse in our .Net core projects. The EF refers to a database which contains just one sample table: "Users" (Id int primary key, Name varchar (200)).

Project <b>CoreConsoleApp</b> is a .Net core 3.1 console application. It consumes the OldEF6Library. To configure the connection string that the library will use, we put it in App.config file.


