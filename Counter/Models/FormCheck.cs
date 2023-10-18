using System;
namespace Counter.Models
{
	public class FormCheck
	{
		public static void checkForm(bool err, Editor Editor_entryValue)
		{
			if (err == true)
			{
				Editor_entryValue.Placeholder = "Twoja wartosc jest nieprawidlowa";
			}
			else
				Editor_entryValue.Placeholder = "Proszę podać liczbową wartosc początkową (Bazowo : 0)";

            Editor_entryValue.Text = "";

        }
		
	}
}

