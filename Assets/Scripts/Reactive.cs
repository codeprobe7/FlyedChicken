using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactive : MonoBehaviour
{
    public GameObject player;
    private PlayerController PlayerController;
    private Rigidbody rb;

    private void Start()
    {
        PlayerController = player.GetComponent<PlayerController>();
        rb = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider.CompareTag("Player")) Debug.Log("Player");
            Vector3 direction = contact.otherCollider.transform.position - contact.point;
            Debug.Log(direction.normalized);
            Debug.Log(Vector3.up);
            rb.AddForce(direction * 10f, ForceMode.Impulse);
        }
    }
}
