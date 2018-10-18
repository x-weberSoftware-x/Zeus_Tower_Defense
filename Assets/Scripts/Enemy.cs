using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
    public Image healthBar;

    public float health = 100;
   
    public int soulsValue = 20;

    public float startSpeed = 5f;
    
    public float turningDistance = .3f; //distance from waypoint to find the next waypoint

    private float currentHealth;
    private float speed;

    [HideInInspector]
    public bool isSlow = false;
 
    private Transform target;
    private int waypointIndex = 0;

	void Start () 
	{
        speed = startSpeed;
        currentHealth = health;
        target = Waypoints.waypoints[0];
	}


	void Update () 
	{
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        float distance = Vector3.Distance(transform.position, target.position);
        transform.LookAt(target);

        if (distance < turningDistance)
        {
            GetNextWaypoint();
        }
    }

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

    public void StartSlow(float _decreaseSpeed, float _slowTime)
    {
        StartCoroutine(Slow(_decreaseSpeed,_slowTime));
    }

    IEnumerator Slow(float decreaseSpeed, float slowTime)
    {
        speed = startSpeed * decreaseSpeed;
        Debug.Log(speed);
        isSlow = true;
        yield return new WaitForSeconds(slowTime);
        speed = startSpeed;
        isSlow = false;
        Debug.Log(speed);
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
