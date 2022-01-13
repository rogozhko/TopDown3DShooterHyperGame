using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    // public Rigidbody rigidbody;
    GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        // Debug.Log(transform.rotation);


        if (gameObject.activeSelf == true)
        {
            transform.position += transform.forward * gameManager.bulletSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        gameManager.GrabBullet(this);
    }

    public void StartCountForDead()
    {
        StartCoroutine(WaitForDead());
    }

    IEnumerator WaitForDead()
    {
        yield return new WaitForSeconds(1);
        gameManager.GrabBullet(this);
    }

}
