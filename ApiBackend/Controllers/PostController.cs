using ApiBackend.DTOs;
using ApiBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController([FromKeyedServices("PostService")]IPostsService postsService) : ControllerBase
    {
        readonly IPostsService _postsServices = postsService;
        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get () =>
            await _postsServices.Get();
    }
}
