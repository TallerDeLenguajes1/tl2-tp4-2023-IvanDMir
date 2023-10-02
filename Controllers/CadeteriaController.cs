using Microsoft.AspNetCore.Mvc;
using Programa;

namespace tl2_tp4_2023_IvanDMir.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    
    private readonly ILogger<CadeteriaController> _logger;
    // Borrrrarrrrrrrr
    private Cadeteria cadeteria;
    private Informe informe;
    //  
     public CadeteriaController(ILogger<CadeteriaController> logger)
     {
         _logger = logger;
         cadeteria = Cadeteria.Instanciar();
     }

    [HttpGet("NombreCadeteria")]
    public ActionResult<string> GetNombre(){
        return Ok(cadeteria.MostrarNombreCadeteria());
    }
   
    [HttpGet("GetPedidos")]
    public ActionResult<List<Pedido>> GetPedidos(){
        if(cadeteria.ListadoPedidos == null){
            return BadRequest("No Hay Pedidos en esta cadeteria");
        }
        return Ok(cadeteria.ListadoPedidos);
    }
    [HttpGet("GetCadetes")]
    public ActionResult<List<Cadete>> GetCadetes(){
         if(cadeteria.MostrarCadetesCadeteria() == null){
            return BadRequest("No Hay cadetes en esta cadeteria");
        }
        return Ok(cadeteria.MostrarCadetesCadeteria());
    }
    [HttpGet("GetInforme")]
    public ActionResult<Informe> GetInformeCadeteria(){
        if(informe !=null){
            return BadRequest("No hay informe realizado");
        }
        return informe;
    }
    [HttpPost("AñadirPedido")]
    public ActionResult PostPedido(Pedido pedido){
        int tamaño1 = cadeteria.ListadoPedidos.Count();
        cadeteria.ListadoPedidos.Add(pedido);
        if (tamaño1 < cadeteria.ListadoPedidos.Count()){
            return Ok("Pedido Añadido");
        }else {
            return BadRequest("Pedido No Añadido");
        }
    }
    [HttpPut("AsignarPedido")]
    public ActionResult AsignarPedido(Pedido pedido, Cadete cadete){
        pedido.asignarCadete(cadete);
        if (pedido.CadeteResponsable == cadete){
            return Ok("Cadete Asignado");
        }else {
            return BadRequest("No ha sido Posible asignar el cadete");
        }
    }
    [HttpPost("CambiarEstado")]
    public ActionResult CambiarEstado(Pedido pedido,Estados estadoS){
        pedido.Estado = estadoS;
        if (pedido.Estado == estadoS){
            return Ok("Estado cambiado correctamente");
        }else{
           return BadRequest("No se ha podido cambiar");
        }
    }
    [HttpPut("ReasignarPedido")]
    public ActionResult ReasignarPedido(Pedido pedido, Cadete cadete){
        pedido.asignarCadete(cadete);
        if (pedido.CadeteResponsable == cadete){
            return Ok("Cadete Asignado");
        }else {
            return BadRequest("No ha sido Posible asignar el cadete");
        }

}
    [HttpGet("GetCadete")]
    public ActionResult<Cadete> GetCadete(int id){
        var cadete = cadeteria.GetCadeteid(id);
        if(cadete == null){
            return BadRequest("No se ha hallado un cadete");
        }else {
            return Ok(cadete);
        }
    }
     [HttpGet("GetPedido")]
    public ActionResult<Pedido> GetOrder(int id) {
        var pedido = cadeteria.GetpedidoID(id);
        if(pedido == null)
            return BadRequest("No se encontro el pedido");
        return Ok(pedido);
    }
      [HttpPost("Addcadete")]
    public ActionResult AddDelivery(Cadete cadete) {
        cadeteria.AgregarCadete(cadete);
        return Ok("Cadete agregado con exito");
    }
}