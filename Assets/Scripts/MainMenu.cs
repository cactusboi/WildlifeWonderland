using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

  

    public void SelectAnimalsScreen ()
    {
        SceneManager.LoadScene("Animals");
    }

    public void SelectShopScreen()
    {
        SceneManager.LoadScene("Shop");
    }

    public void SelectItemsScreen()
    {
        SceneManager.LoadScene("Items");
    }

    public void SelectSettingsScreen()
    {
        SceneManager.LoadScene("Settings");
    }

    public void SelectHomeScreen()
    {
        SceneManager.LoadScene("MainScene");
    }

}
