using ActivityReview.ActivityReview.Domain.Models;
using ActivityReview.ActivityReview.Domain.Services;
using ActivityReview.ActivityReview.Resources;
using ActivityReview.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ActivityReview.ActivityReview.Controllers;

[ApiController]
[Route("/api/v1/activityreview")]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;
    private readonly IMapper _mapper;
    
    public ActivityController(IActivityService activityService, IMapper mapper)
    {
        _activityService = activityService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ActivityResource>> GetAllAsync()
    {
        var activities = await _activityService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Activity>, IEnumerable<ActivityResource>>(activities);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var activiti = await _activityService.GetByIdAsync(id);
        var resource = _mapper.Map<Activity, ActivityResource>(activiti);
        return Ok(resource);
    }


    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveActivityResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        // Mapea SaveActivityResource a Activity
            var activity = _mapper.Map<SaveActivityResource, Activity>(resource);
            activity.ActivityCode = "AR";
            activity.Date= DateTime.Now;
            
            var result = await _activityService.SaveAsync(activity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Resource);
            return Ok(activityResource);

    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveActivityResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var activity = _mapper.Map<SaveActivityResource, Activity>(resource);

        var result = await _activityService.UpdateAsync(id, activity);

        if (!result.Success)
            return BadRequest(result.Message);

        var activityResource = _mapper.Map<Activity, ActivityResource>(result.Resource);

        return Ok(activityResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _activityService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var activityResource = _mapper.Map<Activity, ActivityResource>(result.Resource);

        return Ok(activityResource);
    }
    
    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetByCustomerId(int customerId)
    {
        var activities = await _activityService.GetByCustomerIdAsync(customerId);
        var resources = _mapper.Map<IEnumerable<Activity>, IEnumerable<ActivityResource>>(activities);
        return Ok(resources);
    }

    [HttpGet("activity/{activityId}")]
    public async Task<IActionResult> GetByActivityId(int activityId)
    {
        var activities = await _activityService.GetByActivityIdAsync(activityId);
        var resources = _mapper.Map<IEnumerable<Activity>, IEnumerable<ActivityResource>>(activities);
        return Ok(resources);
    }
}