using AutoMapper;
using MusicCatalog.Dtos.Community;
using MusicCatalog.Dtos.Post;
using MusicCatalog.Dtos.Review;
using MusicCatalog.Models;

namespace MusicCatalog;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateReviewDto,Review>();
        CreateMap<Review, GetReviewDto>();
        CreateMap<UpdateReviewDto, Review>();
        CreateMap<CreatePostDto,Post>();
        CreateMap<Post, GetPostDto>();
        CreateMap<CreateCommunityDto, Community>();
        CreateMap<Community, CreateCommunityDto>();
    }
}