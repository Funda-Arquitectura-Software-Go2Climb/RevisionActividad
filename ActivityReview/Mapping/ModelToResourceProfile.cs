
using ActivityReview.ActivityReview.Domain.Models;
using ActivityReview.ActivityReview.Resources;
using AutoMapper;

namespace ActivityReview.ActivityReview.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Activity, ActivityResource>()
            .ForMember(dest => dest.ActivityId, opt => opt.MapFrom(src => src.ActivityId))
            .ForMember(des => des.CustomersId, opt => opt.MapFrom(src => src.CustomersId));

    }
}