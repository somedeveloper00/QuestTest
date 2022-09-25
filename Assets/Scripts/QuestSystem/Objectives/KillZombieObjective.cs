using System;

namespace QuestSystem
{
    [Serializable]
    public class KillZombieObjective : Objective
    {
        [NonSerialized] public int killed;
        public int amount;

        private Action _onUpdate, _onComplete;
        private Context _context;

        public override void Start(Context context, Action onUpdate, Action onComplete)
        {
            _context = context;
            context.zombieManager.onKill += Update;
            _onUpdate += onUpdate;
            _onComplete = onComplete;
        }
        
        void Update()
        {
            killed++;
            _onUpdate?.Invoke();
            if (killed >= amount)
            {
                _onComplete?.Invoke();
                _context.zombieManager.onKill -= Update;
            }
        }

    }
}