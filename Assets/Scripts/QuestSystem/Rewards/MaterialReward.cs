using System;
using UnityEngine;

namespace QuestSystem
{
    [Serializable]
    public class MaterialReward : Reward
    {
        public string MaterialName;
        public override string DisplayName => "Material";
        
        public override void GetReward()
        {
            Debug.Log($"Got new material: {MaterialName}");
        }

    }
}