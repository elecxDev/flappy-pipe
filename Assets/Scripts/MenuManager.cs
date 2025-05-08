using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public GameObject GameMenuPanel;
    public GameObject AudioSourceParent;

    private void Start()
    {
        GameMenuPanel.SetActive(true);
        AudioSourceParent.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameStart()
    {
        GameMenuPanel.SetActive(false);
        AudioSourceParent.SetActive(true);
        Time.timeScale = 1f;
    }
}
