using System;

namespace QuestSystem
{
    [Serializable]
    public class KillZombieObjective : Objective
    {
        public override string DisplayTitle => "Kill Zombies";

        public override void Start(Action onComplete)
        {
            throw new NotImplementedException();
        }
    }
}