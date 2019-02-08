using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class Win_Lose : MonoBehaviour
    {
        public static Win_Lose staticwinlose;
        public bool Victory = false;
        public bool Lose = false;
        public bool NotLoseYet = true;
        public bool NotWinYet = true;
        public GameObject winText;
        public GameObject loseText;

        private void Start()
        {
            staticwinlose = this;
        }

        public void FixedUpdate()
        {
            if(Move.staticMove.isKO && NotLoseYet)
            {
                NotLoseYet = false;
                Lose = true;

                if (!loseText.GetComponent<Animator>().enabled)
                loseText.GetComponent<Animator>().enabled = true;
            }

            if (TimerBar.staticTimer.time <= 1 && !Move.staticMove.isBouleDeNeige)
            {
                Move.staticMove.Arrival();

            }
                
                
            if (TimerBar.staticTimer.time <= 0 && NotWinYet)
            {
                NotWinYet = false;
                Victory = true;
                Move.staticMove.StopGame();

                if (!winText.GetComponent<Animator>().enabled)
                winText.GetComponent<Animator>().enabled = true;
            }
        }
    }
}
