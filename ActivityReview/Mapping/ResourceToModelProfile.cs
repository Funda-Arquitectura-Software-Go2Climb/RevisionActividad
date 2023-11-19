using ActivityReview.ActivityReview.Resources;
using ActivityReview.ActivityReview.Domain.Models;
using AutoMapper;

namespace ActivityReview.ActivityReview.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveActivityResource, Activity>()
            .ForMember(dest => dest.ActivityId, opt => opt.MapFrom(src => src.ActivityId))
            .ForMember(dest => dest.CustomersId, opt => opt.MapFrom(src => src.CustomersId)); 
    }
}