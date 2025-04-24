namespace MAUIApp;

internal partial class Composition
{
    [Conditional("DI")]
    private void Setup() => DI.Setup()
        .Bind().As(Singleton).To<Ticks>();
}