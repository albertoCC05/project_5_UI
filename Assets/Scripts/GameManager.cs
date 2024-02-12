using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   //variables
    
    [SerializeField] private GameObject[] targetPrefabs;
    private float minx = -3.75f;
    private float miny = -3.75f;
    private float distanceBetwenCenters = 2.5f;
    public bool isGameOver;
    private float spawnRate = 2f;
    private Vector3 randomPos;
    public List<Vector3> targetPositionInScene;
    private int score;
    private UIManager uiManager;
    private int timer = 60;
    [SerializeField] private GameObject pausePanel;
    private Target targetScript;
    public int lives = 3;
    
   



 
   
    
    


    //funciones

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;


    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minx + ((Random.Range(0, 4) * distanceBetwenCenters));
        float spawnPosY = miny + ((Random.Range(0, 4) * distanceBetwenCenters));

        return new Vector3(spawnPosX, spawnPosY, 0);
    }
  
    private IEnumerator SpawnRandomTarget()
    {
        while (!isGameOver)
        {
            if (isGameOver == true)
            {
                break;
            }
            yield return new WaitForSeconds(spawnRate);

            int randomPrefabIndex = Random.Range(0, 4);          

             randomPos = RandomSpawnPosition();
            while (targetPositionInScene.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomPrefabIndex], randomPos, Quaternion.Euler(-90, 0, 0));
           
            targetPositionInScene.Add(randomPos);
        }
        
    }
    private IEnumerator Timer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            timer--;
            uiManager.UpdateTimeTex(timer);
            if (timer <= 0)
            {
                isGameOver = true;
                uiManager.ShowGameOverPanel();

            }
        }
      

    }
    

    public void UpdateScore(int newPoints)
    {
        score += newPoints;
        uiManager.UpdateScoreText(score);
        if (score <= 0)
        {
            isGameOver = true;
            uiManager.ShowGameOverPanel();
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Game");
        
    }

    public void StartGame(int dificulty)
    {
        Time.timeScale = 1;
        spawnRate = spawnRate / dificulty; 
        StartCoroutine(SpawnRandomTarget());
        score = 0;
        uiManager.UpdateScoreText(score);
        uiManager.hideMainmMenuOanel();
        uiManager.UpdateLivesText(lives);
        StartCoroutine (Timer());
    }

 

    private void Start() 
    {
        
        pausePanel.SetActive(false);
        uiManager = FindObjectOfType<UIManager>();
        uiManager.HideGameOverPanel();
        uiManager.HideOptionsPanel();
        lives = 3;
       
        
    }
    private void Awake()
    {
        targetPositionInScene = new List<Vector3>();
        
    }
    
    

}
