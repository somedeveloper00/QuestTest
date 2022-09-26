using UnityEditor;
using UnityEngine;

namespace Editor.QuestsEditor
{
    public class SelectedQuestInfoPane
    {
        private QuestEditorWindow _window;
        
        private Vector2 questPos = new Vector2();
        private UnityEditor.Editor currentEditor;
        private int currentQuestDrawingindex = -1;
        private int currentHolderDrawingindex = -1;
        
        public SelectedQuestInfoPane(QuestEditorWindow window)
        {
            _window = window;
        }



        public void Draw()
        {
            
            using (var scroll = new GUILayout.ScrollViewScope(questPos))
            {
                using (new GUILayout.VerticalScope(EditorStyles.helpBox, 
                           GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true)))
                {
                    // null checks
                    if(QuestEditorData.quests == null || QuestEditorData.quests?.Length <= QuestEditorData.SelectedQuestIndex)
                        return;
                    
                    if (EditorNeedsReInit())
                    {
                        UnityEditor.Editor.CreateCachedEditor(
                            QuestEditorData.quests[QuestEditorData.SelectedQuestIndex], null, ref currentEditor);
                        currentQuestDrawingindex = QuestEditorData.SelectedQuestIndex;
                    }

                    currentEditor.OnInspectorGUI();
                }
                
                questPos = scroll.scrollPosition;
            }
        }

        private bool EditorNeedsReInit()
        {
            return currentEditor == null || 
                   QuestEditorData.SelectedQuestIndex != currentQuestDrawingindex ||
                   QuestEditorData.SelectedQuestHolderIndex != currentHolderDrawingindex;
        }
    }
}