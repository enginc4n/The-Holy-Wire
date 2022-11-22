using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
   private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private void Start()
    {
        Destroy(gameObject, 15);
    }
}
