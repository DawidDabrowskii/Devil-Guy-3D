using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] float timeToSpawn;
    private float currentTimeToSpawn;

    public void Update()
    {
        if(currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnObject();
            currentTimeToSpawn = timeToSpawn;
        }
    }
    public void SpawnObject()
    {
        Instantiate(objectToSpawn,new Vector3 (Random.Range(9,-6),Random.Range(59,59),Random.Range(70,70)),transform.rotation);
    }
}
