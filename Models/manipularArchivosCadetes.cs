using System.Text.Json;
using Programa;
public class CadeteAccesso {
    public List<Cadete> Obtener() {
        List<Cadete> cadetes;
        var ruta = "Datos/Cadete.json";
        string documento;
        using(var reader = new StreamReader(ruta)) {
            documento = reader.ReadToEnd();
        }   
        cadetes = JsonSerializer.Deserialize<List<Cadete>>(documento);
        return cadetes;
    }

    public void GuardarCadetes(List<Cadete> Listacadetes) {
        var ruta = "Datos/Cadete.json";
        var datos = JsonSerializer.Serialize(Listacadetes, new JsonSerializerOptions { WriteIndented = true });
        using(var writer = new StreamWriter(ruta)) {
            writer.WriteLine(datos);
        }
    }
}