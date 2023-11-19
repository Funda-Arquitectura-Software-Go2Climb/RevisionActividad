namespace ActivityReview.ActivityReview.Domain.Models;

public class Activity
{
    public int Id { get; set; }
    
    public string ActivityCode { get; set; }
    public DateTime Date { get; set; }
    public string Comment { get; set; }
    public float Score { get; set; }
    public int ActivityId { get; set; }
    public int CustomersId { get; set; }
}