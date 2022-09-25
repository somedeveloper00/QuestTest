using QuestSystem;
using UnityEditor;
using UnityEngine;

namespace Editor.QuestsEditor
{
    [CustomPropertyDrawer(typeof(Objectives))]
    public class ObjectivesDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var CollectObjectivesProp = property.FindPropertyRelative(nameof(Objectives.CollectObjectives));
            var KillZombieObjectivesProp = property.FindPropertyRelative(nameof(Objectives.KillZombieObjectives));
            var DefendAPositionObjectivesProp =
                property.FindPropertyRelative(nameof(Objectives.DefendAPositionObjectives));

            using (new EditorGUI.PropertyScope(position, label, property))
            {
                position.height = EditorGUIUtility.singleLineHeight;
                property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label, toggleOnLabelClick: true);
                position.y += position.height + EditorGUIUtility.standardVerticalSpacing;

                if (property.isExpanded)
                {
                    EditorGUI.indentLevel++;
                    DrawList(CollectObjectivesProp, ref position);
                    DrawList(KillZombieObjectivesProp, ref position);
                    DrawList(DefendAPositionObjectivesProp, ref position);
                    EditorGUI.indentLevel--;
                }
            }
        }


        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var CollectObjectivesProp = property.FindPropertyRelative(nameof(Objectives.CollectObjectives));
            var KillZombieObjectivesProp = property.FindPropertyRelative(nameof(Objectives.KillZombieObjectives));
            var DefendAPositionObjectivesProp =
                property.FindPropertyRelative(nameof(Objectives.DefendAPositionObjectives));

            // foldout
            float height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            if (property.isExpanded)
            {
                // lists
                height += GetHeight(CollectObjectivesProp);
                height += GetHeight(KillZombieObjectivesProp);
                height += GetHeight(DefendAPositionObjectivesProp);
            }

            return height;
        }

        public static void DrawList(SerializedProperty listProp, ref Rect position)
        {
            bool has = listProp.arraySize > 0;
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                has = EditorGUI.Toggle(position,
                    new GUIContent(listProp.displayName, listProp.tooltip), has);
                if (check.changed)
                    listProp.arraySize = has ? 1 : 0;
            }

            position.y += position.height + EditorGUIUtility.standardVerticalSpacing;

            if (has)
            {
                EditorGUI.PropertyField(position, listProp);
                position.y += EditorGUI.GetPropertyHeight(listProp) + EditorGUIUtility.standardVerticalSpacing;
            }
        }

        public static float GetHeight(SerializedProperty listProp)
        {
            float r = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            if (listProp.arraySize > 0)
                r += EditorGUI.GetPropertyHeight(listProp) + EditorGUIUtility.standardVerticalSpacing;
            return r;
        }
    }

    [CustomPropertyDrawer(typeof(Rewards))]
    public class RewardsDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var CoinRewardsProp = property.FindPropertyRelative(nameof(Rewards.CoinRewards));
            var FeatureUnlockRewardsProp = property.FindPropertyRelative(nameof(Rewards.FeatureUnlockRewards));
            var MaterialRewardsProp = property.FindPropertyRelative(nameof(Rewards.MaterialRewards));
            var MissionUnlockRewardsProp = property.FindPropertyRelative(nameof(Rewards.MissionUnlockRewards));

            using (new EditorGUI.PropertyScope(position, label, property))
            {
                position.height = EditorGUIUtility.singleLineHeight;
                property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label, toggleOnLabelClick: true);
                position.y += position.height + EditorGUIUtility.standardVerticalSpacing;

                if (property.isExpanded)
                {
                    EditorGUI.indentLevel++;
                    ObjectivesDrawer.DrawList(CoinRewardsProp, ref position);
                    ObjectivesDrawer.DrawList(FeatureUnlockRewardsProp, ref position);
                    ObjectivesDrawer.DrawList(MaterialRewardsProp, ref position);
                    ObjectivesDrawer.DrawList(MissionUnlockRewardsProp, ref position);
                    EditorGUI.indentLevel--;
                }
            }
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var CoinRewardsProp = property.FindPropertyRelative(nameof(Rewards.CoinRewards));
            var FeatureUnlockRewardsProp = property.FindPropertyRelative(nameof(Rewards.FeatureUnlockRewards));
            var MaterialRewardsProp = property.FindPropertyRelative(nameof(Rewards.MaterialRewards));
            var MissionUnlockRewardsProp = property.FindPropertyRelative(nameof(Rewards.MissionUnlockRewards));

            // foldout
            float height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            if (property.isExpanded)
            {
                // lists
                height += ObjectivesDrawer.GetHeight(CoinRewardsProp);
                height += ObjectivesDrawer.GetHeight(FeatureUnlockRewardsProp);
                height += ObjectivesDrawer.GetHeight(MaterialRewardsProp);
                height += ObjectivesDrawer.GetHeight(MissionUnlockRewardsProp);
            }

            return height;
        }

    }
}