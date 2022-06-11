using System;
using UnityEngine;
using UnityEngine.UI;



public class LevelsDatabase : MonoBehaviour
{
    [SerializeField] private int _currentStage;
    [SerializeField] private GameObject[] _levels;
    [SerializeField] private Sprite _spriteLock;

    private Image[] _levelsImage;
    private int _passedLevels;




    
    private void Start()
    {
        SetArraysSize();
        _passedLevels = GetPassedLevelsFromDB();
        SetViewToPassedLevels();
    }


    private void SetArraysSize()
    {
        _levelsImage = new Image[_levels.Length];
    }
    private void SetViewToPassedLevels()
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            _levelsImage[i] = _levels[i].GetComponent<Image>();
        }

        for (int i = _levels.Length - 1; i > _passedLevels-1; i--)
        {
            _levelsImage[i].raycastTarget = false;
            Destroy(_levelsImage[i].GetComponentInChildren<Text>());
            _levelsImage[i].sprite = _spriteLock;
        }
    }
    private int GetPassedLevelsFromDB()
    {
        int passedLevels = Convert.ToInt32(DataBase.ExecuteQueryWithAnswer($"SELECT Stage{_currentStage}levels FROM LEVELS;"));
        
        return passedLevels;
    }
}
