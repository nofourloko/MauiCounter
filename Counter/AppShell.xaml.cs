namespace Counter;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("test", typeof(Views.NewPage1));
    }
}

