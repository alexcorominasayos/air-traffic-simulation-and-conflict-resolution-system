using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Videogame
{
    /// <summary>
    /// A small side-scrolling mini-game: keep the jet in the air with the space bar and fly
    /// through the gaps between obstacles. Reaching <see cref="WinningScore"/> wins the game.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Image tags used in MainWindow.xaml to tell the game which images are obstacles or clouds.
        private const string FirstObstacleTag = "obstacle1";
        private const string SecondObstacleTag = "obstacle2";
        private const string ThirdObstacleTag = "obstacle3";
        private const string CloudTag = "clouds";

        private const int CountdownSeconds = 5;
        private const int FrameIntervalMilliseconds = 20;

        /// <summary>Pixels per frame the jet falls (positive) or climbs (negative).</summary>
        private const int FallSpeed = 8;
        private const int ClimbSpeed = -8;

        private const int ObstacleSpeed = 5;
        private const int CloudSpeed = 1;

        /// <summary>
        /// Each obstacle is made of two images (top and bottom), and each image adds half a point
        /// when it is recycled, so passing one obstacle is worth exactly one point.
        /// </summary>
        private const double PointsPerObstacleImage = 0.5;
        private const double WinningScore = 10;

        /// <summary>From this score on, obstacles are recycled much further away, so they come less often.</summary>
        private const double SparseObstaclesScore = 7;

        private const double ObstacleExitPosition = -100;
        private const double ObstacleRespawnPosition = 800;
        private const double SparseObstacleRespawnPosition = 5000;
        private const double CloudExitPosition = -250;
        private const double CloudRespawnPosition = 550;

        private const double JetStartTop = 190;
        private const double CeilingLimit = -10;
        private const double FloorLimit = 458;
        private const double ClimbTiltDegrees = -20;
        private const double FallTiltDegrees = 5;

        private readonly DispatcherTimer gameTimer = new DispatcherTimer();
        private readonly DispatcherTimer countdownTimer = new DispatcherTimer();

        private int countdownSecondsElapsed;
        private int jetVerticalSpeed = FallSpeed;
        private double score;
        private bool isGameOver;

        /// <summary>Builds the window and starts the countdown that precedes the first game.</summary>
        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Tick += OnGameFrame;
            gameTimer.Interval = TimeSpan.FromMilliseconds(FrameIntervalMilliseconds);

            countdownTimer.Interval = TimeSpan.FromSeconds(1);
            countdownTimer.Tick += OnCountdownTick;

            // Timers keep firing after the window closes unless they are stopped explicitly.
            Closed += (sender, eventArgs) => StopTimers();

            ShowCountdownScreen();
            countdownTimer.Start();
        }

        private void ShowCountdownScreen()
        {
            RestartLabel.Visibility = Visibility.Hidden;
            CloseLabel.Visibility = Visibility.Hidden;
            ResultLabel.Visibility = Visibility.Hidden;
            InstructionsLabel.Visibility = Visibility.Visible;
            CountdownLabel.Visibility = Visibility.Visible;
        }

        private void OnCountdownTick(object sender, EventArgs e)
        {
            countdownSecondsElapsed++;
            int secondsLeft = CountdownSeconds - countdownSecondsElapsed;
            CountdownLabel.Content = secondsLeft;

            if (secondsLeft <= 0)
            {
                countdownTimer.Stop();
                InstructionsLabel.Visibility = Visibility.Hidden;
                CountdownLabel.Visibility = Visibility.Hidden;
                StartGame();
            }
        }

        /// <summary>Runs once per frame: applies gravity, scrolls the scenery and checks collisions.</summary>
        private void OnGameFrame(object sender, EventArgs e)
        {
            UpdateScoreLabel();
            Rect jetHitBox = GetHitBox(JetImage);
            Canvas.SetTop(JetImage, Canvas.GetTop(JetImage) + jetVerticalSpeed);

            if (IsJetOutOfScreen())
            {
                EndGame("GAME OVER !!");
                return;
            }

            // ToList() takes a snapshot, so the canvas can be safely modified while iterating.
            foreach (Image image in GameCanvas.Children.OfType<Image>().ToList())
            {
                string tag = image.Tag as string;
                if (IsObstacleTag(tag))
                {
                    if (MoveObstacle(image, jetHitBox))
                        return; // The game ended on this frame.
                }
                else if (tag == CloudTag)
                {
                    MoveCloud(image);
                }
            }
        }

        /// <summary>
        /// Scrolls one obstacle image, recycles it when it leaves the screen and checks for
        /// collisions or victory.
        /// </summary>
        /// <returns>True if the game ended.</returns>
        private bool MoveObstacle(Image obstacle, Rect jetHitBox)
        {
            Canvas.SetLeft(obstacle, Canvas.GetLeft(obstacle) - ObstacleSpeed);

            if (jetHitBox.IntersectsWith(GetHitBox(obstacle)))
            {
                EndGame("GAME OVER !!");
                return true;
            }

            if (Canvas.GetLeft(obstacle) < ObstacleExitPosition)
            {
                double respawnPosition = score >= SparseObstaclesScore ? SparseObstacleRespawnPosition : ObstacleRespawnPosition;
                Canvas.SetLeft(obstacle, respawnPosition);
                score += PointsPerObstacleImage;
            }

            if (score >= WinningScore)
            {
                UpdateScoreLabel();
                EndGame("You've won !");
                return true;
            }
            return false;
        }

        private static void MoveCloud(Image cloud)
        {
            Canvas.SetLeft(cloud, Canvas.GetLeft(cloud) - CloudSpeed);
            if (Canvas.GetLeft(cloud) < CloudExitPosition)
                Canvas.SetLeft(cloud, CloudRespawnPosition);
        }

        /// <summary>Resets the score, the jet and the scenery to their starting positions and starts playing.</summary>
        public void StartGame()
        {
            RestartLabel.Visibility = Visibility.Visible;
            CloseLabel.Visibility = Visibility.Visible;

            score = 0;
            isGameOver = false;
            Canvas.SetTop(JetImage, JetStartTop);
            ResetSceneryPositions();

            gameTimer.Start();
        }

        private void ResetSceneryPositions()
        {
            // The first cloud starts at 500 and every following one at 1100.
            double nextCloudPosition = 500;
            foreach (Image image in GameCanvas.Children.OfType<Image>())
            {
                switch (image.Tag as string)
                {
                    case FirstObstacleTag:
                        Canvas.SetLeft(image, 500);
                        break;
                    case SecondObstacleTag:
                        Canvas.SetLeft(image, 800);
                        break;
                    case ThirdObstacleTag:
                        Canvas.SetLeft(image, 1100);
                        break;
                    case CloudTag:
                        Canvas.SetLeft(image, nextCloudPosition);
                        nextCloudPosition = 1100;
                        break;
                }
            }
        }

        /// <summary>Stops the game and shows <paramref name="resultMessage"/> to the player.</summary>
        public void EndGame(string resultMessage)
        {
            ResultLabel.Content = resultMessage;
            ResultLabel.Visibility = Visibility.Visible;
            gameTimer.Stop();
            isGameOver = true;
        }

        private void StopTimers()
        {
            gameTimer.Stop();
            countdownTimer.Stop();
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    TiltJet(ClimbTiltDegrees);
                    jetVerticalSpeed = ClimbSpeed;
                    break;
                case Key.R when isGameOver:
                    ResultLabel.Visibility = Visibility.Hidden;
                    StartGame();
                    break;
                case Key.C:
                    StopTimers();
                    Close();
                    break;
            }
        }

        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            TiltJet(FallTiltDegrees);
            jetVerticalSpeed = FallSpeed;
        }

        private void TiltJet(double degrees)
        {
            JetImage.RenderTransform = new RotateTransform(degrees, JetImage.Width / 2, JetImage.Height / 2);
        }

        private void UpdateScoreLabel()
        {
            ScoreLabel.Content = $"Score: {score}/{WinningScore}";
        }

        private bool IsJetOutOfScreen()
        {
            double jetTop = Canvas.GetTop(JetImage);
            return jetTop < CeilingLimit || jetTop > FloorLimit;
        }

        private static bool IsObstacleTag(string tag)
        {
            return tag == FirstObstacleTag || tag == SecondObstacleTag || tag == ThirdObstacleTag;
        }

        private static Rect GetHitBox(FrameworkElement element)
        {
            return new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);
        }
    }
}
