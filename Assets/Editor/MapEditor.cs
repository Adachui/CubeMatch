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

    private int x = 3;
    private int y = 3;
    private int z = 3;


    private int[][][] cubes;
    private Vector2 LayoutScrollview;

    private void OnEnable()
    {
        cubes = new int[y][][];
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i] = new int[z][];
            for (int j = 0; j < cubes[i].Length; j++)
            {
                cubes[i][j] = new int[x];
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

        GUILayout.BeginVertical();
        {            
            x = EditorGUILayout.IntField(new GUIContent("x轴值:"),x, GUILayout.Width(180));         
            y = EditorGUILayout.IntField(new GUIContent("y轴值:"),y, GUILayout.Width(180));          
            z = EditorGUILayout.IntField(new GUIContent("z轴值:"),z, GUILayout.Width(180));
        }
        GUILayout.EndVertical();
        

        if (x <= 0 && y <= 0 && z <= 0)
        {
            return;
        }
        GUILayout.Space(5);
        ReInit();
        LayoutScrollview = GUILayout.BeginScrollView(LayoutScrollview, true, true, GUILayout.Width(position.width), GUILayout.Width(position.height));
        for (int i = 0; i < y; i++)
        {
            GUILayout.BeginVertical();
            GUILayout.Label(string.Format("第"+"{0}"+"层",i + 1));
            for (int j = 0; j < z; j++)
            {
                GUILayout.BeginHorizontal();
                for (int k = 0; k < x; k++)
                {
                    int value = cubes[i][j][k];
                    if (GUILayout.Button(value.ToString(),GUILayout.Width(30), GUILayout.Width(30)))
                    {
                        cubes[i][j][k] = (value == 0) ? 1 : 0;

                        EditorTool.CreaterGameObjectInSecen(Selection.activeGameObject.gameObject.transform, cubes);
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndScrollView();
        
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
        cubes = new int[y][][];
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i] = new int[z][];
            for (int j = 0; j < cubes[i].Length; j++)
            {
                cubes[i][j] = new int[x];
                for (int k = 0; k < cubes[i][j].Length; k++)
                {
                    cubes[i][j][k] = 1;
                }
            }
        }
    }

    private void OnSelectionChange()
    {
        this.Repaint();
    }

}
