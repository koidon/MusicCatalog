using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicCatalog.Data;
using MusicCatalog.Dtos.Review;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Reviews;

public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ReviewService(ApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    private string GetUserId() => _httpContextAccessor.HttpContext!.User
        .FindFirstValue(ClaimTypes.NameIdentifier)!;

    public async Task<CreateReviewDto> CreateReview(CreateReviewDto newReview)
    {
        var review = _mapper.Map<Review>(newReview);
        review.User = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

        _dbContext.Reviews.Add(review);
        await _dbContext.SaveChangesAsync();

        return newReview;
    }

    public async Task<List<Review>> GetReviewsById(string playlistId)
    {
        var reviews = await _dbContext.Reviews
            .Where(r => playlistId.Contains(r.UserId))
            .ToListAsync();

        return reviews;
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