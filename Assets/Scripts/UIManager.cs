using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using JetBrains.Annotations;

public class UIManager : MonoBehaviour
{
       //modificar texto

    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI timeText;
    private GameManager gameManager;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Button easyButon;
    [SerializeField] private Button mediumButon;
    [SerializeField] private Button hardButon;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button backOptionsButton;
    [SerializeField] private Button RandomMusicValue;
    [SerializeField] private AudioSource mainMusic;
    [SerializeField] private Slider volumeSlider;




    //funciones
    public void GenerateRandomMusic()
    {
        mainMusic.volume = Random.Range(0f, 1f);
        volumeSlider.value = mainMusic.volume;

    }

    public void HideOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }
    public void ShowOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
    
    public void UpdateLivesText(int lives)
    {
        livesText.text = $"Lives: {lives}";
    }
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
    public void UpdateTimeTex(int time)
    {
        timeText.text = $"time: {time}";
    }
  
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        easyButon.onClick.AddListener(() => { gameManager.StartGame(1); });
        mediumButon.onClick.AddListener(() => { gameManager.StartGame(2); });
        hardButon.onClick.AddListener(() => { gameManager.StartGame(3); });
    }

   

}
