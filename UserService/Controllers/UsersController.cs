using System.Net;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Dtos;
using UserService.Models;
using AutoMapper;

namespace UserService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetUsers()
        {
            var users = _repo.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpGet("{id}", Name="GetUser")]
        public ActionResult<UserReadDto> GetUser(int id)
        {
            var user = _repo.GetUserById(id);
            if (user != null)
                return Ok(_mapper.Map<UserReadDto>(user));
            
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var user  = _mapper.Map<User>(userCreateDto);
            if(user == null)
            {
                throw new System.ArgumentNullException();
            }

            _repo.CreateUser(user);
            _repo.SaveChages();

            var userReadDto = _mapper.Map<UserReadDto>(user);

            return CreatedAtRoute("GetUser", new {Id = userReadDto.Id}, userReadDto);
        }
        
    }
}