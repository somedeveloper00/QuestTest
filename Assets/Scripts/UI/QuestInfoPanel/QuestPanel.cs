using System.Collections.Generic;
using QuestSystem;
using TMPro;
using UnityEngine;

namespace UI.QuestInfoPanel
{
    public class QuestPanel : MonoBehaviour
    {
        public Context context;
        public TMP_Text questTitle;
        public ObjectiveElement objectiveElementPrefab;
        public Transform objectiveElementParent;

        private QuestManager _questManager;
        private List<ObjectiveElement> _objectiveElements = new List<ObjectiveElement>();

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
                    var objectiveElemenent = Instantiate(objectiveElementPrefab, objectiveElementParent);
                    objectiveElemenent.Init(objective);
                    _objectiveElements.Add(objectiveElemenent);
                }
            }
        }
    }
}