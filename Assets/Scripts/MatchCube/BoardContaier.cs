using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardContaier : MonoBehaviour
{
    public static BoardContaier Instance;
    public Vector3[] Boards;
    public List<cubeInfo> cubeList;
    public const int ContaierCount = 7;

    private void Awake()
    {
        Instance = this;
        InitBoawlList();
    }

    private void InitBoawlList()
    {
        cubeList = new List<cubeInfo>();
        //var Childs = GameObject.FindGameObjectsWithTag("board");
        //Boards = new Vector3[Childs.Length];
        //for (int i = 0; i < Childs.Length; i++)
        //{
        //    Boards[i] = Childs[i].transform.localPosition;
        //}
    }

    public void Add(cubeInfo cube)
    {
        if (cubeList.Count >= ContaierCount)
        {
            return;
        }
        int pos = ValidPos(cube);
        if (pos < ContaierCount)
        {
            if (pos < cubeList.Count)
            {
                MoveToRightPos(pos);
            }
            cube.Add(transform, Boards[pos]);
            cubeList.Insert(pos, cube);
            StartCoroutine(Match3(cube));
        }
    }

    public void TurnBack()
    {
        if (cubeList.Count > 0)
        {
            var cube = cubeList[cubeList.Count - 1];
            cube.TurnBack();
            cubeList.Remove(cube);
        }
    }


    public IEnumerator Match3(cubeInfo cube)
    {
        yield return new WaitForSeconds(.5f);
        int count = 0;
        for (int i = 0; i < cubeList.Count; i++)
        {
            if (cubeList[i].Type == cube.Type)
            {
                count++;
                if (count >= 3)
                {                    
                    for (int j = i; j > i - 3; j--)
                    {
                        cubeList[j].gameObject.SetActive(false);
                        cubeList.RemoveAt(j);
                    }
                    count = 0;
                    break;
                }
            }
        }
        for (int i = 0; i < cubeList.Count; i++)
        {
            cubeList[i].Add(transform,Boards[i]);
        }
    }

    public void MoveToRightPos(int start)
    {
        for (int i = cubeList.Count - 1; i >= start; i--)
        {
            cubeList[i].Add(transform, Boards[i + 1]);
        }
    }

    public int ValidPos(cubeInfo info)
    {
        int count = 0;
        int validPos = 0;
        for (int i = 0; i < cubeList.Count; i++)
        {
            if (cubeList[i].Type == info.Type)
            {
                validPos = i;
                count++;
            }
        }
        return count != 0 ? validPos + 1 : cubeList.Count;
    }
}
