using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Page2Window : Window
    {
        public Page2Window()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //check input
            if (acno.Text == null || acno.Text == "")
            {
                MessageBox.Show("请输入编号", "警告");
                return;
            }
            int acno_i = 0;
            bool isNumeric = int.TryParse(acno.Text, out acno_i);
            if (!isNumeric)
            {
                MessageBox.Show("请输入正确的编号", "警告");
                return;
            }
            if (acno_i < 0 || acno_i > 100)
            {
                MessageBox.Show("请输入0~100的编号", "警告");
                return;
            }
            

            if (sex.SelectedIndex == -1)
            {
                MessageBox.Show("请输入性别", "警告");
                return;
            }

            if (age.SelectedIndex == -1)
            {
                MessageBox.Show("请输入年龄", "警告");
                return;
            }

            if (education.SelectedIndex == -1)
            {
                MessageBox.Show("请输入学历", "警告");
                return;
            }

            if (during.SelectedIndex == -1)
            {
                MessageBox.Show("请输入开始到现在的玩游戏时间", "警告");
                return;
            }

            if (timeforgame.SelectedIndex == -1)
            {
                MessageBox.Show("请输入每周游戏时间", "警告");
                return;
            }

            //save result
            string info_output = "";
            info_output += acno.Text + "\t";
            ComboBox[] chooses = { sex, age, education, during, timeforgame};
            for (int i = 0; i < chooses.Length; ++i)
            {
                info_output += ((ComboBoxItem)chooses[i].SelectedValue).Content.ToString() + "\t";
            }
            Console.WriteLine(info_output);
            save.save_info(info_output); 


            //everything is input
            string strCmdText;
            strCmdText = "shell:AppsFolder\\GAMELOFTSA.Asphalt8AirBorne_0pp20fcewvvtj!App";
            Process gameProcess = Process.Start("explorer.exe ", strCmdText);
            //System.Threading.Thread.Sleep(5 * 60 * 1000);
            new MainWindow().Show();
            this.Close();
        }
    }
} 