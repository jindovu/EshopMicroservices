using Ordering.API;
using Ordering.Application;
using Ordering.Infrastruture;

var builder = WebApplication.CreateBuilder(args);

//Add service to the container 

builder.Services
    .AddApplicationServices()
    .AddInfrastuctureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

//Configure the HTTP request pipline.


app.Run();
