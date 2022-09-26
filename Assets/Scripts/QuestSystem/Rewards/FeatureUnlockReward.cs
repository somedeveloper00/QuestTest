using System;
using UnityEngine;

namespace QuestSystem
{
    [Serializable]
    public class FeatureUnlockReward : Reward
    {
        public string FeatureName;
        public override string DisplayName => "Feature Unlock";
        public override void GetReward()
        {
            Debug.Log($"Got New Feature: {FeatureName}");
        }

    }
}