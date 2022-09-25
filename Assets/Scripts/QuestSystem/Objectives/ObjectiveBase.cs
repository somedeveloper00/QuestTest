using System;

namespace QuestSystem
{
    [Serializable]
    public abstract class Objective
    {
        public abstract string DisplayTitle { get; }
        public abstract void Start(Action onComplete);
    }
}