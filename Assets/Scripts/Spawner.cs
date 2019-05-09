using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnTime = 2;
    public LayerMask LmZombiesColliders;
    public Color gizmoColor = Color.yellow;
    public float maxSpawnDistance = 3;

    protected float timeCounter;

    protected void RandomSpawn(GameObject spawnObject, int min, int max)
    {
        if (!GameControl.GameOver)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter > SpawnTime)
            {
                timeCounter = 0;
                SpawnTime = Random.Range(min, max);

                StartCoroutine(RandomSpawnObject(spawnObject));
            }
        }
    }

    protected IEnumerator RandomSpawnObject(GameObject spawnObject)
    {
        Vector3 position = RandomPosition();
        Collider[] collisions = Physics.OverlapSphere(position, 1, LmZombiesColliders);

        while (collisions.Length > 0)
        {
            position = RandomPosition();
            collisions = Physics.OverlapSphere(position, 1, LmZombiesColliders);
            yield return null;
        }

        position.y = transform.position.y;

        Instantiate(spawnObject, position, transform.rotation);
    }

    Vector3 RandomPosition()
    {
        Vector3 position = Random.insideUnitSphere * maxSpawnDistance;
        position += transform.position;
        position.y = 0;

        return position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, maxSpawnDistance);
    }
}