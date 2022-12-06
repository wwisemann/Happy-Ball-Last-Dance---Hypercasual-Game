using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    CurrentDirection cr;
    public bool isPlayerDead = false;
    private GameManager gameManager;
    public AudioSource deathSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.right;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (isPlayerDead == false) 
        {
            RayCastDetector();
            if (Input.GetKeyDown("space"))
            {
                ChangeDirection();
                PlayerStop();
            }
        }
        else
        {
            return;
        }

    }

    private void RayCastDetector()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit)) 
        {
            MovePlayer();
        }
        else
        {
            PlayerStop(); 
            isPlayerDead= true; 
            deathSound.Play();  
            this.gameObject.SetActive(false);   
            gameManager.LevelEnd();
        }

    }

    private enum CurrentDirection
    {
        right, left
    }

    private void ChangeDirection()
    {
        MovePlayer();
        if (cr == CurrentDirection.right)
	    {
            cr = CurrentDirection.left;
	    }
        else if( cr == CurrentDirection.left) 
        {
            cr = CurrentDirection.right;
        }
    }

    private void MovePlayer()
    {
        if(cr == CurrentDirection.right)
        {
            rb.AddForce((Vector3.forward).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if(cr == CurrentDirection.left)
        {
            rb.AddForce((Vector3.right).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void PlayerStop()
    {
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel();
            PlayerStop();
            this.gameObject.SetActive(false);
        }
    }
}
