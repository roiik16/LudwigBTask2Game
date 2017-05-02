using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclespawn : MonoBehaviour {

	public Transform[] spawnpoints;
    public GameObject prefab;

    public GameObject powerup1;
    public GameObject powerup2;

	int path;
	int pathlength = 3;
    int powerupinterval = 6;

    public Transform player;
    Vector3 offset;
    
	// Use this for initialization
	void Start () 
	{
        path = Random.Range(0, spawnpoints.Length);
        StartCoroutine("SpawnTimer");
        offset = transform.position - player.position;
    }

    private void FixedUpdate()
    {

        //disabling x and y position of the Obstacle spawn points
        Vector3 pos = transform.position;
        pos = player.position + offset;

        pos.x = transform.position.x;

        pos.y = transform.position.y;

        transform.position = pos;
    }


    // Update is called once per frame
    void Spawn ()
    {
        for (int i = 0; i < spawnpoints.Length; i++)
        {
            if (i != path)
            {
                int p = Random.Range(0, 2);
                if (p == 1)
                {
                    Instantiate(prefab, spawnpoints[i].position, Quaternion.identity);
                }
            }
            else if (i == path && powerupinterval-- <= 0)
            {
                GameObject spawn = (Random.Range(0, 2) == 1) ? powerup1 : powerup2;
                Instantiate(spawn, spawnpoints[i].position, Quaternion.identity);
                powerupinterval = Random.Range(3,6);
            }
        }
        if (--pathlength <= 0)
        {
            path = Random.Range(0, spawnpoints.Length);
            pathlength = 3;
        } else
        {
            path += Random.Range(-1, 2);

            if (path < 0)
            {
                path = 0;
            }

            if (path > spawnpoints.Length - 1)
            {
                pathlength = spawnpoints.Length - 1;

            }
        }
    }
    IEnumerator SpawnTimer()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(1);
        }
    }
 }
