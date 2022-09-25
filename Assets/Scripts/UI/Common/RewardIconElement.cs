using QuestSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.QuestSelectionPanel
{
    public class RewardIconElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private Image image;

        public void Init(Reward reward)
        {
            amountText.gameObject.SetActive(false);
            switch (reward)
            {
                case CoinReward coinReward:
                    amountText.text = coinReward.CoinAmount.ToString();
                    amountText.gameObject.SetActive(true);
                    break;
            }
        }
    }
}