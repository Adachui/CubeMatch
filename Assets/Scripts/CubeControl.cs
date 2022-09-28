using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ColorObject
{

}

public class CubeControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Color color;
    public Material material;
    private MeshRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void SetMaterialColor(Color color)
    {
        renderer.material.color = color;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
              
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
