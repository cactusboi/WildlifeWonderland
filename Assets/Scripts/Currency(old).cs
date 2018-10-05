/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour {

    public int coin = 0;

    GameObject currencyUI;
	void Start () {
        currencyUI = GameObject.Find("Currency");
	}
	
	
	void Update () {
        currencyUI.GetComponent<Text>().text = coin.ToString();
        if (coin < 0)
        {
            coin = 0;
        }
	}
}
*/