using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace Kursach
{
    public partial class Basket : Window
    {
        //Строка подключения
        public static string conString { get; set; }
        public Basket()
        {
            InitializeComponent();
            //Получаем данные заказа
            FormOrder();
        }

        public static int order_id { get; set; }

        //Строка заказа
        public class OrderItem
        {
            public int id { get; set; }
            public string name { get; set; }
            public string author { get; set; }
            public int count { get; set; }
            public int price { get; set; }
        }

        //Список книг в заказе
        List<OrderItem> order = new List<OrderItem>();

        //Метод выполнения хранимой процедуры получения списка книг в заказе
        public void FormOrder()
        {
            string cmdString = "FormOrder";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = order_id
                };
                cmd.Parameters.Add(idParam);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OrderItem st = new OrderItem();
                    st.id = (int)reader[0];
                    st.name = reader[1].ToString();
                    st.author = reader[2].ToString();
                    st.count = (int)reader[3];
                    st.price = Convert.ToInt32(reader[4]);
                    //Добавляем в список
                    order.Add(st);
                }
                reader.Close();
                //Устанавливаем список источником данных
                BasketGrid.ItemsSource = order;
            }
        }

        //Метод выполнения хранимой процедуры отмены заказа
        public void DeleteOrder()
        {
            string cmdString = "DeleteOrder";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = order_id
                };
                cmd.Parameters.Add(IDParam);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Метод выполнения хранимой процедуры завершения заказа
        public void CompleteOrder()
        {
            string cmdString = "CompleteOrder";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = order_id
                };
                cmd.Parameters.Add(IDParam);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Метод выполнения хранимой процедуры изменения количества товара на складе
        public void UpdateQuantity(int id, int quan)
        {
            string cmdString = "UpdateQuantity";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                cmd.Parameters.Add(IDParam);

                SqlParameter quanParam = new SqlParameter
                {
                    ParameterName = "@quan",
                    Value = quan
                };
                cmd.Parameters.Add(quanParam);

                con.Open();

                cmd.ExecuteScalarAsync();

                con.Close();
            }
        }

        //Нажатие кнопки назад
        private void B_cat_Click(object sender, RoutedEventArgs e)
        {
            //Открываем окно выбора категории книг
            Catalog catalog = new Catalog();
            catalog.Show();
            Close();
        }

        //Нажатие кнопки удаления заказа
        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //Если в заказе есть книги т.е., если заказ был создан
            if (order.Count != 0)
            {
                //Удаляем заказ
                DeleteOrder();
                order.Clear();
                BasketGrid.ItemsSource = null;
                BasketGrid.ItemsSource = order;
            }
        }

        //Нажатие кнопки оплаты
        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            var dstEncoding = Encoding.UTF8;
            //Открываем окно выбора пути сохранения чека
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var desktopPath = openFileDialog.FileName;
            int price = 0;
            //Если в заказе есть книги
            if (order.Count != 0)
            {
                foreach (var item in order)
                {
                    //Изменяем количество товаров
                    UpdateQuantity(item.id, item.count);
                }
                try
                {
                    //Формируем чек
                    var sr = new StreamWriter(desktopPath, append: false, encoding: dstEncoding);
                    sr.WriteLine("Товары:");
                    foreach (var item in order)
                    {
                        sr.WriteLine("\nID: " + item.id + "\nНазвание: " + item.name + "\nАвтор: " + item.author + "\nЦена: " + item.price/item.count + "\nКол-во: " + item.count);
                        price += Convert.ToInt32(item.price);
                    }
                    sr.WriteLine("\nИтого: " + price + " руб.");
                    sr.Close();
                    Close();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка");
                }
                //Меняем статус заказа
                CompleteOrder();
                order.Clear();
            }
        }
    }
}
