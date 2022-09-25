using System;
using System.Collections.Generic;
using QuestSystem;
using TMPro;
using UnityEngine;

namespace UI.QuestInfoPanel
{
    public class QuestInfoPanel : MonoBehaviour
    {
        [NonSerialized] public Context context;
        public TMP_Text questTitle;
        public ObjectiveElementsDict objectiveElementsDict;
        public Transform objectiveElementParent;

        private QuestManager _questManager;
        private readonly List<ObjectiveElement> _objectiveElements = new();

        public void Init(Context context)
        {
            this.context = context;
            _questManager = context.questManager;
            var currentState = _questManager.CurrentState;
            if (currentState.active)
            {
                questTitle.text = currentState.currentQuest.title;
                foreach (var objective in currentState.objectives)
                {
                    var prefab = objectiveElementsDict.GetElementPrefab(objective);
                    var objectiveElemenent = Instantiate(prefab, objectiveElementParent);
                    objectiveElemenent.Init(context, objective);
                    _objectiveElements.Add(objectiveElemenent);
                }
            }
        }
    }
}