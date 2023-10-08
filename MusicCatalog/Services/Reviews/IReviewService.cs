using MusicCatalog.Dtos.Review;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Reviews;

public interface IReviewService
{
    Task<CreateReviewDto> CreateReview(CreateReviewDto review);
    Review GetReview(int id);

    Task<List<Review>> GetReviewsById(string playlistId);

    void UpsertReview(Review review);
    void DeleteReview(int id);
}