using Interfaces;
using UnityEngine;

namespace QuestSystem
{
    // [CreateAssetMenu(fileName = "Quest", menuName = "SampleTest/Quest", order = 0)]
    public class Quest : ScriptableObject, ISavableData<bool>
    {
        public int order = int.MaxValue;

        public bool isUnlockedAtFirst = false;

        public string title;

        [TextArea] public string description;

        public Location location;

        public Objectives objectives;

        public Rewards rewards;

        private void OnEnable()
        {
            if (Application.isPlaying)
            {
                Database.Database.LoadData(this);
            }
        }

        public string GetDatabaseKey()
        {
            return $"{name}:{title}";
        }

        public bool ParseDatabaseString(string data)
        {
            return bool.Parse(data);
        }

        public string ToDatabaseString()
        {
            return isUnlockedAtFirst.ToString();
        }
    }
}