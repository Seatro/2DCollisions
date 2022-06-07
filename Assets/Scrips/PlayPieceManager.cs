using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPieceManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnArea;
    [SerializeField] private GameObject playPiece;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] GameManager gameManager;

    private bool pieceInPlay;
    private GameObject currentPlayPiece;
    
    // Update is called once per frame
    void Update()
    {
        SpawnPlayPiece();

        CollisionManager();
    }

    private void SpawnPlayPiece()
    {
        if (pieceInPlay) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(clickRay, out hit);
            Debug.Log(hit.collider.gameObject.ToString());
            if(hit.collider.gameObject == spawnArea)
            {
                spawnPoint.position = hit.point;
                var spawnRotation = new Quaternion(0, 0, 0, 0);

                currentPlayPiece = Instantiate(playPiece, hit.point, spawnRotation);
                pieceInPlay = true;
            }
        }
    }

    private void CollisionManager()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
