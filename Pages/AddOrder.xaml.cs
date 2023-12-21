using OrderingGiftsBugrina.Classes;
using OrderingGiftsBugrina.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderingGiftsBugrina.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Page
    {
        public OrderInfo OrderInfo;
        public AddOrder(OrderInfo OrderInfo = null)
        {
            InitializeComponent();
            if(OrderInfo!= null)
            {
                this.OrderInfo = OrderInfo;
                fioAdd.Text = this.OrderInfo.FIO;
                messageAdd.Text = this.OrderInfo.Message;
                adressAdd.Text = this.OrderInfo.Adress;
                dateAdd.SelectedDate = this.OrderInfo.Date;
                mailAdd.Text = this.OrderInfo.Mail;
                addBtn.Content = "Изменить";
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.main);
            MainWindow.init.Height = 450;
        }
        private void dateAdd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsLetter(c))
                {
                    e.Handled = true;
                }
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if(fioAdd.Text.Length == 0)
            {
                MessageBox.Show("Проверьте поле с ФИО на корректность");
                return;
            }
            if(adressAdd.Text.Length == 0)
            {
                MessageBox.Show("Проверьте поле с адресом на корректность");
                return;
            }
            if (dateAdd.Text.Length == 0 & !Regex.IsMatch(dateAdd.Text, @"^\d{2}.\d{2}.\d{4}$"))
            {
                MessageBox.Show("Проверьте поле с датой и временем на корректность");
                return;
            }
            if(mailAdd.Text.Length == 0 & !Regex.IsMatch(mailAdd.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Проверьте поле с почтой для связи на корректность");
                return;
            }
            if(OrderInfo == null)
            {
                OrderContext newOrder = new OrderContext();
                newOrder.FIO = fioAdd.Text;
                newOrder.Message = messageAdd.Text;
                newOrder.Adress = adressAdd.Text;

                DateTime newDate = new DateTime();
                DateTime.TryParse(dateAdd.Text, out newDate);
                newOrder.Date = newDate + DateTime.Now.TimeOfDay;
                newOrder.Mail = mailAdd.Text;
                newOrder.Save();
                MessageBox.Show("Заказ оформлен. Ждите обратную связь");
            }
            else
            {
                OrderContext newOrder = new OrderContext();
                newOrder.FIO = fioAdd.Text;
                newOrder.Message = messageAdd.Text;
                newOrder.Adress = adressAdd.Text;

                DateTime newDate = new DateTime();
                DateTime.TryParse(dateAdd.Text, out newDate);
                newOrder.Id = OrderInfo.Id;
                newOrder.Date = newDate + DateTime.Now.TimeOfDay;
                newOrder.Mail = mailAdd.Text;
                newOrder.Save(true);
                MessageBox.Show("Заказ изменён. Ждите обратную связь");
            }
            MainWindow.init.allOrd = new OrderContext().All();
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}
