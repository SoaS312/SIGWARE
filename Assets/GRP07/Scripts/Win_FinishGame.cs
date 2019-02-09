using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class Win_FinishGame : MonoBehaviour
    {

        public void WIN_STOP()
        {
            Debug.Log("WIN");
#if SIGWARE
LevelManager.Instance.Win();
#endif
        }

    }
}
