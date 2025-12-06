using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    // api/v1/products
    [ApiController]
    public class APIController : ControllerBase
    {

    }
}
