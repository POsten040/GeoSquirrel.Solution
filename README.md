# _GeoSquirrel_

### _January 25, 2021_

### By Svea Wade, Nathan Schrader, Randel Moore, Patrick Osten 

## **Project Description**
This is a website that allows you to create a profile and log and track geocaches near you.  


## **Usage / Examples**


## **Required for Use**
* C# and .Net Core installed on your local machine. (Developed on .Net Core v2.2.4)
* Console/Terminal access.
* Code Editor like [Visual Studio Code](https://code.visualstudio.com/)
* MySQL Community Server
* MySQL Workbench
* Postman (optional but recommended)


## **Installation Instructions**
Download [.Net Core](https://dotnet.microsoft.com/download) and follow the installation instructions for your computer's
operating system.



### **Installing C#, .NET**
Install C# and .Net according to your operating system below:

**For Mac**
1. Download this .NET Core SDK Software Development Kit. 
2. Open the .pkg file. This will launch an installer which will walk you through installation steps. Use the default settings the installer suggests.
3. Confirm the installation is successful by opening your terminal and running the command <code>dotnet --version</code>, which should return the correct version number.

**For Windows**
1. Download either the the 64-bit .NET Core SDK Software Development Kit
2. Open the file and follow the steps provided by the installer for your OS.
3. Confirm the installation is successful by opening a new Windows PowerShell window and running the command <code>dotnet --version</code> You should see a response with the correct version number.

**My SQL Installation Below** 

**Windows 10 -**

Start by downloading the MySQL Web Installer from the [MySQL Downloads](https://dev.mysql.com/downloads/file/?id=484919) page. (Use the No thanks, just start my download link.)

Follow along with the installer:

1) Click "Yes" if prompted to update.
2) Accept license terms.
3) Choose Custom setup type.
4) When prompted to Select Products and Features, choose the following:
* MySQL Server 8.0.19 (This will be under "MySQL Servers > MySQL Server > MySQL Server 8.0")

* MySQL Workbench 8.0.19 (This will be under "Applications > MySQL Workbench > MySQL Workbench 8.0")

5) Select "Next", then "Execute". Wait for download and installation. (This can take a few minutes.)

6) Advance through Configuration as follows:

* High Availability set to "Standalone".

* "Defaults are OK" under Type and Networking.

* Authentication Method set to Use Legacy Authentication Method.

* Set password to something you will remember. 

* Defaults are OK under Windows Service. Make sure that checkboxes are checked for the options "Configure MySQL Server as a Windows Service" and "Start the MySQL Server at System Startup". Under Run Windows Service as..., the "Standard System Account" should be selected.

7) Complete Installation process.
Next, add the MySQL environment variable to the System PATH. We must include MySQL in the System Environment Path Variable. This is its own multi-step process:

8) Open the Control Panel and visit System and "Security > System". Select "Change Settings" and a pop-up window will display. Select the tab "Advanced" and select the "Environment Variables" button.
9) Within the System Variables navigator window, select PATH..., click Edit..., and then New.

10) Add the exact location of your MySQL installation, and click OK. (This location is likely C:\Program Files\MySQL\MySQL Server 8.0\bin, but may differ depending on your specific installation.)

**MacOS -**

Start by downloading the MySQL Community Server .dmg file from the [MySQL Community Server page](https://dev.mysql.com/downloads/file/?id=484914). Click the download icon. Use the No thanks, just start my download link.

Next, follow along with the Installer until you reach the Configuration page. Once you've reached Configuration, select or set the following options (use default if not specified):

1) Use Legacy Password Encryption.

2) Set password to something you will remember.

3) Click Finish.

4) Open the terminal and enter the command echo 'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile. This will save this path in .bash_profile, which is where our terminal is configured.

5) Type in source ~/.bash_profile (or restart the terminal) in order to actually verify that MySQL was installed.

Next, verify MySQL installation by opening terminal and entering the command mysql -uroot -pepicodus. You'll know it's working and connected if you gain access and see the MySQL command line. If it's not working, you'll likely get a -bash: mysql: command not found error.

You can exit the mysql program by entering exit.

Next, download the MySQL Workbench .dmg file from the MySQL Workbench page. (Use the No thanks, just start my download link.)

Install MySQL Workbench to Applications folder.

Then open MySQL Workbench and select the Local instance 3306 server. You will need to enter the password you set. (We used epicodus.) If it connects, you're all set.


### **Install/Setup Project**

**Download The Project**

Option 1 (download zip file)
1) Copy and paste the following GitHub project link into your web browser's url bar and hit enter/return. 
2) Download a .zip copy the repository by clicking on the large green "Code" button near the upper right corner of the screen.
3) Right click the .zip file and extract(unzip) it's contents.
4) Open your computer's terminal/console, and navigate to folder called "__GeoSquirrel.Solution__". 


Option 2 (via git console/terminal)
1) Open your Git enabled terminal/console and navigate to a directory that you wish to download this project to.
2) Type the following line of code into your terminal/console to automatically download the project to your current directory and hit return/enter

    <code>git clone https://github.com/schradermade/GeoSquirrel.Solution.git</code>

3) Once the project has finished downloading, use the terminal/console to navigate to the “__GeoSquirrel.Solution__" folder of the project.
  
**Install Postman**
This is optional https://www.postman.com/downloads/ 


**Setup Database Connection**

Create a new file in the root directory of the __BusinessLookup.Solution/ directory named "appsettings.json".  Copy and past the following code inside of the file.

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=geosquirrel;uid=root;pwd=epicodus;"
  }
}

```
Replace "YourId" and "YourPassword" in the code above with the user id and user password you use for logging into MySQL Workbench.  Save the "appsettings.json" file.

Navigate to `GeoSquirrelClient` directory and type the following code and hit enter/return to install the necessary dependencies. 

<code>dotnet restore</code>

Once the dependencies have installed, type the following command to build the database the projects uses.

<code>dotnet ef database update</code>

After installing dependencies and building the database, run the project with the command 

<code>dotnet run</code>

**Swagger**
 
Here is the information on Swagger which was implemented in this project: https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0 
I personally used Swashbuckle, the documentation for intalling swashbuckle is here: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio 


## API Information
**Swagger**
To view the business lookup API with swashbuckle do the following commands:

<code>dotnet run<code>
and navigate to:
<code>(http://localhost:5000/swagger/index.html)</code>

----------------------------------------------------------------------
### Endpoints

Base URL: 
```
https://localhost:5000
```

HTTP Request Structure: 

```
GET /api/{component}
POST /api/{component}
GET /api/{component}/{id}
PUT /api/{component}/{id}
DELETE /api/{component}/{id}
```
---------------------------------------------------------------------

### Caches

Access the name, latitude, longitude and date added for the geocaches. 

HTTP Request Structure: 

```
GET /api/caches
POST /api/caches
GET /api/caches/{id}
PUT /api/caches/{id}
DELETE /api/caches/{id}
```

-------------------------------------------------------------------------


**Example of a Query:** 

```
https://localhost:5000/api/caches/1
```

**Sample JSON Response:**

```

```
**Example of a Search Query**
```
http://localhost:5000/api/caches/?latitude=
```

JSON Response: 
```

```

## Technology Used

* C# 7.3
* .NET Core 2.2
* Entity
* Git
* MySQL
* dotnet script, REPL
* Swagger
* Visual Studio Code
* Identity
  
## Known Bugs
There are no known bugs


## Support and contact details
You can reach out to any of us via email:

Nathan Schrader <>
Patrick Osten <>
Randel Moore <Randel.C.Moore@gmail.com>
Svea Wade <svealinneawade@gmail.com>

## Legal

I used the MIT license, see below: Copyright (c) 2020 Svea Wade, Randel Moore, Patrick Osten, Nathan Schrader Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
