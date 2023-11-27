using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{

    [Header("Initial Number of Enemies in Game")]
    [Space]
    [SerializeField] private int numEnemies;
    [SerializeField] private GameObject prefab;

    public CreateZones createZones;

    private Vector3 min;
    private Vector3 max;

    private void Start()
    {
        min = new Vector3(0, 0, -createZones.gridSize*createZones.matZones.GridSize.x + createZones.gridSize);
        max = new Vector3(createZones.gridSize * createZones.matZones.GridSize.y - createZones.gridSize, 0, 0);

        //spawn n number of enemies when the game starts
        for (int i = 0; i < numEnemies; i++)
        {
            GameObject enemy = Instantiate(prefab, new Vector3(UnityEngine.Random.Range(min.x, max.x), 1f, UnityEngine.Random.Range(min.z, max.z)), Quaternion.identity);
            enemy.name = "Enemy " + i.ToString();
            enemy.GetComponent<EnemyMovement>().min = min;
            enemy.GetComponent<EnemyMovement>().max = max;
        }
    }

    private void Update()
    {
        //spawn an enemy when intro key is pressed
        if (Input.GetKeyDown(KeyCode.E))
            SpawnEnemy();   

    }

    public void SpawnEnemy()
    {
        Instantiate(prefab, new Vector3(UnityEngine.Random.Range(min.x, max.x), 0f, UnityEngine.Random.Range(min.z, max.z)), Quaternion.identity);
        Debug.Log("Enemy Spawned");
    }
}
