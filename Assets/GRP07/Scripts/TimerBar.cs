using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP07_SkiMadness
{
    public class TimerBar : MonoBehaviour
    {
        public int preparationTime = 2;
        public int gameTime = 10;
        public float time;
        public GameObject arrivée;
        public static TimerBar staticTimer;
        public GameObject Spawners;
        public GameObject spawnDécorOutside;
        public GameObject Départ;
        
        void Start()
        {
            staticTimer = this;
            time = gameTime + preparationTime;
        }
        
        void Update()
        {

            if (time <= gameTime && time >0.75f)
            {
                Spawners.SetActive(true);
            }
            if (time <= 1.25f && time > 0.5f)
            {
                Spawners.SetActive(false);
            }
            if (time <= 0.5f && !Move.staticMove.isBouleDeNeige)
            {
                arrivée.SetActive(true);
                spawnDécorOutside.SetActive(false);
            }else if (time <= 0.2f && Move.staticMove.isBouleDeNeige)
            {
                arrivée.SetActive(true);
                spawnDécorOutside.SetActive(false);
            }


            if (testCollision.staticCollision.Collision)
            {
                time = 10000;
            }
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
        }
    }
}
