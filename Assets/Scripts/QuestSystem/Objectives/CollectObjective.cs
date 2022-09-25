using System;

namespace QuestSystem
{
    [Serializable]
    public class CollectObjective : Objective
    {
        public override string DisplayTitle => "Collect Objects";

        public override void Start(Action onComplete)
        {
            throw new NotImplementedException();
        }
    }
}