namespace ConsoleApp;

internal partial class Composition
{
    [Conditional("DI")]
    private void Setup() => DI.Setup()
        .Hint(Hint.Resolve, "Off")
        .Hint(Hint.ThreadSafe, "Off")

#if DEBUG
        .Hint(Hint.ToString, "On")
        .Hint(Hint.OnNewInstance, "On")
        .Hint(Hint.OnDependencyInjection, "On")
#endif

        // Composition root for the console application
        .Root<Program>(nameof(Root))

        .Bind().To<ClockModel>()
        .Bind().As(Singleton).To<Ticks>()
        .Bind().To<ConsoleAdapter>()

        // Infrastructure
        .Bind().To<DebugLog<TT>>();

#if DEBUG
    partial void OnNewInstance<T>(ref T value, object? tag, Lifetime lifetime)
    {
        Debug.WriteLine($"DI: {lifetime} {value}(#{value?.GetHashCode()}) of type {typeof(T).Name} created.");
    }

    private partial T OnDependencyInjection<T>(in T value, object? tag, Lifetime lifetime)
    {
        Debug.WriteLine($"DI: {value}(#{value?.GetHashCode()}) injected as {typeof(T).Name}.");
        return value;
    }
#endif
}