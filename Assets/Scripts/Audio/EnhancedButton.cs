using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UI;
#endif

public class EnhancedButton : Button
{
    [SerializeField] AudioUIButtons.ButtonClick audioType;

    protected override void Awake()
    {
        base.Awake();

        onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        AudioManager.Instance.PlayButtonAudio(audioType);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(EnhancedButton))]
public class EnhancedButtonEditor : ButtonEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("audioType"));
        serializedObject.ApplyModifiedProperties();
    }
}
#endif