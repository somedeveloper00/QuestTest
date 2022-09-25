using System;

namespace QuestSystem
{
    [Serializable]
    public class FeatureUnlockReward : Reward
    {
        public string FeatureName;
        public override string DisplayName => "Feature Unlock";
        public override void GetReward()
        {
            // throw new NotImplementedException();
        }

    }
}