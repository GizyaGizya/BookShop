using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Media.Imaging;

namespace Kursach
{
    public partial class BookPage : Window
    {
        public BookPage()
        {
            InitializeComponent();
            //Получаем книгу по номеру
            GetBookFromID();
            //Заполняем весь текст
            SetText();
            //Если книги нет в наличии
            if (Book.Count == 0)
            {
                AddButton.Content = "НЕТ В НАЛИЧИИ";
                //Отключаем кнопку добавления в корзину
                AddButton.IsEnabled = false;
            }
            //Выводим выбранное количество книги
            CountLabel.Content = count;
        }

        //Строка подключения
        public static string conString { get; set; }

        //Книга
        public partial class NewGood
        {
            public int Id { get; set; }
            public string category { get; set; }
            public string subcategory { get; set; }
            public int Count { get; set; }
            public int Price { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
            public string Language { get; set; }
            public string Age_rating { get; set; }
            public string Sh_desc { get; set; }
            public BitmapImage cover { get; set; }
        }
        
        public static int id { get; set; }
        public static int order_id { get; set; } 
        public static int user_id { get; set; }

        //Выбранное количество
        public int count = 0;

        //Создаём книгу
        NewGood Book = new NewGood();

        //Метод выполнения хранимой процедуры получения книги по её номеру
        public void GetBookFromID()
        {
            string cmdString = "GetBookFromID";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                cmd.Parameters.Add(idParam);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NewGood st = new NewGood();
                    st.Id = (int)reader[0];
                    st.category = reader[1].ToString();
                    st.subcategory = reader[2].ToString();
                    st.Count = (int)reader[3];
                    st.Price = Convert.ToInt32(reader[4]);
                    st.Name = reader[5].ToString();
                    st.Author = reader[6].ToString();
                    st.Language = reader[7].ToString();
                    st.Age_rating = reader[8].ToString();
                    st.Sh_desc = reader[9].ToString();
                    st.cover = new BitmapImage(new Uri(reader[10].ToString(), UriKind.Relative));
                    //Добавляем полученную информацию книге
                    Book = st;
                }
                reader.Close();
            }
        }

        //Метод выполнения хранимой процедуры проверки существования заказа
        public int CheckOrderExists()
        {
            string cmdString = "CheckOrderExists";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = user_id
                };
                cmd.Parameters.Add(idParam);

                con.Open();

                int result = (int)cmd.ExecuteScalar();

                con.Close();

                return result;
            }
        }

        //Метод выполнения хранимой процедуры добавления заказа
        public void AddOrder()
        {
            string cmdString = "AddOrder";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = user_id
                };
                cmd.Parameters.Add(idParam);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Метод выполнения хранимой процедуры получения номера заказа
        public void GetOrder()
        {
            string cmdString = "GetOrder";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                order_id = (int)cmd.ExecuteScalar();

                con.Close();
            }
        }

        //Метод выполнения хранимой процедуры добавления книги в заказ
        public void AddBookToOrder()
        {
            string cmdString = "AddBookToOrder";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter bookIDParam = new SqlParameter
                {
                    ParameterName = "@bookID",
                    Value = Book.Id
                };
                cmd.Parameters.Add(bookIDParam);

                SqlParameter orderIDParam = new SqlParameter
                {
                    ParameterName = "@OrderID",
                    Value = order_id
                };
                cmd.Parameters.Add(orderIDParam);

                SqlParameter countParam = new SqlParameter
                {
                    ParameterName = "@Count",
                    Value = count
                };
                cmd.Parameters.Add(countParam);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Метод заполнения текстовых полей
        public void SetText()
        {
            BookCover.Source = Book.cover;
            NameBlock.Text = "'" + Book.Name + "'";
            AuthorBlock.Text = "Автор: " + Book.Author;
            CategoryBlock.Text = "Категория: " + Book.category;
            SubcategoryBlock.Text = "Подкатегория: " + Book.subcategory;
            LanguageBlock.Text = Book.Language;
            AgeRatingBlock.Text = Book.Age_rating;
            PriceBlock.Text = "Цена: " + Book.Price.ToString() + " руб.";
        }

        //Нажатие кнопки описания
        private void ShowDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Book.Sh_desc);
        }

        //Нажатие кнопки назад
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            //Открываем список книг
            Books books = new Books();
            books.Show();
            Close();
        }

        //Нажатие кнопки добавления в корзину
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //Если выбранное количество не равно нулю
            if (count > 0)
            {
                //Если заказа не существует
                if (CheckOrderExists() == 0)
                {
                    //Добавляем новый заказ
                    AddOrder();
                    //Получаем номер заказа
                    GetOrder();
                }
                //Если заказ существует
                else
                    //Получаем номер заказа
                    GetOrder();
                //Добавляем книгу в заказ
                AddBookToOrder();

                Books.order_id = order_id;

                //Открываем список книг
                Books books = new Books();
                books.Show();
                Close();
            }

        }

        //Нажатие кнопки -
        private void DiscardGoodButton_Click(object sender, RoutedEventArgs e)
        {
            //Если количество больше 1
            if (count > 1)
            {
                //Отнимаем 1
                count--;
            }
            //Выводим
            CountLabel.Content = count;
        }

        //Нажатие кнопки +
        private void AddGoodButton_Click(object sender, RoutedEventArgs e)
        {
            //Если количество меньше количества выбранной книги на складе
            if (count < Book.Count)
            {
                //Прибавляем 1
                count++;
            }
            //Выводим
            CountLabel.Content = count;
        }
    }
}
