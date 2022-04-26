using Microsoft.AspNetCore.Mvc;

namespace PastelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastelAPIController : ControllerBase
    {
        [HttpGet]
        [Route("GetPastelFrango")]
        public String GetPastelFrango()
        {
            return "Pastel de frango com catupiry";
        }

        [HttpGet]
        [Route("GetPastelCarne")]
        public String GetPastelCarne()
        {
            return "Pastel de carne com mussarela";
        }

    }
}
