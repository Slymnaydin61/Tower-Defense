using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    Bank bank;
    [SerializeField] int goldPenalty=25;
    
    List<Waypoint> path=new List<Waypoint>();
    void OnEnable()
    {
        FindPath();
        ReturnToStar();
        StartCoroutine(FollowPathSmooth());
        
    }
    void Start()
    {
        bank=FindObjectOfType<Bank>();
    }
    void ReturnToStar()
    {
        transform.position = path[0].transform.position;
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
        bank.Withdraw(goldPenalty);
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
