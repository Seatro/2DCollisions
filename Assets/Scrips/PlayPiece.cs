using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPiece : MonoBehaviour
{
    private GameManager gameManager;
    private PlayPieceManager playPieceManager;

    private float resetTime = 3f;
    
    private void Start()
    {
        var gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        var playPieceManagerObject = GameObject.Find("Playpiece Manager");
        playPieceManager = playPieceManagerObject.GetComponent<PlayPieceManager>();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        resetTime -= Time.deltaTime;
        Debug.Log("Reset time = " + resetTime);

        if (resetTime <= 0)
        {
            playPieceManager.ResetGame();

            resetTime = 3f;
        }
    }
}
