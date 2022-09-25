namespace UI.QuestInfoPanel
{
    public class DefendAPositionObjectiveElement : ObjectiveElement
    {
        protected override void OnUpdate()
        {
            detailsText.text = $"Defend Position";
        }
    }
}