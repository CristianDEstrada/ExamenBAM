using Microsoft.AspNetCore.Mvc;
using AppERP.Dominio;
using System.Collections.Generic;
using AppERP.Infraestructura.Datos.Configs;
using AppERP.Infraestructura.Datos.Contexto;
using AppERP.Dominio.Interfaces.Repositorios;
using AppERP.Infraestructura.Datos.Repositorios;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AppERP.Aplicaciones.Servicios;
using AppERP.Dominio.Interfaces;
using AppERP.Dominio;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppERP.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {

        CompraServicio CrearServicio()
        {
            CompraContexto db = new CompraContexto();   
            CompraRepositorio repoCompra = new CompraRepositorio(db);
            ProductoRepositorio repoProducto = new ProductoRepositorio(db);
            CompraDetalleRepositorio repoDetalle = new CompraDetalleRepositorio(db);
            CompraServicio servicio = new CompraServicio(repoCompra, repoProducto, repoDetalle);    
            return servicio;
        }
        // GET: api/<CompraController>
        [HttpGet]
        public ActionResult <List<Compra>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<CompraController>/5
        [HttpGet("{id}")]
        public ActionResult<Compra> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<CompraController>
        [HttpPost]
        public ActionResult Post([FromBody] Compra compra)
        {
            var servicio = CrearServicio();
            servicio.Agregar(compra);
            return Ok("Venta Guardada");

        }

        // PUT api/<CompraController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<CompraController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Anular(id);
            return Ok("Venta Anulada");
            
        }
    }
}
