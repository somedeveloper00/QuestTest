using System;
using System.Collections.Generic;

namespace QuestSystem
{
    [Serializable]
    public class CollectObjective : Objective
    {
        public Collectible collectible;
        public int collected;
        public int amount;

        private Action _onUpdate, _onComplete;

        public override void Start(Context context, Action onUpdate, Action onComplete)
        {
            _onUpdate = onUpdate;
            _onComplete = onComplete;
            Update();
            collectible.onCollect += Update;
        }

        private void Update()
        {
            collected++;
            _onUpdate?.Invoke();
            if (collected >= amount)
            {
                _onComplete?.Invoke();
                collectible.onCollect -= Update;
            }
        }
    }
}