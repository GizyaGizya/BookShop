using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Kursach
{
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
            //Получаем список категорий
            GetCatList();
            //Получаем список подкатегорий
            GetSubcatList();
        }

        //Строка подключения
        public static string conString { get; set; }

        //Нажатие кнопки назад
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //Открываем окно администратора
            AdminWindow adminwindow = new AdminWindow();
            adminwindow.Show();
            Close();
        }

        //Категория
        public partial class Category
        {
            public int Id { get; set; }
            public string category { get; set; }
        }

        //Список категорий с номерами
        List<Category> catlist = new List<Category>();
        //Список названий категорий
        List<string> catnameslist = new List<string>();

        //Подкатегория
        public partial class Subcategory
        {
            public int Id { get; set; }
            public string subcategory { get; set; }
        }

        //Список подкатегорий с номерами
        List<Subcategory> subcatlist = new List<Subcategory>();
        //Список названий подкатегорий
        List<string> subcatnameslist = new List<string>();

        //Метод выполнения хранимой процедуры получения списка категорий
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

                foreach (var item in catlist)
                {
                    //Добавляем названия в список
                    catnameslist.Add(item.category);
                }
                //Делаем список названий категорий источником данных
                CategorySelectBox.ItemsSource = catnameslist;
            }
        }

        //Метод выполнения хранимой процедуры получения списка подкатегорий
        public void GetSubcatList()
        {
            string cmdString = "GetSubcatList";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Subcategory st = new Subcategory();
                    st.Id = (int)reader[0];
                    st.subcategory = reader[1].ToString();
                    //Добавляем в список
                    subcatlist.Add(st);
                }
                reader.Close();

                foreach (var item in subcatlist)
                {
                    //Добавляем названия в список
                    subcatnameslist.Add(item.subcategory);
                }
                //Делаем список названий подкатегорий источником данных
                SubcategorySelectBox.ItemsSource = subcatnameslist;
            }
        }

        //Метод выполнения хранимой процедуры добавления новой книги
        public void AddGood()
        {
            string cmdString = "AddGood";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter categoryParam = new SqlParameter
                {
                    ParameterName = "@category_id",
                    Value = CategorySelectBox.SelectedIndex + 1
                };
                cmd.Parameters.Add(categoryParam);

                SqlParameter subcategoryParam = new SqlParameter
                {
                    ParameterName = "@subcategory_id",
                    Value = SubcategorySelectBox.SelectedIndex + 1
                };
                cmd.Parameters.Add(subcategoryParam);

                SqlParameter languageParam = new SqlParameter
                {
                    ParameterName = "@language",
                    Value = LanguageSelectBox.Text
                };
                cmd.Parameters.Add(languageParam);

                SqlParameter ageratingParam = new SqlParameter
                {
                    ParameterName = "@age_rating",
                    Value = AgeRatingSelectBox.Text
                };
                cmd.Parameters.Add(ageratingParam);

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = NameBox.Text
                };
                cmd.Parameters.Add(nameParam);

                SqlParameter authorParam = new SqlParameter
                {
                    ParameterName = "@author",
                    Value = AuthorBox.Text
                };
                cmd.Parameters.Add(authorParam);

                SqlParameter descParam = new SqlParameter
                {
                    ParameterName = "@desc",
                    Value = DescBox.Text
                };
                cmd.Parameters.Add(descParam);

                SqlParameter coverParam = new SqlParameter
                {
                    ParameterName = "@cover",
                    Value = CoverBox.Text
                };
                cmd.Parameters.Add(coverParam);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Метод проверки заполнения полей
        public bool CheckBoxesFilled()
        {
            if (CategorySelectBox.SelectedItem != null
                && SubcategorySelectBox.SelectedItem != null
                && LanguageSelectBox.SelectedItem != null
                && AgeRatingSelectBox.SelectedItem != null
                && NameBox.Text != null
                && AuthorBox.Text != null
                && DescBox.Text != null
                && CoverBox.Text != null
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Нажатие кнопки добавить
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //Если все поля заполнены
            if (CheckBoxesFilled())
            {
                //Добавляем новую книгу
                AddGood();
                MessageBox.Show("Успешно");
            }
        }
    }
}
