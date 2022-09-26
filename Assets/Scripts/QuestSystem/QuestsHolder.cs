using System;
using Interfaces;
using UnityEngine;

namespace QuestSystem
{
    /// <summary>
    /// Used for better control over quests
    /// </summary>
    [CreateAssetMenu(fileName = "Quests Holder", menuName = "SampleTest/Quests Holder", order = 0)]
    public class QuestsHolder : ScriptableObject
    {
        public Quest[] quests = Array.Empty<Quest>();

        private void OnValidate()
        {
            for (int i = 0; i < quests.Length; i++)
            {
                quests[i].order = i;
            }
        }

        public void LoadAll()
        {
            foreach (var quest in quests) quest.Load();
        }
    }
}