using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Data;
using VeterinarySystems.Data.Doctors;
using VeterinarySystems.Dtos.DoctorDto;
using VeterinarySystems.Model;

namespace VeterinarySystems.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorsRepo _doctorsRepo;
        private readonly IMapper _mapper;


        public DoctorController(IDoctorsRepo doctorsRepo, IMapper mapper)
        {
            _doctorsRepo = doctorsRepo;
            _mapper = mapper;
        }

        //api/doctors
        [HttpGet]
        public ActionResult<IEnumerable<DoctorReadDto>> GetAllDoctors()
        {
            var doctorsList = _doctorsRepo.GetAllDoctors();
            return Ok(_mapper.Map<IEnumerable<DoctorReadDto>>(doctorsList));
        }


        /*
                [HttpGet("{search}")]
                public async Task<IActionResult>Search(string specialization)
                    {

                    var empquery = from x in _doctorsRepo




                }

                */


        //api/doctors/{id}
        [HttpGet("{id}", Name = "GetDoctorById")]
        public ActionResult<DoctorReadDto> GetDoctorById(int id)
        {
            var doctor = _doctorsRepo.GetDoctorById(id);
            if (doctor != null)
            {
                return Ok(_mapper.Map<DoctorReadDto>(doctor));
            }
            return NotFound();
        }

        //Post api/doctors
        [HttpPost]
        public ActionResult<DoctorCreateDto> CreateDoctor(DoctorCreateDto doctorCreate)
        {
            var DoctorModel = _mapper.Map<DoctorDetails>(doctorCreate);
            _doctorsRepo.CreateDoctor(DoctorModel);
            _doctorsRepo.SaveChanges();

            var doctorReadDto = _mapper.Map<DoctorReadDto>(DoctorModel);

            return CreatedAtRoute(nameof(GetDoctorById), new { Id = doctorReadDto.UserId }, doctorReadDto);
        }

        // Update //api/doctors/{id}
        [HttpPut("{id}")]
        public ActionResult DoctorUpdateDto(int id, DoctorUpdateDto doctorUpdate)
        {
            var doctorUpdateRepo = _doctorsRepo.GetDoctorById(id);
            if (doctorUpdateRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(doctorUpdate, doctorUpdateRepo);
            _doctorsRepo.UpdateDoctor(doctorUpdateRepo);
            _doctorsRepo.SaveChanges();
            return NoContent();

        }


        // PATCH // api/doctors/{id}
        [HttpPatch("{id}")]
        public ActionResult partialUpdate(int id, JsonPatchDocument<DoctorUpdateDto> patchDoc)
        {
            var doctorUpdateRepo = _doctorsRepo.GetDoctorById(id);
            if (doctorUpdateRepo == null)
            {
                return NotFound();
            }

            var doctorToPatch = _mapper.Map<DoctorUpdateDto>(doctorUpdateRepo);

            patchDoc.ApplyTo(doctorToPatch, ModelState);
            if (!TryValidateModel(doctorToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(doctorToPatch, doctorUpdateRepo);
            _doctorsRepo.UpdateDoctor(doctorUpdateRepo);
            _doctorsRepo.SaveChanges();

            return NoContent();


        }

        // Delete api/doctors/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(int id)
        {
            var deletedoctorFromRepo = _doctorsRepo.GetDoctorById(id);
            if (deletedoctorFromRepo == null)
            {
                return NotFound();
            }

            _doctorsRepo.DeleteDoctor(deletedoctorFromRepo);
            _doctorsRepo.SaveChanges();
            return NoContent();
        }

        [HttpGet("search={Specialization}")]
        public async Task<ActionResult<IEnumerable<DoctorReadDto>>> Search(string Specialization)
        {
            try
            {
                var result = await _doctorsRepo.SearchSpec(Specialization);

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
