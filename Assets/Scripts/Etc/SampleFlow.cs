using System;
using UI.QuestInfoPanel;
using UI.QuestSelectionPanel;
using UnityEngine;

public class SampleFlow : MonoBehaviour
{
    public Context context;
    public QuestSelector questSelectorPrefab;
    public QuestInfoPanel questInfoPanelPrefab;
    public GameObject completeQuestButton;
    public GameObject questSelectorButton;
    public Transform UI;

    public static event Action OnDefendPlace;
    private QuestInfoPanel _questInfoPanel;
        
    public void OpenQuestSelector()
    {
        questSelectorButton.SetActive(false);
        var obj = Instantiate(questSelectorPrefab, UI);
        obj.Init(context);
        obj.onQuestStart += AfterQuestSelected;
    }

    public void AfterQuestSelected()
    {
        completeQuestButton.SetActive(true);
        _questInfoPanel = Instantiate(questInfoPanelPrefab, UI);
        _questInfoPanel.Init(context);
        context.questManager.OnQuestComplete += OnCompleteQuest;
    }

    public void OnCompleteQuest()
    {
        Destroy(_questInfoPanel.gameObject);
        completeQuestButton.SetActive(false);
        questSelectorButton.SetActive(true);

        context.questManager.OnQuestComplete -= OnCompleteQuest;
    }


    public void DefendPlace()
    {
        OnDefendPlace?.Invoke();
    }
}