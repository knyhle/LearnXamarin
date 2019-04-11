using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearnXamarin
{
    public partial class App : Application
    {
        private MainPage mainPage;

        public App()
        {
            InitializeComponent();

            mainPage = new MainPage();
            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            Console.WriteLine("Starting...");
            mainPage.StartLoop();
        }

        protected override void OnSleep()
        {
            Console.WriteLine("Sleeping...");
            mainPage.StopLoop();
        }

        protected override void OnResume()
        {
            Console.WriteLine("Resuming...");
            mainPage.StartLoop();
        }
    }
}
