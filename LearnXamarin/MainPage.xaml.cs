using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Timers;
using System.Runtime.CompilerServices;

namespace LearnXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private static double TIME_INTERVAL = 1000;

        private int INDEX = 0;
        private Timer timer = null;
        private Label displayLabel = null;

        public MainPage()
        {
            InitializeComponent();
            displayLabel = new Label
            {
                Text = "Hello World @" + INDEX++,
                TextColor = Color.AntiqueWhite,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Content = displayLabel;
            Title = "Example Xamarin Application";
            BackgroundColor = Color.BlueViolet;
        }

        private void UpdateDisplay(object source, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ChangeText();
                ChangeBackgroundColor();
            });
        }

        private void ChangeText()
        {
            displayLabel.Text = "Hello World @ " + INDEX++;
        }

        private void ChangeBackgroundColor()
        {
            BackgroundColor = BackgroundColor == Color.BlueViolet ? Color.IndianRed : Color.BlueViolet;
        }

        public void StartLoop()
        {
            if (timer == null)
            {
                timer = new Timer(TIME_INTERVAL);
                timer.Elapsed += UpdateDisplay;
                timer.AutoReset = true;
            }
            timer.Start();
        }

        public void StopLoop()
        {
            timer.Stop();
        }
    }
}
