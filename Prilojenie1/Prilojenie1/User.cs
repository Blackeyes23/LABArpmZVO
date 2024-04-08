using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Prilojenie1
{
    public class User : INotifyPropertyChanged
    {
        private string login;
        private string phoneNumber;
        private DateTime dateTime;
        private string role;

        public string Login
        {
            get { return login; }
            set
            {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        public string Role
        {
            get { return role; }
            set
            {
                if (Role != value)
                {
                    role = value;
                    OnPropertyChanged("Role");
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
