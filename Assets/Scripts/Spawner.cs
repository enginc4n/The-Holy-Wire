using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public IsDead character;
    public GameObject longColumn,shortColumn,longWindow;
    public float time;
    public float x,y;
   
    void Start()
    {
        StartCoroutine(SpawnObjects(time));
    }
    public IEnumerator SpawnObjects(float time)
    {
        int number;
        while (!character.isDead)
        {
            number = Random.Range(0, 75);
            if (number<25)
            {
                Instantiate(longColumn, new Vector3(x, y+0.91f, 0), Quaternion.identity);
            }
            else if (number>25 &&number<50)
            {
                Instantiate(shortColumn, new Vector3(x, y-0.01f, 0), Quaternion.identity);
            }
            else if (number>50)
            {
                Instantiate(longWindow, new Vector3(x, y+3.96f, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(time);
        }
    }
}
