using System.Diagnostics;

namespace guessANumber
{
    public partial class MainPage : ContentPage
    {
        static Random random = new Random();
        int computerNumber = 0;
        int guessCount = 0;
        int score = 0;
        int maxRange = 50;
        int wins = 0;


        public MainPage()
        {
            InitializeComponent();
            RestartGameButton.IsEnabled = false;

         }

        private void ShowARandomNumberClicked(object? sender, EventArgs e)
        {
            if (int.TryParse(UserInput.Text, out int userNumber))
            {
                guessCount++;
                GuessCountLabel.Text = $"Antal gissningar: {guessCount}";

                if (computerNumber == userNumber)
                {
                    int pointsEarned = 0;

                    if (guessCount == 1)
                        pointsEarned = 100;
                    else if (guessCount <= 2)
                        pointsEarned = 80;
                    else if (guessCount <= 5)
                        pointsEarned = 50;
                    else if (guessCount <= 15)
                        pointsEarned = 1;

                    score = score + pointsEarned;

                    scoreLabel.Text= $"Poäng: {score}";

                    if (guessCount == 1)
                    {
                        wins++;
                        winLabel.Text = $"Vinster: {wins}";
                    }

                    ShowRandomNumber.Text= $"🎉 YAYY, du gissade rätt! Talet var {computerNumber}. Du klarade det på {guessCount} försök och fick {pointsEarned} poäng!";

                    GuessButton.IsEnabled = false;
                    RestartGameButton.IsEnabled = true;
                    RestartGameButton.BackgroundColor = Color.FromRgb(0, 255 , 0);
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
            ShowRandomNumber.Text = "Ny omgång startad!";
            GuessButton.IsEnabled = true;
            RestartGameButton.IsEnabled = false;
            computerNumber = random.Next(1, maxRange + 1);
            picker.IsEnabled= true;
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
                    picker.IsEnabled = false;
                }
                else if (selectedIndex == 1)
                {
                    computerNumber = random.Next(1, 50);
                    picker.IsEnabled = false;
                }
                else if (selectedIndex == 2)
                {
                    computerNumber = random.Next(1, 100);
                    picker.IsEnabled = false;
                }
                else if (selectedIndex == 3)
                {
                    computerNumber = random.Next(1, 500);
                    picker.IsEnabled = false;
                }
                else if (selectedIndex == 4)
                {
                    computerNumber = random.Next(1, 1000);
                    picker.IsEnabled = false;
                    scoreLabel.Text = computerNumber.ToString();
                }
            }
        }

    }
}