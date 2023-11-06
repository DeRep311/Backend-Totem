using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class PlanosController : ControllerBase
{

    private IPlanosServices _Planos;

    public PlanosController(IPlanosServices Ubication)
    {
        _Planos = Ubication;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = _Planos.GetAll();

            if (result != null)
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
    public async Task<IActionResult> Add([FromForm] PlanosDTO planos, IFormFile file)
    {
        // Accede a los datos de PlanosDTO
        var codigoPlano = planos.Plano;


        if (file.Length > 0)
        {
            // Genera un nombre único para el archivo
            var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Ruta donde se almacenará el archivo
            var rutaArchivo = Path.Combine("imagenes", nombreArchivo);

            // Guarda el archivo en la carpeta
            using (var stream = new FileStream(rutaArchivo, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Aquí puedes procesar los datos de PlanosDTO y la ruta del archivo según tus necesidades
            // Por ejemplo, puedes guardar la información en la base de datos y asociar la ruta del archivo.

            // Devuelve una respuesta adecuada, por ejemplo, un objeto JSON con el resultado de la operación
            return Ok(new { message = "Plano agregado exitosamente" });
        }

        // Devuelve una respuesta de error si no se envió ningún archivo
        return BadRequest(new { message = "No se proporcionó ningún archivo" });
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(PlanosDTO planos)
    {

        _Planos.Delete(planos);

        return Ok();

    }
}
