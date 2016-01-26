using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Question> items;
        int pageNumber;
        int maxPageNumber;
        int stage = -1;
        List<string> titles = new List<string>(){"第一部分","第二部分，您在游戏过程中的体验（请依据游戏中的真实体验作答）","第三部分：您玩电子游戏以后的感受。"};
        List<Question> currentQuestions;
        string totalResult = "";
        public MainWindow()
        {
            InitializeComponent();
            initStage(++stage);
        }

        private void initStage(int stage)
        {

            titleText.Text = titles[stage];
            getQuestion(stage);
            pageNumber = 0;
            switch(stage)
            {
                case 0:
                    maxPageNumber = 1;
                    stage1.Visibility = Visibility.Visible;
                    stage2and3.Visibility = Visibility.Collapsed;
                    stage1.ItemsSource = getNextFive();
                    break;
                case 1:
                    maxPageNumber = 4;
                    stage1.Visibility = Visibility.Collapsed;
                    stage2and3.Visibility = Visibility.Visible;
                    stage2and3.ItemsSource = getNextFive();
                    break;
                case 2:
                    maxPageNumber = 1;
                    stage2and3.ItemsSource = getNextFive();
                    break;
            }
        }

        private IEnumerable getNextFive()
        {
            List<Question> fiveItems = new List<Question>();
            for (int i = pageNumber * 5; i < pageNumber * 5 + 5 && i < items.Count; ++i)
            {
                fiveItems.Add(items[i]);
            }
            this.currentQuestions = fiveItems;
            pageNumber ++;
            return fiveItems;
        }

        private void getQuestion(int stage)
        {
            switch (stage)
            {
                case 0:

            string all_question_in_one_string1 = "请在以下图片中选择最接近您在游戏过程中的心理效价的图片。\n（从极度不开心到极度开心） 请在以下图片中选择最接近您在游戏过程中的唤起水平的图片。\n（从极度平静到极度被唤醒） 请在以下图片中选择最接近您在游戏过程中的掌控感的图片。\n（从完全被游戏掌控到完全掌控游戏）";
            string[] questions1 = all_question_in_one_string1.Split(' ');
            items = new List<Question>();
            int i = 0;
            foreach (string q in questions1)
            {
                Question item = new Question("" + (++i) + "、" + q, "" + stage + "_" + i);
                items.Add(item);
            }
                    items[0].answers = new List<string>() { "/image/11.png", "/image/12.png" , "/image/13.png" , "/image/14.png" , "/image/15.png"};
                    items[1].answers = new List<string>() { "/image/21.png", "/image/22.png" , "/image/23.png" , "/image/24.png" , "/image/25.png"};
                    items[2].answers = new List<string>() { "/image/31.png", "/image/23.png" , "/image/33.png" , "/image/34.png" , "/image/35.png"};
                    break;
                case 1:
            string all_question_in_one_string2 = "在游戏中我忘却了时间 游戏中的事情好像都在自动地发生着 我感到很不同寻常 我感到恐惧 游戏中让我感觉很真实 我玩游戏的时候听不到别人跟我说话 我玩游戏的时候感到紧张、兴奋 我在玩游戏时感到时间仿佛静止了 我在玩游戏时有一种飘飘然、迷幻的感觉 玩游戏的时候如果有人说话我不会回应 玩游戏的时候我感觉不到疲惫 玩起游戏来好像呼吸一样是无意识的 玩游戏的时候我的思维运转很快 玩游戏的时候我会忘记自己在真实世界中身在何方 玩游戏的时候对于应该怎么玩我不需要思考 玩游戏可以让我平静下来 我玩游戏实际所用的时间总会比自己预想的时间要久 玩游戏的时候我沉浸在游戏中 在玩游戏时我感觉到我不能停止";
            string[] questions2 = all_question_in_one_string2.Split(' ');
            items = new List<Question>();
            i = 0;
            foreach (string q in questions2)
            {
                Question item = new Question("" + (++i) + "、" + q, "" + stage + "_" + i);
                items.Add(item);
            }
                    break;

                case 2:
            string all_question_in_one_string3 = "当我想玩电子游戏时，这个游戏会成为我的第一选择 我打算继续玩这款电子游戏 我会告诉其他人这个游戏积极的一面 我会把这款游戏介绍给其他想玩电子游戏的人 我会鼓励亲戚朋友都来玩这款游戏";
            string[] questions3 = all_question_in_one_string3.Split(' ');
            items = new List<Question>();
            i = 0;
            foreach (string q in questions3)
            {
                Question item = new Question("" + (++i) + "、" + q,  "" + stage + "_" + i);
                items.Add(item);
            }
                    break;
            }
        }
public IEnumerable<T> FindVisualChildren<T>( DependencyObject depObj ) where T : DependencyObject
        {
           if( depObj != null )
           {
              for( int i = 0; i < VisualTreeHelper.GetChildrenCount( depObj ); i++ )
              {
                 DependencyObject child = VisualTreeHelper.GetChild( depObj, i );
                 if( child != null && child is T )
                 {
                    yield return (T)child;
                 }

                 foreach( T childOfChild in FindVisualChildren<T>( child ) )
                 {
                    yield return childOfChild;
                 }
              }
           }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            String result = "";
                if (stage == 0)
                {
                foreach (var q in currentQuestions)
                {

                foreach(StackPanel s in FindVisualChildren<StackPanel>(stage1))
                {
                        if (s.Tag != null && s.Tag.ToString().Equals(q.tag))
                        {
                            bool find = false;
                            int index = 0;
                            foreach(RadioButton r in s.Children.OfType<RadioButton>())
                            {
                                if (r.IsChecked.HasValue && r.IsChecked.Value)
                                {
                                    //
                                    result += ((index + 1) + "\t");
                                    find = true;
                                    break;
                                }
                                ++ index;
                            }
                            if (!find)
                            {
                                MessageBox.Show("请完成所有题目", "提醒");
                                return;
                            }
                        }
                }
                }
                
                }
                else
                {

                foreach (var q in currentQuestions)
                {

                foreach(StackPanel s in FindVisualChildren<StackPanel>(stage2and3))
                {
                        if (s.Tag != null && s.Tag.ToString().Equals(q.tag))
                        {
                            bool find = false;
                            int index = 0;
                            foreach(RadioButton r in s.Children.OfType<RadioButton>())
                            {
                                if (r.IsChecked.HasValue && r.IsChecked.Value)
                                {
                                    //
                                    result += ((r.Content as TextBlock).Text.ToString() + "\t");
                                    find = true;
                                    break;
                                }
                                ++ index;
                            }
                            if (!find)
                            {
                                MessageBox.Show("请完成所有题目", "提醒");
                                return;
                            }
                        }
                }
                }
                }
            totalResult += result;
            if (pageNumber < maxPageNumber)
            {
                stage2and3.ItemsSource = getNextFive();
            }
            else
            {   
                if (stage == 2)
                {
                    finish();
                    save.save_question(totalResult);
                    save.saveToFile();
                } else
                {
                    initStage(++stage);
                }
            }
        }

        private void finish()
        {
            Console.WriteLine("finish");
            this.Close();
        }

    }


    public class Question {
        public string question { get; set; }
        public List<string> answers { get; set; }
        public string tag { get; set;}

        public Question(string q, String tag)
        {
            this.question = q;
            this.tag = tag;
            this.answers = new List<string>();
            this.answers.Add("很不同意");
            this.answers.Add("不同意");
            this.answers.Add("一般");
            this.answers.Add("同意");
            this.answers.Add("很同意");
        }
    }
}
