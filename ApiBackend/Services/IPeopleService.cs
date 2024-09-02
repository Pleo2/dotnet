using System;
using ApiBackend.Controllers;

namespace ApiBackend.Services;

public interface IPeopleService
{
    bool Validate(People people);
}
