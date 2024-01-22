using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   //variables
    
    [SerializeField] private GameObject[] targetPrefabs;
    private float minx = -3.75f;
    private float miny = -3.75f;
    private float distanceBetwenCenters = 2.5f;
    private bool isGameOver;
    private float spawnRate = 2f;
    private Vector3 randomPos;
    public List<Vector3> targetPositionInScene;
    


    //funciones

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

 

    private void Start()
    {
        StartCoroutine(SpawnRandomTarget());
    }
    private void Awake()
    {
        targetPositionInScene = new List<Vector3>();
    }

}
