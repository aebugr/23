 using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGiftsBugrina.Classes
{
    public class OrderContext : Models.OrderInfo, Interfaces.Icontext
    {
        public List<OrderContext> All()
        {
            List<OrderContext> allOrder = new List<OrderContext>();

            OleDbConnection connection = Common.DBConnection.Connection();
            OleDbDataReader dataOrder = Common.DBConnection.Query("SELECT * FROM [OrderingGifts]", connection);
            while (dataOrder.Read())
            {
                OrderContext newOrder = new OrderContext();
                newOrder.Id = dataOrder.GetInt32(0);
                newOrder.FIO = dataOrder.GetString(1);
                newOrder.Message = dataOrder.GetString(2);
                newOrder.Adress = dataOrder.GetString(3);
                newOrder.Date = dataOrder.GetDateTime(4);
                newOrder.Mail = dataOrder.GetString(5);

                allOrder.Add(newOrder);
            }
            Common.DBConnection.CloseConnection(connection);

            return allOrder;
        }

        public void Delete()
        {
            OleDbConnection connection = Common.DBConnection.Connection();
            Common.DBConnection.Query($"DELETE FROM [OrderingGifts] WHERE [Код] = {this.Id}", connection);
            Common.DBConnection.CloseConnection(connection);
        }

        public void Save(bool Update = false)
        {
            if (Update)
            {
                OleDbConnection connection = Common.DBConnection.Connection();
                Common.DBConnection.Query("UPDATE [OrderingGifts] " +
                                          "SET " +
                                              $"[ФИО заказчика] = '{this.FIO}', " +
                                              $"[Текст сообщения] = '{this.Message}', " +
                                              $"[Адрес доставки] = '{this.Adress}', " +
                                              $"[Дата и время отправки] = '{this.Date.ToString("dd.MM.yyyy")}', " +
                                              $"[Почта для связи] = '{this.Mail}' " +
                                              $"WHERE [Код] = {this.Id}", connection);

                Common.DBConnection.CloseConnection(connection);
            }
            else
            {
                OleDbConnection connection = Common.DBConnection.Connection();
                Common.DBConnection.Query("INSERT INTO" +
                                              "[OrderingGifts]" +
                                                    "([ФИО заказчика], " +
                                                    "[Текст сообщения], " +
                                                    "[Адрес доставки], " +
                                                    "[Дата и время отправки], " +
                                                    "[Почта для связи]) " +
                                           "VALUES (" +
                                               $"'{this.FIO}', " +
                                               $"'{this.Message}', " +
                                               $"'{this.Adress}', " +
                                               $"'{this.Date.ToString("dd.MM.yyyy")}', " +
                                               $"'{this.Mail}')", connection);

                Common.DBConnection.CloseConnection(connection);
            }
        }
    }
}
