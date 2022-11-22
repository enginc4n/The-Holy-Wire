using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public int health = 100;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            Die();
        }
    }
    void Die()
    {
        GameManager.score++;
        Destroy(gameObject);
    }
   
}
