namespace NvsFood.Domain.Interfaces;

public interface IUnitOfWork
{
    Task Commit();
}