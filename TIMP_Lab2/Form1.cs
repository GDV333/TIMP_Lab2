using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace TIMP_Lab2
{
    public partial class Form1 : Form
    {
        // Таймер для постоянной проверки состояния формы.
        System.Windows.Forms.Timer formTimer = new System.Windows.Forms.Timer();
        // Количество строк в файле.
        int count = File.ReadAllLines("Users.txt").Length;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formTimer.Interval = 500;
            formTimer.Start();
            formTimer.Tick += new EventHandler(FormTimer_Tick);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private void CloseButton_MouseEnter(object sender, EventArgs e)
        //{
        //    Window.CloseButton.ForeColor = Color.Blue;
        //}

        //private void CloseButton_MouseLeave(object sender, EventArgs e)
        //{
        //    Window.CloseButton.ForeColor = Color.Black;
        //}

        private void FormTimer_Tick(object sender, EventArgs e)
        {
            CapsLockFlagLabel.Text = (Console.CapsLock ? "Клавиша CapsLock нажата" : "");
            if (InputLanguage.CurrentInputLanguage.LayoutName == "США")
                CurrentLanguageLabel.Text = "Язык ввода Английский";
            else if (InputLanguage.CurrentInputLanguage.LayoutName == "Русская")
                CurrentLanguageLabel.Text = "Язык ввода Русский";
        }
        private void EnterButton_Click(object sender, EventArgs e)
        {
            bool windowIsOpen = true;
            // Считывание введенного логина и пароля .
            string userMenu = UserName.Text + " " + Password.Text;
            // Считывание строки из файла и проверка на соответствие введенным данным.
            for (int i = 0; i < count; i++)
            {
                // Хранение имени файла меню.
                string fileName = "";
                // Считывание строки из файла.
                string fileText = File.ReadLines("Users.txt").Skip(i).First();
                // Хранение логина и пароля в файле.
                string logPass = "";
                // Счетчик пробелов.
                int countSpaces = 2;
                for (int j = 0; j < fileText.Length; j++)
                {

                    if (fileText[j] == ' ')
                    {
                        countSpaces--;
                        if (countSpaces == 0)
                            continue;
                    }
                    if (countSpaces != 0)
                    {
                        // Запись логина и пароля из файла.
                        logPass += fileText[j];
                    }
                    else
                    {
                        // Запись имени файла меню.
                        fileName += fileText[j];
                    }
                }
                if (userMenu == logPass)
                {
                    windowIsOpen = false;
                    fileName += ".txt";
                    Menu1 menu1 = new Menu1(this, fileName);
                    menu1.Show();
                    Hide();
                    break;
                }
            }
            if (windowIsOpen == true)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Password.Text = "";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            CapsLockFlagLabel.Text = (Console.CapsLock ? "Клавиша CapsLock нажата" : "");
            if (InputLanguage.CurrentInputLanguage.LayoutName == "США")
                CurrentLanguageLabel.Text = "Язык ввода Английский";
            else if (InputLanguage.CurrentInputLanguage.LayoutName == "Русская")
                CurrentLanguageLabel.Text = "Язык ввода Русский";
        }
    }
}
