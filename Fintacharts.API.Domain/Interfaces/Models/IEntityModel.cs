namespace FintachartsAPI.Domain.Interfaces.Models;

public interface IEntityModel<T> : IEntityModel
{
    T Id { get; set; }
}

public interface IEntityModel;