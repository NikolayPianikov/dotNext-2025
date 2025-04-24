namespace WinFormsAppNetCore;

public class Program(FormMain formMain)
{
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();
    }

    private void Run() => Application.Run(formMain);
}