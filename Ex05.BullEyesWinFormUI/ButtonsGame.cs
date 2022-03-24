using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.BullEyesWinFormUI
{
    public enum eCharacters
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        V,
        X,
    }

    public class ButtonsGame : Button
    {
        private readonly int r_RowOfBoard;
        private readonly int r_ColumnOfBoard;

        public int Row
        {
            get
            {
                return r_RowOfBoard;
            }
        }

        public int Column
        {
            get
            {
                return r_ColumnOfBoard;
            }
        }

        public ButtonsGame()
        {
            BackColor = Color.Black;
        }

        public ButtonsGame(int i_RowOfBoard, int i_ColumnOfBoard)
        {
            r_RowOfBoard = i_RowOfBoard;
            r_ColumnOfBoard = i_ColumnOfBoard;
        }

        public void UpdateAndChangeButton(eCharacters i_ButtonColorCharacter)
        {
            switch (i_ButtonColorCharacter)
            {
                case eCharacters.A:
                    BackColor = Color.Fuchsia;
                    break;
                case eCharacters.B:
                    BackColor = Color.Red;
                    break;
                case eCharacters.C:
                    BackColor = Color.Lime;
                    break;
                case eCharacters.D:
                    BackColor = Color.Cyan;
                    break;
                case eCharacters.E:
                    BackColor = Color.Blue;
                    break;
                case eCharacters.F:
                    BackColor = Color.Yellow;
                    break;
                case eCharacters.G:
                    BackColor = Color.Maroon;
                    break;
                case eCharacters.H:
                    BackColor = Color.White;
                    break;
                case eCharacters.X:
                    BackColor = Color.Yellow;
                    break;
                case eCharacters.V:
                    BackColor = Color.Black;
                    break;
                default:
                    BackColor = Color.Empty;
                    break;
            }
        }
    }
}