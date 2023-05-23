using System.Windows;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Media.Imaging;

namespace Kursach
{
    public partial class Books : Window
    {
        public Books()
        {
            InitializeComponent();
            //Получаем список книг в выбранной категории
            GetBooksFromCatID();
        }

        //Строка подключения
        public static string conString { get; set; }
        public static int CategoryID { get; set; }
        public static int user_id { get; set; }
        public static int order_id { get; set; }

        //Товар
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

        //Список книг
        List<NewGood> booklist = new List<NewGood>();
        //Список найденных книг, меняется при поиске
        List<NewGood> searchlist = new List<NewGood>();

        //Метод выполнения хранимой процедуры получения списка книг в выбранной категории
        public void GetBooksFromCatID()
        {
            string cmdString = "GetBooksFromCatID";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = CategoryID
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
                    //Добавляем в список
                    booklist.Add(st);
                }
                reader.Close();
                //Задаём как источник данных
                CatalogItems.ItemsSource = booklist;
            }
        }

        //Нажатие кнопки назад
        private void B_cat_Click(object sender, RoutedEventArgs e)
        {
            //Открываем список категорий книг
            Catalog Catalog = new Catalog();
            Catalog.Show();
            Close();
        }

        //Изменился элемент в выпадающем списке вариантов сортировки
        private void SortingBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //Если список поиска пустой
            if (searchlist.Count == 0)
            {
                //Если выбрана сортировка по цене (по убыванию)
                if (SortingBox.SelectedItem == c1)
                {
                    //Убираем источник данных
                    CatalogItems.ItemsSource = null;
                    //Сортируем список книг по цене (по убыванию)
                    booklist.Sort(delegate (NewGood inf1, NewGood inf2)
                    {
                        return inf2.Price.CompareTo(inf1.Price);
                    });
                    //Задаём источник данных
                    CatalogItems.ItemsSource = booklist;
                }

                //Если выбрана сортировка по цене (по возрастанию)
                if (SortingBox.SelectedItem == c2)
                {
                    //Убираем источник данных
                    CatalogItems.ItemsSource = null;
                    //Сортируем список книг по цене (по возрастанию)
                    booklist.Sort(delegate (NewGood inf1, NewGood inf2)
                    {
                        return inf1.Price.CompareTo(inf2.Price);
                    });
                    //Задаём источник данных
                    CatalogItems.ItemsSource = booklist;
                }
                //Если выбрана сортировка по автору
                if (SortingBox.SelectedItem == c3)
                {
                    //Убираем источник данных
                    CatalogItems.ItemsSource = null;
                    //Сортируем список книг по автору
                    booklist.Sort(delegate (NewGood inf1, NewGood inf2)
                    {
                        return inf1.Author.CompareTo(inf2.Author);
                    });
                    //Задаём источник данных
                    CatalogItems.ItemsSource = booklist;
                }
                //Если выбрана сортировка по названию
                if (SortingBox.SelectedItem == c4)
                {
                    //Убираем источник данных
                    CatalogItems.ItemsSource = null;
                    //Сортируем список книг по названию
                    booklist.Sort(delegate (NewGood inf1, NewGood inf2)
                    {
                        return inf1.Name.CompareTo(inf2.Name);
                    });
                    //Задаём источник данных
                    CatalogItems.ItemsSource = booklist;
                }
            }
            else //Если список поиска не пустой, то все те же действия применяем для него, а не для основного списка книг
            {
                if (SortingBox.SelectedItem == c1)
                {
                    CatalogItems.ItemsSource = null;
                    searchlist.Sort(delegate (NewGood inf1, NewGood inf2)
                    {
                        return inf2.Price.CompareTo(inf1.Price);
                    });
                    CatalogItems.ItemsSource = searchlist;
                }

                if (SortingBox.SelectedItem == c2)
                {
                    CatalogItems.ItemsSource = null;
                    searchlist.Sort(delegate (NewGood inf1, NewGood inf2)
                    {
                        return inf1.Price.CompareTo(inf2.Price);
                    });
                    CatalogItems.ItemsSource = searchlist;
                }
                if (SortingBox.SelectedItem == c3)
                {
                    CatalogItems.ItemsSource = null;
                    searchlist.Sort(delegate (NewGood inf1, NewGood inf2)
                    {
                        return inf1.Author.CompareTo(inf2.Author);
                    });
                    CatalogItems.ItemsSource = searchlist;
                }
                if (SortingBox.SelectedItem == c4)
                {
                    CatalogItems.ItemsSource = null;
                    searchlist.Sort(delegate (NewGood inf1, NewGood inf2)
                    {
                        return inf1.Name.CompareTo(inf2.Name);
                    });
                    CatalogItems.ItemsSource = searchlist;
                }
            }
        }

        //Если текст в строке поиска изменился
        private void SearchBar_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //Если поле поиска не пустое
            if (SearchBar.Text != null)
            {
                //Очищаем список поиска
                searchlist.Clear();
                //Для каждой книге в общеем списке книг
                foreach (var item in booklist)
                {
                    //Если название содержит то, что написано в поле поиска
                    if (item.Name.ToLower().Contains(SearchBar.Text.ToLower()))
                    {
                        //Добавляем книгу в список найденных книг
                        searchlist.Add(item);
                    }
                    //Удаляем источник данных
                    CatalogItems.ItemsSource = null;
                    //Задаём источником данных список поиска
                    CatalogItems.ItemsSource = searchlist;
                }
            }
            //Если поле поиска пустое
            else
            {
                //Очищаем список найденных книг
                searchlist.Clear();
                //Удаляем источник данных
                CatalogItems.ItemsSource = null;
                //Задаём источником данных общий список книг
                CatalogItems.ItemsSource = booklist;
            }
        }

        //Выбрана книга из списка
        private void CatalogItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //Получаем её номер
            foreach (var item in CatalogItems.SelectedItems)
            {
                var obj = item as NewGood;
                //Передаём в окно книги
                BookPage.id = obj.Id;
            }
            BookPage.user_id = user_id;
            //Открываем окно с информацией о книге
            BookPage bookpage = new BookPage();
            bookpage.Show();
            Close();
        }

        //Нажатие на кнопку корзины
        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            Basket.order_id = order_id;
            //Открываем окно корзины
            Basket basket = new Basket();
            basket.Show();
            Close();
        }
    }
}
