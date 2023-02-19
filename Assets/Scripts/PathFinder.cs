using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveconfig;
    List<Transform> waypoints;
    int waypointIndex  = 0;

    void Start()
    {
        waypoints = waveconfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        //if last waypoint was reached delete gameobject and exit the method
        if (waypointIndex >= waypoints.Count)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 targetPosition = waypoints[waypointIndex].position;
        float delta = waveconfig.GetMovementSpeed() * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
        if(transform.position == targetPosition)
        {
            waypointIndex++;
        }

        
    }
}
