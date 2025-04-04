using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ExamScoreCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidationText.Text = "";

                if (!int.TryParse(Module1TextBox.Text, out int module1Score))
                {
                    ValidationText.Text = "Ошибка: введите число для модуля 1";
                    return;
                }

                if (!int.TryParse(Module2TextBox.Text, out int module2Score))
                {
                    ValidationText.Text = "Ошибка: введите число для модуля 2";
                    return;
                }

                if (!int.TryParse(Module3TextBox.Text, out int module3Score))
                {
                    ValidationText.Text = "Ошибка: введите число для модуля 3";
                    return;
                }

                var (totalScore, grade) = ExamCalculator.CalculateResult(module1Score, module2Score, module3Score);

                TotalScoreText.Text = $"Общая сумма баллов: {totalScore} из {ExamCalculator.MaxTotal}";
                GradeText.Text = $"Оценка: {grade}";

                StartResultAnimation();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ValidationText.Text = ex.Message;
            }
            catch (Exception ex)
            {
                ValidationText.Text = $"Произошла ошибка: {ex.Message}";
            }
        }



        private void StartResultAnimation()
        {
            Storyboard storyboard = new Storyboard();

            // Анимация прозрачности
            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5)
            };
            Storyboard.SetTarget(opacityAnimation, ResultPanel);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(opacityAnimation);

            // Анимация отступа
            ThicknessAnimation marginAnimation = new ThicknessAnimation
            {
                From = new Thickness(0, 20, 0, 0),
                To = new Thickness(0, 10, 0, 0),
                Duration = TimeSpan.FromSeconds(0.3)
            };
            Storyboard.SetTarget(marginAnimation, ResultPanel);
            Storyboard.SetTargetProperty(marginAnimation, new PropertyPath(MarginProperty));
            storyboard.Children.Add(marginAnimation);

            storyboard.Begin();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
}