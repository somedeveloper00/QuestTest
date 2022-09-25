using QuestSystem;

namespace UI.QuestInfoPanel
{
    public class KillZombiesObjectiveElement : ObjectiveElement
    {
        protected override void OnUpdate()
        {
            var killZombieObjective = (KillZombieObjective)objective;
            detailsText.text = $"Kill Zombies ({killZombieObjective.killed}/{killZombieObjective.amount})";
        }
    }
}