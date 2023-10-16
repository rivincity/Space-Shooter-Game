using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move2 : MonoBehaviour
{
    private float incrementZ;
    public GameObject missile;
    private GameObject ship;
    public ParticleSystem ParticleSystem;
    float timer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        incrementZ = 0.2f;
        ship = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
            transform.position -= new Vector3(0, 0, incrementZ);
        else
            transform.position += new Vector3(0, 0, incrementZ);
        if (transform.position.z > 20)
            OnDestroy();
    }
    void OnDestroy()
    {
        Destroy(missile.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ship.GetComponent<tilt>().incScore();
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        ParticleSystem particleSystem = (ParticleSystem)Instantiate(ParticleSystem, transform.position, Quaternion.identity);
        Destroy(particleSystem.gameObject, 1.5f);
    }
}
