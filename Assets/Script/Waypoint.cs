using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField ] Tower tower;

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
        bool isPlaced= tower.CreateTower(tower,transform.position);
        isBuildiable = !isPlaced;
    }

}
