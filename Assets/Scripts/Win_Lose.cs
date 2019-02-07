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

        private void Start()
        {
            staticwinlose = this;
        }

        public void FixedUpdate()
        {
            if(Move.staticMove.isKO)
            {
                Lose = true;

                /*#if SIGWARE
	    LevelManager.Instance.Lose();
        #endif*/
            }

            if (TimerBar.staticTimer.time <= 1)
            {
                Move.staticMove.Arrival();
            }
                
                
            if (TimerBar.staticTimer.time <= 0)
            {
                Victory = true;
                Move.staticMove.StopGame();

/*#if SIGWARE
	LevelManager.Instance.Win();
#endif*/
            }
        }
    }
}
