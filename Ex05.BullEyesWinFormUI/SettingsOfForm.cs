using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ex05.BullEyesWinFormUI
{
    public enum eBoardSize
    {
        SizeOfFour = 4,
        SizeOfFive,
        SizeOfSix,
        SizeOfSeven,
        SizeOfEight,
        SizeOfNine,
        SizeOfTen,
    }

    public partial class SettingsOfForm : Form
    {
        private int m_GameBoardSize = 4;
        private eBoardSize m_MinimumSizeOfBoard = eBoardSize.SizeOfFour;
        private eBoardSize m_MaximumSizeOfBoard = eBoardSize.SizeOfTen;

        public int GameBoardSize
        {
            get
            {
                return m_GameBoardSize;
            }
        }

        public eBoardSize BoardSizeMinimum
        {
            get
            {
                return m_MinimumSizeOfBoard;
            }
        }

        public eBoardSize BoardSizeMaximum
        {
            get
            {
                return m_MaximumSizeOfBoard;
            }
        }

        public SettingsOfForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void sizeBoardButton_Click(object sender, EventArgs e)
        {
            if(m_GameBoardSize == (int)BoardSizeMaximum)
            {
                m_GameBoardSize = (int)BoardSizeMinimum;
            }
            else
            {
                m_GameBoardSize++;
            }
            
            (sender as Button).Text = string.Format("Number of chances: {0}", m_GameBoardSize);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}