using QuestSystem;
using UnityEditor;

namespace Editor.QuestsEditor
{
    [CustomEditor(typeof(Quest))]
    public class QuestEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var isUnlockedAtFirstProp = serializedObject.FindProperty(nameof(Quest.isUnlockedAtFirst));
            var locationProp = serializedObject.FindProperty(nameof(Quest.location));
            var titleProp = serializedObject.FindProperty(nameof(Quest.title));
            var descriptionProp = serializedObject.FindProperty(nameof(Quest.description));
            var objectivesProp = serializedObject.FindProperty(nameof(Quest.objectives));
            var rewardsProp = serializedObject.FindProperty(nameof(Quest.rewards));
            
            
            serializedObject.Update();

            EditorGUILayout.PropertyField(isUnlockedAtFirstProp);
            EditorGUILayout.PropertyField(locationProp);
            EditorGUILayout.PropertyField(titleProp);
            EditorGUILayout.PropertyField(descriptionProp);
            EditorGUILayout.PropertyField(objectivesProp);
            EditorGUILayout.PropertyField(rewardsProp);

            serializedObject.ApplyModifiedProperties();
        }
    }
}