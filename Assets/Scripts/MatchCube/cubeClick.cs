using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class cubeClick : MonoBehaviour,IPointerClickHandler
{
    private cubeInfo cubeinfo;

    private void Awake()
    {
        cubeinfo = GetComponent<cubeInfo>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BoardContaier.Instance.Add(cubeinfo);
    }
}
