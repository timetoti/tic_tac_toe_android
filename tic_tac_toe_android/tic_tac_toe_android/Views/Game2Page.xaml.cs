using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tic_tac_toe_android
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Game2Page : ContentPage
	{
        Button[,] buttons = new Button[3, 3];
        bool IsGameOn;
        bool FirstPlayerTurn;
        int turncount;
        string[] States = { "First Player's turn", "Second Player's turn", "First Player win!", "Second Player win!", "Draw"};

		public Game2Page ()
		{
			InitializeComponent();
            buttons[0, 0] = b1;
            buttons[0, 1] = b2;
            buttons[0, 2] = b3;
            buttons[1, 0] = b4;
            buttons[1, 1] = b5;
            buttons[1, 2] = b6;
            buttons[2, 0] = b7;
            buttons[2, 1] = b8;
            buttons[2, 2] = b9;
            IsGameOn = true;
            FirstPlayerTurn = true;
            turncount = 0;
		}

        public void Check()
        {
            for (int i = 0; i < 2; i++)
            {
                if (buttons[i, 0].Text == buttons[i, 1].Text && buttons[i, 1].Text == buttons[i, 2].Text && buttons[i, 0].Text != "")
                {
                    IsGameOn = false;
                    return;
                }

                if (buttons[0, i].Text == buttons[1, i].Text && buttons[1, i].Text == buttons[2, i].Text && buttons[0, i].Text != "")
                {
                    IsGameOn = false;
                    return;
                }
            }

            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text && buttons[0, 0].Text != "")
            {
                IsGameOn = false;
                return;
            }

            if (buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text && buttons[2, 0].Text != "")
            {
                IsGameOn = false;
                return;
            }

            return;
        }

        private void ButtonCellClicked(object sender, EventArgs e)
        {
            if (IsGameOn && ((Button)sender).Text == "")
            {
                if (FirstPlayerTurn)
                {
                    ((Button)sender).Text = "X";
                }
                else
                {
                    ((Button)sender).Text = "O";
                }

                Check();
                if (IsGameOn)
                {
                    FirstPlayerTurn = !FirstPlayerTurn;
                    StateLabel.Text = FirstPlayerTurn ? States[0] : States[1];
                }
                else
                {
                    StateLabel.Text = FirstPlayerTurn ? States[2] : States[3];
                    RestartButton.IsVisible = true;
                }
                turncount++;
                if (turncount==9)
                {
                    IsGameOn = false;
                    StateLabel.Text = States[4];
                    RestartButton.IsVisible = true;
                }
            }
        }

        private void RestartButtonClicked(object sender, EventArgs e)
        {
            RestartButton.IsVisible = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                }
            }
            IsGameOn = true;
            FirstPlayerTurn = true;
            StateLabel.Text = States[0];
            turncount = 0;
        }
    }
}