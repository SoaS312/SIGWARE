using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class Difficulty : MonoBehaviour
    {

        public static Difficulty staticDifficulty;

        [Range(0, 2)]
        public int difficultyRate;

        public float minTimer;
        public float maxTimer;
        void Awake()
        {
            if (difficultyRate == 0)
            {
                minTimer = 0.5f;
                maxTimer = 1f;
            }
            if (difficultyRate == 1)
            {
                minTimer = 0.25f;
                maxTimer = 0.5f;
            }

            if (difficultyRate == 2)
            {
                minTimer = 0.1f;
                maxTimer = 0.25f;
            }
            staticDifficulty = this;

        }
    }
}
