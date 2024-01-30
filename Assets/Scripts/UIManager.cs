using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    //modificar texto

    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshPro timeText;
    private GameManager gameManager;
    [SerializeField] private GameObject mainMenu;

    

    //funciones
    public void hideMainmMenuOanel()
    {
        mainMenu.SetActive(false);
    }

    public void UpdateScoreText(int points)
    {
        pointsText.text = $"Points = {points} ";
        
    }
    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
        Debug.Log("hola");
    }
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

   

}
