using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    Vector3 center;

    [SerializeField]
    Vector3 size;

    

    [SerializeField]
    float spawnDelay;

    [SerializeField]
    float distributionFromSpawn = 0f;

    [SerializeField]
    GameObject[] objectsToSpawn;

    void Start()
    {
        StartCoroutine(Spawn());

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

    IEnumerator Spawn() {
        while (true) {
            Vector3 position = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0f);

            float time = Random.Range(spawnDelay - distributionFromSpawn, spawnDelay + distributionFromSpawn);

            yield return new WaitForSeconds(time);

            int index = Random.Range(0, objectsToSpawn.Length);
            Instantiate(objectsToSpawn[index], position, Quaternion.identity);
                
            
        }
    }




}
