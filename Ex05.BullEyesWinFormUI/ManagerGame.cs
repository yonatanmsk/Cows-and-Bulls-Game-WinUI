using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.BullEyesWinFormUI
{
    public class ManagerGame
    {
        public BullEyesGameForm m_GameForm;
        
        public void Run()
        {
            m_GameForm = new BullEyesGameForm();
            m_GameForm.ActivateGame();
        }
    }
}