using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UI;
#endif

public class EnhancedButton : Button
{
    [SerializeField] AudioUIButtons.ButtonClick audioType;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        PlaySound();
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        base.OnSubmit(eventData);

        PlaySound();
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