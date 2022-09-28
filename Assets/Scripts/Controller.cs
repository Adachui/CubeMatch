using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float Speed = 120.0f;
    public float Smooth = 2f;
    public Text TouchPosition;
    public Text UpdatePositoin;
         

    private Vector2 touchPosition;
    private Vector2 updatePosition;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch input = Input.GetTouch(0);

            if (input.phase == TouchPhase.Began)
            {
                touchPosition = input.rawPosition;
                TouchPosition.text = touchPosition.ToString();
            } 
            else if (input.phase == TouchPhase.Moved)
            {
                updatePosition += input.deltaPosition;
                UpdatePositoin.text = updatePosition.ToString();
                if (updatePosition.sqrMagnitude > .5f)
                {
                    var target = Quaternion.Euler(updatePosition);
                    transform.rotation = Quaternion.Slerp(transform.rotation, target, Smooth * Time.deltaTime);
                }
            }
            else if (input.phase == TouchPhase.Ended)
            {
                updatePosition = Vector2.zero;
            }
        }
    }
             
}
