using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prilojenie1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Librarian : ContentPage
    {
        protected internal ObservableCollection<book> Books { get; set; }

        public Librarian()
        {
            InitializeComponent();
            Books = new ObservableCollection<book> 
            {
                 new book {Name="Финансист", Author="Теодор Драйзер", Genre="Роман"},
                 new book {Name="1984", Author="Джордж Оруэлл", Genre="Роман"}
            };
            booklist.BindingContext = Books;
        }
    }
}