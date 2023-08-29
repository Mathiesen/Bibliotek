using System.Text.Json;
using Bibliotek.Entities;

namespace Bibliotek;

public class JsonUtils
{
    private JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public void Write(Library library, string file)
    {
        var jsonString = JsonSerializer.Serialize(library, _options);
        File.WriteAllText(file, jsonString);
    }

    public Library Read(string file)
    {
        var libraryIn = File.ReadAllText(file);
        return JsonSerializer.Deserialize<Library>(libraryIn);
    }
}