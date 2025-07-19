using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapForce;
    public LogicScript logic;

    private bool isBirdAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBirdAlive)
        {
            myRigidbody.velocity = Vector2.up * flapForce;  //short hand for y = 0 and x = 1
        }

        birdOffScreen();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isBirdAlive = false;

    }

    private void birdOffScreen()
    {
        if (transform.position.y < -30 || transform.position.y > 30 || transform.position.x < -20)
        {
            logic.gameOver();
            isBirdAlive = false;
        }
    }
}
