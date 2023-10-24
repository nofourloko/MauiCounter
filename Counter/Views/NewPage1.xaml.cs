namespace Counter.Views;
using Models;

public partial class NewPage1 : ContentPage
{
    public Counter SelectedCounter { get; set; }
    public CounterMananger CounterManager { get; set; } = new CounterMananger();
    public string CounterColorString { get; set; } = "Black";

    public NewPage1(Models.Counter selectedCounter)
	{
		InitializeComponent();
        SelectedCounter = selectedCounter;
        BindingContext = this;
    }
    void Button_ChangeCount(System.Object sender, System.EventArgs e)
    {
        Button button = (Button)sender;
        string operation = button.Text;
        CounterManager.ChangeCount(SelectedCounter, operation);
    }

    void ButtonReset_Clicked(System.Object sender, System.EventArgs e)
    {
        CounterManager.resetCounter(SelectedCounter);
    }

}
