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
        public QuestsHolder holder;
        public Quest[] AvailableQuests { get; private set; }

        public State CurrentState { get; private set; } = new State();


        private void Start()
        {
            DontDestroyOnLoad(this);
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
        }
        
        private void UpdateCurrentQuests()
        {
            holder.SyncAll();
            AvailableQuests = holder.quests.Where(quest => !quest.IsCompleted && quest.IsUnlocked).ToArray();
            Debug.Log($"Available Quests: {string.Join(", ", AvailableQuests.Select(quest=>quest.title))}");
        }

        public void CompleteCurrentQuest() => CompleteQuest(CurrentState.currentQuest);
        public void CompleteQuest(Quest quest)
        {
            if (quest == null || !AvailableQuests.Contains(quest))
            {
                Debug.LogWarning($"Completing quest was not valid");
                return;
            }
            
            quest.Complete();
            UpdateCurrentQuests();
        }
    }
}