using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float incrementZ;
    private float incrementY;
    private float incrementX;
    private float xPosition;
    public GameObject gameObject;
    int flightPath;
    private float timer;
    bool boolean;
    bool boolean2;
    bool boolean3;
    // Start is called before the first frame update
    void Start()
    {
        incrementZ = -0.05f;
        incrementX = 0.05f;
        incrementY = 0.05f;
        xPosition = transform.position.x;
        flightPath = Random.Range(0, 2);
        timer = 0f;
        boolean = true;
        boolean2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 3)
            transform.position += new Vector3(0, 0, incrementZ);
        if (transform.position.z <= 3 && boolean)
            transform.position += new Vector3(incrementX, 0, 0);
        if (transform.position.x > xPosition + 2)
        {
            boolean = false;
            transform.position += new Vector3(0, 0, incrementZ);
        }
        /*
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (flightPath == 1)
            {
                if (transform.position.z > 3)
                    transform.position += new Vector3(0, 0, incrementZ);
                if (transform.position.z <= 3 && boolean)
                    transform.position += new Vector3(incrementX, 0, 0);
                if (transform.position.x > xPosition + 2)
                {
                    boolean = false;
                    transform.position += new Vector3(0, 0, incrementZ);
                }
            }
            if (flightPath == 2)
            {
                if (transform.position.z > 3.5)
                    transform.position += new Vector3(incrementX, 0, incrementZ);
                if (transform.position.z <= 3.5 && transform.position.z > 2)
                    transform.position += new Vector3(-incrementX, 0, incrementZ);
                if (transform.position.z <= 2)
                    transform.position += new Vector3(incrementX, 0, incrementZ);
            }
            if (flightPath == 0)
            {
                if (transform.position.z > 3.5 && boolean2)
                    transform.position += new Vector3(incrementX, 0, incrementZ);
                if (transform.position.z <= 3.5 && transform.position.z > 2)
                    transform.position += new Vector3(0, 0, incrementZ);
                if (transform.position.x > xPosition + 2)
                    transform.position += new Vector3(0, 0, incrementZ);
            }
            timer = 5f;
            flightPath = Random.Range(0, 2);
        }*/
        if (transform.position.z < -10 || transform.position.x > 15)
            OnDestroy();
    }
    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
