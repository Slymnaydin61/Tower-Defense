using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject tower;

    [SerializeField] bool isBuildiable;

    void OnMouseDown()
    {
        if(isBuildiable)
        {
            InstantiateTower();
        } 
    }
    void InstantiateTower()
    {
        Instantiate(tower, transform.position, Quaternion.identity);
        isBuildiable = false;
    }

}
