using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TIMP_Lab2
{
    public partial class Menu1 : Form
    {
        private MenuStrip TopMenu;
        Form1 form1 = new Form1();
        Dispatcher dispatcher = new Dispatcher();
        // Переменные для хранения информации о вкладках для каждого уровня иерархии.
        ToolStripMenuItem menu = new ToolStripMenuItem();
        ToolStripMenuItem soMenu = new ToolStripMenuItem();
        private ContextMenuStrip contextMenuStrip1;
        private IContainer components;
        private ToolStripComboBox toolStripComboBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripComboBox toolStripComboBox8;
        private ToolStripComboBox toolStripComboBox9;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripComboBox toolStripComboBox2;
        private ToolStripComboBox toolStripComboBox3;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripComboBox toolStripComboBox4;
        private ToolStripComboBox toolStripComboBox5;
        private ToolStripComboBox toolStripComboBox6;
        private ToolStripComboBox toolStripComboBox7;
        ToolStripMenuItem sosoMenu = new ToolStripMenuItem();
        public Menu1(Form1 form, string fileName)
        {
            InitializeComponent();
            TopMenu = new MenuStrip();
            form1 = form;
            // Количество строк в файле.
            int count = File.ReadAllLines(fileName).Length;
            // Количество вкладок на панели.
            int countMenus;
            // Количество подвкладок на панели.
            int countSoMenu;
            // Считывание строки файла меню и добавление вкладки.
            for (int i = 0; i < count; i++)
            {
                // Статус пункта.
                int status;
                int j = 2;
                // Имя метода для вкладки.
                string methodName = "";
                // Чтение строки из файла.
                string currentString = File.ReadLines(fileName).Skip(i).First();
                // Проверка положения вкладки в иерархии.
                if (currentString[0] == '0')
                {

                    menu = new ToolStripMenuItem();
                    // Записываем имя вкладки.
                    while (currentString[j] != ' ')
                    {
                        menu.Text += currentString[j];
                        j++;
                    }
                    // Записываем статус.
                    status = int.Parse(currentString[j + 1].ToString());
                    // Добавление вкладки в панель.
                    TopMenu.Items.Add(menu);
                    if (status == 2)
                    {
                        menu.Visible = false;
                        menu.Enabled = false;
                    }
                    if (status == 1)
                    {
                        menu.Enabled = false;
                    }
                    if (j + 2 < currentString.Length)
                        for (j += 3; j < currentString.Length; j++)
                        {
                            // Записываем имя метода.
                            methodName += currentString[j];
                        }
                    try
                    {
                        countMenus = TopMenu.Items.Count - 1;
                        // Добавляем обработчки клика мышью по вкладке.
                        TopMenu.Items[countMenus].Click += new System.EventHandler(dispatcher.GetMethod(methodName));
                    }
                    catch (Exception)
                    {

                    }
                }
                if (int.Parse(currentString[0].ToString()) > 0)
                {
                    soMenu = new ToolStripMenuItem();
                    // Записываем имя вкладки.
                    while (currentString[j] != ' ')
                    {
                        soMenu.Text += currentString[j];
                        j++;
                    }


                    status = int.Parse(currentString[j + 1].ToString());
                    if (status == 2)
                    {
                        soMenu.Visible = false;
                        soMenu.Enabled = false;
                    }
                    if (status == 1)
                    {
                        soMenu.Enabled = false;
                    }
                    if (j + 2 < currentString.Length)
                        for (j += 3; j < currentString.Length; j++)
                        {
                            // Записываем имя метода.
                            methodName += currentString[j];
                        }
                    if (currentString[0] == '1')
                    {
                        // Добавление подвкладки в панель.
                        menu.DropDownItems.Add(soMenu);
                        countSoMenu = menu.DropDownItems.Count - 1;
                        sosoMenu = soMenu;
                        try
                        {
                            // Добавляем обработчки клика мышью по вкладке.
                            menu.DropDownItems[countSoMenu].Click += new System.EventHandler(dispatcher.GetMethod(methodName));
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else
                    {
                        // Добавление подвкладки в панель.
                        sosoMenu.DropDownItems.Add(soMenu);
                        countSoMenu = sosoMenu.DropDownItems.Count - 1;
                        try
                        {
                            // Добавляем обработчки клика мышью по вкладке.
                            sosoMenu.DropDownItems[countSoMenu].Click += new System.EventHandler(dispatcher.GetMethod(methodName));
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }

        }
        private void Menu1_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox8 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox9 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox3 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox4 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox5 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox6 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox7 = new System.Windows.Forms.ToolStripComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 52);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 40);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem8});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1668, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "Справка";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 38);
            this.toolStripMenuItem1.Text = "Разное";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.Others_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(166, 38);
            this.toolStripMenuItem2.Text = "Сотрудники";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.Stuff_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(131, 38);
            this.toolStripMenuItem3.Text = "Приказы";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.Orders_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(160, 38);
            this.toolStripMenuItem4.Text = "Документы";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.Docs_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox8,
            this.toolStripComboBox9});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(92, 38);
            this.toolStripMenuItem6.Text = "Окно";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.Window_Click);
            // 
            // toolStripComboBox8
            // 
            this.toolStripComboBox8.Name = "toolStripComboBox8";
            this.toolStripComboBox8.Size = new System.Drawing.Size(200, 40);
            this.toolStripComboBox8.Text = "Оглавление";
            this.toolStripComboBox8.Click += new System.EventHandler(this.Content_Click);
            // 
            // toolStripComboBox9
            // 
            this.toolStripComboBox9.Name = "toolStripComboBox9";
            this.toolStripComboBox9.Size = new System.Drawing.Size(200, 40);
            this.toolStripComboBox9.Text = "О_программе";
            this.toolStripComboBox9.Click += new System.EventHandler(this.About_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(126, 38);
            this.toolStripMenuItem8.Text = "Справка";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.Helper_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox2,
            this.toolStripComboBox3,
            this.toolStripMenuItem7});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(170, 38);
            this.toolStripMenuItem5.Text = "Справочник";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.Certificates_Click);
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(175, 40);
            this.toolStripComboBox2.Text = "Отделы";
            this.toolStripComboBox2.Click += new System.EventHandler(this.Departs_Click);
            // 
            // toolStripComboBox3
            // 
            this.toolStripComboBox3.Name = "toolStripComboBox3";
            this.toolStripComboBox3.Size = new System.Drawing.Size(175, 40);
            this.toolStripComboBox3.Text = "Города";
            this.toolStripComboBox3.Click += new System.EventHandler(this.Towns_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox4,
            this.toolStripComboBox5,
            this.toolStripComboBox6,
            this.toolStripComboBox7});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(359, 44);
            this.toolStripMenuItem7.Text = "Должности";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.Contracts_Click);
            // 
            // toolStripComboBox4
            // 
            this.toolStripComboBox4.Name = "toolStripComboBox4";
            this.toolStripComboBox4.Size = new System.Drawing.Size(180, 40);
            this.toolStripComboBox4.Text = "Основатели";
            this.toolStripComboBox4.Click += new System.EventHandler(this.Founders_Click);
            // 
            // toolStripComboBox5
            // 
            this.toolStripComboBox5.Name = "toolStripComboBox5";
            this.toolStripComboBox5.Size = new System.Drawing.Size(180, 40);
            this.toolStripComboBox5.Text = "Строители";
            this.toolStripComboBox5.Click += new System.EventHandler(this.Builders_Click);
            // 
            // toolStripComboBox6
            // 
            this.toolStripComboBox6.Name = "toolStripComboBox6";
            this.toolStripComboBox6.Size = new System.Drawing.Size(180, 40);
            this.toolStripComboBox6.Text = "Инженеры";
            this.toolStripComboBox6.Click += new System.EventHandler(this.Engineers_Click);
            // 
            // toolStripComboBox7
            // 
            this.toolStripComboBox7.Name = "toolStripComboBox7";
            this.toolStripComboBox7.Size = new System.Drawing.Size(180, 40);
            this.toolStripComboBox7.Text = "Другие";
            this.toolStripComboBox7.Click += new System.EventHandler(this.Other_Click);
            // 
            // Menu1
            // 
            this.ClientSize = new System.Drawing.Size(1668, 790);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu1";
            this.Text = "АИС Отдел Кадров";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Others_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Others", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void Stuff_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Stuff", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        private void Orders_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Orders", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void Docs_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Docs", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void Licenses_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Licenses", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Question);
        private void Certificates_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Certificates", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void Contracts_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Contracts", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void Departs_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Departs", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Question);
        private void Towns_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Towns", "Вызов", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void Founders_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Founders", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Question);
        private void Engineers_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Engineers", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void Builders_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Builders", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Question);
        private void Other_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Other", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void Window_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Window", "Вызов", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void Helper_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Help", "Вызов", MessageBoxButtons.OK, MessageBoxIcon.Question);
        private void Content_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Content", "Вызов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        private void About_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод About", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Information);

    }
    //
    // Класс, возврающий обработчик событий по имени функции.
    //
    public class Dispatcher
    {
        public EventHandler GetMethod(string name)
        {
            // Возвращение запрашиваемого обработчика событий.
            switch (name)
            {
                case "Others": return Others_Click; break;
                case "Stuff": return Stuff_Click; break;
                case "Orders": return Orders_Click; break;
                case "Docs": return Docs_Click; break;
                case "Licenses": return Licenses_Click; break;
                case "Certificates": return Certificates_Click; break;
                case "Contracts": return Contracts_Click; break;
                case "Departs": return Departs_Click; break;
                case "Towns": return Towns_Click; break;
                case "Founders": return Founders_Click; break;
                case "Engineers": return Engineers_Click; break;
                case "Builders": return Builders_Click; break;
                case "Other": return Other_Click; break;
                case "Window": return Window_Click; break;
                case "Help": return Helper_Click; break;
                case "Content": return Content_Click; break;
                case "About": return About_Click; break;
                default: return null;
            }

        }
        //
        // Обработчики событий. 
        //
        private void Others_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Others", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void Stuff_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Stuff", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        private void Orders_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Orders", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void Docs_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Docs", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void Licenses_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Licenses", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Question);
        private void Certificates_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Certificates", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void Contracts_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Contracts", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void Departs_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Departs", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Question);
        private void Towns_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Towns", "Вызов", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void Founders_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Founders", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Question);
        private void Engineers_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Engineers", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void Builders_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Builders", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Question);
        private void Other_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Other", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void Window_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Window", "Вызов", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void Helper_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Help", "Вызов", MessageBoxButtons.OK, MessageBoxIcon.Question);
        private void Content_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод Content", "Вызов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        private void About_Click(object sender, EventArgs e) => MessageBox.Show("Вызвался метод About", "Вызов функции", MessageBoxButtons.OK, MessageBoxIcon.Information);


    }
}


