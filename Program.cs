using FrasesMotivacionais.Routes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.InitRoutes();

app.UseCors(x => {
  x.AllowAnyHeader();
  x.AllowAnyMethod();
  x.AllowAnyOrigin();
});
app.Run();
