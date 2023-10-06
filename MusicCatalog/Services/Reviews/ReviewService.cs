using ErrorOr;
using MusicCatalog.Data;
using MusicCatalog.Models;
using MusicCatalog.ServiceErrors;

namespace MusicCatalog.Services.Reviews;

public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _dbContext;

    public ReviewService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ErrorOr<Created> CreateReview(Review review)
    {

        _dbContext.Add(review);
        _dbContext.SaveChanges();

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteReview(int reviewId)
    {
        var review = _dbContext.Reviews.Find(reviewId);

        if (review is null)
        {
            return Errors.Review.NotFound;
        }

        _dbContext.Remove(review);
        _dbContext.SaveChanges();

        return Result.Deleted;
    }

    public ErrorOr<Review> GetReview(int reviewId)
    {
        if (_dbContext.Reviews.Find(reviewId) is Review review)
        {
            return review;
        }

        return Errors.Review.NotFound;
    }

    public ErrorOr<UpsertedReview> UpsertReview(Review review)
    {
        var isNewlyCreated = _dbContext.Reviews.Find(review.Id) is not Review;

        if (isNewlyCreated)
        {
            _dbContext.Reviews.Add(review);
        }
        else
        {
            _dbContext.Reviews.Update(review);
        }

        _dbContext.SaveChanges();

        return new UpsertedReview(isNewlyCreated);
    }




}