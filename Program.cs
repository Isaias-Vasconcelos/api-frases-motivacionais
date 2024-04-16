using Dapper;
using FrasesMotivacionais.Database;
using FrasesMotivacionais.Frases;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var db = Config.Database();

var frases = app.MapGroup("/api/frases");

frases.MapGet("/", async () =>
{

    var mensagensDb = await db.QueryAsync<string>("SELECT texto FROM mensagens");
    var mensagensArray = mensagensDb.ToArray();

    var rand = new Random();

    var indexRandomico = rand.Next(0, mensagensArray.Length - 1);

    return Results.Ok(new
    {
        Mensagem = mensagensArray[indexRandomico]
    });

});

frases.MapPost("/", async (AdicionarNovaMensagem novaMensagemInput) =>
{
    try
    {
        await db.ExecuteAsync("INSERT INTO mensagens (texto) VALUES (@Texto)", new { novaMensagemInput.Texto });

        return Results.Ok(new
        {
            Info = "Mensagem adicionada com sucesso!"
        });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new
        {
            Error = ex.Message
        });
    }
});

app.Run();
