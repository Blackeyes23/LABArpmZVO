using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Prilojenie1
{
    public class book : INotifyPropertyChanged
    {

        private string name;
        private string author;
        private string genre;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                if (author != value)
                {
                    author = value;
                    OnPropertyChanged("Author");
                }
            }
        }
        public string Genre
        {
            get { return genre; }
            set
            {
                if (genre != value)
                {
                    genre = value;
                    OnPropertyChanged("Genre");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}