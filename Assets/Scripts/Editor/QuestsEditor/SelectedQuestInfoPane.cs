using UnityEditor;
using UnityEngine;

namespace Editor.QuestsEditor
{
    public class SelectedQuestInfoPane
    {
        private QuestEditorWindow _window;
        
        private Vector2 questPos = new Vector2();
        private UnityEditor.Editor currentEditor;
        private int currentDrawingindex = -1;
        
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
                    
                    if (currentEditor == null || QuestEditorData.SelectedQuestIndex != currentDrawingindex)
                    {
                        UnityEditor.Editor.CreateCachedEditor(
                            QuestEditorData.quests[QuestEditorData.SelectedQuestIndex], null, ref currentEditor);
                        currentDrawingindex = QuestEditorData.SelectedQuestIndex;
                    }

                    currentEditor.OnInspectorGUI();
                }
                
                questPos = scroll.scrollPosition;
            }
        }
    }
}