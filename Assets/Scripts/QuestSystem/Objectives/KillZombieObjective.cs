using System;

namespace QuestSystem
{
    [Serializable]
    public class KillZombieObjective : Objective
    {
        [NonSerialized] public int killed;
        public int amount;

        protected override void OnStart()
        {
            context.zombieManager.onKill += OnKill;
        }

        void OnKill()
        {
            killed++;
            Update();
            if (killed >= amount)
            {
                Complete();
                context.zombieManager.onKill -= OnKill;
            }
        }
    }
}