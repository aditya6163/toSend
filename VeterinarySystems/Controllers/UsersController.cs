using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Data;
using VeterinarySystems.Dtos;
using VeterinarySystems.Dtos.UserDto;
using VeterinarySystems.Model;

namespace VeterinarySystems.Controllers
{
   
    [Route("api/users")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var usersList = _repository.GetAllUsers();
            

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(usersList));
            

        }


        //api/users/{id}
        [HttpGet("{id}",Name = "GetUserById")]
        public ActionResult <UserReadDto> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            if(userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem));
            }

            return NotFound();

        }

        //POST api/users
        [HttpPost]
        public ActionResult<UserCreateDto> CreateUser(UserCreateDto userCreateDto)
        {
            var UserModel = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(UserModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(UserModel);

            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.UserId }, userReadDto);



          //  return Ok(userReadDto);
        }


        //Update : PUT // api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UserUpdate(int id, UserUpdateDto userUpdateDto)
        {
            var userUpdateRepo = _repository.GetUserById(id);
            if(userUpdateRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(userUpdateDto, userUpdateRepo);

            _repository.UpdateUser(userUpdateRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        // PATCH api/users/{id}
        [HttpPatch("{id}")]
        public ActionResult partialUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var userUpdateRepo = _repository.GetUserById(id);
            if (userUpdateRepo == null)
            {
                return NotFound();
            }
            var userToPatch = _mapper.Map<UserUpdateDto>(userUpdateRepo);

            patchDoc.ApplyTo(userToPatch, ModelState);
            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(userToPatch, userUpdateRepo);

            _repository.UpdateUser(userUpdateRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // Delete api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var deleteUserFromRepo = _repository.GetUserById(id);
            if(deleteUserFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(deleteUserFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }
    }
}
