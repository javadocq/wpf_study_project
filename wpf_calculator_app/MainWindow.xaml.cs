using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            ACButton.Click += ACButton_Click;
            PlusMinusButton.Click += PlusMinusButton_Click;
            PercentButton.Click += PercentButton_Click;
            EqualButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber)) 
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Minus(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;
                }
            }
            resultLabel.Content = result.ToString();
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                newNumber = newNumber / 100;
                if (lastNumber != 0)
                {
                    newNumber *= lastNumber;
                }
                resultLabel.Content = newNumber.ToString(); 
            }
        }

        private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber)) // 결과를 반환하는 out lastNumber
            {
                lastNumber = -lastNumber;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber)) // 결과를 반환하는 out lastNumber
            {
                resultLabel.Content = "0";
            }

            if (sender == MultiplyButton)
            {
                selectedOperator = SelectedOperator.Multiplication;

            }
            else if (sender == DivisionButton)
            {
                selectedOperator = SelectedOperator.Division;
            }
            else if (sender == PlusButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            else if (sender == MinusButton)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString().Contains(".")) {
                return;
            }
            resultLabel.Content = $"{resultLabel.Content}.";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Minus(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Division(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("0으로 나눌 수 없습니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
}