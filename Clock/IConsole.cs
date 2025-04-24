namespace Clock;

public interface IConsole
{
    void WaitForKey();

    void Write(object? value);
}