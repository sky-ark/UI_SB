using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenu, settingsMenu, creditsMenu, ShopMenu, ShopBar;
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Shop()
    {
        ShopMenu.SetActive(true);
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        ShopBar.SetActive(false);

    }
    
    public void Settings()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(true);
        ShopMenu.SetActive(false);
        ShopBar.SetActive(true);
    }
    
    public void Credits()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(true);
        ShopMenu.SetActive(false);
        ShopBar.SetActive(true);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
