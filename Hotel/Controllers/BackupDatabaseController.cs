using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ConfigurationManager = System.Configuration.ConfigurationManager;


[ApiController]
[Route("[controller]")]
public class BackupDatabaseController: ControllerBase
{
    [HttpPost("Copy")] 
    public void BackupDatabase()
    {
        try
        {           
            // Получение строки подключения к базе данных из файла конфигурации
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connectionString);
            // Создание пути для файла резервной копии
            string folderPath = Path.Combine("D:", "Диплом");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string backupFilePath = Path.Combine(folderPath, "DatabaseBackup.bak"); Console.WriteLine(backupFilePath);
            // Выполнение резервного копирования базы данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string backupQuery = $"BACKUP DATABASE [Hotel] TO DISK = '{backupFilePath}'";
                SqlCommand command = new SqlCommand(backupQuery, connection);
                command.ExecuteNonQuery();
            }

            // Возвращение результата действия
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            // Обработка ошибок
        }
    }
}