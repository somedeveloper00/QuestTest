using System;

namespace QuestSystem
{
    [Serializable]
    public class DefendAPositionObjective : Objective
    {
        public override string DisplayTitle => "Defend A Position";

        public override void Start(Action onComplete)
        {
            throw new NotImplementedException();
        }
    }
}