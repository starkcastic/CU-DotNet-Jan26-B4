using Vagabond.MVC.Models;

namespace Vagabond.MVC.Services;

public interface IDestinationService
{
    Task<IEnumerable<DestinationViewModel>> GetAllAsync();
}