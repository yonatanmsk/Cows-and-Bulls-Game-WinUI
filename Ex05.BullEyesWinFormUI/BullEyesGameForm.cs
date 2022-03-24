using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BullEyesLogic;

namespace Ex05.BullEyesWinFormUI
{
    public enum eStringsOfBoard
    {
        Button = 1,
        GameButton,
        Control,
    }

    public partial class BullEyesGameForm : Form
    {
        private ButtonsGame[,] m_ButtonsBoardGame;
        private Button[] m_ButtonsOfArrows, m_ButtonsOfResult;
        private SettingsOfForm m_SettingsOfForm = new SettingsOfForm();
        private TableColor m_ColorTable = new TableColor();
        private LogicGame m_LogicOfGame = new LogicGame();
        private string m_ArrowString = "-->>";
        private int m_CurrentRowInArrayOfArrows = 0, m_NumberOfChances;
        private bool m_IsUserShutDownWindow = false;
        private const int k_WidthOfBoard = 8, k_SpaceLimits = 10, k_SpaceBetweenButtons = 10, k_SpecialSpaceWidth = 45,
            k_WidthOfBigButton = 50, k_SpecialSpace = 70, k_WidthOfSmallButton = 15, k_NumberOfButtons = 4, k_ArrowNumber = 2;
        private char[] m_ComputerGussesArray, m_GuessOfUserArray = new[] {'0', '0', '0', '0'};

        public BullEyesGameForm()
        {
            m_SettingsOfForm.FormClosing += settingsOfForm_FormClosing;
            m_SettingsOfForm.ShowDialog();
            m_NumberOfChances = m_SettingsOfForm.GameBoardSize;
            m_ButtonsBoardGame = new ButtonsGame[m_NumberOfChances, k_WidthOfBoard];
            m_ButtonsOfArrows = new Button[m_NumberOfChances];
            m_ButtonsOfResult = new Button[(k_WidthOfBoard / 2)];
            boardCreator();
            m_ComputerGussesArray = m_LogicOfGame.GetLettersFromComputer();
            InitializeComponent();
            setBoardProperties();
        }

        private void setBoardProperties()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            setBoardHeight(m_NumberOfChances);
            setBoardWidth();
        }

        private void setBoardHeight(int i_NumberOfChances)
        {
            Height = k_SpaceLimits + (i_NumberOfChances + 1) * k_WidthOfBigButton
                + k_SpaceBetweenButtons * (i_NumberOfChances - 1) + k_SpecialSpace + k_SpaceLimits;
        }

        private void setBoardWidth()
        {
            Width = k_SpaceLimits + k_NumberOfButtons * k_WidthOfBigButton + k_NumberOfButtons
                * k_WidthOfSmallButton + k_SpaceLimits + k_SpecialSpaceWidth + k_ArrowNumber
                * k_WidthOfSmallButton + k_WidthOfSmallButton;
        }

        private void setButtonForArray(int i_IndexOfButton, int i_ButtonWidthSize, int i_ButtonHieghtSize,
            int i_DistanceTop, int i_DistanceLeft, ref Button[] i_ArrayOfButtons, string i_IsButonOrGameButton)
        {
            if(i_IsButonOrGameButton == eStringsOfBoard.Button.ToString())
            {
                i_ArrayOfButtons[i_IndexOfButton] = new Button();
            }
            else
            {
                i_ArrayOfButtons[i_IndexOfButton] = new ButtonsGame();
            }

            i_ArrayOfButtons[i_IndexOfButton].Width = i_ButtonWidthSize;
            i_ArrayOfButtons[i_IndexOfButton].Height = i_ButtonHieghtSize;
            i_ArrayOfButtons[i_IndexOfButton].Top = i_DistanceTop;
            i_ArrayOfButtons[i_IndexOfButton].Left = i_DistanceLeft;
            i_ArrayOfButtons[i_IndexOfButton].Enabled = false;
            Controls.Add(i_ArrayOfButtons[i_IndexOfButton]);
        }

        private void setButtonForWholeMatrix(int i_IndexOfRows, int i_IndexOfColumns,int i_ButtonWidthSize,
            int i_ButtonHieghtSize, int i_DistanceTop, int i_DistanceLeft)
        {
            m_ButtonsBoardGame[i_IndexOfRows, i_IndexOfColumns] = new ButtonsGame(i_IndexOfRows, i_IndexOfColumns);
            m_ButtonsBoardGame[i_IndexOfRows, i_IndexOfColumns].Width = i_ButtonWidthSize;
            m_ButtonsBoardGame[i_IndexOfRows, i_IndexOfColumns].Height = i_ButtonHieghtSize;
            m_ButtonsBoardGame[i_IndexOfRows, i_IndexOfColumns].Top = i_DistanceTop;
            m_ButtonsBoardGame[i_IndexOfRows, i_IndexOfColumns].Left = i_DistanceLeft;

            if(i_IndexOfRows != 0 || (i_IndexOfRows == 0 && i_IndexOfColumns > 3))
            {
                m_ButtonsBoardGame[i_IndexOfRows, i_IndexOfColumns].Enabled = false;
            }

            Controls.Add(m_ButtonsBoardGame[i_IndexOfRows, i_IndexOfColumns]);
        }

        private void buttonsResultCreator(string i_IsButonOrGameButton)
        {
            const int k_BigButtonSize = 50, k_SpaceSize = 10;
            int distanceLeft = 10, distanceTop = 10;

            for(int i = 0; i < k_WidthOfBoard / 2; i++)
            {
                setButtonForArray(i, k_BigButtonSize, k_BigButtonSize, distanceTop,
                    distanceLeft, ref m_ButtonsOfResult, i_IsButonOrGameButton);
                distanceLeft += k_BigButtonSize + k_SpaceSize;
            }
        }

        private void boardCreator()
        {
            const int k_BigButtonSize = 50, k_SmallButtonSize = 15, k_SpaceSize = 5;
            int distanceLeft = 10, distanceTop = k_BigButtonSize + 8 * k_SpaceSize;

            buttonsResultCreator(eStringsOfBoard.GameButton.ToString());
            for(int i = 0; i < m_NumberOfChances; i++)
            {
                for(int j = 0; j < k_WidthOfBoard; j++)
                {
                    if(j < (int)eBoardSize.SizeOfFour)
                    {
                        setButtonForWholeMatrix(i, j, k_BigButtonSize, k_BigButtonSize, distanceTop, distanceLeft);
                        m_ButtonsBoardGame[i, j].Click += new EventHandler(gameButton_Click);
                        distanceLeft += k_BigButtonSize + 2 * k_SpaceSize;
                    }
                    else
                    {
                        if(j == (int)eBoardSize.SizeOfFour)
                        {
                            setButtonForArray(i, k_SpecialSpaceWidth, k_SmallButtonSize + k_SpaceLimits, distanceTop + k_SpaceLimits,
                                distanceLeft, ref m_ButtonsOfArrows, eStringsOfBoard.Button.ToString());
                            m_ButtonsOfArrows[i].Text = m_ArrowString;
                            m_ButtonsOfArrows[i].Click += new EventHandler(arrowButton_Click);
                            distanceLeft += k_BigButtonSize + k_SpaceSize + 5;
                        }

                        if(j == (int)eBoardSize.SizeOfFour || j == (int)eBoardSize.SizeOfFive)
                        {
                            setButtonForWholeMatrix(i, j, k_SmallButtonSize, k_SmallButtonSize, distanceTop + 5, distanceLeft);
                            distanceLeft += k_SmallButtonSize + k_SpaceSize;

                            if(j == (int)eBoardSize.SizeOfFive)
                            {
                                distanceLeft -= 2 * (k_SmallButtonSize + k_SpaceSize);
                                distanceTop += k_SmallButtonSize + k_SpaceSize;
                            }
                        }

                        if(j == (int)eBoardSize.SizeOfSix || j == (int)eBoardSize.SizeOfSeven)
                        {
                            setButtonForWholeMatrix(i, j, k_SmallButtonSize, k_SmallButtonSize, distanceTop + 5, distanceLeft);
                            distanceLeft += k_SmallButtonSize + k_SpaceSize;
                        }
                    }
                }

                distanceTop += k_SmallButtonSize + 5 * k_SpaceSize;
                distanceLeft = 10;
            }
        }

        private void arrowButton_Click(object sender, EventArgs e)
        {
            int numberOfRightAnswers, numberOfWrongAnswers;
            char[] checkIfBullsEye;
            bool isUserWonTheGame;
            (sender as Button).Enabled = false;
            checkIfBullsEye = m_LogicOfGame.CheckIfBullsEye(m_GuessOfUserArray, m_ComputerGussesArray);
            isUserWonTheGame = m_LogicOfGame.CheckIfUserSucceeded(checkIfBullsEye, out numberOfRightAnswers, out numberOfWrongAnswers);

            if(isUserWonTheGame)
            {
                showRealResultsToUser();
                markResultsInBlackAndYellow(numberOfRightAnswers, numberOfWrongAnswers, m_CurrentRowInArrayOfArrows);
                enableOrDisableGuessButtons(m_CurrentRowInArrayOfArrows, false);
            }
            else
            {
                markResultsInBlackAndYellow(numberOfRightAnswers, numberOfWrongAnswers, m_CurrentRowInArrayOfArrows);
                if((sender as Button) == m_ButtonsOfArrows[m_NumberOfChances - 1])
                {
                    enableOrDisableGuessButtons(m_CurrentRowInArrayOfArrows, false);
                    showRealResultsToUser();
                }
                else
                {
                    enableOrDisableGuessButtons(m_CurrentRowInArrayOfArrows + 1, true);
                    enableOrDisableGuessButtons(m_CurrentRowInArrayOfArrows, false);
                }
            }

            initializeNewUserGuessArray();
            m_CurrentRowInArrayOfArrows++;
        }

        private void initializeNewUserGuessArray()
        {
            for(int i = 0; i < m_GuessOfUserArray.Length; i++)
            {
                m_GuessOfUserArray[i] = '0';
            }
        }

        private void enableOrDisableGuessButtons(int i_CurrentRowInArrayOfArrows, bool i_IsTrueOrFalse)
        {
            for(int i = 0; i < k_WidthOfBoard / 2; i++)
            {
                m_ButtonsBoardGame[i_CurrentRowInArrayOfArrows, i].Enabled = i_IsTrueOrFalse;
            }
        }

        private void markResultsInBlackAndYellow(int i_NumberOfRightAnswers, int i_NumberOfWrongAnswers,
            int i_CurrentRowInArrayOfArrows)
        {
            int firstIndexButtonOfResults = (int)eBoardSize.SizeOfFour;

            for(int i = 0; i < i_NumberOfRightAnswers; i++)
            {
                m_ButtonsBoardGame[i_CurrentRowInArrayOfArrows, firstIndexButtonOfResults].UpdateAndChangeButton(eCharacters.V);
                firstIndexButtonOfResults++;
            }

            for(int i = 0; i < i_NumberOfWrongAnswers; i++)
            {
                m_ButtonsBoardGame[i_CurrentRowInArrayOfArrows, firstIndexButtonOfResults].UpdateAndChangeButton(eCharacters.X);
                firstIndexButtonOfResults++;
            }
        }

        private void showRealResultsToUser()
        {
            eCharacters actualCharacter;
            int indexOfComputerGuess = 0;

            foreach(ButtonsGame button in m_ButtonsOfResult)
            {
                Enum.TryParse(m_ComputerGussesArray[indexOfComputerGuess].ToString(), out actualCharacter);
                button.UpdateAndChangeButton(actualCharacter);
                indexOfComputerGuess++;
            }
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            eCharacters actualCharacter;
            m_ColorTable.ShowDialog();
            char chosenColor = m_ColorTable.ChosenColor;
            ButtonsGame clickdGameButton = (sender as ButtonsGame);

            if(!m_GuessOfUserArray.Contains(chosenColor))
            {
                m_GuessOfUserArray[clickdGameButton.Column] = chosenColor;
                Enum.TryParse(chosenColor.ToString(), out actualCharacter);
                clickdGameButton.UpdateAndChangeButton(actualCharacter);
            }

            if(checkIfListIsFull(clickdGameButton.Row))
            {
                m_ButtonsOfArrows[clickdGameButton.Row].Enabled = true;
            }
            else
            {
                m_ButtonsOfArrows[clickdGameButton.Row].Enabled = false;
            }
        }

        public void ActivateGame()
        {
            if(!m_IsUserShutDownWindow)
            {
                ShowDialog();
            }
        }

        private bool checkIfListIsFull(int i_RowOfGuess)
        {
            bool isListFull = true;

            for(int i = 0; i < (int)eBoardSize.SizeOfFour; i++)
            {
                if(m_ButtonsBoardGame[i_RowOfGuess, i].BackColor.Name.Equals(eStringsOfBoard.Control.ToString()))
                {
                    isListFull = false;
                    break;
                }
            }

            return isListFull;
        }

        private void settingsOfForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                m_IsUserShutDownWindow = true;
            }
        }
    }
}