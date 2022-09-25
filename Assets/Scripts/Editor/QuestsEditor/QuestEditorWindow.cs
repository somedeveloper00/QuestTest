using System;
using System.Linq;
using QuestSystem;
using UnityEditor;
using UnityEngine;

namespace Editor.QuestsEditor
{
    public class QuestEditorWindow : EditorWindow
    {
        [MenuItem("SampleTest/Quest Editor")]
        private static void ShowWindow()
        {
            var window = GetWindow<QuestEditorWindow>();
            window.titleContent = new GUIContent("Quest Editor");

            window.Init();
            window.Show();
        }

        private void Init()
        {
            listPane = new ListPane(this);
            selectedQuestInfoPane = new SelectedQuestInfoPane(this);
        }

        public ListPane listPane;
        public SelectedQuestInfoPane selectedQuestInfoPane;

        private float lastValidate = -100;

        private void OnGUI()
        {
            if (listPane == null || selectedQuestInfoPane == null)
                Init();

            if (EditorApplication.timeSinceStartup - lastValidate > 1)
            {
                if (QuestEditorData.quests == null || QuestEditorData.quests.Any(quest => quest == null))
                    RefreshData();
                lastValidate = (float)EditorApplication.timeSinceStartup;
            }

            using (new GUILayout.HorizontalScope())
            {
                using (new GUILayout.VerticalScope(GUILayout.MaxWidth(200)))
                    listPane.Draw();
                using (new GUILayout.VerticalScope(GUILayout.ExpandWidth(true)))
                    selectedQuestInfoPane.Draw();
            }
        }

        public static void RefreshData()
        {
            // load all quests
            QuestEditorData.questsHolders =
                AssetDatabase.FindAssets($"t:{nameof(QuestsHolder)}")
                    .Select(guid => AssetDatabase.LoadAssetAtPath<QuestsHolder>(AssetDatabase.GUIDToAssetPath(guid)))
                    .ToArray();

            // validate quests
            foreach (var questsHolder in QuestEditorData.questsHolders)
            {
                for (int i = 0; i < questsHolder.quests?.Length; i++)
                {
                    if (questsHolder.quests[i] == null)
                    {
                        // remove element
                        var tmp = questsHolder.quests.ToList();
                        tmp.RemoveAt(i);
                        questsHolder.quests = tmp.ToArray();
                        i--;
                        continue;
                    }
                    questsHolder.quests[i].order = i;
                }
            }
        }
    }
}