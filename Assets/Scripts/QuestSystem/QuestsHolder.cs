using UnityEngine;

namespace QuestSystem
{
    /// <summary>
    /// Used for better control over quests
    /// </summary>
    [CreateAssetMenu(fileName = "Quests Holder", menuName = "SampleTest/Quests Holder", order = 0)]
    public class QuestsHolder : ScriptableObject
    {
        public Quest[] quests;
    }
}