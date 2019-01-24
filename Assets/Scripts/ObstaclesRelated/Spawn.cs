using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class Spawn : MonoBehaviour
    {

        [Header("===Settings===")]
        public Vector3 position;
        public Vector3 size;
        public float timer;
        public float minTime = Difficulty.staticDifficulty.minTimer;
        public float maxTime = Difficulty.staticDifficulty.maxTimer;

        [Header("===Obstacles===")]
        public List<GameObject> prefabs;
        public GameObject gameObjectSelected;
        public int index;
        public List<GameObject> EasyObject;
        public List<GameObject> NormalObjects;
        public List<GameObject> HardObjects;

        // Use this for initialization
        void Start()
        {
            position = gameObject.transform.position;
            timer = Random.Range(minTime, maxTime);
            minTime = Difficulty.staticDifficulty.minTimer;
            maxTime = Difficulty.staticDifficulty.maxTimer;
        }

        // Update is called once per frame
        void Update()
        {
            Timing();

            DifficultyCheck();

            Spawning();
        }

        void DifficultyCheck()
        {
            if (Difficulty.staticDifficulty.difficultyRate == 0)
            {
                if (EasyObject.Count > 0)
                    prefabs = EasyObject;
            }

            if (Difficulty.staticDifficulty.difficultyRate == 1)
            {
                prefabs = NormalObjects;
            }

            if (Difficulty.staticDifficulty.difficultyRate == 2)
            {
                prefabs = HardObjects;
            }
        }

        void Spawning()
        {

            if (Input.GetKeyDown("l") || timer <= 0)
            {
                Vector3 Pos = position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, 0);
                index = Random.Range(0, prefabs.Count);
                gameObjectSelected = prefabs[index];
                Instantiate(gameObjectSelected, Pos, Quaternion.Euler(Random.Range(0, 360), -90, 90));
                timer = Random.Range(minTime, maxTime);
            }
        }

        void Timing()
        {

            if (timer > 0)
                timer -= Time.deltaTime;

        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(position, size);
        }
    }
}
