using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace Counter.Models
{
	public class AddCounter
    {
        public ObservableCollection<Counter> Counters { get; set; } = new ObservableCollection<Counter>();
        public int index { get; set; }
        public DataBaseConnection db = new DataBaseConnection();


        public AddCounter() => index = db.getAllDocument(Counters, index);



        public void addCounter(int value, string counterColorString)
        {
            string stringTitle = $"licznik {index++}";
            db.addCounter(value, stringTitle, counterColorString);
            Color counterColor = ColorConverter.convertColor(counterColorString);
            Counters.Add(new Counter { Title = stringTitle, Count = value, CounterColor =  counterColor});
        }

        public void ChangeCount(Button button, string operation)
        {
            if (button.BindingContext is Counter counter)
            {
                if (operation == "+")
                {
                    counter.Count++;

                }
                else
                {
                    if (counter.Count > 0)
                    {
                        counter.Count--;
                    }
                }
                db.saveCount(counter.Title);
            }
        }

        public void deleteCount(Button button)
        {
            if (button.BindingContext is Counter counter)
            {
                db.deleteCounter(counter.Title);
                Counters.Remove(counter);
            }
        }

        public void resetCounter(Button button)
        {
            if (button.BindingContext is Counter counter)
            {
                counter.Count = db.resetCounter(counter.Title);
            }
        }
    }
}

