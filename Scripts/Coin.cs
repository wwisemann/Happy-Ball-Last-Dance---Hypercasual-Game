using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    public int minScore,maxScore;
    public ParticleSystem collectEffect;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.AddScore(Random.Range(minScore,maxScore));
            collectEffect.Play();
            Destroy(gameObject,0.5f);
        }
    }

}
