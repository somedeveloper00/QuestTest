using System;
using System.Linq;
using QuestSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace UI.QuestSelectionPanel
{
    public class DetailsPane : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text descText;
        [SerializeField] private RewardIconElement rewardIconElementSample;
        [SerializeField] private Transform rewardIconsParent;

        private RewardIconElement[] _rewardIconElements;

        private void Start()
        {
            titleText.text = "";
            descText.text = "";

            for (int i = 0; i < rewardIconsParent.childCount; i++) Destroy(rewardIconsParent.GetChild(i).gameObject);
        }

        public void Show(Quest quest)
        {
            titleText.text = quest.title;
            descText.text = quest.description;

            // remove previous icons
            if(_rewardIconElements != null)
                foreach (var rewardIconElement in _rewardIconElements)
                    Destroy(rewardIconElement.gameObject);

            // create new icons
            var rewards = quest.Rewards;
            _rewardIconElements = new RewardIconElement[rewards.Length];
            for (var i = 0; i < rewards.Length; i++)
            {
                _rewardIconElements[i] = Instantiate(rewardIconElementSample, rewardIconsParent);
                _rewardIconElements[i].Init(rewards[i]);
            }
        }
    }
}