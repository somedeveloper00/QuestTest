using System;

namespace QuestSystem
{
    [Serializable]
    public class KillZombieObjective : Objective
    {
        public int amount;

        public override void Start(Action onUpdate, Action onComplete)
        {
            throw new NotImplementedException();
        }

    }
}