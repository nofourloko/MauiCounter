namespace Counter.Views;
using System.Collections.ObjectModel;
using Counter.Models;

public partial class MainCounterPage : ContentPage
{
    public AddCounter CounterManager { get; set; } = new AddCounter();
    public string CounterColorString { get; set; } = "Black";

    public MainCounterPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        bool err = false;

        if(Editor_entryValue.Text == "")
        {
            CounterManager.addCounter(0, CounterColorString);
        }
        else
        {
            if (int.TryParse(Editor_entryValue.Text, out int value))
            {
                CounterManager.addCounter(value, CounterColorString);
            }
            else
                err = true;
        }
        Models.FormCheck.checkForm(err, Editor_entryValue);
       
    }

    void Button_ChangeCount(System.Object sender, System.EventArgs e)
    {


        if (sender is Button button )
        {
            string operation = button.Text;
            CounterManager.ChangeCount(button, operation);
        }
    }

    void ColorPicker_HandlerChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            string selectedValue = picker.Items[selectedIndex];
            CounterColorString = selectedValue;

        }
    }

    void DeleteButtonClicked(System.Object sender, System.EventArgs e)
    {
        if(sender is Button button)
        {
            CounterManager.deleteCount(button);
        }
    }

    void ButtonResetClicked(System.Object sender, System.EventArgs e)
    {
        if (sender is Button button)
        {
            CounterManager.resetCounter(button);
        }
    }
}


