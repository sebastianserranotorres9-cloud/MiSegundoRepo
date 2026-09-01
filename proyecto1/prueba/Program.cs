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

string github_token = "ghp_1234567890abcdefghijklmnopqrstuvwx";
