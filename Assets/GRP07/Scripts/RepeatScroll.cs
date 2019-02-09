using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class RepeatScroll : MonoBehaviour
    {

    public GameObject gameObjectSelected;
        public static RepeatScroll staticRepeatScroll;

    // Use this for initialization
    public void Start()
    {
            staticRepeatScroll = this;
    }

    public void Spawning()
    {
                Instantiate(gameObjectSelected, transform.position, Quaternion.Euler(0, 0, 0));
    }
}
}