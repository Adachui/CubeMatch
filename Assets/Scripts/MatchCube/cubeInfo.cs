using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    red,
    yellow,
    blue,
    magenta,
    cyan,
    white,
    gray,
}

public class cubeInfo : MonoBehaviour
{
    public Type Type;
    private Color color;
    private Vector3 orangePosition;
    private Transform orangeParent;

    private MeshRenderer render;

    public void Init(Type type,Vector3 orange)
    {
        this.Type = type;
        switch (Type)
        {
            case Type.red: render.material.color = Color.red; break;
            case Type.yellow: render.material.color = Color.yellow; break;
            case Type.blue: render.material.color = Color.blue; break;
            case Type.cyan: render.material.color = Color.cyan; break;
            case Type.gray: render.material.color = Color.gray; break;
            case Type.magenta: render.material.color = Color.magenta; break;
            case Type.white: render.material.color = Color.white; break;
        }
    }

    public void Position(Vector3 pos)
    {
        transform.position = pos;
        orangePosition = pos;
    }

    public void Add(Transform parent,Vector3 pos)
    {
        transform.SetParent(parent);
        transform.localPosition = pos;
    }

    public void TurnBack()
    {
        transform.SetParent(orangeParent);
        transform.position = orangePosition;
    }

    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
        orangePosition = transform.localPosition;
        orangeParent = transform.parent;
    }

}
