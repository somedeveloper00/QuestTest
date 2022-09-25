using System;

namespace QuestSystem
{
    [Serializable]
    public class MaterialReward : Reward
    {
        public string MaterialName;
        public override string DisplayName => "Material";
        
        public override void GetReward()
        {
            // throw new NotImplementedException();
        }

    }
}