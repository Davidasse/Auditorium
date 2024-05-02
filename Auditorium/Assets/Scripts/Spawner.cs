using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

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
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle*spawnRadius;

            //on recupere la particule
            //GameObject Particles = Instantiate(_Prefab, spawnPosition, Quaternion.identity);
            GameObject particles = ObjectPool.Get();

            if (particles == null)
            {
                return;
            }

            //On active la particule
            particles.SetActive(true);

            //on teleporte la particule
            particles.transform.position = spawnPosition;

            //On initialise la particule
            particles.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
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
