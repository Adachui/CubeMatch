using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIController : MonoBehaviour
{
    public GameObject obj;
    RectTransform rect;
    Vector2 org;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        org = rect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            var mousePos = Input.mousePosition;
            Debug.Log(mousePos);
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
            mousePos = obj.transform.InverseTransformPoint(mousePos);
            //Debug.Log(mousePos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rect.anchoredPosition = org;
        }        
    }
}
