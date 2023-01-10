using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ranged, melee;

    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(0);
        Instantiate(ranged, new Vector3(transform.position.x+Random.Range(-.5f, .5f), transform.position.y+Random.Range(-1f, 1f), 0), Quaternion.identity);
        Instantiate(melee, new Vector3(transform.position.x+Random.Range(-.5f, .5f), transform.position.y+Random.Range(-1f, 1f), 0), Quaternion.identity);
    }   
}
