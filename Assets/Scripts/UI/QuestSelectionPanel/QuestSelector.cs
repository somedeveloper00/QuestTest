using System;
using System.Linq;
using QuestSystem;
using UnityEngine;

namespace UI.QuestSelectionPanel
{
    public class QuestSelector : MonoBehaviour
    {
        public Quest[] quests { get; private set; }

        public Context context;
        public QuestElement questElementSample;
        public Transform questListParent;

        public DetailsPane detailsPane;

        private QuestElement[] questElements { get; set; }

        public event Action onQuestStart;

        public void Init(Context context)
        {
            this.context = context;
            quests = context.questManager.AvailableQuests;
            PopulateQuestList();
        }

        private void PopulateQuestList()
        {
            questElements = new QuestElement[quests.Length];
            for (var i = 0; i < quests.Length; i++)
            {
                questElements[i] = Instantiate(questElementSample, questListParent);
                questElements[i].Init(quests[i], this);
            }
        }

        public void Select(QuestElement element)
        {
            if (element == null || !questElements.Contains(element))
            {
                Debug.LogWarning($"Selecting quest element is not valid!");
                return;
            }

            detailsPane.Show(element.quest);
            foreach (var q in questElements)
            {
                if(ReferenceEquals(q, element)) continue;
                q.UnSelect();
            }
        }

        public void Go(Quest quest)
        {
            context.questManager.StartQuest(quest);
            Destroy(gameObject);
            onQuestStart?.Invoke();
        }
    }
}