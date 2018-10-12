using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public float speed = 5f;
    public float turningDistance = .3f; //distance from waypoint to find the next waypoint

    private Transform target;
    private int waypointIndex = 0;

	void Start () 
	{
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
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
