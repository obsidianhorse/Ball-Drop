using System;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private GameObject[] _skinItems;
    [SerializeField] private Sprite[] _skinImages;
    [SerializeField] private GameObject _currentSkinPointer;
    [SerializeField] private AudioSource _chooseSound;
    [SerializeField] private AudioSource _buySound;


    private Image[] _buttonImage;

    private const int _PriceForSkin = 100;

    private int _lenghtOfItems;
    private bool[] _isBought;

    private StoreDB _storeDB;








    private void Start()
    {
        _lenghtOfItems = _skinItems.Length;

        InitializeArrays();
        GetComponents();
        _storeDB = new StoreDB(_lenghtOfItems);
        _isBought = _storeDB.ReadBoughtSkins();
        

        ChangeViewOnBoughtSkinsButtons();
        SetPointerOnCurrentSkin();
    }


    private void GetComponents()
    {
        for (int i = 0; i <= _lenghtOfItems - 1; i++)
        {
            _buttonImage[i] = _skinItems[i].GetComponent<Image>();
        }
    }
    private void InitializeArrays()
    {
        _buttonImage = new Image[_lenghtOfItems];
        _isBought = new bool[_lenghtOfItems];
    }
    public void TryToBuy(int indexOfSkin)
    {
        bool isAlreadyBought = _isBought[indexOfSkin] == true;
        if (isAlreadyBought)
        {
            _chooseSound.Play();
            ChangeSkin(indexOfSkin);
        }
        else if (MoneyManager.Money >= _PriceForSkin)
        {
            Buy(indexOfSkin);
        }
    }
    private void Buy(int indexOfSkin)
    {
        MoneyManager.Money -= _PriceForSkin;
        MoneyManager.UpdateInfo();

        _buySound.Play();

        ChangeSkin(indexOfSkin);
        _isBought[indexOfSkin] = true;
        ChangeViewOnBoughtSkinsButtons();

        _storeDB.WriteBoughtSkins(_isBought);
    }

    private void ChangeSkin(int currentSkin)
    {
        BallViewManager.CurrentIndex = currentSkin;
        _storeDB.SetCurrentSkin(currentSkin);
        PlayChooseAnimation(currentSkin);
        SetPointerOnCurrentSkin();

    }
    private void ChangeViewOnBoughtSkinsButtons()
    {
        for (int i = 0; i <= _lenghtOfItems - 1; i++)
        {
            if (_isBought[i] == true)
            {
                _buttonImage[i].sprite = _skinImages[i];
                _buttonImage[i].color = Color.white;

                Destroy(_buttonImage[i].GetComponent<Transform>().Find("Price").GetComponent<Text>());
            }
        }
    }
    private void PlayChooseAnimation(int currentSkin)
    {
        _skinItems[currentSkin].GetComponent<Animation>().Play();
    }
    private void SetPointerOnCurrentSkin()
    {
        int currentSkin = int.Parse(DataBase.ExecuteQueryWithAnswer($"SELECT currentSkin FROM STORE;"));
        _currentSkinPointer.transform.SetParent(_skinItems[currentSkin].transform, false);
    }
}
