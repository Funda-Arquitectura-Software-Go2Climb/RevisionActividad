
using ActivityReview.ActivityReview.Domain.Models;
using ActivityReview.ActivityReview.Domain.Repositories;
using ActivityReview.ActivityReview.Domain.Services;
using ActivityReview.ActivityReview.Domain.Services.Communication;
using ActivityReview.Shared.Persistence.Contexts;

namespace ActivityReview.ActivityReview.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppDbContext _context;
    
    public ActivityService(IActivityRepository activityRepository, IUnitOfWork unitOfWork
        ,AppDbContext context)
    {
        _activityRepository = activityRepository;
        _unitOfWork = unitOfWork;
        _context = context; 
    }
    
    public async Task<IEnumerable<Activity>> ListAsync()
    {
        return await _activityRepository.ListAsync();


    }
    
    public async Task<ActivityResponse> SaveAsync(Activity activity)
    {
        try
        {
            await _activityRepository.AddAsync(activity);
            await _unitOfWork.CompleteAsync();
            return new ActivityResponse(activity);
        }
        catch (Exception e)
        {
            return new ActivityResponse($"An error occurred while saving the activity: {e.Message}");
        }
    }

    public async Task<ActivityResponse> UpdateAsync(int activityId, Activity activity)
    {
        var existingActivity = await _activityRepository.FindByIdAsync(activityId);
        if (existingActivity == null)
            return new ActivityResponse("Activity not found");

        existingActivity.Comment = activity.Comment;
        existingActivity.Date = activity.Date;
        existingActivity.Score = activity.Score;
        existingActivity.ActivityId = activity.ActivityId;
        existingActivity.CustomersId = activity.CustomersId;

        try
        {
            _activityRepository.Update(existingActivity);
            await _unitOfWork.CompleteAsync();
            return new ActivityResponse(existingActivity);

        }
        catch (Exception e)
        {
            return new ActivityResponse($"An error occurred while updating the activity: {e.Message}");
        }
    }

  

    public async Task<ActivityResponse> DeleteAsync(int activityId)
        {
            var existingActivity = await _activityRepository.FindByIdAsync(activityId);
            if (existingActivity == null)
                return new ActivityResponse("Activity not found");
            try
            {
                _activityRepository.Remove(existingActivity);
                await _unitOfWork.CompleteAsync();
                return new ActivityResponse(existingActivity);
            }
            catch (Exception e)
            {
                return new ActivityResponse($"An error occurred while deleting the activity: {e.Message}");
            }
        }

    public async Task<Activity> GetByIdAsync(int id)
    {
        var activity = await _activityRepository.FindByIdAsync(id);
        if (activity == null)
        {
            throw new KeyNotFoundException("Activity not found");
        }

        return activity;

    }

    public async Task<IEnumerable<Activity>> GetByCustomerIdAsync(int customerId)
    {
        return await _activityRepository.FindByCustomerIdAsync(customerId);
    }

    public async Task<IEnumerable<Activity>> GetByActivityIdAsync(int activityId)
    {
        return await _activityRepository.FindByActivityIdAsync(activityId);
    }
  
}