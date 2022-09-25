using QuestSystem;
using UnityEngine;

namespace UI.QuestInfoPanel
{
    public class ObjectiveElement : MonoBehaviour
    {
        public Objective objective { get; private set; }

        public TMPro.TMP_Text detailsText;

        public virtual void Init(Objective objective)
        {
            this.objective = objective;
            detailsText.text = objective.ToString();
            objective.Start(null, null);
        }
    }
}