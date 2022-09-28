using UnityEngine;
using UnityEditorInternal;
using UnityEditor;

public class GameSettingCreater : EditorWindow
{
    [MenuItem("Window/GameSettingWindow")]
    public static void CreaterWindow()
    {
        EditorWindow.GetWindow<GameSettingCreater>().Show();
    }
    private const int COUNT = 9;
    private Vector2 TitlescorllViewPosition;
    Texture texture;
    int hight;
    int height;
    int width;
    int totalKindCount;
    int kindsCount;
    Color mColor;
    public int[][][] cubeArr;
    private Vector2 mScrollView;

    private void OnEnable()
    {
        texture = AssetDatabase.LoadAssetAtPath<Texture>("");
    }

    private void OnGUI()
    {
        var style = new GUIStyle
        {
            fontSize = 20,
            fontStyle = FontStyle.Bold,
            normal = { textColor = Color.white }
        };
        EditorGUILayout.BeginVertical(GUILayout.Width(500));

        height = EditorGUILayout.IntField(new GUIContent("深", "长度的范围应该限制在2～7"), height, GUILayout.Width(200));
        width = EditorGUILayout.IntField(new GUIContent("宽", "宽度的范围应该限制在2～7"), width, GUILayout.Width(200));
        hight = EditorGUILayout.IntField(new GUIContent("高", "高度的范围应该限制在2～7"), hight, GUILayout.Width(200));
        totalKindCount = height * width * hight;        
        kindsCount = totalKindCount / COUNT;
  
        
        GUI.enabled = (height > 0 && width > 0 && hight > 0);
        if (!GUI.enabled)
        {            
            cubeArr = null;
            totalKindCount = 0;
        }
        GUILayout.Space(5);

        if (GUILayout.Button(new GUIContent("Creater"), GUILayout.Width(100), GUILayout.Height(50)))
        {
            BeginCreater();
        }
        EditorGUILayout.EndVertical();


        mColor = EditorGUILayout.ColorField("Block Color", mColor, GUILayout.Width(400));
        EditorGUIUtility.labelWidth = 90;
        GUI.color = mColor;
        GUILayout.BeginHorizontal();
        for (int i = 0; i < kindsCount; i++)
        {            
            if (GUILayout.Button("", GUILayout.Width(30), GUILayout.Height(30)))
            {
       
            }
        }        
        GUILayout.EndHorizontal();
        GUI.color = Color.white;

        GUILayout.Space(10);
        mScrollView = GUILayout.BeginScrollView(mScrollView, GUILayout.Width(width), GUILayout.Height(position.y - 40));
        if (cubeArr != null) 
        {
            for (int i = 0; i < hight; i++)
            {
                GUILayout.BeginVertical();
                GUILayout.Space(20);
                GUILayout.TextField($"第{0}层", i);
                for (int j = 0; j < height; j++)
                {
                    GUILayout.BeginHorizontal();
                    for (int k = 0; k < width; k++)
                    {
                         var value = cubeArr[i][j][k];
                        if (GUILayout.Button(value.ToString(), GUILayout.Width(30), GUILayout.Height(30)))
                        {
                            cubeArr[i][j][k] = cubeArr[i][j][k] == 0 ? 1 : 0;
                        }
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndVertical();
            }
        }
        GUILayout.EndScrollView();
    }

    

    private void BeginCreater()
    {
        cubeArr = new int[hight][][];
        for (int i = 0; i < cubeArr.Length; i++)
        {
            cubeArr[i] = new int[height][];
            for (int j = 0; j < cubeArr[i].Length; j++)
            {
                cubeArr[i][j] = new int[width];
                for (int k = 0; k < cubeArr[i][j].Length; k++)
                {
                    cubeArr[i][j][k] = 0;
                }
            }
        }
    }
}
