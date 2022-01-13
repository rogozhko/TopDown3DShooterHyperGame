using UnityEngine;
using System;
using System.Collections;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    public Transform bulletPoolPoint;
    public CheckMovement checkMovement;

    [Space(20)]
    public bool shooting = true;

    private float timer;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }


    void FixedUpdate()
    {
        if (!checkMovement.playerIsMoving)
        {
            timer += Time.deltaTime;
            if (timer > gameManager.bulletInterval)
            {
                timer = 0;
                // Debug.Log("Shoot!");
                if (shooting) Shoot();
            }
        }
        else
        {
            timer = 0;
            // Debug.Log("Stop Shooting");
        }
    }




    private void Shoot()
    {
        if (gameManager.bulletPool.Count != 0)
        {
            //Get bullet from pool
            Bullet bullet = gameManager.bulletPool[0];

            bullet.gameObject.SetActive(true);
            gameManager.bulletPool.Remove(bullet);
            bullet.gameObject.transform.parent = null;

            bullet.StartCountForDead();
        }
    }
}
