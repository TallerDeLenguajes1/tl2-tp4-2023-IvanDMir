
namespace Programa
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;

     
    public int Id { get => id; set => id = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Cadete(int id, string nombre, string telefono, string direccion)
        {
            this.id=id;
            this.nombre=nombre;
            this.direccion=direccion;
            this.telefono=telefono;
          
        }

      


      

       
    }
}