using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace Kursach
{
    public partial class AddSubcategoryWindow : Window
    {
        public AddSubcategoryWindow()
        {
            InitializeComponent();
        }

        //Строка подключения
        public static string conString { get; set; }

        //Нажатие кнопки назад
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //Открываем окно администратора
            AdminWindow admin = new AdminWindow();
            admin.Show();
            Close();
        }

        //Метод выполнения хранимой процедуры добавления подкатегории
        public void AddSubcategory()
        {
            string cmdString = "AddSubcategory";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = ChangeBox.Text
                };
                cmd.Parameters.Add(nameParam);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Нажатие кнопки добавить
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            //Если поле заполнено
            if (ChangeBox.Text != "")
            {
                //Добавляем подкатегорию
                AddSubcategory();
                ChangeBox.Text = null;
                MessageBox.Show("Успешно");
            }
        }
    }
}
