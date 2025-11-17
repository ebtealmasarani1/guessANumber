using Microsoft.Graphics.Canvas.Effects;
using System.Diagnostics;

namespace guessANumber
{
    public partial class MainPage : ContentPage
    {
        static Random random = new Random();
        int computerNumber = 0;
        int guessCount = 0;
        public MainPage()
        {
            InitializeComponent();
        }
        private void ShowARandomNumberClicked(object? sender, EventArgs e)
        {
            if (int.TryParse(UserInput.Text, out int userNumber))
            {
                guessCount++;
                GuessCountLabel.Text = $"Antal gissningar: {guessCount}";

                if (computerNumber == userNumber)
                {
                    ShowRandomNumber.Text = $"🎉 YAYY, du gissade rätt: {computerNumber.ToString()}";
                    TheButton.IsEnabled = false;
                }
                else if (computerNumber > userNumber)
                {
                    ShowRandomNumber.Text = $"Nope, för litet.";
                }
                else if (computerNumber < userNumber)
                {
                    ShowRandomNumber.Text = $"Nope, för stort.";
                }
            }
            else
            {
                ShowRandomNumber.Text = "Vänligen skriv in ett heltal.";
            }

        }
        private void RestartGame(object? sender, EventArgs e)
        {
            guessCount = 0;
            GuessCountLabel.Text = "Antal gissningar: 0";
            guessCount = 0;
            ShowRandomNumber.Text = "Knappen fungerar, grattis!";
            TheButton.IsEnabled = true; 
            computerNumber = random.Next(1, 51);
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;


            int selectedIndex = picker.SelectedIndex;

            Debug.WriteLine(selectedIndex);

            if (selectedIndex != -1)
            {
                ShowRandomNumber.Text = (string)picker.ItemsSource[selectedIndex];
                if(selectedIndex == 0)
                {
                    computerNumber = random.Next(1, 20);
                }
                else if (selectedIndex == 1)
                {
                    computerNumber = random.Next(1, 50);
                }
                else if (selectedIndex == 2)
                {
                    computerNumber = random.Next(1, 100);
                }
                else if (selectedIndex == 3)
                {
                    computerNumber = random.Next(1, 500);
                }
                else if (selectedIndex == 4)
                {
                    computerNumber = random.Next(1, 1000);
                }
            }
        }

    }
}