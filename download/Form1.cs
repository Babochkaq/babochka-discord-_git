using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.IO.Compression;
using TheArtOfDevHtmlRenderer.Core.Handlers;
using System.Net;
using Ionic.Zip;
using SharpCompress.Archives;
using SharpCompress.Readers;
using Telegram.Bot;
using SharpCompress.Common;
using ICSharpCode.SharpZipLib.Zip;
using Guna.UI2.WinForms;
using System.Security.AccessControl;
using FileSystem = System.IO.File;
using TelegramFile = Telegram.Bot.Types.File;
using System.Threading;

namespace download
{
    public partial class Form1 : Form
    {
 
        private Button myButton; // Объявление myButton как поля класса


        public Form1()
        {
            InitializeComponent();
            OpenTelegram();
            this.MaximizeBox = false;
            this.MinimizeBox = false; //Также можно запретить минимизацию
            this.AutoScaleMode = AutoScaleMode.Dpi;



        }

            private void Form1_Resize(object sender, EventArgs e)
        {
            // Рассчитываем масштабный коэффициент
            float scaleFactor = (float)this.Width / this.MinimumSize.Width; // Используйте MinimumSize как базовое значение

            // Изменяем размер шрифта
            float newFontSize = myButton.Font.Size * scaleFactor;
            myButton.Font = new Font(myButton.Font.FontFamily, newFontSize, myButton.Font.Style);
        }

        private void OpenTelegram() // Убедитесь, что метод объявлен правильно
        {
            string telegramLink = "https://t.me/babochkaoff"; // Замените на вашу ссылку

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = telegramLink,
                    UseShellExecute = true // Обязательно, чтобы открыть URL
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии Telegram: {ex.Message}");
            }
        }



        private bool form2IsOpen = false;
        private Form2 form2Instance; // Хранение экземпляра Form2
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void guna2Button2_Click(object sender, EventArgs e)
        {
            {

                try
                {
                    string folder = @"C:\RKNPIDORASB"; // Папка для сохранения
                    string zipFile = @"C:\RKNPIDORASB\zapret-discord-youtube-1.6.1.zip"; // Путь к zip файлу


                    // Проверяем и удаляем папку если она существует
                    if (Directory.Exists(folder))
                    {
                        Directory.Delete(folder, true); // true означает удалить всё содержимое
                    }

                    // Создаём папку
                    Directory.CreateDirectory(folder);

                    // Скачиваем файл
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile("https://github.com/Flowseal/zapret-discord-youtube/archive/refs/tags/1.6.1.zip", zipFile);
                    }

                    // Распаковываем архив
                    FastZip fastZip = new FastZip();
                    fastZip.ExtractZip(zipFile, folder, null);

                    // Удаляем zip файл
                    File.Delete(zipFile);

                    // Запускаем bat файл
                    Process.Start(@"C:\RKNPIDORASB\zapret-discord-youtube-1.6.1\discord.bat");
                    Process.Start(@"C:\RKNPIDORASB\zapret-discord-youtube-1.6.1\general.bat");

                    MessageBox.Show("Готово!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("winws"))
            {
                process.Kill();
            }
            MessageBox.Show("Сделано!");
            foreach (var process in Process.GetProcessesByName("WinDivert64"))
            {
                process.Kill();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\RKNPIDORASB\zapret-discord-youtube-1.6.1\service_remove.bat");
            MessageBox.Show("Сервисы были удалены!");
            string directoryPath = @"C:\RKNPIDORASB"; // Укажите путь к папке

            try
            {
                DeleteDirectory(directoryPath);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Ошибка: Сервисы уже удалены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }




        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
        Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string directoryPath = @"C:\RKNPIDORASB"; // Укажите путь к папке

            try
            {
                DeleteDirectory(directoryPath);
                MessageBox.Show("Папка удалена успешно.");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Ошибка: доступ запрещен. Убедитесь, что папка не используется другими программами (советуется перезапустить ПК). Или запустите программу от имени администратора");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void DeleteDirectory(string path)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                // Убираем атрибуты, если они установлены
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
            foreach (var dir in Directory.GetDirectories(path))
            {
                DeleteDirectory(dir);
            }
            Directory.Delete(path);
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (!form2IsOpen)
            {
                form2Instance = new Form2();
                form2Instance.Show();
                form2IsOpen = true;
                guna2Button5.Text = "Закрыть";
            }
            else
            {
                form2Instance.Close();
                form2IsOpen = false;
                guna2Button5.Text = "Плюшки";
            }
        }



        private void guna2Button6_Click(object sender, EventArgs e)
        {
                try
                {
                    // Запуск команды shutdown.exe для перезагрузки
                    Process process = new Process();
                    process.StartInfo.FileName = "shutdown.exe";
                    process.StartInfo.Arguments = "/r /t 0"; // /r - перезагрузка, /t 0 - без отсчета времени
                    process.StartInfo.UseShellExecute = true; // Важно для запуска внешней команды
                    process.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при перезагрузке компьютера: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}




