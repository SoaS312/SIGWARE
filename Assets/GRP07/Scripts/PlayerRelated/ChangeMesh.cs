using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class ChangeMesh : MonoBehaviour
    {
        public Mesh[] animMeshes;
        public Mesh currentMesh;
        public int index = 0;
        public float timer = 10f;
        public float currentTime;
        public float decreaseTime;
        public GameObject SkieurNormal;

        private void FixedUpdate()
        {
            gameObject.GetComponent<MeshFilter>().mesh = currentMesh;

            if (Input.GetKeyDown("space"))
            {
                timer = 5;
            }

            if (timer > 0)
            {
                timer -= 0.05f;
            }

            if (timer <= 0)
            {
                gameObject.GetComponent<Animator>().Play("New Animation");
                timer = 5;
            }
        }

        public void EndAnim()
        {
            this.gameObject.SetActive(false);
            SkieurNormal.SetActive(true);
        }
    }
}
