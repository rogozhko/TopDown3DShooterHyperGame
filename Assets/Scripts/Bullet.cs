using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // public Rigidbody rigidbody;
    GameManager gameManager;

    public Vector3 targetPosition;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void ShootDebug()
    {
        if (targetPosition != null)
        {
            // Debug.Log("Enemy is on " + targetPosition);
        }


    }

    private void Update()
    {
        // If bullet is active, move toward enemy
        if (gameObject.activeSelf == true)
        {
            transform.Translate(Vector3.forward * gameManager.bulletSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Activate GrabBullet() in GameManager with this bullet
        gameManager.GrabBullet(this);
    }

    public void StartCountForDead()
    {
        StartCoroutine(WaitForDead());
    }

    IEnumerator WaitForDead()
    {
        Debug.Log("Start Count");
        yield return new WaitForSeconds(2);
        Debug.Log("Dead Bullet");
        gameManager.GrabBullet(this);
    }

}
