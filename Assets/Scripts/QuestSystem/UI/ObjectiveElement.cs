using UnityEngine;

namespace QuestSystem.UI
{
    public class ObjectiveElement : MonoBehaviour
    {
        public Objective objective { get; private set; }

        public TMPro.TMP_Text detailsText;

        public void Init(Objective objective)
        {
            this.objective = objective;
            detailsText.text = objective.DisplayTitle;
        }
    }
}