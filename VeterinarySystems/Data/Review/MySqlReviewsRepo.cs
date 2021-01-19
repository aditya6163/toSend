using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data.Review
{
    public class MySqlReviewsRepo : IReviewsRepo
    {
        private readonly ReviewsContext _reviewsContext;

        public MySqlReviewsRepo(ReviewsContext ReviewsContext)
        {
            _reviewsContext = ReviewsContext;
        }
        public void CreateReview(Reviews review)
        {
            if(review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            _reviewsContext.CustomerReviews.Add(review);

            //throw new NotImplementedException();
        }

        public void DeleteReview(Reviews review)
        {
            if(review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            _reviewsContext.CustomerReviews.Remove(review);
            //throw new NotImplementedException();
        }

        public IEnumerable<Reviews> GetAllReviews()
        {
            return _reviewsContext.CustomerReviews.ToList();
            //throw new NotImplementedException();
        }

        public Reviews GetReviewById(int id)
        {
            return _reviewsContext.CustomerReviews.FirstOrDefault(p => p.ReviewId == id);
            //throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_reviewsContext.SaveChanges() >= 0);
           // throw new NotImplementedException();
        }

        public void UpdateReview(Reviews review)
        {
           // throw new NotImplementedException();
        }
    }
}
