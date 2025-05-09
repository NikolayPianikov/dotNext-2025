namespace AvaloniaApp;

internal partial class Composition
{
    [Conditional("DI")]
    private void Setup() => DI.Setup()
        .Hint(Hint.Resolve, "Off")

        .Root<IAppViewModel>(nameof(App), kind: Virtual)
        .Root<IClockViewModel>(nameof(Clock), kind: Virtual)

        .OrdinalAttribute<InitializableAttribute>()

        .Bind().As(Singleton).To<ClockViewModel>()
        .Bind().To<ClockModel>()
        .Bind().As(Singleton).To<Ticks>()

        // Infrastructure
        .Bind().To<DebugLog<TT>>()
        .Bind().To<AvaloniaDispatcher>();
}