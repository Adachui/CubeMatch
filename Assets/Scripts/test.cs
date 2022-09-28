using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Camera cam;
    Vector3 point;
    Event currentEvent;
    Vector2 mousePos;
    public float speed;

    GameObject obj;

    private void Awake()
    {
        cam = Camera.main;
        point = new Vector3();
        currentEvent = Event.current;
        mousePos = new Vector2();
    }

    void Start()
    {
        obj = GameObject.CreatePrimitive(PrimitiveType.Cube); 
    }

    private void Update()
    {
        obj.transform.position = point;
    }


    private void OnGUI()
    {
        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        cam = Camera.main;
        point = new Vector3();
        currentEvent = Event.current;
        mousePos = new Vector2();

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        
        //Debug.Log("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        //Debug.Log("Mouse position: " + mousePos);
        //Debug.Log("World position: " + point.ToString("F3"));

        var style = new GUIStyle
        {           
            fontSize = 20,
            fontStyle = FontStyle.Bold,            
        };

        GUILayout.BeginArea(new Rect(20, 20, 450, 200));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight, style);
        GUILayout.Label("Mouse position: " + mousePos, style);
        GUILayout.Label("World position: " + point, style);
        GUILayout.EndArea();
    }

}
