# Selise_Task_Project_API
This Project has been designed with N-Tier architecture of three layer of API, Business Logic Layer and Database Access Layer Project. Also there is Xunit  test project for unit testing.

# Dependencies
Need latest .NET 6 SDK fork running this project in local <b> SDK 6.0.417 </b>

# Project Internal Dependencies
As have said there are 3 layer. So this projects are interdependent.
Main API Project <b> SeliseTaskProject </b> has project refference of <b>BusinessLogicLayer</b> project,
Then <b>BusinessLogicLayer</b>  has project refference of <b> DatabaseAccessLayer</b> project.
So project refference should be ensured to run the project with dependencies.

Lastly Unit testing Project has refference of both <b> SeliseTaskProject </b> api project and <b>BusinessLogicLayer</b> project.

#DB 
Script added which can be restored in Microsoft SQL Server or try command <b>update-database</b> by selecting project <b>DatabaseAccessLayer </b> for having the schema from migrations in that project.

#Postman Request Live Documentaion
https://documenter.getpostman.com/view/15373317/2s9Ykq6fx3
