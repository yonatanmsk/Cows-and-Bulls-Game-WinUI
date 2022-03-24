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
    public partial class TableColor : Form
    {
        private char m_ChosenColor;

        public char ChosenColor
        {
            get
            {
                return m_ChosenColor;
            }
        }

        public TableColor()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            m_ChosenColor = (sender as Button).Name[0];
            Close();
        }
    }
}