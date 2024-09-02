using ApiBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController(
        [FromKeyedServices("RandomSingletoneService")] IRandomService randomServiceSingletone,
        [FromKeyedServices("RandomScopeService")] IRandomService randomServiceScoped,
        [FromKeyedServices("RandomTransientService")] IRandomService randomServiceTransient,
        [FromKeyedServices("RandomSingletoneService")] IRandomService randomService2Singletone,
        [FromKeyedServices("RandomScopeService")] IRandomService randomService2Scoped,
        [FromKeyedServices("RandomTransientService")] IRandomService randomService2Transient
            ) : ControllerBase
    {
        private readonly IRandomService _randomServiceSingletone = randomServiceSingletone;
        private readonly IRandomService _randomServiceScoped = randomServiceScoped;
        private readonly IRandomService _randomServiceTransient = randomServiceTransient;
        private readonly IRandomService _randomService2Singletone = randomService2Singletone;
        private readonly IRandomService _randomService2Scoped = randomService2Scoped;
        private readonly IRandomService _randomService2Transient = randomService2Transient;

        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get() {
            Dictionary<string, int> result = new()
            {
                { "Singeltone 1", _randomServiceSingletone.Value },
                { "Scope 1", _randomServiceScoped.Value },
                { "Transient 1", _randomServiceTransient.Value },
                { "Singeltone 2", _randomService2Singletone.Value },
                { "Scope 2", _randomService2Scoped.Value },
                { "Transient 2", _randomService2Transient.Value }
            };

            return result;
        }
    }
}
