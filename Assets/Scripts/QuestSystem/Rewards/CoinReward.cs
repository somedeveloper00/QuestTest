using System;
using UnityEngine;

namespace QuestSystem
{
    [Serializable]
    public class CoinReward : Reward
    {
        [Min(0)] public long CoinAmount;

        public override string DisplayName => "Coin";
    }
}