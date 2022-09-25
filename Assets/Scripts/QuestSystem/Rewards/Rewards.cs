using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    /// <summary>
    /// An Editor-friendly list of rewards
    /// </summary>
    [Serializable]
    public class Rewards
    {
        [SerializeField] private CoinReward[] CoinRewards;
        [SerializeField] private FeatureUnlockReward[] FeatureUnlockRewards;
        [SerializeField] private MaterialReward[] MaterialRewards;
        [SerializeField] private QuestUnlockReward[] MissionUnlockRewards;

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