using UnityEngine;
using System;
using System.Collections;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    public Transform bulletPoolPoint;
    public CheckMovement checkMovement;

    [Range(0.2f, 1f)] public float bulletTimer;
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
            if (timer > bulletTimer)
            {
                timer = 0;
                // Debug.Log("Shoot!");
                // Shoot();
            }
        }
        else
        {
            timer = 0;
            // Debug.Log("Stop Shooting");
        }
    }


    IEnumerator StartShoot()
    {
        yield return new WaitForSeconds(0.3f);
        Shoot();
        StartCoroutine(StartShoot());
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
