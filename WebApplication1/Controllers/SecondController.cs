using Microsoft.AspNetCore.Mvc;
 using WebApplication1.Classes;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecondController : ControllerBase
    {

        IStudent _student;
        public SecondController(IStudent student)
        {
            _student = student;
        }

    }
}
