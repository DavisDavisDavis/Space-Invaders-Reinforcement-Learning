using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int xBound = 18;
    public int Direction = 1;

    public GameObject Ufo;
    public GameObject Enemy;
    public int Points = 800;
    public int Speed;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(3, 3, new Vector3(-7, 2, 4));
        InvokeRepeating("SpawnRandomUfo", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemies(int xNumberOfEnemies, int yNumberOfEnemies, Vector3 initalSpawnPosition)
    {
        
        Vector3 nextSpawnPosition = initalSpawnPosition;

        for (int y = 0; y < yNumberOfEnemies; y++)
        {
            for (int x = 0; x < xNumberOfEnemies; x++)
            {
                Instantiate(Enemy, nextSpawnPosition, Enemy.transform.rotation);
                nextSpawnPosition.x += 2;
            }
            nextSpawnPosition.z += 2;
            nextSpawnPosition.x = initalSpawnPosition.x;
        }
    }

    void SpawnRandomUfo()
    {
        if (0 == Random.Range(0, 2))
        {
            Direction = -1;
        }
        else
        {
            Direction = 1;
        }
        int randomPoint = Direction * xBound;

        Vector3 spawnPoint = new Vector3(randomPoint, 1.5f, 24);
        Instantiate(Ufo, spawnPoint, Ufo.transform.rotation);
    }
}