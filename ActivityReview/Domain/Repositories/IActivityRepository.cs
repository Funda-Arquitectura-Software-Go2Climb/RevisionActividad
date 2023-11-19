using ActivityReview.ActivityReview.Domain.Models;

namespace ActivityReview.ActivityReview.Domain.Repositories;

public interface IActivityRepository
{
    Task<IEnumerable<Activity>> ListAsync();
    
    Task AddAsync(Activity activity);
    Task<Activity> FindByIdAsync(int id);
    Task<IEnumerable<Activity>> FindByCustomerIdAsync(int customerId);
    Task<IEnumerable<Activity>> FindByActivityIdAsync(int activityId);
    
    void Update(Activity activity);
    void Remove(Activity activity);
}