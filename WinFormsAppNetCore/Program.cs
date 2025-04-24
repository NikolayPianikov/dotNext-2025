namespace WinFormsAppNetCore;

class Program(FormMain formMain)
{
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();
        using var composition = new Composition();
        composition.GetRoot(period: TimeSpan.FromSeconds(2)).Run();
    }

    private void Run() => Application.Run(formMain);
}