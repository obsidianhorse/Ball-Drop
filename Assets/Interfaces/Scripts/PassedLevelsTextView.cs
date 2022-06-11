using UnityEngine;
using UnityEngine.UI;

public class PassedLevelsTextView : MonoBehaviour
{
    [SerializeField] private int _currentStage;
    [SerializeField] private  int _guantityOfLevelsToOpenTheStage = 20;
    [SerializeField] private Text _levelsArePassedText;

    
    private int _passedLevelsOfCurrentStage;




    void Start()
    {
        GetfPassedLevelsFromDatabase();
        SetPassedLevelsInText();
    }



    private void SetPassedLevelsInText()
    {
        _levelsArePassedText.text = $"{_passedLevelsOfCurrentStage}/{_guantityOfLevelsToOpenTheStage}";
    }


    private void GetfPassedLevelsFromDatabase()
    {
        _passedLevelsOfCurrentStage = int.Parse(DataBase.ExecuteQueryWithAnswer($"SELECT Stage{_currentStage}Levels FROM LEVELS;"));
    }
}
