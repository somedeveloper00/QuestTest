using QuestSystem;
using TMPro;
using UnityEngine.UI;

namespace UI.QuestInfoPanel
{
    public class CollectObjectiveElement : ObjectiveElement
    {
        public TMP_Text titleText;
        public Image icon;
        
        protected override void OnUpdate()
        {
            var collectibleObjective = objective as CollectObjective;
            titleText.text = $"Collect {collectibleObjective.collectible.displayName}";
            icon.sprite = collectibleObjective.collectible.icon;
            detailsText.text = $"({collectibleObjective.collected}/{collectibleObjective.amount})";
        }
    }
}