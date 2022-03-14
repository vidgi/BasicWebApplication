## Basics of ASP.NET Core with Rider

*below are notes from [this video](https://www.youtube.com/watch?v=rFO1zHgkS30&ab_channel=JetBrainsTV)*

#### 1. Starting an ASP.NET Core Project
- create new project (ASP.NET Core Project) with rider, web app template
#### 2. ASP.NET Core Startup.cs
- contains config and dependencies and order of request pipeline
- iConfiguration file gives access to appsettings.json and appsettings.Development.json
- ConfigureServices allows us to add services, adding RazorPages here
- Configure Method contains IApplicationBuilder and IWebHostEnvironment
  - requires secure connection, serves static files, and does routing
- this file is very important to configure app needs
#### 3. ConfigureServices and Dependencies
  - inject service into index.cshtml: `@inject Model.HelloWorldService One`
  - add service to Program.cs"
    - adding HelloWorld service with AddTransient makes different for each instance: `builder.Services.AddTransient<HelloWorldService>();`
    - adding HelloWorld service with AddScoped is same for every page refresh: `builder.Services.AddScoped<HelloWorldService>();`
    - adding HelloWorld service with AddSingleton is same instance for whole duration each time app is run: `builder.Services.AddSingleton<HelloWorldService>();`

#### 4. Configure the Request Pipeline
- pipeline/middleware shown below
- where it is nested in chain, each step receives a request which then passes on or returns http response back (which breaks chain)
- there are many types of middleware as seen below!

`

    var app = builder.Build();
    
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    }
    
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    
    app.UseRouting();
    
    app.UseAuthorization();
    
    app.MapRazorPages();
    
    app.Run();`

#### 5. Routing and Endpoints
- use `app.UseEndpoints()` to map api with `endpoints.MapGet('some pattern')` (Can do put/get/post/delete)
- patterns can be used for constrains, placeholders that can be important for configuring the route
- than this can connect to maprazorpages or mapcontrollerroute
- uses `app.UseRouting();` to handle the path values
- lots of ways to configure such as razor pages

#### 6. ASP.NET MVC
- so that dependencies are connected: `services.AddControllersWithViews();`
- adds route attribute prefix to all endpoints [like here](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0#attributes)
- overall, this is a way to handle api requests

#### 7. ASP.NET Razor Pages
- each page is an endpoint in the app
- razor view + csharp file and each page has a ref to page directive and model


----

### additional resources:

- [Tutorial: Create a web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio-code)
- [Create web APIs with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0)
- [Basics of ASP.NET Core with Rider](https://www.youtube.com/watch?v=rFO1zHgkS30&ab_channel=JetBrainsTV)
- [.NET Rider Tutorials](https://www.jetbrains.com/dotnet/guide/technologies/.net/)
- [ASP.Net Documentation](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
- [get/post/put/patch/delete](https://medium.com/@9cv9official/what-are-get-post-put-patch-delete-a-walkthrough-with-javascripts-fetch-api-17be31755d28)
- [static deployment Blazor WASM](https://swimburger.net/blog/dotnet/how-to-deploy-aspnet-blazor-webassembly-to-github-pages)