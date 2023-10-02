using System.Text.Json;
namespace Programa;
public class PedidoAccesso {
    public List<Pedido> Obtener() {
        List<Pedido> Pedidos;
        var ruta = "Datos/Pedidos.json";
        string documento;
        using(var reader = new StreamReader(ruta)) {
            documento = reader.ReadToEnd();
        }
        Pedidos = JsonSerializer.Deserialize<List<Pedido>>(documento);
        return Pedidos;
    }

    public static void Guardar(List<Pedido> Pedidos) {
        var ruta = "Datos/Pedidos.json";
        var datos = JsonSerializer.Serialize(Pedidos, new JsonSerializerOptions { WriteIndented = true });
        using(var writer = new StreamWriter(ruta)) {
            writer.WriteLine(datos);
        }
    }
}