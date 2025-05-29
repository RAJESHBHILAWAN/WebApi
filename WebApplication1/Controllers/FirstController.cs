using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Classes;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        IStudent _student;
        public FirstController(IStudent student)
        {
            _student = student;
        }
    }
}
