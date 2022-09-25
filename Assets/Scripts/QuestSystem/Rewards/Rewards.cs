using System;
using System.Collections.Generic;

namespace QuestSystem
{
    /// <summary>
    ///     An Editor-friendly list of rewards
    /// </summary>
    [Serializable]
    public class Rewards
    {
        public CoinReward[] CoinRewards;
        public FeatureUnlockReward[] FeatureUnlockRewards;
        public MaterialReward[] MaterialRewards;
        public QuestUnlockReward[] MissionUnlockRewards;

        public static implicit operator Reward[](Rewards rewards)
        {
            var r = new List<Reward>();
            r.AddRange(rewards.CoinRewards);
            r.AddRange(rewards.FeatureUnlockRewards);
            r.AddRange(rewards.MaterialRewards);
            r.AddRange(rewards.MissionUnlockRewards);
            return r.ToArray();
        }
    }
}