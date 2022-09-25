using UI.QuestInfoPanel;
using UI.QuestSelectionPanel;
using UnityEngine;

public class SampleFlow : MonoBehaviour
{
    public Context context;
    public QuestSelector questSelectorPrefab;
    public QuestPanel questPanelPrefab;
    public GameObject completeQuestButton;
    public GameObject questSelectorButton;
    public Transform UI;

    private QuestPanel _questPanel;
        
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
        _questPanel = Instantiate(questPanelPrefab, UI);
        _questPanel.Init(context);
    }

    public void CompleteQuest()
    {
        Destroy(_questPanel.gameObject);
        completeQuestButton.SetActive(false);
        context.questManager.CompleteCurrentQuest();
        questSelectorButton.SetActive(true);
    }
}