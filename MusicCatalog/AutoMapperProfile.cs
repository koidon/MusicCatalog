using AutoMapper;
using MusicCatalog.Dtos.Review;
using MusicCatalog.Models;

namespace MusicCatalog;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateReviewDto,Review>();
    }
}