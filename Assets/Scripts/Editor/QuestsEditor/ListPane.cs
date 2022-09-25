using System.Linq;
using Editor.Utils;
using QuestSystem;
using UnityEditor;
using UnityEngine;

namespace Editor.QuestsEditor
{
    public class ListPane
    {
        private QuestEditorWindow _window;
        private Vector2 listPos;

        public ListPane(QuestEditorWindow window)
        {
            _window = window;
        }


        public void Draw()
        {
            using (new GUILayout.VerticalScope(EditorStyles.helpBox, GUILayout.ExpandWidth(true)))
            {
                DrawQuestsList();
                GUILayout.FlexibleSpace();
                DrawBottomButtons();
            }
        }

        private void DrawBottomButtons()
        {
            using (new GUILayout.HorizontalScope())
            {
                using (new EditorGUI.DisabledScope(QuestEditorData.quests == null ||
                                                   QuestEditorData.SelectedQuestIndex <= 0))
                {
                    if (GUILayout.Button("move Up")) MoveSelectedQuestUp();
                }

                using (new EditorGUI.DisabledScope(QuestEditorData.quests == null ||
                                                   QuestEditorData.SelectedQuestIndex >=
                                                   QuestEditorData.quests.Length - 1))
                {
                    if (GUILayout.Button("move Down")) MoveSelectedQuestDown();
                }
            }

            using (new EditorGUI.DisabledScope(QuestEditorData.quests == null))
            {
                if (GUILayout.Button("New Quest")) CreateNewQuest();


                using (new EditorGUI.DisabledScope(QuestEditorData.quests?.Length == 0))
                {
                    if (GUILayout.Button("Remove Selected Quest")) DeleteSelectedQuest();
                    if (GUILayout.Button("Update File names")) UpdateFileNames(); 
                }
            }
        }

        private static void MoveSelectedQuestUp()
        {
            QuestEditorData.quests[QuestEditorData.SelectedQuestIndex].order--;
            QuestEditorData.quests[QuestEditorData.SelectedQuestIndex - 1].order++;
            QuestEditorData.SelectedQuestIndex--;
            QuestEditorWindow.RefreshData();
        }

        private static void MoveSelectedQuestDown()
        {
            QuestEditorData.quests[QuestEditorData.SelectedQuestIndex].order++;
            QuestEditorData.quests[QuestEditorData.SelectedQuestIndex + 1].order--;
            QuestEditorData.SelectedQuestIndex++;
            QuestEditorWindow.RefreshData();
        }

        private static void UpdateFileNames()
        {
            AssetDatabase.SaveAssets();

            // set file names
            var assetRenamed = false;
            foreach (var quest in QuestEditorData.quests)
                if (quest.name != quest.title)
                {
                    AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(quest), quest.title + ".asset");
                    assetRenamed = true;
                }

            if (assetRenamed)
                AssetDatabase.Refresh();
            QuestEditorWindow.RefreshData();
        }

        private static void CreateNewQuest()
        {
            // save holder
            var questsHolder = QuestEditorData.questsHolders[QuestEditorData.SelectedQuestHolderIndex];
            AssetDatabase.SaveAssetIfDirty(questsHolder);

            // new quest
            var quest = ScriptableObject.CreateInstance<Quest>();
            quest.order = questsHolder.quests.Length;
            quest.name = $"Quest{quest.order}";
            AssetDatabase.AddObjectToAsset(quest, questsHolder);
            AssetDatabase.SaveAssetIfDirty(questsHolder);

            // add new quest to holder
            var list = questsHolder.quests.ToList();
            list.Add(quest);
            questsHolder.quests = list.ToArray();

            AssetDatabase.Refresh();
            QuestEditorWindow.RefreshData();
        }

        private static void DeleteSelectedQuest()
        {
            var questsHolder = QuestEditorData.questsHolders[QuestEditorData.SelectedQuestHolderIndex];
            var quest = QuestEditorData.quests?[QuestEditorData.SelectedQuestIndex];
            
            Object.DestroyImmediate(quest, true);
            AssetDatabase.SaveAssetIfDirty(questsHolder);

            AssetDatabase.Refresh();
            QuestEditorWindow.RefreshData();
        }

        private void DrawQuestsList()
        {
            var buttonStyle =
                DynamicStyles.LeftAlignedOf(
                    DynamicStyles.WordWrapOf(
                        DynamicStyles.RichTextOf(GUI.skin.button)));

            QuestEditorData.SelectedQuestHolderIndex =
                EditorGUILayout.Popup(
                    QuestEditorData.SelectedQuestHolderIndex,
                    QuestEditorData.questsHolders.Select(qh => qh.name).ToArray()
                );

            GUILayout.Space(2);

            if (QuestEditorData.quests != null)
                using (var scroll = new GUILayout.ScrollViewScope(listPos))
                {
                    var quests = QuestEditorData.quests;
                    for (var i = 0; i < quests.Length; i++)
                    {
                        var backgroundCol = Color.white;
                        if (QuestEditorData.SelectedQuestIndex == i)
                            backgroundCol = GUI.skin.settings.selectionColor;
                        using (new GuiUtils.GuiBackgroundColor(backgroundCol))
                        {
                            var shortDesc = quests[i].description;
                            if (shortDesc?.Length > 50) shortDesc = shortDesc.Substring(0, 47) + "...";

                            var label = $"{quests[i].order}: <b>{quests[i].title}</b>\n    <i>({shortDesc})</i>";

                            if (GUILayout.Button(label, buttonStyle)) QuestEditorData.SelectedQuestIndex = i;
                        }
                    }

                    listPos = scroll.scrollPosition;
                }
        }
    }
}