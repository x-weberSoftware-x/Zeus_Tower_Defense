using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour 
{
    private GameObject target;

    [Header("Attributes")]
    public float range = 10f;
    public float firerate = 1f;
    private float fireCountdown = 0;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Unity Required")]
    public string enemyTag = "Enemy";

	void Start () 
	{
        InvokeRepeating("UpdateTarget", 0f, .5f);
	}


	void Update ()
    {
        if (target == null)
            return;
        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1 / firerate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (target != null)
            bullet.AimBullet(target.transform);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
