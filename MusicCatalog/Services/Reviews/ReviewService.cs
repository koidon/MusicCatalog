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
        review.User = await _dbContext.AppUsers.FirstOrDefaultAsync(u => u.Id == GetUserId()) ??
                      throw new InvalidOperationException($"The user with Id '{review.User.Id}' could not be found");

        _dbContext.Reviews.Add(review);
        await _dbContext.SaveChangesAsync();

        return newReview;
    }

    public async Task<GetReviewDto> GetReviewById(int reviewId)
    {
        var dbReview =
            await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId) ??
            throw new Exception($"Review with Id '{reviewId}' not found.");

        var reviewDto = _mapper.Map<GetReviewDto>(dbReview);

        return reviewDto;
    }

    public async Task<IEnumerable<GetReviewDto>> GetReviewsById(string songId)
    {
        var dbReviews = await _dbContext.Reviews
            .Include(r => r.User)
            .Where(r => songId.Contains(r.SongId))
            .ToListAsync();


        var reviews = dbReviews.Select(r => _mapper.Map<GetReviewDto>(r)).ToList();

        return reviews;
    }

    public async Task DeleteReview(int reviewId)
    {
        var dbReview =
            await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId && r.User.Id == GetUserId()) ??
            throw new Exception($"Review with Id '{reviewId}' not found.");


        _dbContext.Reviews.Remove(dbReview);
        await _dbContext.SaveChangesAsync();
    }



    public async Task UpdateReview(UpdateReviewDto updatedReview)
    {
        var review =
            await _dbContext.Reviews
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == updatedReview.Id && r.User.Id == GetUserId()) ??
            throw new Exception($"Review with Id '{updatedReview.Id}' not found.");

        _mapper.Map(updatedReview, review);

        review.UpdatedAt = DateTime.Now;


        _dbContext.Update(review);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> GetReviewCount(string songId)
    {
        var reviewCount = await _dbContext.Reviews
            .Where(r => r.SongId == songId)
            .CountAsync();

        return reviewCount;
    }
}