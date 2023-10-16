using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tilt : MonoBehaviour
{
    private float angle;
    private float speed;
    private float tiltAngle;
    private float xPosition;
    public GameObject missile;
    public Text scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        speed = 4f;
        angle = 0;
        xPosition = 0;
        tiltAngle = Time.deltaTime*45f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 10)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (angle < 45)
                    angle += tiltAngle;              
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }
            else
            {
                if (angle > 0f)
                    angle -= tiltAngle;               
            }
            transform.localRotation = Quaternion.Euler(0, 0, -angle);
        }
        if (transform.position.x > -10)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (angle > -45)
                    angle -= tiltAngle;
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
            else
            {
                if (angle < 0f)
                    angle += tiltAngle;
            }
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
        xPosition = transform.position.x;
        if (Input.GetKeyUp(KeyCode.D))
            Instantiate(missile, new Vector3(xPosition + 0.85f, transform.position.y, transform.position.z), Quaternion.identity);
        if (Input.GetKeyUp(KeyCode.A))
            Instantiate(missile, new Vector3(xPosition - 0.85f, transform.position.y, transform.position.z), Quaternion.identity);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void incScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}