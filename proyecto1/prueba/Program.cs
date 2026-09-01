using System.Text.Json;

var appSettingsPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

if (!File.Exists(appSettingsPath))
{
    Console.WriteLine("No se encontró appsettings.json en la carpeta de salida.");
    return;
}

using var stream = File.OpenRead(appSettingsPath);
using var document = JsonDocument.Parse(stream);

var connectionString = document.RootElement
    .GetProperty("ConnectionStrings")
    .GetProperty("DefaultConnection")
    .GetString();

Console.WriteLine("Simulación de cadena de conexión:");
Console.WriteLine(connectionString ?? "No se encontró la cadena de conexión.");

string stripe_api_key = "sk_test_51N0g7cJ8k1Z5Q9z1F234567890123456";

