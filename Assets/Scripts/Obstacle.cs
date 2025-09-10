using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float leftBoundary = -10f;
    //public float gameSpeed = 5;
  

    // Update is called once per frame
    void Update()
    {
        MoverObstacle();
    }
    private void MoverObstacle() 
    {
        transform.position += Vector3.left * GameManager.Instance.GetGameSpeed() * Time.deltaTime;
        if (transform.position.x < leftBoundary) 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            GameManager.Instance.GameOver();
        }
    }
}
