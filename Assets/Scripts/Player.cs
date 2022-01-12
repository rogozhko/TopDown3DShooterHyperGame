using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    public Transform bulletPoolPoint;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        if (gameManager.bulletPool.Count != 0)
        {
            //Get bullet from pool
            Bullet bullet = gameManager.bulletPool[0];

            //Set enemyPosition
            bullet.targetPosition = gameManager.enemy.transform.position;
            bullet.ShootDebug();

            bullet.gameObject.SetActive(true);
            gameManager.bulletPool.Remove(bullet);
            bullet.gameObject.transform.parent = null;

            bullet.StartCountForDead();
        }
    }
}
