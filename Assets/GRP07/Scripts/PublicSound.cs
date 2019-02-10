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
        public bool asplayed = false;


        public void FixedUpdate()
        {
            if (Move.staticMove.isKO)
            {
                asplayed = true;
                if(!source.isPlaying && !asplayed)
                source.PlayOneShot(déçu);
            }

            if (Move.staticMove.arrivee)
            {
                asplayed = true;
                if (!source.isPlaying && !asplayed)
                    source.PlayOneShot(heureux);
            }

                if (Move.staticMove.SelectedMeshSaut.activeInHierarchy)
            {
                if (!source.isPlaying)
                    source.PlayOneShot(applaudissement);
            }
        }

    }
}
 