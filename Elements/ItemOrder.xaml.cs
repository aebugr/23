using OrderingGiftsBugrina.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
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

namespace OrderingGiftsBugrina.Elements
{
    /// <summary>
    /// Логика взаимодействия для ItemOrder.xaml
    /// </summary>
    public partial class ItemOrder : UserControl
    {

        OrderContext NewOrder;
        public ItemOrder(OrderContext Order)
        {
            InitializeComponent();
            fioTB.Content = $"ФИО: {Order.FIO}";
            messageTB.Content = $"Сообщение: {Order.Message}";
            adressTB.Content = $"Адрес доставки: {Order.Adress}";
            dateTB.Content = $"Дата и время: {Order.Date.ToString("dd.MM.yyyy")}";
            mailTB.Content = $"Почта для связи:   {Order.Mail}";
            this.NewOrder = Order;
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.AddOrder(NewOrder));
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            NewOrder.Delete();
            MainWindow.init.allOrd = new OrderContext().All();
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}
