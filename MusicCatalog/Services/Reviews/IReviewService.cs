using ErrorOr;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Reviews;

public interface IReviewService
{
    void CreateReview(Review review);
    Review GetReview(int id);

    void UpsertReview(Review review);
    void DeleteReview(int id);
}