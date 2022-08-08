using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{
    public Canvas achievementsCanvas;
    public Canvas foodsCanvas;
    public Canvas ordersCanvas;
    public Canvas upgradesCanvas;
    public Canvas settingsCanvas;

    public void ButtonAchievements()
    {
        DeactiveAll();
        achievementsCanvas.gameObject.SetActive(true);
    }

    public void ButtonFoods()
    {
        DeactiveAll();
        foodsCanvas.gameObject.SetActive(true);
    }

    public void ButtonOrders()
    {
        DeactiveAll();
        ordersCanvas.gameObject.SetActive(true);
    }

    public void ButtonUpgrades()
    {
        DeactiveAll();
        upgradesCanvas.gameObject.SetActive(true);
    }

    public void ButtonSettings()
    {
        DeactiveAll();
        settingsCanvas.gameObject.SetActive(true);
    }

    private void DeactiveAll()
    {
        achievementsCanvas.gameObject.SetActive(false);
        foodsCanvas.gameObject.SetActive(false);
        ordersCanvas.gameObject.SetActive(false);
        upgradesCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
    }
}
