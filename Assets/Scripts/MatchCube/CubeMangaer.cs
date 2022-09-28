using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class CubeMangaer : MonoBehaviour
{
    public GameObject cubePrefab;
    public int RandomCount = 10;
    [Header("高")]
    int hight = 3;       //y layout
    [Header("长")]   
    int deep = 3;        //z layout[0]
    [Header("宽")]
    int width = 3;       //x layout[0][0]
    public float offset = .1f;
    private Type[] types;
    private List<cubeInfo> cubes;
    CubeConfige cubeConfig;

    private void Awake()
    {
        Init();
        StartCoroutine(BegingDisplay2());

    }

    private void Initialization()
    {
        types = new Type[RandomCount];
        cubes = new List<cubeInfo>(RandomCount * 3);
        for (int i = 0; i < RandomCount; i++)
        {
            Type r = (Type)Random.Range(0, 7);
            types[i] = r;
        }

        for (int i = 0; i < RandomCount; i++)
        {
            var cubeType = types[i];
            for (int j = 0; j < 3; j++)
            {
                var cube = GameObject.Instantiate(cubePrefab, transform);
                cubeInfo cubeinfo = cube.GetComponent<cubeInfo>();
                if (cubeinfo == null)
                {
                    cube.AddComponent<cubeInfo>();                    
                }
                cubeinfo.Init(cubeType, transform.position);
                cubes.Add(cubeinfo);
                cube.SetActive(false);                
            }
        }
    }

    private void BegingDisplay()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int z = 0; z < 3; z++)
            {
                for (int x = 0; x < 3; x++)
                {
                    cubes[y * (deep * width) + (z * width + x)].Position(
                        new Vector3((x + x * offset) - width * .5f, (z + z * offset) - deep * .5f, (y + y * offset) - hight * .5f) +
                        new Vector3(.5f, .5f, .5f));
                    cubes[y * (3 * 3) + (z * 3 + x)].gameObject.SetActive(true);
                }
            }
        }
    }

    private void Init()
    {
        var jsonStr = Resources.Load<TextAsset>("Data/data1").text;
        Debug.Log(jsonStr);
        cubeConfig = JsonMapper.ToObject<CubeConfige>(jsonStr);
        hight = cubeConfig.layout.Length;
        deep = cubeConfig.layout[0].Length;
        width = cubeConfig.layout[0][0].Length;
    }

    private IEnumerator BegingDisplay2()
    {
        for (int y = 0; y < hight; y++)
        {
            for (int z = 0; z < deep; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (cubeConfig.layout[y][z][x] == 1)
                    {
                        var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        obj.transform.SetParent(transform);
                        obj.transform.localPosition = new Vector3((x + x * offset) - width * .5f, (y + y * offset) - hight * .5f, (z + z * offset) - deep * .5f) +
                            new Vector3(.5f, .5f, .5f);
                    }
                }
            }
            yield return new WaitForSeconds(.1f);

        }
    }

}
