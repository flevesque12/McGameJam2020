using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public GameObject creditPanel;
    public GameObject mainPanel;
    
    public void GotoMainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ActivateCreditPanel()
    {
        creditPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void ActivateMainPanel()
    {
        creditPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
