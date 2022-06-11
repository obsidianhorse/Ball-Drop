using UnityEngine;

[CreateAssetMenu(fileName = "MoneyData", menuName = "Scriptable/Money", order = 51)]
public class MoneyContainer : ScriptableObject
{
    public int money;   


    public MoneyContainer()
    {
        money = GetMoneyFromDataBase();
    }

    

    public int Money
    {
        get 
        {
            money = GetMoneyFromDataBase();
            return money; 
        }
        set
        {
            money = value;
            SaveMoneyToDataBase();
        }
    }



    private int GetMoneyFromDataBase()
    {
        return int.Parse(DataBase.ExecuteQueryWithAnswer("SELECT money FROM Money;"));
    }
    private void SaveMoneyToDataBase()
    {
        DataBase.ExecuteQueryWithoutAnswer($"UPDATE Money set money = {money};");
    }
}
