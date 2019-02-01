﻿using System.Collections;
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
        public float minTime;
        public float maxTime;

        [Header("===Obstacles===")]
        public GameObject gameObjectSelected;
        public int index;

        [Header("===OnGoing===")]
        public List<GameObject> commonObjects;
        public List<GameObject> uncommonObjects;
        public List<GameObject> rareObjects;
        public float spawnChances;
        public List<GameObject> SelectedList;

        void Start()
        {
            spawnChances = Random.Range(0f, 1f);
            position = gameObject.transform.position;
            timer = Random.Range(minTime, maxTime);
            minTime = Difficulty.staticDifficulty.minTimer;
            maxTime = Difficulty.staticDifficulty.maxTimer;
        }

        void Update()
        {
            Timing();
            SpawningChanceTable();
            Spawning();
        }
        void SpawningChanceTable()
        {
            if (Difficulty.staticDifficulty.difficultyRate == 0)
            {
                if (spawnChances >= 0.7f)
                {
                    SelectedList = uncommonObjects;
                }
                if (spawnChances < 0.7f)
                {
                    SelectedList = commonObjects;
                }
            }
            if (Difficulty.staticDifficulty.difficultyRate == 1)
            {
                if (spawnChances >= 0.85f)
                {
                    SelectedList = rareObjects;
                }
                if (spawnChances >= 0.5f && spawnChances < 0.85f)
                {
                    SelectedList = uncommonObjects;
                }
                if (spawnChances < 0.5f)
                {
                    SelectedList = commonObjects;
                }
            }
            if (Difficulty.staticDifficulty.difficultyRate == 2)
            {
                if (spawnChances >= 0.75f)
                {
                    SelectedList = rareObjects;
                }
                if (spawnChances >= 0.35f && spawnChances < 0.75f)
                {
                    SelectedList = uncommonObjects;
                }
                if (spawnChances < 0.35f)
                {
                    SelectedList = commonObjects;
                }
            }
        }

        void Spawning()
        {
            
            if (timer <= 0)
            {
                timer = Random.Range(minTime, maxTime);
                spawnChances = Random.Range(0f, 1f);
                Vector3 Pos = position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, 0);
                index = Random.Range(0, SelectedList.Count);
                gameObjectSelected = SelectedList[index];
                Instantiate(gameObjectSelected, Pos, Quaternion.Euler(Random.Range(0, 360), -90, 90));
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
