using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GRP07_SkiMadness
{
    public class PublicSound : MonoBehaviour
    {
        public AudioClip déçu;
        public AudioClip heureux;
        public AudioClip applaudissement;
        public AudioSource source;


        public void Update()
        {
            if (Move.staticMove.isKO)
            {
                if(!source.isPlaying)
                source.PlayOneShot(déçu);
            }

            if (Move.staticMove.arrivee)
            {
                if (!source.isPlaying)
                    source.PlayOneShot(heureux);
            }

                if (Move.staticMove.isJumping)
            {
                if (!source.isPlaying)
                    source.PlayOneShot(applaudissement);
            }
        }

    }
}
 