using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager Manager;
    private static GameObject thisObject = null;

    public int Money;
    
    public Text MoneyText;


    void Awake()
    {
        if (thisObject == null)
        {
            thisObject = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start () {

        Manager = this;
        PlayerPrefs.GetInt("Money", Money);
        PlayerPrefs.Save();
        UpdateUI();

	}

  

    public bool CheckMoney(float Amount)
    {
        if(Amount <= Money)
        {
            return true;
        }
        return false;
    }
    public void UpdateUI()
    {
        MoneyText.text = "$" + Money.ToString();

    }

}
