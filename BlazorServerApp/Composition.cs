namespace BlazorServerApp;

partial class Composition: ServiceProviderFactory<Composition>
{
    [Conditional("DI")]
    private void Setup() => DI.Setup()
        .DependsOn(Base)

        .Arg<TimeSpan>("period")
        .Root<IAppViewModel>()
        .Root<IClockViewModel>()

        .Bind().To<ClockViewModel>()
        .Bind().To<ClockModel>()
        .Bind().As(Singleton).To<Ticks>()

        // Infrastructure
        .Bind().To<MicrosoftLoggerAdapter<TT>>()
        .Bind().To<CurrentThreadDispatcher>();
}