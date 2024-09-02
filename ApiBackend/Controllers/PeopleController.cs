using ApiBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController([FromKeyedServices("keytoaccesName")]IPeopleService peopleService) : ControllerBase 
    {
        private readonly IPeopleService _peopleService = peopleService;

        [HttpGet("all")]
        public List<People> GetPeoples() => Repository.Peoples;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id) {
            var people = Repository.Peoples.FirstOrDefault(people => people.Id == id);
            if (people == null) {
                return NotFound();
            }

            return Ok(people); 
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.Peoples.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people)) {
                return BadRequest();
            }
            Repository.Peoples.Add(people);
            return NoContent();
        }
    }

    public class Repository {
        public static List<People> Peoples = [
            new People(){Id =1, Name= "Champin", Birthday = new DateTime(2016, 05, 28)},
            new People(){Id =2, Name= "Pixel", Birthday = new DateTime(2024, 03, 08)},
            new People(){Id =3, Name= "Piolina", Birthday = new DateTime(2002, 05, 02)}
        ];
    }

    public class People {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

    }
}
