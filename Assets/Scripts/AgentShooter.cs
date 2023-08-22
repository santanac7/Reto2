using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawner;
    public int poolSize = 10;
    public float timeBetweenShots = 0.5f;
    public float velocidad;
    //AudioSource audioSource;
    //public AudioClip Fogueo;

    private List<GameObject> bulletPool = new List<GameObject>();
    private int currentBulletIndex = 0;

    NavMeshAgent move;
    private void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
        //move = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        InitializeBulletPool();
    }
    private void FixedUpdate()
    {
        StartCoroutine(SpawnProjectile());
    }

    private void InitializeBulletPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    private IEnumerator SpawnProjectile()
    {
        //if (move.remainingDistance <= 0)
        //{
            while (true)
            {
                ShootBulletFromPool();
                //audioSource.PlayOneShot(Fogueo);
                yield return new WaitForSeconds(timeBetweenShots);
            }
        //}
    }
    private void ShootBulletFromPool()
    {
        GameObject bullet = GetNextAvailableBullet();
        if (bullet != null)
        {
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = spawner.rotation;
            bullet.SetActive(true);

            // Reset TrailRenderer in children
            foreach (Transform child in bullet.transform)
            {
                TrailRenderer trailRenderer = child.GetComponent<TrailRenderer>();
                if (trailRenderer != null)
                {
                    trailRenderer.Clear();
                }
            }

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = bullet.transform.up * velocidad;
            }
        }
    }

    private GameObject GetNextAvailableBullet()
    {
        int initialIndex = currentBulletIndex;
        do
        {
            GameObject bullet = bulletPool[currentBulletIndex];
            if (!bullet.activeInHierarchy)
            {
                currentBulletIndex = (currentBulletIndex + 1) % poolSize;
                return bullet;
            }

            currentBulletIndex = (currentBulletIndex + 1) % poolSize;
        } while (currentBulletIndex != initialIndex);

        // If no available bullets found, recycle in order
        GameObject oldestBullet = bulletPool[currentBulletIndex];
        currentBulletIndex = (currentBulletIndex + 1) % poolSize;
        return oldestBullet;
    }

}

