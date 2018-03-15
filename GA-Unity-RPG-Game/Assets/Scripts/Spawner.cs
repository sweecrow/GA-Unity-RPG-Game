using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randEnemy;
    public int enemieCount;
    public int enemieMaxCount;
    
	
	void Start ()
    {
        StartCoroutine(WaitSpawner());
        
	}

	
	void Update ()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

        if(enemieCount >= enemieMaxCount)
        {
            stop = true;
        }
        if(enemies == null)
        {
            stop = true;
        }
    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        
        while(!stop)
        {
            randEnemy = Random.Range(0, 2);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            enemieCount++;

            yield return new WaitForSeconds(spawnWait);
        }
        
    }
}