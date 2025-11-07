using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class SceneField
{
    [SerializeField]
    private Object _sceneAsset;
    [SerializeField]
    private string _sceneName = "";

    public string SceneName
    {
        get { return _sceneName; }
    }

    // 使它可以与现有的 Unity 方法（如 LoadLevel/LoadScene）一起工作
    public static implicit operator string(SceneField sceneField)
    {
        return sceneField.SceneName;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SceneField))]
public class SceneFieldPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        EditorGUI.BeginProperty(_position, GUIContent.none, _property);

        SerializedProperty sceneAsset = _property.FindPropertyRelative("_sceneAsset");
        SerializedProperty sceneName = _property.FindPropertyRelative("_sceneName");

        _position = EditorGUI.PrefixLabel(_position, GUIUtility.GetControlID(FocusType.Passive), _label);

        if (sceneAsset != null)
        {
            EditorGUI.ObjectField(_position, sceneAsset, typeof(SceneAsset), GUIContent.none);

            if (sceneAsset.objectReferenceValue != null)
            {
                sceneName.stringValue = (sceneAsset.objectReferenceValue as SceneAsset).name;
            }
        }

        EditorGUI.EndProperty();
    }
}
#endif