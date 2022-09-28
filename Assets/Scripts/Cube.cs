using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct CubeData
{
    public Vector2Int position;
    public Color color;
}

public class GameSetting
{
    [SerializeField]
    public List<CubeData> list;
    [SerializeField]
    public int hight;
    [SerializeField]
    public int height;
    [SerializeField]
    public int width;
    public int[][][] cubeContaier;
}

public class Cube : MonoBehaviour
{
    private GameSetting gameSetting;
    public GameObject CubePrefab;
    public int widht;
    public int height;
    public int high;
    public int[][][] CubeContainer;
    private List<GameObject> list = new List<GameObject>();
    private Dictionary<int, List<GameObject>> dir = new Dictionary<int, List<GameObject>>();

    public float interval = 0.05f;

    private void Awake()
    {
        CubeContainer = new int[high][][];
        for (int i = 0; i < CubeContainer.Length; i++)
        {
            CubeContainer[i] = new int[height][];
            for (int j = 0; j < CubeContainer[i].Length; j++)
            {
                CubeContainer[i][j] = new int[widht];
                for (int k = 0; k < CubeContainer[i][j].Length; k++)
                {
                    CubeContainer[i][j][k] = 1;
                }
            }
        }
    }

    private void Start()
    {
        InitCubes();
    }

    void InitCubes()
    {
        for (int i = 0; i < high; i++)
        {
            for (int j = 0; j < height; j++)
            {
                for (int k = 0; k < widht; k++)
                {
                    if (CubeContainer[i][j][k] == 1)
                    {
                        var obj = GameObject.Instantiate(CubePrefab, transform);
                        obj.transform.position = new Vector3((k + k * interval) - (widht * .5f), (i + i * interval) - (high * .5f), (j + j * interval) - (height * .5f))
                            + new Vector3(0.5f, 0.5f, 0.5f);
                        list.Add(obj);                        
                    }
                }
            }
        }
    }

    IEnumerator show()
    {
        for (int i = 0; i < dir.Keys.Count; i++)
        {
            yield return new WaitForSeconds(1f);
            foreach (var item in dir[i])
            {
                item.gameObject.SetActive(true);
            }
        }
        yield return new WaitForSeconds(1f);

    }

}
