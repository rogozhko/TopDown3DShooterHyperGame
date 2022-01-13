using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{

    public bool isDetect = false;
    public bool letsGrab = false;

    private Vector3 target = Vector3.zero;
    private float speed = 0.01f;

    private GameObject player;


    private void Update()
    {
        if (isDetect)
        {
            transform.position = Vector3.Lerp(transform.position, target, speed);
            if (letsGrab)
            {
                target = player.transform.position;
            }
        }

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator GrabIntoPlayer()
    {
        yield return new WaitForSeconds(1);
        letsGrab = true;
        speed = 0.1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDetect && other.gameObject.CompareTag("Player"))
        {
            isDetect = true;
            player = other.gameObject;
            target = transform.position;
            target.y = 3;

            StartCoroutine(GrabIntoPlayer());
        }
    }
}
