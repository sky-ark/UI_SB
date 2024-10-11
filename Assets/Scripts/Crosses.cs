using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosses : MonoBehaviour
{
    private float health = 100f;
    public Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hits the crosses");
            health -= 50f;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
