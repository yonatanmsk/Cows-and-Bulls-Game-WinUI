using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullEyesLogic
{
    public enum eResultTypes
    {
        Bool = 'V',
        Pgia = 'X',
    }

    public class LogicGame
    {
        private const int m_NumberOfGuesses = 4;
        private char m_RandomCharacter;
        private Random m_Random;

        public LogicGame()
        {
            m_Random = new Random();
        }

        public char RandomCharacter
        {
            get
            {
                return m_RandomCharacter;
            }

            set
            {
                m_RandomCharacter = value;
            }
        }

        public char[] GetLettersFromComputer()
        {
            int randomNumber, rightPlaceOfLetter = 0;
            char[] computerRandomLettersArray = new char[m_NumberOfGuesses];

            foreach(char letter in computerRandomLettersArray)
            {
                randomNumber = m_Random.Next(0, 8);
                RandomCharacter = (char)('A' + randomNumber);

                for(int i = 0; i < m_NumberOfGuesses; i++)
                {
                    if(RandomCharacter == computerRandomLettersArray[i])
                    {
                        i = -1;
                        randomNumber = m_Random.Next(0, 8);
                        RandomCharacter = (char)('A' + randomNumber);
                    }
                }

                computerRandomLettersArray[rightPlaceOfLetter] = RandomCharacter;
                rightPlaceOfLetter++;
            }

            return computerRandomLettersArray;
        }

        public char[] CheckIfBullsEye(char[] i_GuessFromUser, char[] i_LettersFromComputer)
        {
            char[] answerResultForGuess = new char[m_NumberOfGuesses], sortedAnswerResultForGuess = new char[m_NumberOfGuesses];
            int newPlaceOfIndexResult = 0;

            for(int i = 0; i < m_NumberOfGuesses; i++)
            {
                for(int j = 0; j < m_NumberOfGuesses; j++)
                {
                    if(i == j && i_GuessFromUser[i] == i_LettersFromComputer[j])
                    {
                        answerResultForGuess[i] = (char)eResultTypes.Bool;
                    }
                    else if(i_GuessFromUser[i] == i_LettersFromComputer[j])
                    {
                        answerResultForGuess[i] = (char)eResultTypes.Pgia;
                    }
                }
            }

            putVOrXInPlace(sortedAnswerResultForGuess, answerResultForGuess, ref newPlaceOfIndexResult, (char)eResultTypes.Bool);
            putVOrXInPlace(sortedAnswerResultForGuess, answerResultForGuess, ref newPlaceOfIndexResult, (char)eResultTypes.Pgia);

            return sortedAnswerResultForGuess;
        }

        private void putVOrXInPlace(char[] i_SortedAnswerResultForGuess, char[] i_AnswerResultForGuess, ref int io_NewPlaceOfIndexResult, char i_VOrX)
        {
            for(int i = 0; i < m_NumberOfGuesses; i++)
            {
                if(i_AnswerResultForGuess[i] == i_VOrX)
                {
                    i_SortedAnswerResultForGuess[io_NewPlaceOfIndexResult] = i_VOrX;
                    io_NewPlaceOfIndexResult++;
                }
            }
        }

        public bool CheckIfUserSucceeded(char[] i_ArrayOfResultIfBullsEye, out int io_NumberOfCorrectAnswers, out int io_NumberOfIncorrectAnswers)
        {
            io_NumberOfCorrectAnswers = 0;
            io_NumberOfIncorrectAnswers = 0;
            bool isArrayFullOfV = true;

            foreach(char character in i_ArrayOfResultIfBullsEye)
            {
                if(character != (char)eResultTypes.Bool)
                {
                    isArrayFullOfV = false;
                }
            }

            foreach(char character in i_ArrayOfResultIfBullsEye)
            {
                if(character == (char)eResultTypes.Bool)
                {
                    io_NumberOfCorrectAnswers++;
                }
                else if(character == (char)eResultTypes.Pgia)
                {
                    io_NumberOfIncorrectAnswers++;
                }
            }

            return isArrayFullOfV;
        }
    }
}