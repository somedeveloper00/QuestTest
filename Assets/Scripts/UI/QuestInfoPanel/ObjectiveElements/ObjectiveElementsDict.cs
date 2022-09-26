using QuestSystem;
using UnityEngine;

namespace UI.QuestInfoPanel
{
    [CreateAssetMenu(fileName = "ObjectiveElementDict", menuName = "SampleTest/Dict/Objective Element Dict", order = 0)]
    public class ObjectiveElementsDict : ScriptableObject
    {
        public ObjectiveElement defaultElement;
        public KillZombiesObjectiveElement killZombiesObjectiveElement;
        public CollectObjectiveElement collectObjectiveElement;
        public DefendAPositionObjectiveElement defendAPositionObjectiveElement;

        public ObjectiveElement GetElementPrefab(Objective objective)
        {
            return objective switch
            {
                CollectObjective => collectObjectiveElement,
                DefendAPositionObjective => defendAPositionObjectiveElement,
                KillZombieObjective => killZombiesObjectiveElement,
                _ => defaultElement
            };
        }
    }
}