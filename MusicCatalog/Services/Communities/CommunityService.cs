/*using System.Security.Claims;
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

    public async Task<IEnumerable<GetCommunityDto>> GetCommunitiesById()
    {
        var dbCommunities = await _dbContext.Communities
            .Include(c => c.User)    
            .Where(c => )
            .ToListAsync();

        var communities = dbCommunities.Select(c => _mapper.Map<GetCommunityDto>(c)).ToList();

        return communities;
    }

    public async Task<List<GetCommunityDto>> DeleteCommunity(int communityId)
    {
        var communities = new List<GetCommunityDto>();

        try
        {
            var dbCommunity = await _dbContext.Communities.FirstOrDefaultAsync(c => c.Id == communityId && c.User!.Id == GetUserId());
            if (dbCommunity is null)
                throw new Exception($"Community with Id '{communityId}' not found.");

            _dbContext.Communities.Remove(dbCommunity);
            await _dbContext.SaveChangesAsync();

            communities = await _dbContext.Communities.Where(c => c.User!.Id == GetUserId())
                .Select(c => _mapper.Map<GetCommunityDto>(c)).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }

        return communities;
    }


    public Community GetCommunity(int communityId)
    {
        if (_dbContext.Communities.Find(communityId) is Community community)
        {
            return community;
        }

        return null;
    }
}*/
