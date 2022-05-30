using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float delta;
    [SerializeField] List<Waypoint> path=new List<Waypoint>();
    void Start()
    {
        //StartCoroutine(PrintWaypointName());
        StartCoroutine(FollowPath());
       //StartCoroutine(FollowPathSmooth());
        
    }

    IEnumerator  PrintWaypointName()
    {
      foreach(Waypoint waypoint in path)
        {
            Debug.Log(waypoint.name);
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            transform.position=waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator FollowPathSmooth()
    {
        foreach (Waypoint waypoint in path)
        {
            float xposition =  Mathf.Lerp(transform.position.x, waypoint.transform.position.x,delta);
            float yposition = Mathf.Lerp(transform.position.y, waypoint.transform.position.y, delta);
            float zposition = Mathf.Lerp(transform.position.z, waypoint.transform.position.z, delta);
            transform.position = new Vector3(xposition, yposition, zposition);
            yield return new WaitForSeconds(5f);
        }
    }


}
