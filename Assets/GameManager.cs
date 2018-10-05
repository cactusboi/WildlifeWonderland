using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager Manager;
    public int Money;

    public Text MoneyText;


	void Start () {

        Manager = this;
        PlayerPrefs.GetInt("Money", Money);
        PlayerPrefs.Save();
        UpdateUI();
        DontDestroyOnLoad(gameObject);

	}

  

    // Update is called once per frame
    void Update () {
		
        
	}

    public void AddMoney(int Amount)
    {
        Money += Amount;
        UpdateUI();
    }

    public void ReduceMoney(int Amount)
    {
        Money -= Amount;
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
    void UpdateUI()
    {
        MoneyText.text = "$" + Money.ToString();
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.Save();

    }

}
