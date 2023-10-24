using System;
namespace Counter.Models
{
	public class FormCheck
	{
        public static bool checkForm(Editor Editor_entryValue, Editor Editor_counterTitle,string CounterColorString, Picker ColorPicker)
        {
            bool result = true;

            if (Editor_counterTitle.Text == "")
            {
                Editor_counterTitle.Placeholder = "Pole nie może być puste proszę podać nazwę countera";
                result = false;
            }

            if (CounterColorString == "")
            {
                ColorPicker.Title = "Pole nie może być puste proszę podać wybrać kolor";
                result = false;
            }

            if (!int.TryParse(Editor_entryValue.Text, out int countValue))
            {
                Editor_entryValue.Placeholder = "Twoja wartosc jest nieprawidlowa";
                Editor_entryValue.Text = "";
                result = false;
            }

            if(countValue < 0)
            {
                Editor_entryValue.Placeholder = "Twoja wartosc nie może być mniejsza od 0";
                Editor_entryValue.Text = "";
                result = false;
            }

            return result;



        }
		public static void clearForm(Editor Editor_entryValue, Editor Editor_counterTitle, Grid addCounterForm, Picker ColorPicker)
        {
            Editor_counterTitle.Text = "";
            Editor_entryValue.Text = "";

            Editor_entryValue.Placeholder = "Proszę podać liczbową wartosc początkową (Bazowo : 0)";
            Editor_counterTitle.Placeholder = "Proszę podać nazwę countera";

            ColorPicker.SelectedItem = null;
            ColorPicker.Title = "Wybierz swój kolor";

            addCounterForm.IsVisible = !addCounterForm.IsVisible;
        }
	}
}

