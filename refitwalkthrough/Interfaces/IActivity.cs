using Refit;
using refitwalkthrough.DTOs;

namespace refitwalkthrough.Interfaces;

public interface IActivity
{
    [Get("/activity")]
    Task<ActivityDTO> GetUser();
    
}