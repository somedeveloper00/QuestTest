using System;
using UnityEngine;

namespace QuestSystem
{
    [Serializable]
    public abstract class Objective
    {
        private event Action onUpdate, onComplete;
        
        protected Context context;
        
        public void Start(Context context, Action onUpdate, Action onComplete)
        {
            this.context = context;
            this.IsCompleted = false;
            this.onUpdate += onUpdate;
            this.onComplete += onComplete;
            OnStart();
        }

        protected void Update() => onUpdate?.Invoke();
        protected void Complete()
        {
            if (IsCompleted)
            {
                Debug.LogWarning($"Objective already completed: {this}");
                return;
            }
            IsCompleted = true;
            Debug.Log($"Objective Completed: {this}");
            onComplete?.Invoke();
        }

        public void AddOnUpdate(Action callback) => onUpdate += callback;
        public void AddOnComplete(Action callback) => onComplete += callback;

        public bool IsCompleted { get; private set; } = false;

        protected abstract void OnStart();
    }
}