# Creating an ASP.NET MVC Project

## Setting Up

1. **Open Visual Studio.**
2. **Create a new project and select ASP.NET Web Application.**
3. **Choose the MVC template and ensure that authentication is set as needed.**

## Install NuGet Packages

Make sure you install all of these if you want a functinal application, to install go under

`Tools` > `NuGet Packaage Manager` > `Manage NuGet Packet` for Solution and then downlaod the below:

1. `Microsoft.EntityFrameWorkCore`
2. `Microsoft.EntityFrameWorkCore.Design`
3. `Microsoft.EntityFrameWorkCore.Sql`
4. `Microsoft.EntityFrameWorkCore.Tools`

![image](https://github.com/noturlee/MVC-Basics/assets/100778149/ec59ac63-6aab-4b59-8f74-6561ca85ee71)

## Scaffold your Database

To Connect to your database go to :

View > SQL Server Object explorer > find your SSMS Database > right click on it > properties > a side bar will open> scroll and find Connection string

![image](https://github.com/noturlee/MVC-Basics/assets/100778149/21e30aa0-e71c-4c6d-90af-488e2ef54cdf)

Now go to:

`Tools` > `NuGet Package Manager` > `Packet Manager Console`:

Copy the below Code, Change the Connection string to yours paste it in 'Paste Your Connection String'

`Scaffold-DbContext "Paste Your Connection String " Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models`

Press `Enter` and it will start scaffolding, it may take a while, a yellow bar will appear so that means you doing it right
The Scaffolding will Add your Database Tables in the `Models` Folder


## Adding a Controller

1. **Right-click on the Controllers folder.**
2. **Select Add and then Controller.**
3. **Choose MVC Controller with views, using Entity Framework.**
4. **Follow the prompts to link the Model and context.**

Adding the Controller e.g. for the Model Donations will create a View automatically for that table

## Running the Application

1. **Build the project.**
2. **Run it using the local server provided by Visual Studio.**

Follow these steps, and you will have a basic ASP.NET MVC application running on your local machine.
