using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class CollectableSpawnArea : MonoBehaviour
{
    public Collectable collectableObject;

    public List<Collectable> spawnedObjects = new List<Collectable>();
    public int maxSpawnCount = 10;
    public float spawnRadius = 10;
    public float spawnPeriod = 2f;
    public bool isTrainSpawner;

    private float nextSpawnTime = 0;
    void Update()
    {
        HandleNullElements();
        if (spawnedObjects.Count >= maxSpawnCount)
        {
            return;
        }

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnPeriod;
            SpawnObject();
        }

    }

    private void SpawnObject()
    {
        var circlePos = Random.insideUnitCircle;
       
        if (isTrainSpawner)
        {
            Vector3 spawnPosition = new Vector3(2,1,0);
            spawnPosition += transform.position;
            var collectable = Instantiate(collectableObject, transform);
            collectable.transform.position = spawnPosition;
            spawnedObjects.Add(collectable);
        }
        else
        {
            Vector3 spawnPosition = new Vector3(circlePos.x, 0.06f, circlePos.y) * spawnRadius;
            spawnPosition += transform.position;
            var collectable = Instantiate(collectableObject, null);
            collectable.transform.position = spawnPosition;
            spawnedObjects.Add(collectable);
            collectable.transform.DORotate(Vector3.up * 360f, 5f, RotateMode.LocalAxisAdd).SetLoops(-1);
        }
      


    }

    private void HandleNullElements()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i] == null)
            {
                spawnedObjects.RemoveAt(i);
            }
        }

    }
}
