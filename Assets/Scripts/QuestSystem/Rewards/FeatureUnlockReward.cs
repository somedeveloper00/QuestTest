using System;

namespace QuestSystem
{
    [Serializable]
    public class FeatureUnlockReward : Reward
    {
        public string FeatureName;
        public override string DisplayName => "Feature Unlock";
    }
}