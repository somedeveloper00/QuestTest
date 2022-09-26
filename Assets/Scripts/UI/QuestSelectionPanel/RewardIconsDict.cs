using System;
using QuestSystem;
using UnityEngine;

namespace UI.QuestSelectionPanel
{
    [CreateAssetMenu(fileName = "RewardIconDic", menuName = "SampleTest/Dict/Reward Icons", order = 0)]
    public class RewardIconsDict : ScriptableObject
    {
        [SerializeField] private RewardIconElement coinIcon;
        [SerializeField] private RewardIconElement featureIcon;
        [SerializeField] private RewardIconElement materialIcon;
        [SerializeField] private RewardIconElement questIcon;

        public RewardIconElement GetElementPrefab(Reward reward)
        {
            return reward switch
            {
                CoinReward => coinIcon,
                FeatureUnlockReward => featureIcon,
                MaterialReward => materialIcon,
                QuestUnlockReward => questIcon,
                _ => throw new ArgumentOutOfRangeException(nameof(reward), reward, null)
            };
        }
    }
}