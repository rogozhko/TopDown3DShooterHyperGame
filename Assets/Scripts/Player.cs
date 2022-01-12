using UnityEngine;
using System;
using System.Collections;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    public Transform bulletPoolPoint;

    private void Start()
    {
        gameManager = GameManager.Instance;
        StartCoroutine(StartShoot());
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
