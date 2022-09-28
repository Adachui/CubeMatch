using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

[Serializable]
public class MapLayoutData
{
    [SerializeField]
    public int width;
    [SerializeField]
    public int height;
    [SerializeField]
    public int[][] mapLayout;
}


public class mapLayout : MonoBehaviour
{
    public GameObject bg;
    public MapLayoutData mapData;
    public enum LayoutState {
        empty,
        full
    };


    // Start is called before the first frame update
    void Start()
    {
        
        for (int y = 0; y < mapData.height; y++)
        {
            
            for (int x = 0; x < mapData.width; x++)
            {
                
            }
        }
    }


}
