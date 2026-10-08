using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeatherPresetResolver))]
public class WeatherPresetResolverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();

        var resolver = (WeatherPresetResolver)target;

        using (new EditorGUI.DisabledScope(resolver.CurrentPreset == null))
        {
            if (GUILayout.Button("Apply"))
            {
                resolver.ApplyWeather();
                EditorUtility.SetDirty(resolver);
            }
        }
    }
}