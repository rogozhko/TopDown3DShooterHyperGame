using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    private float speed = 2f;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Collision on me!");
            // ContactPoint contact = other.contacts[0];
            // Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            // Vector3 position = contact.point;

            int magnitude = 50;
            var force = transform.position - other.transform.position;
            force.Normalize();
            rigidbody.AddForce(force * magnitude, ForceMode.Impulse);

            rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
        }
    }

}
