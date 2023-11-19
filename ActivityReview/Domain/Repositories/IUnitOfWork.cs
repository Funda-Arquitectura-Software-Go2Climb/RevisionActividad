namespace ActivityReview.ActivityReview.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}