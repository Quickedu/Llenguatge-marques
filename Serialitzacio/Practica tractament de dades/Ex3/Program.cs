var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/test", () => "Hello World!");

app.MapPost("/introduirinfo", (string info) => {
    var info2 = "Hola, ";
    return info2+info;
});

app.Run();


<?php
header("Content-Type: application/json"); //Devolveremos un JSON

// Obtenemos el JSON del formulario usando el $_POST que es un objeto de php que contiene los datos enviados por el formulario
$json = $_POST['inputJson'];

// Devolvemos el JSON recibido codificado en JSON
echo json_encode($data);
<!DOCTYPE html>
<html lang="ca">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>JSON a Api</title>
</head>

<body>
    <h2>Conversió de JSON a Api</h2>
    <textarea id="jsonInput" placeholder="Enganxa aquí el teu JSON"></textarea>
    <button onclick="sendJson()">Convertir</button>

    <form id="jsonForm" method="post" action="jsonToApi.php" type="application/json"> <!--action es a donde se envia el contenido del form-->
        <input type="hidden" name="inputJson" id="input">
    </form>
    <script>

        function sendJson() {
            const jsonInput = document.getElementById('jsonInput').value;
            const parsedData = JSON.stringify(JSON.parse(jsonInput)); //Parsea el texto en un JSON valido. JSON = JavaScript Object Notation = Objeto de JavaScript y lo convierte en un string valido para PHP
            document.getElementById('input').value = parsedData; //Guarda el json en un input oculto
            document.getElementById('jsonForm').submit(); //Envia el formulario
        }
    </script>
</body>

</html>