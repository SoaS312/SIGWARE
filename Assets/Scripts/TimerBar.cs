using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP07_SkiMadness
{
    public class TimerBar : MonoBehaviour
    {
        // public Image TimeFill;
        public int preparationTime = 2;
        public int gameTime = 10;
        public float time;
        public GameObject arrivée;
        public static TimerBar staticTimer;
        public GameObject Spawners;
        public GameObject Départ;
        
        void Start()
        {
            //TimeFill = this.GetComponent<Image>();
            staticTimer = this;
            time = gameTime + preparationTime;
        }
        
        void Update()
        {

            if (time <= gameTime && time >0.5f)
            {
                Spawners.SetActive(true);
                if (Départ != null)
                Départ.GetComponent<Animator>().enabled = true;
            }
            else if (time <= 0.5f)
            {
                arrivée.SetActive(true);
                Spawners.SetActive(false);
            }

            if (testCollision.staticCollision.Collision)
            {
                time = 10000;
            }
            if (time > 0)
            {
                time -= Time.deltaTime;
                //TimeFill.fillAmount = time / timeAmt;
            }
        }
    }
}
