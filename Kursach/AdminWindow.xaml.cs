using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace Kursach
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            //Получаем список книг
            GetGoodList();
        }

        //Строка подключения
        public static string conString { get; set; }
        public static int current_id { get; set; }

        //Книга
        public class Good
        {
            public int id { get; set; }
            public string category { get; set; }
            public string subcategory { get; set; }
            public string name { get; set; }
            public string author { get; set; }
            public string language { get; set; }
            public string age_rating { get; set; }
            public string sh_desc { get; set; }
            public int count { get; set; }
            public int price { get; set; }
            public string cover_path { get; set; }
        }

        //Список товаров
        List<Good> goods = new List<Good>();

        //Метод выполнения хранимой процедуры получения списка всех книг
        public void GetGoodList()
        {
            string cmdString = "GetGoodList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Good st = new Good();
                    st.id = (int)reader[0];
                    st.category = reader[1].ToString();
                    st.subcategory = reader[2].ToString();
                    st.name = reader[3].ToString();
                    st.author = reader[4].ToString();
                    st.language = reader[5].ToString();
                    st.age_rating = reader[6].ToString();
                    st.sh_desc = reader[7].ToString();
                    st.count = (int)reader[8];
                    st.price = Convert.ToInt32(reader[9]);
                    st.cover_path = reader[10].ToString();
                    //Добавляем в список
                    goods.Add(st);
                }
                reader.Close();
                //Задаём источник данных
                GoodGrid.ItemsSource = goods;
            }
        }

        //Метод выполнения хранимой процедуры изменения количества товаров
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

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Метод выполнения хранимой процедуры изменения имени товара
        public void UpdateGoodName(int id, string name)
        {
            string cmdString = "UpdateGoodName";

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

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                cmd.Parameters.Add(nameParam);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Метод выполнения хранимой процедуры изменения цены товара
        public void UpdatePrice(int id, int price)
        {
            string cmdString = "UpdatePrice";

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

                SqlParameter priceParam = new SqlParameter
                {
                    ParameterName = "@price",
                    Value = price
                };
                cmd.Parameters.Add(priceParam);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Метод выполнения хранимой процедуры удаления книги
        public void DeleteBook()
        {
            string cmdString = "DeleteBook";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = current_id
                };
                cmd.Parameters.Add(IDParam);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Нажатие кнопки выходы
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //Открываем окно входа в аккаунт
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }

        //Выбранная книга поменялась
        private void GoodGrid_SelectedCellsChanged(object sender, System.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            //Получаем её номер
            Good item = new Good();
                foreach (var obj in GoodGrid.SelectedItems)
                {
                    item = obj as Good;
                    current_id = item.id;
                }
        }

        //Выбранный элемент выпадающего списка изменился
        private void ChangeSelectBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //Выбран пункт изменения количества
            if (ChangeSelectBox.SelectedItem == c1)
            {
                ChangeTextLabel.Content = "Введите размер партии:";
            }
            //Выбран пункт изменения названия
            if (ChangeSelectBox.SelectedItem == c2)
            {
                ChangeTextLabel.Content = "Введите новое название:";
            }
            //Выбран пункт изменения цены
            if (ChangeSelectBox.SelectedItem == c3)
            {
                ChangeTextLabel.Content = "Введите цену:";
            }
            //Выбрано добавление новой книги
            if (ChangeSelectBox.SelectedItem == c4)
            {
                //Открываем окно добавления новой книги
                AddBookWindow addbookwindow = new AddBookWindow();
                addbookwindow.Show();
                Close();
            }
            //Выбрано удаление книги
            if (ChangeSelectBox.SelectedItem == c5)
            {
                //Удаляем книгу
                DeleteBook();
                //Выводим обновлённый список книг
                GoodGrid.ItemsSource = null;
                goods.Clear();
                GetGoodList();
                GoodGrid.ItemsSource = goods;
            }
            //Выбрано добавление новой категории
            if (ChangeSelectBox.SelectedItem == c6)
            {
                //Открываем окно добавления категории
                AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
                addCategoryWindow.Show();
                Close();
            }
            //Выбрано добавление новой подкатегории
            if (ChangeSelectBox.SelectedItem == c7)
            {
                //Открываем окно добавления подкатегории
                AddSubcategoryWindow addSubcategoryWindow = new AddSubcategoryWindow();
                addSubcategoryWindow.Show();
                Close();
            }
        }

        //Нажатие кнопки ввода
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            //Если поле ввода изменений не пустое и выбрано изменение из выпадающего списка
            if (ChangeBox.Text != null && GoodGrid.SelectedItem != null)
            {
                //Если выбрано изменение количества книги
                if (ChangeSelectBox.SelectedItem == c1)
                {
                    //Если введено число больше нуля
                    if (int.TryParse(ChangeBox.Text.ToString(), out int result) == true && Convert.ToInt32(ChangeBox.Text) > 0)
                    {
                        //Обновляем количество товара
                        UpdateQuantity(current_id, Convert.ToInt32(ChangeBox.Text) * -1);
                        ChangeBox.Text = null;
                        MessageBox.Show("Успешно");
                    }
                }
                //Если выбрано изменение названия
                if (ChangeSelectBox.SelectedItem == c2)
                {
                    //Изменяем название книги на введённое
                    UpdateGoodName(current_id, ChangeBox.Text);
                    ChangeBox.Text = null;
                    MessageBox.Show("Успешно");
                }
                //Если выбрано изменение цены
                if (ChangeSelectBox.SelectedItem == c3)
                {
                    //Если введено число больше нуля
                    if (int.TryParse(ChangeBox.Text.ToString(), out int result) == true && Convert.ToInt32(ChangeBox.Text) > 0)
                    {
                        //Изменяем цену на введённую
                        UpdatePrice(current_id, Convert.ToInt32(ChangeBox.Text));
                        ChangeBox.Text = null;
                        MessageBox.Show("Успешно");
                    }
                }
            }
            //Обновляем список книг и выводим
            GoodGrid.ItemsSource = null;
            goods.Clear();
            GetGoodList();
            GoodGrid.ItemsSource = goods;
        }
    }
}
