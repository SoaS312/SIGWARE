using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class Weather : MonoBehaviour
    {

        public List<GameObject> SnowList;
        public GameObject gameObjectSelected;

        // Use this for initialization
        void Start()
        {
            int index = Random.Range(0, SnowList.Count);
            gameObjectSelected = SnowList[index];
            Instantiate(gameObjectSelected);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
