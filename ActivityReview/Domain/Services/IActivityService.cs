using ActivityReview.ActivityReview.Domain.Models;
using ActivityReview.ActivityReview.Domain.Services.Communication;

namespace ActivityReview.ActivityReview.Domain.Services;

public interface IActivityService
{
    Task<IEnumerable<Activity>> ListAsync();
    Task<ActivityResponse> SaveAsync(Activity activity);
    Task<ActivityResponse> UpdateAsync(int idActivity, Activity activity);
    Task<ActivityResponse> DeleteAsync(int idActivity);
    
    Task<Activity> GetByIdAsync(int id);
    Task<IEnumerable<Activity>> GetByCustomerIdAsync(int customerId);
    Task<IEnumerable<Activity>> GetByActivityIdAsync(int activityId);



}