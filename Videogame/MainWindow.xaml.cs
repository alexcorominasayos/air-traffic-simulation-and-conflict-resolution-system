using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace Videogame
{
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer(); // create a new instance of the timer class called game timer
        DispatcherTimer CountdownTimer = new DispatcherTimer(); // another one for the countdown at the beginning of the game

        int count = 0;
        int gravity = 8; // new gravity integer hold the vlaue 8
        double score; // score keeper
        bool gameover = false; // new boolean for checking if the game is over or not

        Rect JetHitBox; // new rect class to help us detect collisions
        public MainWindow()
        {
            InitializeComponent();

            // set the default settings for the timer
            gameTimer.Tick += GameEngine; // link the timer tick to the game engine event
            gameTimer.Interval = TimeSpan.FromMilliseconds(20); // set the interval to 20 miliseconds

            // we configurate all the textboxes at the beginning
            RestartText.Visibility = Visibility.Hidden;
            CloseText.Visibility = Visibility.Hidden;
            ResultText.Visibility = Visibility.Hidden;
            InfoText.Visibility = Visibility.Visible;
            CountdownText.Visibility = Visibility.Visible;

            // we count every tick of the timer to make a countdown
            CountdownTimer.Interval = TimeSpan.FromSeconds(1);
            CountdownTimer.Tick += (a, b) =>
            {
                count++;
                CountdownText.Content = 5 - count;
                if (Convert.ToInt32(CountdownText.Content) == 0)
                {
                    InfoText.Visibility = Visibility.Hidden;
                    CountdownText.Visibility = Visibility.Hidden;
                    StartGame();
                }
            };
            CountdownTimer.Start();
        }

        private void GameEngine(object sender, EventArgs e)
        {
            // this is the game engine event linked to the timer
            scoreText.Content = "Score: " + score + "/50"; // first update the score text label with the score integer
            JetHitBox = new Rect(Canvas.GetLeft(Jet), Canvas.GetTop(Jet), Jet.Width, Jet.Height); // link the flappy bird image to the flappy rect class
            Canvas.SetTop(Jet, Canvas.GetTop(Jet) + gravity); // set the gravity to the flappy bird image in the canvas

            // check if the bird has either gone off the screen from top or bottom
            if (Canvas.GetTop(Jet) < -10 || Canvas.GetTop(Jet) > 458)
            {
                // if it has then we end the game and show the reset game text
                ResultText.Content = "GAME OVER !!";
                EndGame();
            }
            // below is the main loop, this loop will go through each image in the canvas
            // if it finds any image with the tags and follow the instructions with them
            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1" || (string)x.Tag == "obs2" || (string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5); // if we found an image with the tag obs1,2 or 3 then we will move it towards left of the screen
                    Rect PipeHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height); // create a new rect called pillars and link the rectangles to it

                    // if the flappy rect and the pillars rect collide
                    if (JetHitBox.IntersectsWith(PipeHitBox))
                    {
                        // end the game
                        ResultText.Content = "GAME OVER !!";
                        EndGame();
                    }

                    // if the first layer of pipes leave the scene and go to -100 pixels from the left
                    // we need to reset the pipe to come back again
                    if (Canvas.GetLeft(x) < -100)
                    {
                        if (score >= 7)
                        {
                            Canvas.SetLeft(x, 5000); // reset the pipe to 800 pixels
                            score = score + .5; // add 1 to the score
                        }
                        if (score < 7)
                        {
                            Canvas.SetLeft(x, 800); // reset the pipe to 800 pixels
                            score = score + .5; // add 1 to the score
                        }
                    }
                    if (score == 10)
                    {
                        scoreText.Content = "Score: " + score + "/50";
                        ResultText.Content = "You've won !";
                        // end the game
                        EndGame();
                    }
                }
                // if find any of the images with the clouds tag on it
                if ((string)x.Tag == "clouds")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 1); // then we will slowly move the cloud towards left of the screen

                    // if the clouds have reached -250 pixels then we will reset it
                    if (Canvas.GetLeft(x) < -250)
                    {
                        // reset the cloud images to 550 pixels
                        Canvas.SetLeft(x, 550);
                    }
                }
            }
        }
        public void StartGame()
        {
            RestartText.Visibility = Visibility.Visible;
            CloseText.Visibility = Visibility.Visible;

            // this is the start game function 
            // this function will load all of the default values to start this game

            int temp = 200; // first make a temp integer with the value 200
            score = 0; // set score to 0
            Canvas.SetTop(Jet, 190); // set the flappy bird top position to 100 pixels
            gameover = false;  // set game over to false

            // the loop below will simply check for each image in this game and set them to their default positions
            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                // set obs1 pipes to its default position
                if (x is Image && (string)x.Tag == "obs1")
                {
                    Canvas.SetLeft(x, 500);
                }
                // set obs2 pipes to its default position
                if (x is Image && (string)x.Tag == "obs2")
                {
                    Canvas.SetLeft(x, 800);
                }
                // set obs3 pipes to its default position
                if (x is Image && (string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, 1100);
                }
                // set the clouds to its default position
                if (x is Image && (string)x.Tag == "clouds")
                {
                    Canvas.SetLeft(x, (300 + temp));
                    temp = 800;
                }
            }
            gameTimer.Start(); // start the main game timer
        }
        public void EndGame()
        {
            ResultText.Visibility = Visibility.Visible;
            // stop the timer, set the game over to true and show the reset text
            gameTimer.Stop();
            gameover = true;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // if the space key is pressed
            if (e.Key == Key.Space)
            {
                // rotate the bird image to -20 degrees from the center position
                Jet.RenderTransform = new RotateTransform(-20, Jet.Width / 2, Jet.Height / 2);
                gravity = -8; // change gravity so it will move upwards
            }
            if (e.Key == Key.R && gameover == true)
            {
                // if the r key is pressed AND game over boolean is set to true
                ResultText.Visibility = Visibility.Hidden;
                StartGame(); // run the start game function
            }
            if (e.Key == Key.C)
            {
                EndGame();
                Close();
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // if the keys are released then we will change the rotation of the flappy bird to 5 degrees from the center
            Jet.RenderTransform = new RotateTransform(5, Jet.Width / 2, Jet.Height / 2);
            gravity = 8; // change the gravity to 8 so the bird will go downwards and not up
        }
    }
}
