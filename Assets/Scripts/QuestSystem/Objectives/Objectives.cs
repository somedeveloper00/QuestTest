using System;
using System.Collections.Generic;

namespace QuestSystem
{
    /// <summary>
    ///     An Editor-friendly list of objectives
    /// </summary>
    [Serializable]
    public sealed class Objectives
    {
        public CollectObjective[] CollectObjectives;
        public KillZombieObjective[] KillZombieObjectives;
        public DefendAPositionObjective[] DefendAPositionObjectives;

        public static implicit operator Objective[](Objectives objectives)
        {
            var r = new List<Objective>();
            r.AddRange(objectives.CollectObjectives);
            r.AddRange(objectives.KillZombieObjectives);
            r.AddRange(objectives.DefendAPositionObjectives);
            return r.ToArray();
        }
    }
}