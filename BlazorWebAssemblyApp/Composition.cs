namespace BlazorWebAssemblyApp;

partial class Composition: ServiceProviderFactory<Composition>
{
    [Conditional("DI")]
    private void Setup() => DI.Setup()
        .DependsOn(Base)

        .Root<IAppViewModel>()
        .Root<IClockViewModel>()

        .Bind().As(Singleton).To<ClockViewModel>()
        .Bind().To<ClockModel>()
        .Bind().As(Singleton).To<Ticks>()

        // Infrastructure
        .Bind().To<MicrosoftLoggerAdapter<TT>>()
        .Bind().To<CurrentThreadDispatcher>();
}