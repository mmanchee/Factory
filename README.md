# _Sillystringz Factory_

#### _Week 4 C# ASP.NET MCV w/ MySQL Project for Epicodus, October 16th, 2020_

#### By _**Mike Manchee**_

## Description

Dr. Sillystringz wants to keep track of his factory engineers. The good doctor needs a program that will help him figure out which engineers can repair which machines. The Dreamweaver, the Bubblewrappinator, and the Laughbox all need special attention and they can't be down for more then a nanoblarb.  
<!-- Brainstorming
View a list of Engineers
View a list of Machines
details for each Engineer
details for each Machine
list of Machines each Engineer can repair
list of Engineers each Machine has assigned
add/remove Engineers
add/remove Machines

********** Further **************
add tagout property to Machine
add idle property to Engineer
add date tracker w/ incidents and details
 -->
### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
|  1.  Create Engineer, Machine Classes | ... | ... |
|  2.  Build Engineers Controllers for Index, Create, Details, Delete, Edit | ... | ... |
|  3.  Build Machines Controllers for Index, Create, Details, Delete, Edit | ... | ... |
|  4.  Build Home Controllers and View for Index | ... | ... |
|  5.  Build Engineer Views for Index, Create, Details, Delete, Edit | ... | ... |
|  6.  Build Language Views for Index, Create, Details, Delete, Edit | ... | ... |
|  7.  Create License, MachineType, Record, EngineerLicense, and LicenseType Classes | ... | ... |
|  8.  Build Licenses Controllers for Index, Create, Details, Delete, Edit | ... | ... |
|  9.  Build MachineTypes Controllers for Index, Create, Details, Delete, Edit | ... | ... |
|  10.  Build Records Controllers for Index, Create, Details, Delete, Edit | ... | ... |
|  11.  Build License Views for Index, Create, Details, Delete, Edit | ... | ... |
|  12.  Build MachineType Views for Index, Create, Details, Delete, Edit | ... | ... |
|  13.  Build Record Views for Index, Create, Details, Delete, Edit | ... | ... |
|  14.  Add CSS and Styling | ... | ... |


## Setup/Installation Requirements

### Project from GitHub
* Download option
  * Download files from GitHub repository by click Code and Download Zip
  * Extract files into a single directory 
  * Run GitBASH in directory
  * Type "dotnet restore" to get bin and obj files
  * Type "dotnet run" in GitBash to run the program
  * Add database per the instructions below.
  * Have fun with Factory <!-- TITLE HERE -->

* Cloning options
  * For cloning please use the following GitHub [tutorial](https://docs.github.com/en/enterprise/2.16/user/github/creating-cloning-and-archiving-repositories/cloning-a-repository)
  * Place files into a single directory 
  * Run GitBASH in directory
  * Type "dotnet restore" to get bin and obj files
  * Type "dotnet run" in GitBash to run the program
  * Add database per the instructions below.
  * Have fun with Factory <!-- TITLE HERE -->

### Database Setup
* Go to appsettings.json and change the password if needed.

* Setup with SQL migrations
  * In the terminal, navigate to the project folder
  * Type "dotnet ef database update" and wait for build confirmation
  
* Setup with SQL statements 
  * Enter the following code into your SQL database and run.
  ``` SQL
  CREATE DATABASE `mike_manchee` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
  USE mike_manchee
  CREATE TABLE `engineerlicense` (
    `EngineerLicenseId` int NOT NULL AUTO_INCREMENT,
    `EngineerId` int NOT NULL,
    `LicenseId` int NOT NULL,
    PRIMARY KEY (`EngineerLicenseId`),
    KEY `IX_EngineerLicense_EngineerId` (`EngineerId`),
    KEY `IX_EngineerLicense_LicenseId` (`LicenseId`),
    CONSTRAINT `FK_EngineerLicense_Engineers_EngineerId` FOREIGN KEY (`EngineerId`) REFERENCES `engineers` (`EngineerId`) ON DELETE CASCADE,
    CONSTRAINT `FK_EngineerLicense_Licenses_LicenseId` FOREIGN KEY (`LicenseId`) REFERENCES `licenses` (`LicenseId`) ON DELETE CASCADE
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
  CREATE TABLE `engineers` (
    `EngineerId` int NOT NULL AUTO_INCREMENT,
    `Name` longtext,
    `HireDate` longtext,
    `Contact` longtext,
    PRIMARY KEY (`EngineerId`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
  CREATE TABLE `licenses` (
    `LicenseId` int NOT NULL AUTO_INCREMENT,
    `Name` longtext,
    PRIMARY KEY (`LicenseId`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
  CREATE TABLE `licensetype` (
    `LicenseTypeId` int NOT NULL AUTO_INCREMENT,
    `MachineTypeId` int NOT NULL,
    `LicenseId` int NOT NULL,
    PRIMARY KEY (`LicenseTypeId`),
    KEY `IX_LicenseType_LicenseId` (`LicenseId`),
    KEY `IX_LicenseType_MachineTypeId` (`MachineTypeId`),
    CONSTRAINT `FK_LicenseType_Licenses_LicenseId` FOREIGN KEY (`LicenseId`) REFERENCES `licenses` (`LicenseId`) ON DELETE CASCADE,
    CONSTRAINT `FK_LicenseType_MachineTypes_MachineTypeId` FOREIGN KEY (`MachineTypeId`) REFERENCES `machinetypes` (`MachineTypeId`) ON DELETE CASCADE
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
  CREATE TABLE `machines` (
    `MachineId` int NOT NULL AUTO_INCREMENT,
    `Name` longtext,
    `MachineTypeId` int NOT NULL,
    `Purchase` longtext,
    `SerialNumber` longtext,
    PRIMARY KEY (`MachineId`)
  ) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
  CREATE TABLE `machinetypes` (
    `MachineTypeId` int NOT NULL AUTO_INCREMENT,
    `Name` longtext,
    PRIMARY KEY (`MachineTypeId`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
  CREATE TABLE `records` (
    `RecordId` int NOT NULL AUTO_INCREMENT,
    `Issue` longtext,
    `RecordType` longtext,
    `Details` longtext,
    `IssueDate` longtext,
    `FinishDate` longtext,
    `EngineerId` int NOT NULL,
    `MachineId` int NOT NULL,
    PRIMARY KEY (`RecordId`)
  ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
  ```

* Setup with SQL Import
  * MySQL
    * In the Navigator > Administration window, select Data Import/Restore.
    * In Import Options select Import from Self-Contained File.
    * Navigate to mike_manchee.sql.
    * Under Default Schema to be Imported To, select the New button.
      * Enter 'mike_manchee' as the name of your database.
      * Click Ok.
    * Click Start Import.

## Known Bugs

No Known Bugs

## Technologies Used
Project Specifics
* Many to Many Database relationships

Main Programs
* MySQL
* C# / ASP.NET Core 
* MVC
* MSTest
* CSS
  * Bootstrap
  * Font Awesome [Link Here](https://www.w3schools.com/icons/fontawesome_icons_intro.asp)


### Other Links
[GitHub](https://blog.agood.cloud/img/common/github.png)
[Mike's GitHub](https://github.com/mmanchee)

### License

Copyright (c) 2020 **_{Mike Manchee}_**
Licensed under MIT