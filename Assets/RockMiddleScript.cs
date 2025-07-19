using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        // Debug to check if logic is found
        if (logic == null)
        {
            Debug.LogError("LogicScript not found! Make sure there's a GameObject with 'Logic' tag and LogicScript component.");
        }
        else
        {
            Debug.Log("LogicScript found successfully!");
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Trigger detected with: {collision.gameObject.name}, Layer: {collision.gameObject.layer}");

        if (collision.gameObject.layer == 3 || collision.gameObject.CompareTag("Player") || collision.gameObject.name.Contains("bird"))
        {
            if (logic != null)
            {
                logic.incrementScore(1);
                Debug.Log("Score incremented by 1 (trigger)");
            }
            else
            {
                Debug.LogError("Logic is null!");
            }
        }
    }
}
