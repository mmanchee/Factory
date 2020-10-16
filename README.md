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
|  1.  Create Engineer, Machine, and EngineerMachine Classes | ... | ... |
|  2.  Build Engineers Controllers for Index, Create, Details, Delete, Edit, and Search | ... | ... |
|  3.  Build Machines Controllers for Index, Create, Details, Delete, Edit, and Search | ... | ... |
|  4.  Build Home Controllers and View for Index | ... | ... |
|  5.  Build Engineer Views for Index, Create, Details, Delete, Edit, and Search | ... | ... |
|  6.  Build Language Views for Index, Create, Details, Delete, Edit, and Search | ... | ... |
|  7.  Add CSS and Styling | ... | ... |


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