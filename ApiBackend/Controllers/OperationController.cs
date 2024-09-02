using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DebuggerDisplay($"{{{nameof(Get)}(),nq}}")]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b )
        {
            return a + b;
        }
        [HttpPost] 
        public decimal Sustraendo(decimal a, decimal b, Numbers numbers,[FromHeader] string Host, [FromHeader(Name = "Content-Length")] string  ContentLenght, [FromHeader(Name = "X-Customheader")] string XCustomHeader,bool useTheBody = false) {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLenght);
            Console.WriteLine(XCustomHeader);
            
            if (useTheBody) {
                return numbers.A - numbers.B;
            }
            var resultQuery = a - b;
            return resultQuery;
        }
    }

    public class Numbers {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }
}
