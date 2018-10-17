using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    private Transform target;
    
    [Header("Ice Stats")]
    public bool iceBullet = false;
    public float slowAmount = .6f;
    public float slowTime = 2f;

    [Header("Stats")]
    public int damage = 50;
    public float speed = 50f;

    public void AimBullet(Transform _target)
    {
        target = _target;
    }

    

	void Update () 
	{
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceTravelled = speed * Time.deltaTime;

        if(dir.magnitude <= distanceTravelled)
        {
            HitEnemy();
        }

        transform.Translate(dir.normalized * distanceTravelled, Space.World);
	}

    void HitEnemy()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(damage);

        if(iceBullet == true && enemy.isSlow == false)
        {
            enemy.StartSlow(slowAmount, slowTime);
        }

        Destroy(gameObject);
    }

}
