using FrasesMotivacionais.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options 
  => options.AddPolicy(name: "_police", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();
app.UseCors("_police");

app.InitRoutes();
app.Run();
