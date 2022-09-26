using System;

namespace QuestSystem
{
    [Serializable]
    public class DefendAPositionObjective : Objective
    {
        protected override void OnStart()
        {
            SampleFlow.OnDefendPlace += OnDefend;
        }

        private void OnDefend()
        {
            Update();
            Complete();
            SampleFlow.OnDefendPlace -= OnDefend;
        }
    }
}