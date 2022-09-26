using System;
using Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace QuestSystem
{
    // [CreateAssetMenu(fileName = "Quest", menuName = "SampleTest/Quest", order = 0)]
    public class Quest : ScriptableObject, ISavableData
    {
        public int order = int.MaxValue;

        [SerializeField]
        private bool isUnlockedAtFirst = false;

        public bool IsUnlocked { get; private set; }
        public bool IsCompleted { get; private set; }

        public string title;

        [TextArea] public string description;

        public Location location;

        public Objectives objectives;

        [SerializeField] private Rewards rewards;
        public Reward[] Rewards => rewards;


        public void Complete()
        {
            GetRewards();
            IsCompleted = true;
            this.Save();
        }

        private void GetRewards()
        {
            foreach (var reward in Rewards)
            {
                reward.GetReward();
            }
        }

        public void Unlock()
        {
            IsUnlocked = true;
            this.Save();
        }

        private void OnEnable()
        {
            IsUnlocked = isUnlockedAtFirst;
            IsCompleted = false;
        }

        string ISavableData.GetDatabaseKey()
        {
            return $"{name}:{order}";
        }

        void ISavableData.LoadFromDatabase(string data)
        {
            var obj = new { unlocked = false, completed = false };
            obj = JsonConvert.DeserializeAnonymousType(data, obj);

            if (obj != null)
            {
                IsUnlocked = obj.unlocked;
                IsCompleted = obj.completed;
            }
        }

        string ISavableData.ToDatabaseString()
        {
            var obj = new
            {
                unlocked = IsUnlocked,
                completed = IsCompleted
            };
            return JsonConvert.SerializeObject(obj);
        }
    }
}