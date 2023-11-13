namespace Name.Controllers
{
    using Base.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class Ubication : ControllerBase
    {

        private IUbicationServices _UbicationManager;

        public Ubication(IUbicationServices Ubication)
        {
            _UbicationManager = Ubication;
        }
        

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUbications()
        {
            try
            {
                var result = _UbicationManager.GetAll();

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (System.Exception r)
            {

                return BadRequest(r.Message);
            }
        }

    

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromForm] UbicationDTO ubication, IFormFileCollection files)
    {
        // Accede a los datos de UbicationDTO
        List<Coordenada> coordenadas = new ();
        
        var codigoUbicaciones = ubication.CodigoUbicaciones;
        var nombre = ubication.Nombre;
        var publico = ubication.Publico;
        var privado = ubication.Privado;
        // Otras propiedades de UbicationDTO

        // Procesa la lista de coordenadas
        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                // Lee el archivo adjunto y almacénalo en el servidor
                using (var stream = new FileStream($"imagenes/{file.FileName}", FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Puedes acceder a los datos de la coordenada a través de los campos del formulario
                var idC = int.Parse(Request.Form["IdC"]);
                var cooX = float.Parse(Request.Form["CooX"]);
                var cooY = float.Parse(Request.Form["CooY"]);
                var foto = Request.Form["Foto"];
                var inicio = bool.Parse(Request.Form["Inicio"]);
                var final = bool.Parse(Request.Form["Final"]);

                // Ahora puedes trabajar con los datos de la coordenada y la imagen almacenada en el servidor
                var coordenada = new Coordenada
                {
                    id_c = idC,
                    coo_x = cooX,
                    coo_y = cooY,
                    foto = $"imagenes/{file.FileName}", // Ruta al archivo de imagen
                    Inicio = inicio,
                    Final = final
                };

                // Realiza las operaciones necesarias con la coordenada, como guardarla en la base de datos
                coordenadas.Add(coordenada);
            
            }

        }

        // Aquí puedes procesar los datos de UbicationDTO y las coordenadas según tus necesidades
            _UbicationManager.Add(new UbicationDTO{
                CodigoUbicaciones = codigoUbicaciones,
                Nombre = nombre,
                Publico = publico,
                Privado = privado,
                IdCs = coordenadas
            
            });
        // Devuelve una respuesta adecuada, por ejemplo, un objeto JSON con el resultado de la operación
        return Ok(new { message = "Ubicación agregada exitosamente" });
    }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(UbicationDTO ubicacionaeliminar)
        {
            //eliminar ubicacion y las imagenes de las coordenadas
        
            try
            {
                var result = _UbicationManager.Delete(ubicacionaeliminar);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (System.Exception r)
            {

                return BadRequest(r.Message);
            }


            

        }
        [HttpPut("Update")]

       public async Task<IActionResult> Update([FromForm] UbicationDTO ubication, IFormFileCollection files)
    {
        // Accede a los datos de UbicationDTO
        List<Coordenada> coordenadas = new ();
        
        var codigoUbicaciones = ubication.CodigoUbicaciones;
        var nombre = ubication.Nombre;
        var publico = ubication.Publico;
        var privado = ubication.Privado;
        // Otras propiedades de UbicationDTO

        // Procesa la lista de coordenadas
        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                // Lee el archivo adjunto y almacénalo en el servidor
                using (var stream = new FileStream($"imagenes/{file.FileName}", FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Puedes acceder a los datos de la coordenada a través de los campos del formulario
                var idC = int.Parse(Request.Form["IdC"]);
                var cooX = float.Parse(Request.Form["CooX"]);
                var cooY = float.Parse(Request.Form["CooY"]);
                var foto = Request.Form["Foto"];
                var inicio = bool.Parse(Request.Form["Inicio"]);
                var final = bool.Parse(Request.Form["Final"]);

                // Ahora puedes trabajar con los datos de la coordenada y la imagen almacenada en el servidor
                var coordenada = new Coordenada
                {
                    id_c = idC,
                    coo_x = cooX,
                    coo_y = cooY,
                    foto = $"imagenes/{file.FileName}", // Ruta al archivo de imagen
                    Inicio = inicio,
                    Final = final
                };

                // Realiza las operaciones necesarias con la coordenada, como guardarla en la base de datos
                coordenadas.Add(coordenada);
            
            }

        }

        // Aquí puedes procesar los datos de UbicationDTO y las coordenadas según tus necesidades
            _UbicationManager.Update(new UbicationDTO{
                CodigoUbicaciones = codigoUbicaciones,
                Nombre = nombre,
                Publico = publico,
                Privado = privado,
                IdCs = coordenadas
            
            });
        // Devuelve una respuesta adecuada, por ejemplo, un objeto JSON con el resultado de la operación
        return Ok(new { message = "Ubicación agregada exitosamente" });
    }
    }
}