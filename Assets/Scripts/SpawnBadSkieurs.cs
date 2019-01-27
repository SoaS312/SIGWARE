using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness { 
public class SpawnBadSkieurs : MonoBehaviour {

    [Header("===Settings===")]
    public Vector3 position;
    public Vector3 size;
    public float timer;
    public float minTime;
    public float maxTime;

    [Header("===Fans===")]
    public List<GameObject> prefabs;
    public GameObject gameObjectSelected;

    // Use this for initialization
    void Start()
    {
        position = gameObject.transform.position;
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        Timing();
        Spawning();

            if(Difficulty.staticDifficulty.difficultyRate == 0)
            {
                this.enabled = false;
            }
            if (Difficulty.staticDifficulty.difficultyRate == 1)
            {
                minTime = 0.5f;
                maxTime = 1;
            }
            if (Difficulty.staticDifficulty.difficultyRate == 2)
            {
                minTime = 0.25f;
                maxTime = 0.5f;
            }

        }

    void Spawning()
    {

        if (timer <= 0)
        {
            Vector3 Pos = position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, 0);
                int index = Random.Range(0, prefabs.Count);
                gameObjectSelected = prefabs[index];
                Instantiate(gameObjectSelected, Pos, Quaternion.Euler(-270, 90, -90));
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

