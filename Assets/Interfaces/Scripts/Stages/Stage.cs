using UnityEngine;
using UnityEngine.UI;

enum ObjectType
{
    TextAboutLevels,
    Lock
}
public class Stage : MonoBehaviour
{
    [SerializeField] private int _previousStage;
    private const int _QuantityOfLevelsOfPreviousToOpenNextStage = 20;
    private Color32 availableStageColor = new Color32(255, 255, 255, 255);
    private Color32 lockedStageColor = new Color32(140, 140, 140, 255);

    private Image _stageImage;
    private int _passedLevels;





    private void Start()
    {
        GetfPassedLevelsFromDatabase();
        GetComponents();
        SetStageCondition();
    }


    private void GetComponents()
    {
        _stageImage = GetComponent<Image>();
    }
    
    private void SetStageCondition()
    {
        bool isPreviousStagePassed = _passedLevels >= _QuantityOfLevelsOfPreviousToOpenNextStage;
        if (isPreviousStagePassed)
        {
            SetStageAsActive();
            SetStageView(availableStageColor);
            DeleteChild(ObjectType.Lock);
        }
        else
        {
            SetStageAsLocked();
            SetStageView(lockedStageColor);
            DeleteChild(ObjectType.TextAboutLevels);
        }
    }
    private void SetStageAsActive()
    {
        _stageImage.raycastTarget = true;
    }
    private void SetStageAsLocked()
    {
        _stageImage.raycastTarget = false;
    }
    private void SetStageView(Color32 color)
    {
        _stageImage.color = color;
    }
    private void DeleteChild(ObjectType objectType )
    {
        Destroy(transform.GetChild(((int)objectType)).gameObject);
    }

    private void GetfPassedLevelsFromDatabase()
    {
        _passedLevels = int.Parse(DataBase.ExecuteQueryWithAnswer($"SELECT stage{_previousStage}Levels FROM LEVELS;"));
    }
}
