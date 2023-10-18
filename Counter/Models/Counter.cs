using System;
using System.ComponentModel;
namespace Counter.Models
{

    public class Counter : INotifyPropertyChanged
    {
        public string Title { set; get; }
        public Color CounterColor {set;get;}
        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                if (count != value)
                {
                    count = value;
                    NotifyPropertyChanged("Count");
                }
            }
        }

        // Other properties and methods in Counter class

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
    }
}
