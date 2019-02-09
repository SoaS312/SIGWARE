using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness { 
public class Lose_FinishGame : MonoBehaviour {

        public void LOSE_STOP()
        {
            Debug.Log("Lose");
#if SIGWARE
LevelManager.Instance.Lose();
#endif          
        }

    }
}
