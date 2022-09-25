using System;

namespace QuestSystem
{
    [Serializable]
    public class QuestUnlockReward : Reward
    {
        public Quest unlockingQuest;
        public override string DisplayName => "Mession Unlock";
    }
}