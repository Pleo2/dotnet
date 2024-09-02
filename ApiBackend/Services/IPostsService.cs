using System;
using ApiBackend.DTOs;

namespace ApiBackend.Services;

public interface IPostsService
{
    public Task<IEnumerable<PostDto>> Get(); 
}
