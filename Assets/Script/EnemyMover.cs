using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    
    List<Waypoint> path=new List<Waypoint>();
    void OnEnable()
    {
        //StartCoroutine(PrintWaypointName());
        //StartCoroutine(FollowPath());
        FindPath();
        ReturnToStar();
        StartCoroutine(FollowPathSmooth());
        
    }
    void ReturnToStar()
    {
        transform.position = path[0].transform.position;
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
           Vector3 startPosition = transform.position;
           Vector3 endPosition = waypoint.transform.position;
            float delta=0f;
            transform.LookAt(endPosition);
            while (delta<1f)
            {
                delta+=Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, delta);
                yield return new WaitForEndOfFrame();
            }
           
        }   
        gameObject.SetActive(false);
    }
    void FindPath()
    {
        path.Clear();
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach (GameObject waypoint in waypoints )
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }


}
