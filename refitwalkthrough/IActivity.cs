using Refit;

namespace refitwalkthrough;

public interface IActivity
{
    [Get("/activity")]
    Task<ActivityDTO> GetUser();
    
}