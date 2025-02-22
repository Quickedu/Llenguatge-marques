var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/test", () => "Hello World!");

app.MapPost("/introduirinfo", (string info) => {
    var info2 = "Hola, ";
    return info2+info;
});

app.Run();
