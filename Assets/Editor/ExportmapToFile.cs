using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class EditorTool
{
    public static void WriterFile(string fileName, GameObject rootObj)
    {
        using (StreamWriter filewriteer = new StreamWriter(fileName))
        {
            for (int i = 0; i < rootObj.transform.childCount; i++)
            {
                Transform tras = rootObj.transform.GetChild(i);

                string position = tras.position.ToString();
                filewriteer.Write(position);
            }              
        }

        AssetDatabase.Refresh();
    }

    public static List<GameObject> list = new List<GameObject>();

    public static void CreaterGameObjectInSecen(Transform trans,int[][][] maplayout)
    {

        for (int y = 0; y < maplayout.Length; y++)
        {
            for (int z = 0; z < maplayout[y].Length; z++)
            {
                for (int x = 0; x < maplayout[y][z].Length; x++)
                {
                    if (maplayout[y][z][x] == 1 && list[(y * maplayout[y].Length * maplayout[y][z].Length) + (z * maplayout[y].Length + maplayout[y][z].Length)] == null) 
                    {
                        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        list.Add(obj);
                        obj.transform.SetParent(trans);
                        obj.transform.position = new Vector3((x + x * 0.05f) - maplayout[y][z].Length * .5f, 
                            (z + z * 0.05f) - maplayout[y].Length * .5f,
                            (y + y * 0.05f) - maplayout.Length * .5f) +
                        new Vector3(.5f, .5f, .5f);
                    }
                    else 
                    {
                        list[(y * maplayout[y].Length * maplayout[y][z].Length) + (z * maplayout[y].Length + maplayout[y][z].Length)].SetActive(
                             list[(y * maplayout[y].Length * maplayout[y][z].Length) + (z * maplayout[y].Length + maplayout[y][z].Length)].activeInHierarchy? false : true);
                    }
                }
            }
        }
    }

    public static void RefereshObj()
    {

    }


}
