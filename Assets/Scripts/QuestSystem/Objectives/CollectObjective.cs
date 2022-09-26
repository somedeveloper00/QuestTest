using System;

namespace QuestSystem
{
    [Serializable]
    public class CollectObjective : Objective
    {
        public Collectible collectible;
        public int amount;
        [NonSerialized] public int collected;

        protected override void OnStart()
        {
            collectible.onCollect += OnCollect;
        }

        private void OnCollect()
        {
            collected++;
            Update();
            if (collected >= amount)
            {
                Complete();
                collectible.onCollect -= OnCollect;
            }
        }
    }
}