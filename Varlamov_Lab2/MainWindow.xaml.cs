using System;
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
using Lib_3;
using LibArray;

namespace Varlamov_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window                                                                     
    {                                                                                                            
        public MainWindow()                                                                                      
        {                                                                                                        
            InitializeComponent();
            this.Height += 25;
        }

        private void AboutProgram(object sender, RoutedEventArgs e)                                              
        {                                                                                                        
            MessageBox.Show("Практическая работа №2.\r\n" +
                "Разработчик: Варламов Артём ИСП-34.\r\n" +
                "Найти разницу чисел. Результат вывести на экран");                                                                                 
        }
                                                                                                                 
        private void Exit(object sender, RoutedEventArgs e)                                                      
        {                                                                                                        
            Close();                                                                                             
        }                                                                                                        
                                                                                                                 
        Array<int> array;

        private void ArrayCreate(object sender, RoutedEventArgs e)
        {
            if (Create.IsEnabled)
            {
                Add.IsEnabled = true;
                Clear.IsEnabled = true;
                Diff.IsEnabled = true;
                Delete.IsEnabled = true;
            }

            if (!int.TryParse(ArraySize.Text, out int count))
            {
                MessageBox.Show("Неверный размер массива");
            }

            if (count <= 0)
            {
                MessageBox.Show("Размер массива должен быть больше 0");
            }

            array = new Array<int>(count);
            array.ArrayCreate();
            ArrayOutput.ItemsSource = array.ToDataTable().DefaultView;
        }

        private void ArrayAdd(object sender, RoutedEventArgs e)
        {
            string[] massiveString = ArrayAdded.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[massiveString.Length];

            for (int i = 0; i < massiveString.Length; i++)
            {
                int.TryParse(massiveString[i], out int value);
                numbers[i] = value;
            }

            array.AddRange(numbers);
            ArrayOutput.ItemsSource = array.ToDataTable().DefaultView;
        }

        private void NumbersDelete(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(RemoveNumbers.Text, out int item))
            {
                if (array.Remove(item))
                {
                    ArrayOutput.ItemsSource = array.ToDataTable().DefaultView;
                }
                else MessageBox.Show("Такого элемента нет");
            }
            else MessageBox.Show("Некорректные значения");
        }

        private void ArrayDiff(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(ExtensionArray.ArrayDifference(array).ToString());
        }

        private void ArrayClear(object sender, RoutedEventArgs e)
        {
            array.Clear();
            ArrayOutput.ItemsSource = null;
        }
    }                                                                                                            
}                                                                                                                
                                                                                                                 