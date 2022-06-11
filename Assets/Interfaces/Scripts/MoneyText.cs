using UnityEngine;
using UnityEngine.UI;



public class MoneyText : MonoBehaviour
{
    private void Awake()
    {
        MoneyManager.MoneyText =gameObject.GetComponent<Text>();
        MoneyManager.UpdateInfo();
    }
}
