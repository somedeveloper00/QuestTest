using QuestSystem;
using UnityEngine;

namespace Editor.QuestsEditor
{
    public class QuestEditorData
    {
        public static QuestsHolder[] questsHolders;

        public static QuestsHolder SelectedQuestHolder => questsHolders?[SelectedQuestHolderIndex];

        private static int selectedQuestHolderIndex;

        public static int SelectedQuestHolderIndex
        {
            get
            {
                selectedQuestHolderIndex = Mathf.Clamp(selectedQuestHolderIndex, 0, questsHolders.Length - 1);
                return selectedQuestHolderIndex;
            }
            set
            {
                value = Mathf.Clamp(value, 0, questsHolders.Length);
                selectedQuestHolderIndex = value;
            }
        }

        public static Quest[] quests => SelectedQuestHolder?.quests;

        private static int selectedQuestIndex = 0;

        public static int SelectedQuestIndex
        {
            get => selectedQuestIndex;
            set
            {
                value = Mathf.Clamp(value, 0, quests?.Length - 1 ?? 0);
                selectedQuestIndex = value;
            }
        }
    }
}