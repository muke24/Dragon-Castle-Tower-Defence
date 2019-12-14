using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;
    public int goldValue = 20;

    //current health of this enemy
    public int currentHealth = 100;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        // if enemy has made it to current waypoint make next point target waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        if (currentHealth <= 0)
        {
            // if enemy's health is 0 or less destroy enemy
            Destroy(this.gameObject);
            // add gold to player
            PlayerHandler.playerGold += goldValue;
        }
    }

    void GetNextWaypoint()
    {
        // if enemy makes it to last waypoint destroy the object
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        // incrase index of waypoints (next waypoint)
        wavepointIndex++;
        // set next target waypoint for enemy
        target = Waypoints.points[wavepointIndex];
    }
}
