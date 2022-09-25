using System;

namespace QuestSystem
{
    [Serializable]
    public abstract class Objective
    {
        public abstract void Start(Context context, Action onUpdate, Action onComplete);
    }
}