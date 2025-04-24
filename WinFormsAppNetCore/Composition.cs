namespace WinFormsAppNetCore;

internal partial class Composition
{
    [Conditional("DI")]
    private void Setup() => DI.Setup()
        .Bind().As(Singleton).To<ClockViewModel>()
        .Bind().To<ClockModel>()
        .Bind().As(Singleton).To<Ticks>()

        // Infrastructure
        .Bind().To<DebugLog<TT>>()
        .Bind().To<WinFormsDispatcher>();
}