using System;

namespace QuestSystem
{
    [Serializable]
    public abstract class Objective
    {
        public abstract void Start(Action onUpdate, Action onComplete);
    }
}