using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDB : MonoBehaviour
{
    private int _lenghtOfItems;

    public StoreDB(int lenghtOfItems)
    {
        _lenghtOfItems = lenghtOfItems;
    }


    public void SetCurrentSkin(int currentSkin)
    {
        DataBase.ExecuteQueryWithoutAnswer($"UPDATE STORE set currentSkin = {currentSkin};");
    }
    public bool[] ReadBoughtSkins()
    {
        string strBoughtSkins = DataBase.ExecuteQueryWithAnswer("SELECT boughtSkins FROM STORE;");
        bool[] isBought = new bool[_lenghtOfItems];

        for (int i = 0; i <= _lenghtOfItems - 1; i++)
        {
            if (strBoughtSkins[i] == '0')
                isBought[i] = false;
            else if (strBoughtSkins[i] == '1')
                isBought[i] = true;
        }

        return isBought;
    }
    public void WriteBoughtSkins(bool[] boughtSkins)
    {
        string strBoughtSkins = "";

        foreach (var item in boughtSkins)
        {
            if (item == true)
                strBoughtSkins += "1";
            else
                strBoughtSkins += "0";
        }

        DataBase.ExecuteQueryWithoutAnswer($"UPDATE Store set boughtSkins = '{strBoughtSkins}';");
    }
}
