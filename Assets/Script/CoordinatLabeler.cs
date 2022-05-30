using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[ExecuteAlways]
public class CoordinatLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates=new Vector2Int();
    void Awake()
    {
        label =FindObjectOfType<TextMeshPro>();
        DisplayCoordinates();
        UpdateObjectName();
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        
    }
    void DisplayCoordinates() // methods that responsible the displaying coordinates on label.
    {
        coordinates.x =Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y =Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x+","+coordinates.y;
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
