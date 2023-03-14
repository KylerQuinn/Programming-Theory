using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private const float bottomBoard = -10;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomBoard)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Player"))
            {
                gameManager.GameOver();
            }
        }
    }
}
