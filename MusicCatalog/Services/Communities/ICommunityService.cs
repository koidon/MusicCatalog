using MusicCatalog.Dtos.Community;

namespace MusicCatalog.Services.Communities;

public interface ICommunityService
{
    Task<CreateCommunityDto> CreateCommunity(CreateCommunityDto community);
    Task<GetCommunityDto> GetCommunity(int id);

    Task<IEnumerable<GetCommunityDto>> GetCommunities();

    Task<List<GetCommunityDto>> DeleteCommunity(int communityId);
}