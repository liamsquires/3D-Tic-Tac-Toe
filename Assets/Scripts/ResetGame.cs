using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    public Material boxColor;
    public Button playForSecondButton;


    public void quitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
        Debug.Log("Quitting");
    }


    public void ResetBoard()
    {
        globals.BoardArray = new int[,] {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};

        //find pieces and destory them
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("Piece");
        foreach (var piece in pieces)
        {
            Destroy(piece);
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Grid box");
        foreach (var box in boxes)
        {
            box.GetComponent<Renderer>().material = boxColor;
            box.GetComponent<threeDButton>().localPiece = 0;
            box.GetComponent<threeDButton>().VictoryCount = 0;
        }

        globals.pieceTurn = 2;
        globals.pieceThatWon = 0;

        playForSecondButton.interactable = true;

        changePieceIndicator.gameStartEvent.Invoke();
        //find boxes and set static int pieceTurn = 2; / public int localPiece = 0;
        //Also set their color
    }
}
