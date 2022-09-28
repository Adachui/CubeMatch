using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[Serializable]
public class GmaeSetting
{
    [SerializeField]
    public int width;
    [SerializeField]
    public int height;
    [SerializeField]
    public int hight;
    [SerializeField]
    public List<int> cubesList;

    
}


[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    [SerializeField]
    public GameSetting gameSetting;
    public int[][][] cubeLayout;

    private void Reset()
    {
        if (gameSetting == null)
        {
            return;
        }
        if (Application.IsPlaying(gameObject))
        {
            Debug.Log("Play logic");
        }
        else
        {

            // Editor logic
            Debug.Log("Editor logic");
            for (int i = 0; i < gameSetting.height; i++)
            {
                for (int j = 0; j < gameSetting.width; j++)
                {
                    for (int k = 0; k < gameSetting.hight; k++)
                    {
                        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        obj.transform.SetParent(transform);
                        obj.transform.localPosition = new Vector3(i, j, k);
                    }
                }
            }
        }
        Debug.Log("Reset");
    }


    // Start is called before the first frame update
    void Start()
    {


    }

}
