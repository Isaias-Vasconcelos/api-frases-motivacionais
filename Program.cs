using FrasesMotivacionais.Routes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.InitRoutes();
app.Run();
