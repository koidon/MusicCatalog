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
        review.User = await _dbContext.AppUsers.FirstOrDefaultAsync(u => u.Id == GetUserId());
        //Fixa isak!

        _dbContext.Reviews.Add(review);
        await _dbContext.SaveChangesAsync();

        return newReview;
    }

    public async Task<IEnumerable<GetReviewDto>> GetReviewsById(string songId)
    {

        var dbReviews = await _dbContext.Reviews
            .Include(r => r.User)
            .Where(r => songId.Contains(r.SongId))
            .ToListAsync();
        //AppUser eller User?



        var reviews = dbReviews.Select(r => _mapper.Map<GetReviewDto>(r)).ToList();

        return reviews;
    }

    public async Task<List<GetReviewDto>> DeleteReview(int reviewId)
    {

        var reviews = new List<GetReviewDto>();

        try
        {
            var dbReview = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId && r.User!.Id == GetUserId());
            if (dbReview is null)
                throw new Exception($"Character with Id '{reviewId}' not found.");

            _dbContext.Reviews.Remove(dbReview);
            await _dbContext.SaveChangesAsync();


            reviews = await _dbContext.Reviews.Where(r => r.User!.Id == GetUserId())
                .Select(r => _mapper.Map<GetReviewDto>(r)).ToListAsync();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }

        return reviews;
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