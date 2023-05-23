using System;
using System.Windows;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;

namespace Kursach
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        //Строка подключения
        public static string conString { get; set; }

        //Регулярное выражение для проверки формата номера телефона
        Regex validatePhoneNumberRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");

        //Нажатие кнопки назад
        private void B_entr_Click(object sender, RoutedEventArgs e)
        {
            //Открываем окно входа в аккаунт
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }

        //Метод выполнения хранимой процедуры проверки существования пользователя с введённым логином и паролем
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
                    Value = TB_reg_passw.Text
                };
                cmd.Parameters.Add(passwordParam);

                int result = (int)cmd.ExecuteScalar();

                con.Close();
                return result;
            }
        }

        //Метод выполнения хранимой процедуры добавления нового пользователя
        public void AddUser()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string cmdString = "AddUser";
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
                    Value = TB_reg_passw.Text
                };
                cmd.Parameters.Add(passwordParam);

                SqlParameter phoneParam = new SqlParameter
                {
                    ParameterName = "@phone",
                    Value = TB_numb_phon.Text
                };
                cmd.Parameters.Add(phoneParam);

                SqlParameter addressParam = new SqlParameter
                {
                    ParameterName = "@address",
                    Value = TB_address.Text
                };
                cmd.Parameters.Add(addressParam);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Нажатие на кнопку регистрации
        private void B_reg_Click(object sender, RoutedEventArgs e)
        {
            //Если все поля заполнены
            if ((TB_login.Text != "") && (TB_reg_passw.Text != "") && (TB_numb_phon.Text != "") && (TB_address.Text != ""))
            {
                try
                {
                    //Если пользователь уже зарегистрирован
                    if (CheckLoginExists() == 1)
                    {
                        throw new Exception("Логин уже занят");
                    }
                    //Если в каком-то из полей превышено количество символов
                    if ((TB_login.Text.Length > 50) || (TB_reg_passw.Text.Length > 50) || (TB_numb_phon.Text.Length > 12) && (TB_address.Text.Length > 100))
                    {
                        TB_login.Text = "";
                        TB_reg_passw.Text = "";
                        TB_numb_phon.Text = "";
                        TB_address.Text = "";
                        throw new Exception("Превышено разрешённое количество символов в одном или нескольких полях");
                    }
                    //Если номер введён неверно
                    if (!validatePhoneNumberRegex.IsMatch(TB_numb_phon.Text))
                    {
                        throw new Exception("Неверный формат номер телефона");
                    }
                    //Если не возникло исключений, добавляем пользователя
                    AddUser();
                    //Открываем окно входа в аккаунт
                    MainWindow mainwindow = new MainWindow();
                    mainwindow.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Для продолжения заполните все поля");
        }

    }
}
