namespace GrpcService;

public class ClockService()
    : ClockGrpcService.ClockGrpcServiceBase
{
    public override Task<NowReply> GetNow(NowRequest request, ServerCallContext context) =>
        Task.FromResult(new NowReply
        {
            Title = "Title",
            Date = "Date",
            Time = "Time"
        });
}