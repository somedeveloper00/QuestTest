using QuestSystem;
using UnityEngine;

namespace UI.QuestInfoPanel
{
    public class ObjectiveElement : MonoBehaviour
    {
        public Objective objective { get; protected set; }

        public TMPro.TMP_Text detailsText;
        public CanvasGroup canvasGroup;

        public virtual void Init(Context context, Objective objective)
        {
            this.objective = objective;
            objective.Start(context, OnUpdate, OnComplete);
            OnUpdate();
        }

        protected virtual void OnUpdate()
        {
            detailsText.text = objective.ToString();
        }
        
        protected virtual void OnComplete()
        {
            canvasGroup.alpha = 0.5f;
        }
    }
}