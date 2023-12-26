﻿using System;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;


namespace PLC_Reader_Console
{
    /// <summary>
    /// Подключение к базе данных
    /// </summary>
    public class ConnectDB
    {
        /// <summary>
        /// Строка подключения к БД connectionString = $"Server={server};Initial Catalog={databaseName};User ID={login};Password={password}";
        /// </summary>
        public static string connectionString = "";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        /// <summary>
        /// Имя сервера или ip-адрес
        /// </summary>
        public string Server { get;}
        /// <summary>
        /// Имя базы данных
        /// </summary>
        public string DatabaseName {  get;}
        /// <summary>
        /// Логин для авторизации в БД
        /// </summary>
        public string Login { get;}
        /// <summary>
        /// Пароль для авторизации в БД
        /// </summary>
        public string Password { get;}

        /// <summary>
        /// Создать строку подключения к базе данных
        /// </summary>
        /// <param name="server">Имя сервера или ip-адрес</param>
        /// <param name="databaseName">Имя базы данных</param>
        /// <param name="login">Логин для авторизации в БД</param>
        /// <param name="password">Пароль для авторизации в БД</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ConnectDB(string server, string databaseName, string login, string password)
        {
            if (string.IsNullOrWhiteSpace(server))
            {
                throw new ArgumentNullException("Имя сервера не может быть пустым или null.", nameof(server));
            }
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                throw new ArgumentNullException("Имя базы данных не может быть пустым или null.", nameof(databaseName));
            }
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException("Логин не может быть пустым или null.", nameof(login));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Пароль не может быть пустым или null.", nameof(password));
            }

            this.Server = server;
            this.DatabaseName = databaseName;
            this.Login = login;
            this.Password = password;
        }

        /// <summary>
        /// Открыть подключение к БД
        /// </summary>
        public void openConnection()
        {
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Нет подключения к БД!\n\nОшибка: {ex.Message}"); 
            }
        }

        /// <summary>
        /// Закрыть подключение к БД
        /// </summary>
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        /*
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
        */
    }
}
