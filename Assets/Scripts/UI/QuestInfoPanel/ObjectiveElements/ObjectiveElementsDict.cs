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
            switch (objective)
            {
                case CollectObjective collectObjective:
                    return collectObjectiveElement;
                case DefendAPositionObjective defendAPositionObjective:
                    return defendAPositionObjectiveElement;
                case KillZombieObjective killZombieObjective:
                    return killZombiesObjectiveElement;
                default:
                    return defaultElement;
            }
        }
    }
}