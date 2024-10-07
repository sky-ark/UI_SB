using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10f;

    public Animation swordAnimation;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(-moveX * speed * Time.deltaTime, 0, 0); 
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    
    private void Attack()
    {
        Debug.Log("Attack");
        swordAnimation.Play();
    }
    
}
