using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randomEnemy;



	void Start () {

        StartCoroutine(waitSpawner());

	}

	// Update is called once per frame
	void Update () {

        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

	}

    IEnumerator waitSpawner ()
    {
        yield return new WaitForSeconds(startWait);

        while(!stop)
        {
            randomEnemy = Random.Range(0, 2);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(enemies[randomEnemy], spawnPosition + transform.TransformPoint(250, 0, 250), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}