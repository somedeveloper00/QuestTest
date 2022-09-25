using System;

namespace QuestSystem
{
    [Serializable]
    public abstract class Reward
    {
        public abstract string DisplayName { get; }
    }
}