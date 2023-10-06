using ErrorOr;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Reviews;

public interface IReviewService
{
    ErrorOr<Created> CreateReview(Review review);
    ErrorOr<Review> GetReview(int id);
    ErrorOr<UpsertedReview> UpsertReview(Review review);
    ErrorOr<Deleted> DeleteReview(int id);
}