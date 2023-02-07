using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class changePieceIndicator : MonoBehaviour
{

    public static UnityEvent piecePlacedEvent = new UnityEvent();
    public static UnityEvent gameStartEvent = new UnityEvent();
    public static UnityEvent gameWonEvent = new UnityEvent();
    public GameObject OPiece;
    public GameObject XPiece;

    public GameObject torusPiece;
    GameObject newPiece;

    void Start()
    {
        piecePlacedEvent.AddListener(ChangePiece);
        gameStartEvent.AddListener(SetPiece);
        gameWonEvent.AddListener(GameWon);
    }


    void ChangePiece()
    {
        Destroy(newPiece);

        if (globals.pieceTurn == 1)
        {
           newPiece = Instantiate(XPiece, transform.position, Quaternion.identity); 
        }
        else if (globals.pieceTurn == 2)
        {
           newPiece = Instantiate(OPiece, transform.position, Quaternion.identity); 
        }
        else if (globals.pieceTurn == 3)
        {
           newPiece = Instantiate(torusPiece, transform.position, Quaternion.identity); 
        }
       
        newPiece.transform.parent = gameObject.transform;
        //newPiece.transform.position -= new Vector3(-297,-267f,74f);
        //Debug.Log("Change Called");

    }

    public void SetPiece() {
        Destroy(newPiece);
        
        newPiece = Instantiate(OPiece, transform.position, Quaternion.identity);
       
        newPiece.transform.parent = gameObject.transform;
        //newPiece.transform.position -= new Vector3(-297,-267f,74f);

       // Debug.Log("Called");
    }

    void GameWon() {
        transform.parent.gameObject.SetActive(false);
    }
}
