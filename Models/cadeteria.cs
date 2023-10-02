using ACCESOADATOS;

namespace Programa{
    public class Cadeteria
    {
        static Cadeteria S_Cadeteria;
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        
        private List<Pedido> listadoPedidos;

       public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }


        public Cadeteria(string nombre, string celular, List<Cadete> listaCadete)
        {
            this.nombre = nombre;
            this.telefono =celular;
            this.listadoCadetes = new List<Cadete>();
            this.listadoCadetes.AddRange(listaCadete);
            this.listadoPedidos = new List<Pedido>();
        }
         public Cadeteria()
        {
            this.nombre="";
            this.telefono="";
            this.listadoCadetes=new List<Cadete>();
            this.listadoPedidos=new List<Pedido>(); 
        }
        
        public string MostrarNombreCadeteria(){
            return this.nombre;
        }
         public string MostrarTelefonoCadeteria(){
            return this.telefono;
        }
        public List<Cadete> MostrarCadetesCadeteria(){
            return listadoCadetes;
        }

        public void tomarPedido(Pedido PedidoTomado){
            this.listadoPedidos.Add(PedidoTomado);
        }

        public double jornalACobrar(int idDelCadete){
            int PedidosEntregados = 0;
            var cadete = this.listadoCadetes.FirstOrDefault(l=>l.Id==idDelCadete);
            if (cadete !=null){
                foreach (var pedido in this.listadoPedidos){
                    if (pedido.CadeteResponsable==cadete && pedido.Estado==Estados.aceptado){
                           PedidosEntregados += 1;
                    }
                }
             
            }else {
                return 0;
            }
            double Jornal = 500* PedidosEntregados;
            return Jornal;
        }
    public void AsignarCadetePorID(int idCadete, int idPedido){
         var cadete = this.listadoCadetes.FirstOrDefault(l=>l.Id==idCadete);
         var pedido = this.listadoPedidos.FirstOrDefault(l=>l.Numero==idPedido);
         if (cadete != null && pedido !=null){
            pedido.asignarCadete(cadete);
         }else{
              return ;
         }
           
            }
             public void aceptarPedido(int idPedido){
            var pedido = this.listadoPedidos.FirstOrDefault(l=>l.Numero==idPedido);
            if(pedido != null){
                pedido.AceptarPedido();
            }
       }
  
        public List<Pedido> PedidosPendientes(){
            List<Pedido> pedidosPendientes = new List<Pedido>();
            foreach ( var pedido in this.listadoPedidos)
            {
                if (pedido.Estado == Estados.pendiente){
                    pedidosPendientes.Add(pedido);
                }
            }
            return pedidosPendientes;
        }
        public static Cadeteria Instanciar(){
            if(S_Cadeteria == null){
                AccesoADatos Instancia = new ManipulacionJSON();
                S_Cadeteria = Instancia.LeerArchivoDeCadeteria().First();
            }
            return S_Cadeteria;
        }
    }   
}