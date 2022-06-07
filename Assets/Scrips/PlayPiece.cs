using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPiece : MonoBehaviour
{
    private GameManager gameManager;
    
    private void Start()
    {
        var gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionGameObject = collision.gameObject;
        if (collisionGameObject.GetComponent<Peg>() != null)
        {
            var peg = collisionGameObject.GetComponent<Peg>();
            gameManager.AddScore(peg.pegScore);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var triggerGameObject = collision.gameObject;

        if (triggerGameObject.GetComponent<ScoreZone>() != null)
        {
            var scoreZone = triggerGameObject.GetComponent<ScoreZone>();
            gameManager.AddScore(scoreZone.scoreZoneScore);
        }
    }
}
