using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicCatalog.Data;
using MusicCatalog.Dtos.Community;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Communities;

public class CommunityService : ICommunityService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CommunityService(ApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    private string GetUserId() => _httpContextAccessor.HttpContext!.User
        .FindFirstValue(ClaimTypes.NameIdentifier)!;

    public async Task<CreateCommunityDto> CreateCommunity(CreateCommunityDto newCommunity)
    {
        var community = _mapper.Map<Community>(newCommunity);
        community.UserId = GetUserId();

        _dbContext.Communities.Add(community);
        await _dbContext.SaveChangesAsync();

        return newCommunity;
    }

    public async Task<IEnumerable<GetCommunityDto>> GetCommunities()
    {
        var dbCommunities = await _dbContext.Communities.ToListAsync();

        var communities = dbCommunities.Select(c => _mapper.Map<GetCommunityDto>(c)).ToList();

        return communities;
    }

    public async Task<List<GetCommunityDto>> DeleteCommunity(int communityId)
    {
        var dbCommunity =
            await _dbContext.Communities.FirstOrDefaultAsync(c => c.Id == communityId && c.User.Id == GetUserId()) ??
            throw new Exception($"Community with Id '{communityId}' not found.");

        _dbContext.Communities.Remove(dbCommunity);
        await _dbContext.SaveChangesAsync();

        var communities = await _dbContext.Communities.Where(c => c.User.Id == GetUserId())
            .Select(c => _mapper.Map<GetCommunityDto>(c)).ToListAsync();

        return communities;
    }
    
    public async Task<GetCommunityDto> GetCommunity(int communityId)
    {
        var dbCommunity = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == communityId);

        if (dbCommunity is null) return new GetCommunityDto();
        var communityDto = _mapper.Map<GetCommunityDto>(dbCommunity);
        return communityDto;
    }
    public async Task UpdateCommunity(UpdateCommunityDto updatedCommunity)
    {
        var community =
            await _dbContext.Communities
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == updatedCommunity.Id && c.User.Id == GetUserId()) ??
            throw new Exception($"Community with Id '{updatedCommunity.Id}' not found.");

        _mapper.Map(updatedCommunity, community);

        community.UpdatedAt = DateTime.Now;

        _dbContext.Update(community);
        await _dbContext.SaveChangesAsync();
    }

}