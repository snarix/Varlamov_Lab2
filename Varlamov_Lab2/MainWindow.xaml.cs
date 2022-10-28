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

        Array<double> array = new Array<double>(8);

        private void AboutProgram(object sender, RoutedEventArgs e)                                              
        {                                                                                                        
            MessageBox.Show("");                                                                                 
        }
                                                                                                                 
        private void Exit(object sender, RoutedEventArgs e)                                                      
        {                                                                                                        
            Close();                                                                                             
        }                                                                                                        
                                                                                                                 

        private void ArrayCreate(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ArraySize.Text, out int count))
            {
                MessageBox.Show("Неверный размер массива");
                return;
            }

            if (count <= 0)
            {
                MessageBox.Show("Размер массива должен быть больше 0");
                return;
            }

            Array<int> array = new Array<int>(count);

            Random rnd = new Random(count);

            array.ArrayCreate();

            ArrayOutput.ItemsSource = array.ToDataTable().DefaultView;
        }

        private void ArrayAdd(object sender, RoutedEventArgs e)
        {
            string[] massiveString = ArrayAdded.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            double[] numbers = new double[massiveString.Length];

            for (int i = 0; i < massiveString.Length; i++)
            {
                int.TryParse(massiveString[i], out int value);
                numbers[i] = value;
            }

            array.AddRange(numbers);
            ArrayOutput.ItemsSource = array.ToDataTable().DefaultView;
        }

        private void ArrayClear(object sender, RoutedEventArgs e)
        {
            //adkagd
        }

        private void ArrayDiff(object sender, RoutedEventArgs e)
        {

        }
    }                                                                                                            
}                                                                                                                
                                                                                                                 