namespace Counter.Views;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using Counter.Models;

public partial class MainCounterPage : ContentPage
{
    public CounterMananger CounterManager { get; set; } = new CounterMananger();
    public string CounterColorString { get; set; } = "";

    public MainCounterPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        bool formValidation = FormCheck.checkForm(Editor_entryValue, Editor_counterTitle, CounterColorString, ColorPicker);

        if (formValidation == true)
        {
            if (int.TryParse(Editor_entryValue.Text, out int countValue))
                CounterManager.addCounter(countValue, CounterColorString, Editor_counterTitle.Text);
            else
                CounterManager.addCounter(0, CounterColorString, Editor_counterTitle.Text);

            FormCheck.clearForm(Editor_entryValue, Editor_counterTitle, addCounterForm, ColorPicker);
            CounterColorString = "";
        }
    }

    void ColorPicker_HandlerChanged(object sender, EventArgs e)
    {
        string selectedValue = (string)ColorPicker.SelectedItem;

        if (selectedValue != null)
        {
            CounterColorString = selectedValue;
        }
    }

    void DeleteButtonClicked(System.Object sender, System.EventArgs e)
    {
        Button button = (Button)sender;
        CounterManager.deleteCount(button);
    }

    void ShowFilters_Clicked(System.Object sender, System.EventArgs e)
    {
        addCounterForm.IsVisible = !addCounterForm.IsVisible;
    }

    async void ListView_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var selectedCounter = (Counter)e.SelectedItem; 
            await Navigation.PushAsync(new NewPage1(selectedCounter));                                                                                     
        }
        CountersListView.SelectedItem = null;

    }
}


