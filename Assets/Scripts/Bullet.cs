using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public AudioClip kýrýlma;
    public AudioSource sesler;


    private void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 10);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Window window = hitInfo.GetComponent<Window>();
        if (window != null)
        {
            sesler.PlayOneShot(kýrýlma);
            window.TakeDamage(100);
            Destroy(gameObject);

        }
        if (hitInfo.gameObject.tag.Equals("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}