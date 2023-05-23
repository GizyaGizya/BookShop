using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Kursach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Передаём строку подключения во все нужные окна
            Books.conString = conString;
            BookPage.conString = conString;
            Basket.conString = conString;
            AdminWindow.conString = conString;
            AddBookWindow.conString = conString;
            Registration.conString = conString;
            Catalog.conString = conString;
            AddCategoryWindow.conString = conString;
            AddSubcategoryWindow.conString = conString;
        }

        //Строка подключения
        static string conString = @"Data Source=.\SQLEXPRESS; Initial Catalog=BookShop; Integrated Security=true;";

        public static int user_id { get; set; }

        //Метод выполнения хранимой процедуры проверки существования логина и пароля
        public int CheckLoginExists()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string cmdString = "CheckLoginExists";
                con.Open();

                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = TB_login.Text
                };
                cmd.Parameters.Add(loginParam);

                SqlParameter passwordParam = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = TB_passw.Password
                };
                cmd.Parameters.Add(passwordParam);

                int result = (int)cmd.ExecuteScalar();

                con.Close();
                return result;
            }
        }

        //Метод выполнения хранимой процедуры получения номера пользователя
        public void GetUserID()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string cmdString = "GetUserID";
                con.Open();

                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = TB_login.Text
                };
                cmd.Parameters.Add(loginParam);

                SqlParameter passwordParam = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = TB_passw.Password
                };
                cmd.Parameters.Add(passwordParam);

                user_id = (int)cmd.ExecuteScalar();

                con.Close();
            }
        }

        //Метод выполнения хранимой процедуры проверки роли пользователя
        public int CheckIfAdmin()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string cmdString = "CheckIfAdmin";
                con.Open();

                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = user_id
                };
                cmd.Parameters.Add(idParam);

                int result = (int)cmd.ExecuteScalar();

                con.Close();

                return result;
            }
        }

        //Нажатие кнопки ввода
        private void B_entr_Click(object sender, RoutedEventArgs e)
        {
            //Если все поля заполнены
            if ((TB_login.Text != "") && (TB_passw.Password != ""))
            {
                try
                {
                    //Проверяем, существует ли пользователь с таким логином и паролем
                    if (CheckLoginExists() == 1)
                    {
                        //Получаем номер пользователя
                        GetUserID();
                        //Если пользователь не администратор
                        if (CheckIfAdmin() == 0)
                        {
                            //Открываем окно выбора категории
                            Catalog.user_id = user_id;
                            Catalog catalog = new Catalog();
                            catalog.Show();
                            Close();
                        }
                        //Иначе открываем окно администратора
                        else
                        {
                            AdminWindow adminwindow = new AdminWindow();
                            adminwindow.Show();
                            Close();
                        }
                    }
                    else
                    {
                        throw new Exception("Неправильный логин или пароль");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Для продолжения заполните все поля");
        }

        //Нажатие на кнопку регистрации
        private void B_reg_Click(object sender, RoutedEventArgs e)
        {
            //Открываем окно регистрации
            Registration Registration = new Registration();
            Registration.Show();
            Close();
        }
    }
}
