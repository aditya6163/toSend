using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Data.Review;
using VeterinarySystems.Dtos.ReviewsDtos;
using VeterinarySystems.Model;

namespace VeterinarySystems.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsCotroller: ControllerBase
    {
        private readonly IReviewsRepo _reviewsRepo;
        private readonly IMapper _reviewMappper;

        public ReviewsCotroller(IReviewsRepo reviewsRepo,IMapper mapper)
        {
            _reviewsRepo = reviewsRepo;
            _reviewMappper = mapper;

        }

        //GetALL : api/reviews
        [HttpGet]
        public ActionResult<IEnumerable<ReviewReadDto>> GetAllReviews()
        {

            var reviewsList = _reviewsRepo.GetAllReviews();

            return Ok(_reviewMappper.Map<IEnumerable<ReviewReadDto>> (reviewsList));

        }

        // GetByID : api/reviews/{id}
        [HttpGet("{id}",Name = "GetReviewById")]

        public ActionResult<ReviewReadDto> GetById(int id)
        {
           var review = _reviewsRepo.GetReviewById(id);
            if(review != null)
            {
                return Ok(_reviewMappper.Map<ReviewReadDto>(review));
            }

            return NotFound();
        } 

        // Post : api/reviews
        [HttpPost]
        public ActionResult<ReviewCreateDto> CreateReview(ReviewCreateDto reviewCreateDto)
        {
            var ReviewModel = _reviewMappper.Map<Reviews>(reviewCreateDto);
            _reviewsRepo.CreateReview(ReviewModel);
            _reviewsRepo.SaveChanges();

            var reviewRead = _reviewMappper.Map<ReviewReadDto>(ReviewModel);

            return CreatedAtRoute(nameof(GetById), new { Id = reviewRead.ReviewId }, reviewRead);

        } 


        // PUT : api/reviews/{id}
        [HttpPut("{id}")]
        public ActionResult ReviewUpdate(int id, ReviewUpdateDto reviewUpdateDto)
        {
            var reviewUpdateRepo = _reviewsRepo.GetReviewById(id);
            if(reviewUpdateRepo == null)
            {
                return NotFound();
            }
            _reviewMappper.Map(reviewUpdateDto, reviewUpdateRepo);
            _reviewsRepo.UpdateReview(reviewUpdateRepo);
            _reviewsRepo.SaveChanges();

            return NoContent();

        }

        // Patch // api/reviews/{id}
        [HttpPatch("{id}")]
        public ActionResult updatePartial(int id, JsonPatchDocument<ReviewUpdateDto> patchDoc)
        {
            var reviewUpdate = _reviewsRepo.GetReviewById(id);
            if(reviewUpdate == null)
            {
                return NotFound();
            }

            var reviewToPatch = _reviewMappper.Map<ReviewUpdateDto>(reviewUpdate);

            patchDoc.ApplyTo(reviewToPatch, ModelState);
            if (!TryValidateModel(reviewToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _reviewMappper.Map(reviewToPatch, reviewUpdate);
            _reviewsRepo.UpdateReview(reviewUpdate);
            _reviewsRepo.SaveChanges();
            return NoContent();

        }

        // Delete : api/reviews/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletReview(int id)
        {
            var DeleteFromRepo = _reviewsRepo.GetReviewById(id);
            if(DeleteFromRepo == null)
            {
                return NotFound();
            }

            _reviewsRepo.DeleteReview(DeleteFromRepo);
            _reviewsRepo.SaveChanges();
            return NoContent();
        }


    }
}
