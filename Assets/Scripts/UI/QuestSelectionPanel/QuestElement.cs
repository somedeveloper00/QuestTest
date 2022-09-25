using System.Linq;
using QuestSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.QuestSelectionPanel
{
    public class QuestElement : MonoBehaviour
    {
        public Quest quest { get; private set; }
        private QuestSelector _questSelector { get; set; }

        public TMP_Text titleText;
        public TMP_Text coinsAmountText;
        public Color selectedCol;

        public void Init(Quest quest, QuestSelector selector)
        {
            this.quest = quest;
            this._questSelector = selector;
            
            titleText.text = quest.title;
            coinsAmountText.text = quest.Rewards
                .Where(reward => reward is CoinReward)
                .Cast<CoinReward>()
                .Sum(c => c.CoinAmount).ToString();
        }

        public void Go()
        {
            _questSelector.Go(quest);
        }

        public void Select()
        {
            if (TryGetComponent<Image>(out var image))
            {
                image.color = selectedCol;
            }
            _questSelector.Select(this);
        }

        public void UnSelect()
        {
            if (TryGetComponent<Image>(out var image))
            {
                image.color = Color.white;
            }
        }
    }
}