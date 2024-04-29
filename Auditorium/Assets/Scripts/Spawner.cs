using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _Prefab;
    public float fireRate = 0.1f;
    public float chrono = 0f;
    public float spawnRadius = 1f;
    public bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            //Random.insideUnitCircle => Vector2 (-1,1 ; -1,1)
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle;
            GameObject Particles = Instantiate(_Prefab, spawnPosition, Quaternion.identity);
            Particles.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
            canSpawn = false;
        }
        if (!canSpawn)
        {
            chrono += Time.deltaTime;
        }
        if (chrono >= fireRate)
        {
            canSpawn = true;
            chrono = 0f;
        }
    }
}
