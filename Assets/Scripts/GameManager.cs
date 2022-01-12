using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager Instance { get; set; }
    #endregion


    [SerializeField] private Player player;

    [SerializeField] private GameObject bulletPrefab;
    public int countBulletsInPool = 3;
    public int bulletSpeed = 5;

    public List<Bullet> bulletPool;

    private void Awake()
    {
        // Init singleton
        Instance = this;

        //Create Pool Of Bullets
        InitializeBulletPool();
    }

    private void InitializeBulletPool()
    {
        bulletPool = new List<Bullet>();
        for (int i = 0; i < countBulletsInPool; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, player.bulletPoolPoint);
            bullet.gameObject.SetActive(false);
            bulletPool.Add(bullet.GetComponent<Bullet>());
            bullet.gameObject.name = "Bullet " + i;
        }
    }

    public void GrabBullet(Bullet bullet)
    {
        //Grab bullet and put back to pool
        // Debug.Log("Grab " + bullet.gameObject.name);

        bullet.gameObject.SetActive(false);

        bulletPool.Add(bullet);
        bullet.transform.SetParent(player.bulletPoolPoint);
        bullet.transform.position = player.bulletPoolPoint.transform.position;

    }
}
