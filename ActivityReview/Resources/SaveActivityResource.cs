using System.ComponentModel.DataAnnotations;

namespace ActivityReview.ActivityReview.Resources;

public class SaveActivityResource
{
    public string Comment { get; set; }
 
    //tiene que ser como maximo 20 y minimo 0
    [Range(0, 20)]
    public float Score { get; set; }
    public int ActivityId { get; set; }
    public int CustomersId { get; set; }
}