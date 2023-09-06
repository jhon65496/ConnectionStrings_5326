using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DBManagement
{
    public partial class Form1 : Form
    {

        
        string connectionString;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string pathDB = ""; // <==== Получить данные из настроек приложения
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;"
                                + $"AttachDbFilename = {pathDB};"
                                + "Integrated Security = True; "
                                + "Connect Timeout = 30";

            GetTablesName();
        }       

        public void GetTablesName()
        {
            try
            {
                // Создание подключения            
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Открываем подключение
                    connection.Open();
                    
                    string sqlExpression = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                                        
                    while (reader.Read())
                    {
                        object name = reader.GetValue(2);
                        Debug.WriteLine(name);
                    }

                    Debug.WriteLine("Подключение открыто");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                // throw;
            }

        }

       
    }
}

