using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CharacterController : MonoBehaviour
{
    public float speed = 10f;

    public Animation swordAnimation;

    public InventoryManager inventoryManager;

    public Button moveButton;

    private void Start()
    {
        if (moveButton != null)
        {
            moveButton.onClick.AddListener(MoveCharacter);
        }
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(-moveX * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            CallInventory();
        }
    }

    public void CallInventory()
    {
        if (inventoryManager.InventoryOpen)
            inventoryManager.CloseInventory();
        else
            inventoryManager.OpenInventory();
    }

    public void Attack()
    {
        Debug.Log("Attack");
        swordAnimation.Play();
    }

    public void MoveCharacter()
    {
        transform.Translate(Vector3.left * 20 * speed * Time.deltaTime, Space.World);
    }
}
