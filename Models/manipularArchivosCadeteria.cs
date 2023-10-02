namespace Programa;
using System.Text.Json;
public class AccesoADatosCadeteria {
    public Cadeteria Obtener(){
        List<Cadeteria> LCadeteria;
        var ruta = "Datos/Cadetria.Json";
        string documento;
        using(var reader = new StreamReader(ruta)) {
            documento = reader.ReadToEnd();
        }
        LCadeteria = JsonSerializer.Deserialize<List<Cadeteria>>(documento);
        return LCadeteria[0];
    }
    }
