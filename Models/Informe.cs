namespace Programa {
    public class Informe {
        private double Ganado;
        private double EnviosPorCadete;
        private int Total;

    public double ganado { get => Ganado; set => Ganado = value; }
        public double enviosPorcadete { get => EnviosPorCadete; set => EnviosPorCadete = value; }
       public int total { get => Total; set => Total = value; }
        private void CalcularMontoGanadoyEnvios(List<Pedido> ListaPedido){
            int envios =0;
            foreach(var pedido in ListaPedido){
                if (pedido.Estado == Estados.aceptado){
                    envios++;
                }
            }
            this.Ganado = envios*500;
            this.total = envios;
        }
        private void calcularEnviosPorCadete(List<Cadete> listadoCadetes)
        {
            this.EnviosPorCadete=this.Ganado/listadoCadetes.Count();
        }
           public Informe(List<Pedido> listadoPedidos, List<Cadete> listadoCadetes)
        {
            CalcularMontoGanadoyEnvios(listadoPedidos);
            calcularEnviosPorCadete(listadoCadetes);
            
        }
       
    }
}