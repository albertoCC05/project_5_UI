using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float timeToDestroy = 3;
    private GameManager gameManager;
    [SerializeField] private int pointsValue;
    [SerializeField] private GameObject explosionParticles;

    private void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, timeToDestroy);

            
    }
    private void OnMouseDown()
    {
        if (gameManager.isGameOver == false)
        {
            gameManager.UpdateScore(pointsValue);

            Instantiate(explosionParticles, transform.position, Quaternion.identity);

            Destroy(gameObject);

           

        }

    }
    private void OnDestroy()
    {
        Debug.Log(transform.position);
        Debug.Log($"antes {gameManager.targetPositionInScene.Count}");
        gameManager.targetPositionInScene.Remove(transform.position);
        Debug.Log($"despues {gameManager.targetPositionInScene.Count}");
    }
}
