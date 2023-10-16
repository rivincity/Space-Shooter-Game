using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private float timer;
    private float randomX;
    private float randomY;
    private float randomZ;
    private float count;
    bool boolean;
    public GameObject gameObject;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        boolean = false;
        timer = 1.5f;
        randomZ = 8f;
        randomY = 0f;
        randomX = Random.Range(-7, 7);
        //setBounds();
        count = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && count%5!=0)
        {
            position = new Vector3(randomX, randomY, randomZ);
            Instantiate(gameObject, position, transform.rotation);
            timer = 1f;
            count++;
        }
        if (count == 5)
        {
            randomX = Random.Range(-7, 7);
            //setBounds();
            count = 1f;
            timer = 4f;
        }
    }
    public void setBounds()
    {
        randomX = Random.Range(-7, 7);
        while(!boolean)
        {
            if (randomX > -3 || randomX < 3)
                randomX = Random.Range(-7, 7);
            else
                boolean = true;
        }
    }
}
