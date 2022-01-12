using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Material material;
    private Color baseColor;

    private int countToDeath = 3;

    private void Start()
    {
        material = GetComponentInChildren<Renderer>().material;
        baseColor = material.color;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Debug.Log("Enemy: Bullet on me!");
            StartCoroutine(ChangeColor());

            if (countToDeath > 0)
            {
                countToDeath--;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.08f);
        material.color = Color.black;
        yield return new WaitForSeconds(0.08f);
        material.color = baseColor;
    }

    private void GetDamage()
    {

    }
}
