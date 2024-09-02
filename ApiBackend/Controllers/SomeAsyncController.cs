using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeAsyncController : ControllerBase
    {
        [HttpGet("async")] 
        public async Task<IActionResult> GetAsync(){
            Task<int> task1 = new(() => {
                Thread.Sleep(1000);
                System.Console.WriteLine("Connect DataBase");
                return 1;
            });

            task1.Start();
            System.Console.WriteLine("hace otra cosa");

            var res = await task1;

            System.Console.WriteLine("todo a terminado");
            return Ok(res);
        }
    }
}
