using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.RegularExpressions;


namespace Prilojenie1
{
    public partial class MainPage : ContentPage
    {
        public bool isBackgroundChanged = false;
        
       
        public interface IExitAppService
        {
            void Exit();
        }
        public MainPage()
        {
            InitializeComponent();
           
        }
        protected override void OnAppearing()
        {
           
        }
        private void ContactInfoEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            string newText = e.NewTextValue;

           
            foreach (char c in newText)
            {
                
                if (!char.IsDigit(c))
                {
                    
                    newText = newText.Remove(newText.IndexOf(c), 1);
                }
            }

           
            ContactInfoEntry.Text = newText;
        }




        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            // Проверка на пустые поля для ввода пароля
            if (string.IsNullOrWhiteSpace(LoginEntry.Text))
            {
                await DisplayAlert("Ошибка", "Поле для ввода логина не может быть пустым", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(ContactInfoEntry.Text))
            {
                await DisplayAlert("Ошибка", "Поле для ввода телефона не может быть пустым", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordEntry.Text) || string.IsNullOrWhiteSpace(ConfirmPasswordEntry.Text))
            {
                await DisplayAlert("Ошибка", "Поля для ввода пароля не могут быть пустыми", "OK");
                return;
            }

            // Проверка на совпадение паролей
            if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            {
                await DisplayAlert("Ошибка", "Пароли не совпадают", "OK");
                return;
            }

            string phoneNumber = ContactInfoEntry.Text;
            if (!ValidatePhoneNumber(phoneNumber))
            {
                await DisplayAlert("Ошибка", "Номер телефона должен состоять из 11 цифр", "OK");
                return;
            }

          

            await DisplayAlert("Успех", "Регистрация успешна", "OK");
            int a = RolePicker.SelectedIndex;
            User user = new User(LoginEntry.Text,PasswordEntry.Text,phoneNumber,RolePicker.SelectedItem.ToString(),BirthDatePicker.Date);
            switch (a)
            {
                case 0:
                    await Navigation.PushAsync(new Page1(user));
                    break;
                case 1:
                    await Navigation.PushAsync(new Librarian());
                    break;
                case 2:
                    await Navigation.PushAsync(new Admin());
                    break;
                default:
                    await DisplayAlert("Ошибка", "Неизвестная ошибка", "OK");
                    break;
            }
             
        }
        private bool ValidatePhoneNumber(string phoneNumber)
        {
            // Проверяем, состоит ли номер телефона из 11 цифр
            return Regex.IsMatch(phoneNumber, @"^\d{11}$");
        }


        private async void ExitButton_Clicked(object sender, EventArgs e)
        {
            bool exit = await DisplayAlert("Выход", "Вы уверены, что хотите выйти?", "Да", "Нет");
            if (exit)
            {
                // Закрыть приложение
                DependencyService.Get<IExitAppService>().Exit();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        { 
            
            if (!isBackgroundChanged)
            {
                // Создаем кисть для задания нового цвета фона StackLayout
                SolidColorBrush brush = new SolidColorBrush(Color.DarkGray); // Новый цвет
                SolidColorBrush brush3 = new SolidColorBrush(Color.Black); // Новый цвет


                // Устанавливаем цвет фона StackLayout при нажатии на кнопку
                StackLayout.Background = brush;
                PasswordEntry.Background = brush;
                ConfirmPasswordEntry.Background = brush;
                BirthDatePicker.Background = brush;
                ContactInfoEntry.Background = brush;
                LoginEntry.Background = brush;

                // Устанавливаем флаг в true, чтобы указать, что цвет был изменен
                isBackgroundChanged = true;
            }
            else
            {
                SolidColorBrush brush2 = new SolidColorBrush(Color.LightGray); // Новый цвет
                                                                           // Возвращаем оригинальный цвет фона StackLayout
                StackLayout.Background = brush2;
                PasswordEntry.Background = brush2;
                ConfirmPasswordEntry.Background = brush2;
                BirthDatePicker.Background = brush2;
                ContactInfoEntry.Background = brush2;
                LoginEntry.Background = brush2;
                // Устанавливаем флаг в false, чтобы указать, что цвет был возвращен
                isBackgroundChanged = false;
            }


        }
    }
}

