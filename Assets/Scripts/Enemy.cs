using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
    public Image healthBar;

    public float health = 100;
    public float currentHealth;

    public int soulsValue = 20;

    public float speed = 5f;
    public float turningDistance = .3f; //distance from waypoint to find the next waypoint

    private Transform target;
    private int waypointIndex = 0;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / health;

        if (currentHealth <= 0)
        {
            PlayerStats.souls += soulsValue;
            Destroy(gameObject);

            WaveSpawner.EnemiesAlive--;
        }
    }

	void Start () 
	{
        currentHealth = health;
        target = Waypoints.waypoints[0];
	}


	void Update () 
	{
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < turningDistance)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length -1)
        {
            PlayerStats.worshippers -= 1;
            Destroy(gameObject);
            WaveSpawner.EnemiesAlive--;
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
