using System;
using System.Linq;
using UnityEngine;

namespace QuestSystem
{
    public class State
    {
        public bool active = false;
        public Quest currentQuest;

        public Reward[] rewards => currentQuest.Rewards;
        public Objective[] objectives => currentQuest.objectives;
    }

    public class QuestManager : MonoBehaviour
    {
        public Context context;
        public QuestsHolder holder;
        public Quest[] AvailableQuests { get; private set; }

        public State CurrentState { get; private set; } = new State();

        public event Action OnQuestComplete;


        private void Start()
        {
            UpdateCurrentQuests();
        }

        public void StartQuest(Quest quest)
        {
            if (quest == null || !AvailableQuests.Contains(quest))
            {
                Debug.LogWarning($"Starting quest is not valid!");
                return;
            }

            CurrentState.currentQuest = quest;
            CurrentState.active = true;

            foreach (var objective in CurrentState.objectives)
            {
                objective.Start(context, null, CheckForCompletion);
            }

            void CheckForCompletion()
            {
                var objectives = CurrentState.objectives;
                var remaining = objectives.Count(obj => !obj.IsCompleted);
                
                Debug.Log($"{remaining}/{objectives.Length} objectives left.");
                if (remaining > 0)
                    return;
                CompleteCurrentQuest();
            }
        }

        private void UpdateCurrentQuests()
        {
            holder.LoadAll();
            AvailableQuests = holder.quests.Where(quest => !quest.IsCompleted && quest.IsUnlocked).ToArray();
            Debug.Log($"Available Quests: {string.Join(", ", AvailableQuests.Select(quest => quest.title))}");
        }

        public void CompleteCurrentQuest() => CompleteQuest(CurrentState.currentQuest);

        public void CompleteQuest(Quest quest)
        {
            if (quest == null || !AvailableQuests.Contains(quest))
            {
                Debug.LogWarning($"Completing quest was not valid");
                return;
            }

            Debug.Log($"Quest '{quest.title}' is completed!");

            quest.Complete();
            OnQuestComplete?.Invoke();
            UpdateCurrentQuests();
        }
    }
}