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

    public void CreateReview(Review review)
    {

        _dbContext.Add(review);
        _dbContext.SaveChanges();

    }

    public void DeleteReview(int reviewId)
    {
        var review = _dbContext.Reviews.Find(reviewId);

        _dbContext.Remove(review);
        _dbContext.SaveChanges();
    }

    public Review GetReview(int reviewId)
    {
        if (_dbContext.Reviews.Find(reviewId) is Review review)
        {
            return review;
        }

        return null;
    }

    public void UpsertReview(Review review)
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
    }




}