using System;

namespace QuestSystem
{
    [Serializable]
    public class CollectObjective : Objective
    {
        public string collectible;
        public int amount;

        public override void Start(Action onUpdate, Action onComplete)
        {
            throw new NotImplementedException();
        }
    }
}