using System;
namespace Counter.Models
{
	public class ColorConverter
	{

		public static Color convertColor(string stringColor)
		{
            Color CounterColor;

            switch (stringColor)
            {
                case "Blue":
                    CounterColor = Colors.Blue;
                    break;
                case "Red":
                    CounterColor = Colors.Red;
                    break;
                case "White":
                    CounterColor = Colors.White;
                    break;
                case "Orange":
                    CounterColor = Colors.Orange;
                    break;
                default:
                    CounterColor = Colors.Black;
                    break;
            }

            return CounterColor;
        }
	}
}

