# Friday Project Set-Up

## Set up API and Databases

    dotnet --info (to check and see if you have the correct version, not neccesary if webapi command works)
    dotnet new globaljson --sdk-version 2.2.106
dotnet new webapi --framework netcoreapp2.2
dotnet add package Microsoft.EntityFrameworkCore -v 2.2.0
dotnet add package Pomelo.EntityFrameworkCore.MySql -v 2.2.0 

1. Setup the .Solution folder to hold the ProjectNameAPI folder and the ProjectNameMVC folder. 
2. Navigate to the API folder and run the above commands for "set up API and Databases"
3. Navigate to the Startup.cs and comment out the app.UseHttpsRedirection();
4. Now add the dotnet packages listed above
5. Update the Startup CS as below:

```
using CretaceousPark.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CretaceousPark
{
  public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CretaceousParkContext>(opt =>
                opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
```

6. Update your appsettings.JSON should look like the below:
```
   {
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=cretaceous_park;uid=root;pwd=epicodus;"
  }
}
```
7. Now create your Models Folders and add a ProjectNameContext.cs and add a DB Context Class

```
using Microsoft.EntityFrameworkCore;

namespace CretaceousPark.Models
{
    public class CretaceousParkContext : DbContext
    {
        public CretaceousParkContext(DbContextOptions<CretaceousParkContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
    }
}
```
8. Add a model file for your project example: Class.cs (in cretaceous park we named it Animal.cs)
9.  Run the following commands: dotnet ef migrations add Initial
                               dotnet ef database update
10. You can delete the ValuesController.cs at this point or keep it for reference. 
11. Create a ClassController.cs (in cretaceous park we created AnimalsController.cs)
```
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CretaceousPark.Models;


namespace CretaceousPark.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private CretaceousParkContext _db;

    public AnimalsController(CretaceousParkContext db)
    {
      _db = db;
    }

    // GET api/animals
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> Get()
    {
      return _db.Animals.ToList();
    }

    // POST api/animals
    [HttpPost]
    public void Post([FromBody] Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
    }
    // GET api/animals/5
    [HttpGet("{id}")]
    public ActionResult<Animal> Get(int id)
    {
        return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
    }
    // PUT api/animals/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Animal animal)
    {
        animal.AnimalId = id;
        _db.Entry(animal).State = EntityState.Modified;
        _db.SaveChanges();
    }
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
      _db.Animals.Remove(animalToDelete);
      _db.SaveChanges();
    }
  }
}
```
1.  You can then seed your database within the Context.cs file. Below is the code used for cretaceous park:
```
protected override void OnModelCreating(ModelBuilder builder)
{
  builder.Entity<Animal>()
      .HasData(
          new Animal { AnimalId = 1, Name = "Matilda", Species = "Woolly Mammoth", Age = 7, Gender = "Female" },
          new Animal { AnimalId = 2, Name = "Rexie", Species = "Dinosaur", Age = 10, Gender = "Female" },
          new Animal { AnimalId = 3, Name = "Matilda", Species = "Dinosaur", Age = 2, Gender = "Female" },
          new Animal { AnimalId = 4, Name = "Pip", Species = "Shark", Age = 4, Gender = "Male" },
          new Animal { AnimalId = 5, Name = "Bartholomew", Species = "Dinosaur", Age = 22, Gender = "Male" }
      );
}
```
13. Then run the dotnet migrations command followed by dotnet ef database update.
14. You can then implement the Search Parameters code if you want: check out this lesson https://www.learnhowtoprogram.com/c-and-net/building-an-api/adding-parameters-to-a-get-request 
15. You can then add in Validations if neccesary if you check out this lesson: https://www.learnhowtoprogram.com/c-and-net/building-an-api/adding-validations
16. At this point in the process your API side should be working correctly. 


## Set up MVC application connected to the API
dotnet new mvc --framework netcoreapp2.2
dotnet add package RestSharp --version 106.6.10
dotnet add package Newtonsoft.Json --version 12.0.2

1. Run `dotnet new mvc --framework...` to build the mvc side file structure
2. Install the packages above
3. Create a class.cs file in your models. (animal.cs for this example)
```
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CretaceousClient.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public static List<Animal> GetAnimals()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }
  }
}
```
4. Create an APIHelper.cs file within the models. Make sure that the ports match the ones you are using
```
using System.Threading.Tasks;
using RestSharp;

namespace CretaceousClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}
```

6. Now you will want to create your animals controller for the MVC
7. Now you can create your views and continue on with the rest of your project. 
8. Add the GetDetails() in addition to the GetAnimals in our Animal.cs
9. You will now need to update your APIhelper by adding the Get() method you can now add your POST, PUT and DELETE methods to the MVC

Completed Animal.cs in MVC side:
```
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CretaceousClient.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public static List<Animal> GetAnimals()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }
    public static Animal GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

      return animal;
    }

    public static void Post(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      var apiCallTask = ApiHelper.Post(jsonAnimal);
    }

    public static void Put(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      var apiCallTask = ApiHelper.Put(animal.AnimalId, jsonAnimal);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
    
  }
}
```











//Possible Errors//

Attempting to:
dotnet new webapi --framework netcoreapp2.2

Error:
Couldn't find an installed template that matches the input, searching online for one that does...
ASP.NET Core Web API (C#)
Author: Microsoft
Description: A project template for creating an ASP.NET Core application with an example Controller for a RESTful HTTP service. This template can also be used for ASP.NET Core MVC Views and Controllers.
Error: Invalid parameter(s):
--framework netcoreapp2.2
    'netcoreapp2.2' is not a valid value for --framework (Framework).
    

Fix:
install appropriate version (2.2)
dotnet new globaljson --sdk-version 2.1.503