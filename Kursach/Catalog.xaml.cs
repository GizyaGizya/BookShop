using System.Windows;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Kursach
{
    public partial class Catalog : Window
    {
        public Catalog()
        {
            InitializeComponent();
            //Получаем список категорий
            GetCatList();
        }

        //Строка подключения
        public static string conString { get; set; }
        public static int user_id { get; set; }

        //Категория
        public partial class Category
        {
            public int Id { get; set; }
            public string category { get; set; }
        }

        //Список категорий
        List<Category> catlist = new List<Category>();

        //Метод выполнения хранимой процедуры получения списка категорий книг
        public void GetCatList()
        {
            string cmdString = "GetCatList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Category st = new Category();
                    st.Id = (int)reader[0];
                    st.category = reader[1].ToString();
                    //Добавляем в список
                    catlist.Add(st);
                }
                reader.Close();
                //Задаём источник данных, которые выведутся на экран
                CatalogItems.ItemsSource = catlist;
            }
        }

        //Если выбранный элемент в списке поменялся
        private void CatalogItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //Получаем номер выбранной категории
            foreach (var item in CatalogItems.SelectedItems)
            {
                var obj = item as Category;
                //Передаём в следующее окно
                Books.CategoryID = obj.Id;
            }
            //Передаём номер пользователя
            Books.user_id = user_id;
            //Открываем окно каталога с книгами
            Books books = new Books();
            books.Show();
            Close();
        }

        //Нажатие кнопки назад
        private void B_cat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
