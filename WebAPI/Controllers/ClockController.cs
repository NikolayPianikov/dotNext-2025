namespace WebAPI.Controllers;

[Route("[controller]")]
public class ClockController(
    ILogger<ClockController> logger) : ControllerBase
{
    [HttpGet]
    public Task<ClockResult> GetDateTime()
    {
        logger.LogInformation(nameof(GetDateTime));
        return Task.FromResult(new ClockResult("Title", "Date", "Time"));
    }
}