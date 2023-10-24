using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Counter.Models
{
	public class CounterMananger
    {
        public ObservableCollection<Counter> Counters { get; set; } = new ObservableCollection<Counter>();
        public DataBaseConnection db = new DataBaseConnection();

        public CounterMananger() => db.getAllDocument(Counters);

        public void addCounter(int value, string counterColorString, string stringTitle)
        {
            db.addCounter(value, stringTitle, counterColorString);
            Color counterColor = ColorConverter.convertColor(counterColorString);
            Counters.Add(new Counter { Title = stringTitle, Count = value, CounterColor =  counterColor});
        }

        public void ChangeCount(Counter SelectedCounter, string operation)
        {
            if (operation == "+")
            {
                SelectedCounter.Count++;
            }
            else if (SelectedCounter.Count > 0)
            {
                SelectedCounter.Count--;
            }

            db.saveCount(SelectedCounter.Title);
        }

        public void deleteCount(Button button)
        {
            if (button.BindingContext is Counter counter)
            {
                db.deleteCounter(counter.Title);
                Counters.Remove(counter);
            }
        }

        public void resetCounter(Counter counter)
        {
            counter.Count = db.resetCounter(counter.Title);
        }
    }
}

