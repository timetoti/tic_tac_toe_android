﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace tic_tac_toe_android
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Game2ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Game2Page());
        }
    }
}
