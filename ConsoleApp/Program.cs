return;

internal partial class Program(
    ITicks ticks,
    IConsole console,
    IClockModel clock)
{
    private void Run()
    {
        ticks.Tick += OnTick;
        while (!console.IsKeyAvailable);
        ticks.Tick -= OnTick;
    }

    private void OnTick()
    {
        var now = clock.Now;
        console.Write($"{now:d} {now:T}");
    }
}