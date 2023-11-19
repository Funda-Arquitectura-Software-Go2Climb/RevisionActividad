using ActivityReview.ActivityReview.Domain.Models;
using ActivityReview.Shared.Domain.Services.Communication;

namespace ActivityReview.ActivityReview.Domain.Services.Communication;

public class ActivityResponse: BaseResponse<Activity>
{
    public ActivityResponse(string message) : base(message)
    {
    }
    public ActivityResponse(Activity resource) : base(resource)
    {
    }
}