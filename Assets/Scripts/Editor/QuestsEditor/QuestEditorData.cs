using QuestSystem;
using UnityEngine;

namespace Editor.QuestsEditor
{
    public class QuestEditorData
    {
        public static QuestsHolder[] questsHolders;

        private static int selectedQuestHolderIndex;

        public static int SelectedQuestHolderIndex
        {
            get
            {
                selectedQuestHolderIndex = Mathf.Clamp(selectedQuestHolderIndex, 0, questsHolders.Length);
                return selectedQuestHolderIndex;
            }
            set
            {
                value = Mathf.Clamp(value, 0, questsHolders.Length);
                selectedQuestHolderIndex = value;
            }
        }

        public static Quest[] quests => questsHolders?[SelectedQuestHolderIndex].quests;

        private static int selectedQuestIndex = 0;

        public static int SelectedQuestIndex
        {
            get => selectedQuestIndex;
            set
            {
                value = Mathf.Clamp(value, 0, quests?.Length ?? 0);
                selectedQuestIndex = value;
            }
        }
    }
}