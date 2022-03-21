using System; 
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GradientShaderGUI : ShaderGUI 
{
    private Gradient gradient;
    private Gradient Gradient {
        get
        {
            if (gradient == null)
                gradient = new Gradient();
            return gradient;
        }
        set
        {
            gradient = value;
        }
    }
     
    
    public override void OnGUI (MaterialEditor materialEditor, MaterialProperty[] properties)
    {
        EditorGUILayout.Space(15);
        
        Gradient = EditorGUILayout.GradientField("Gradient", Gradient);

        EditorGUILayout.Space(10);
        
        if(GUILayout.Button("Save")) {

            string path = EditorUtility.SaveFilePanel("Save png", Application.dataPath + "/Game/GradientPalletes", "gradient", "png");

            if(path.Length > 0) {
                var tex = Create(gradient, 256, 1);
                byte[] pngData = tex.EncodeToPNG();
                File.WriteAllBytes(path, pngData);
                AssetDatabase.Refresh();
            }
        }

        EditorGUILayout.Space(20);
        
        base.OnGUI (materialEditor, properties);
    }

     private Texture2D Create (Gradient grad, int width = 32, int height = 1) 
     {
        var gradTex = new Texture2D(width, height, TextureFormat.ARGB32, false);
        gradTex.filterMode = FilterMode.Bilinear;
        float inv = 1f / (width - 1);
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                var t = x * inv;
                Color col = grad.Evaluate(t);
                gradTex.SetPixel(x, y, col);
            }
        }
        gradTex.Apply();
        return gradTex;
    }

}