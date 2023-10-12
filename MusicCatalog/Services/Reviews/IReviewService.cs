using MusicCatalog.Dtos.Review;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Reviews;

public interface IReviewService
{
    Task<CreateReviewDto> CreateReview(CreateReviewDto review);


    Task<GetReviewDto> GetReviewById(int id);

    Task<IEnumerable<GetReviewDto>> GetReviewsById(string songId);

    Task UpdateReview(UpdateReviewDto review);
    Task DeleteReview(int reviewId);
}