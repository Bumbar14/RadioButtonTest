﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using Xamarin.Essentials;

namespace RadioButtonTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = FreshPageModelResolver.ResolvePageModel<FirstPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        private bool IsLogedIn()
        {
            bool isLogedIn = Preferences.Get("IsLogedIn", false);
            if (isLogedIn)
            {
                return true;
            }

            return false;
        }
    }
}
