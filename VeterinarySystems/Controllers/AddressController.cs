using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Data;
using VeterinarySystems.Dtos.AddressDtos;
using VeterinarySystems.Model;

namespace VeterinarySystems.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepo _addrRepo;
        private readonly IMapper _addrMapper;

        public AddressController(IAddressRepo addressRepo, IMapper mapper)
        {
            _addrRepo = addressRepo;
            _addrMapper = mapper;
        }

        // api/address
        [HttpGet]
        public ActionResult<IEnumerable<AddressReadDto>> GetAllAddress()
        {
            var addrList = _addrRepo.GetAllAddresses();
            return Ok(_addrMapper.Map<IEnumerable<AddressReadDto>>(addrList));
        }


        //api/address/{id}
        [HttpGet("{id}", Name="GetAddressById")]
        public ActionResult <AddressReadDto> GetAddrById(int id)
        {
            var addr = _addrRepo.GetAddressById(id);
            if(addr != null)
            {
                return Ok(_addrMapper.Map<AddressReadDto>(addr));
            }
            return NotFound();
        }

        //POST : appi/address
        [HttpPost]
        public ActionResult<AddressCreateDto> CreateAddress(AddressCreateDto addressCreateDto)
        {
            var AddrModel = _addrMapper.Map<Address>(addressCreateDto);
            _addrRepo.CreateAddress(AddrModel);
            _addrRepo.SaveChanges();

            var addrReadDto = _addrMapper.Map<AddressReadDto>(AddrModel);
            return CreatedAtRoute(nameof(GetAddrById), new { Id = addrReadDto.Id }, addrReadDto);
        }

        // PUT : api/address/{id}
        [HttpPut("{id}")]
        public ActionResult AddressUpdate(int id, AddressUpdateDto addressUpdate)
        {
            var addressUpdateRepo = _addrRepo.GetAddressById(id);
            if(addressUpdateRepo == null)
            {
                return NotFound();
            }

            _addrMapper.Map(addressUpdate, addressUpdateRepo);
            _addrRepo.UpdateAddress(addressUpdateRepo);
            _addrRepo.SaveChanges();
            return NoContent();
        }

        //Patch  api/address/{id}
        [HttpPatch("{id}")]

        public ActionResult partialUpdate(int id, JsonPatchDocument<AddressUpdateDto> patchDoc)
        {
            var addressUpdateRepo = _addrRepo.GetAddressById(id);
            if (addressUpdateRepo == null)
            {
                return NotFound();
            }

            var AddrToPatch = _addrMapper.Map<AddressUpdateDto>(addressUpdateRepo);
            patchDoc.ApplyTo(AddrToPatch, ModelState);
            if (!TryValidateModel(AddrToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _addrMapper.Map(AddrToPatch, addressUpdateRepo);
            _addrRepo.UpdateAddress(addressUpdateRepo);
            _addrRepo.SaveChanges();

            return NoContent();

        }

        // Delete api/address/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            var addressDeleteRepo = _addrRepo.GetAddressById(id);
            if (addressDeleteRepo == null)
            {
                return NotFound();
            }

            _addrRepo.DeleteAddress(addressDeleteRepo);
            _addrRepo.SaveChanges();
            return NoContent();

        }

        [HttpGet("search={city}")]
        public async Task<ActionResult<IEnumerable<AddressReadDto>>> Search(string City)
        {
            try
            {
                var result = await _addrRepo.SearchAddr(City);

                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        } 
    }


}

