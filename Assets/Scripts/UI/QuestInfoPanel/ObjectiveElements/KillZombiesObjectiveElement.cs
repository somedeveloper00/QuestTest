using System;
using QuestSystem;

namespace UI.QuestInfoPanel
{
    public class KillZombiesObjectiveElement : ObjectiveElement
    {
        public override void Init(Objective objective)
        {
            base.Init(objective);
            UpdateView();
        }

        private void UpdateView()
        {
            detailsText.text = $"Kill Zombies ()";
        }
    }
}