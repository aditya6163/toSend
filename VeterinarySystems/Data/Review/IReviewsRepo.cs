using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Model;

namespace VeterinarySystems.Data.Review
{
    public interface IReviewsRepo
    {
        IEnumerable<Reviews> GetAllReviews();
        Reviews GetReviewById(int id);
        void CreateReview(Reviews review);

        void UpdateReview(Reviews review);

        void DeleteReview(Reviews review);

        bool SaveChanges();
    }
}
