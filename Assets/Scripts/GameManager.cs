using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager Instance { get; set; }
    #endregion

    [SerializeField] private GameObject playerGO;
    [SerializeField] private Player player;
    [SerializeField] private GameObject bulletPrefab;

    [Space(20)]
    [Range(1, 10)] public int countBulletsInPool = 3;
    [Space(20)]
    [Range(5, 50)] public int bulletSpeed = 5;
    [Space(20)]
    [Range(0.2f, 1f)] public float bulletInterval;

    public List<Bullet> bulletPool;

    private void Awake()
    {
        Instance = this;

        CreateBulletPool();
    }

    private void CreateBulletPool()
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
        bullet.transform.localPosition = Vector3.zero;
        // bullet.transform.localRotation = Quaternion.Euler(Vector3.zero);
        bullet.transform.localRotation = Quaternion.identity;


    }
}
