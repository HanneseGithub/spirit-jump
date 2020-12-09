using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField]
    private int gemValue;

    private Game game;

    private void Awake()
    {
        // Make reference to game automatically, without having to assign it yourself.
        game = FindObjectOfType<Game>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            game.GetComponent<Game>().addCollectiblesScore(gemValue);
            Destroy(gameObject);
        }
    }
}
