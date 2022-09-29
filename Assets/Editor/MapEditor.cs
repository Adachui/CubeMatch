using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapEditor : EditorWindow
{
    [MenuItem("Window/MapEditor")]
    public static void Open()
    {
        EditorWindow window = GetWindow<MapEditor>();
        window.titleContent = new GUIContent("Editor Map");
        window.Show();
    }


    private string Writepath = "/Resources/Data/";
    private string rootName;
    private string MapName = "level";
    private string levelNum = "1";

    private int _x;
    private int _y;
    private int _z;

    public int xvalue
    {
        get => _x;
        set
        {            
            if (_x != value)
            {
                _x = value;
            }
        }
    }
    public int yvalue
    {
        get => _y;
        set
        {
            if (_y != value)
            {
                _y = value;
            }
        }
    }
    public int zvalue
    {
        get => _z;
        set
        {
            if (_z != value)
            {
                _z = value;
            }
        }
    }


    private int[][][] cubes;
    private Vector2 LayoutScrollview;
    private bool refresh = false;
    private List<GameObject> list;

    private void OnEnable()
    {
        list = new List<GameObject>();
        cubes = new int[yvalue][][];
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i] = new int[zvalue][];
            for (int j = 0; j < cubes[i].Length; j++)
            {
                cubes[i][j] = new int[xvalue];
                for (int k = 0; k < cubes[i][j].Length; k++)
                {
                    cubes[i][j][k] = 1;
                }
            }
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("选择地图节点");
        
        if (Selection.activeGameObject)
        {
            GUILayout.Label(Selection.activeGameObject.name);
        }else
        {
            GUILayout.TextField("没有选择无法生成");            
            return;
        }

        GUILayout.Label("\n输出路径");
        GUILayout.TextField(Writepath);

        GUILayout.Label("地图前缀");
        MapName = GUILayout.TextField(MapName);
        GUILayout.Label("关卡1～n");
        levelNum = GUILayout.TextField(levelNum);
        GUILayout.Space(5);
        string filename = Application.dataPath + Writepath + MapName + levelNum + ".csv";

        GUILayout.BeginHorizontal();
        {
            GUILayout.BeginVertical();
            {
                xvalue = EditorGUILayout.IntField(new GUIContent("x轴值:"), xvalue, GUILayout.Width(180));
                yvalue = EditorGUILayout.IntField(new GUIContent("y轴值:"), yvalue, GUILayout.Width(180));
                zvalue = EditorGUILayout.IntField(new GUIContent("z轴值:"), zvalue, GUILayout.Width(180));
            }
            GUILayout.EndVertical();
            if (GUILayout.Button("Create", GUILayout.Width(100), GUILayout.Height(70))) 
            {
                ReInit();
            }

        }
        GUILayout.EndHorizontal();



        if (xvalue <= 0 && yvalue <= 0 && zvalue <= 0)
        {
            return;
        }
        GUILayout.Space(5);
        float scorllHight = cubes.Length * 90.0f;
        LayoutScrollview = GUILayout.BeginScrollView(LayoutScrollview, true, true, GUILayout.Width(position.width), GUILayout.Height(scorllHight));
        for (int y = 0; y < yvalue; y++)
        {
            GUILayout.BeginVertical();
            GUILayout.Label(string.Format("第"+"{0}"+"层",y + 1));
            for (int x = 0; x < xvalue; x++)
            {
                GUILayout.BeginHorizontal();
                for (int z = 0; z < zvalue ; z++)
                {
                    int value = cubes[y][x][z];
                    if (GUILayout.Button(value.ToString(),GUILayout.Width(30), GUILayout.Width(30)))
                    {
                        cubes[y][x][z] = (value == 0) ? 1 : 0;
                        refresh = true;
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndScrollView();

        if (refresh)
        {
            refresh = false;
            //EditorTool.CreaterGameObjectInSecen(Selection.activeGameObject.gameObject.transform, cubes);
        }

        if (GUILayout.Button("保存"))
        {
            EditorTool.WriterFile(filename, Selection.activeGameObject);
        }
        if (GUILayout.Button("清除"))
        {

        }        

    }

    private void ReInit()
    {
        if (list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                //Editor.Destroy(list[i]);
            }
        }

        cubes = new int[yvalue][][];

        for (int y = 0; y < yvalue; y++)
        {
            cubes[y] = new int[xvalue][];
            for (int x = 0; x < xvalue; x++)
            {
                cubes[y][x] = new int[zvalue];
                for (int z = 0; z < zvalue; z++)
                {
                     cubes[y][x][z] = 1;
                    GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    list.Add(obj);
                    obj.transform.SetParent(Selection.activeGameObject.transform);
                    obj.transform.localPosition = new Vector3((x - xvalue * .5f) + x * 0.07f, (y - yvalue * .5f) + y * 0.07f, (z - zvalue * .5f) + z * 0.07f) + new Vector3(.5f, .5f, .5f);
                }
            }
        }
    }

    private void ShowCubes()
    {
        for (int y = 0; y < xvalue; y++)
        {
            for (int z = 0; z < zvalue; z++)
            {
                for (int x = 0; x < xvalue; x++)
                {
                    if (cubes[y][x][z] == 1)
                    {

                    }
                }
            }
        }
    }
         

    private void OnSelectionChange()
    {
        this.Repaint();
    }

}
