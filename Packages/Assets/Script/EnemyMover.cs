using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f,5f)]float speed;
    [SerializeField] List<Waypoint> path=new List<Waypoint>();
    void Start()
    {
        //StartCoroutine(PrintWaypointName());
        //StartCoroutine(FollowPath());
       StartCoroutine(FollowPathSmooth());
        
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
            float transformDelta=0;
            transform.LookAt(endPosition);
            
            while(transformDelta<1)
            {
                transformDelta+=Time.deltaTime*speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, transformDelta);
                yield return new WaitForEndOfFrame();
            }
        }
    }


}
