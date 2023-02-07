using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class threeDButton : MonoBehaviour
{
    

    public int positionFlat;
    public int positionDeep;
    
    public Material Plain;
    public Material Click;
    public Material Hover;
    public Material Win;

    public int localPiece = 0; //0==empty, 1==X, 2==O, 3=Torus
    public int VictoryCount = 0;

    public GameObject OPiece;
    public GameObject XPiece;

    public GameObject torusPiece;

    public GameObject endMenu;
    public GameObject endMenuText;
    public Button playForSecondButton;
    Text victoryText;
    int localWinner;

    private void Victory(int winningPieceType, int blockOneDeep, int blockOneFlat, int blockTwoDeep, int blockTwoFlat, int blockThreeDeep, int blockThreeFlat) {
        
        //Find the gameobject reference which contain the winning pieces, change their color.
        //Make an end menu pop up: "X piece wins! Play again? Menu? Exit? Play for second place?"
        if (globals.pieceThatWon != winningPieceType || VictoryCount > 0 && localWinner == winningPieceType) //This means that something can't run this if that piece already won, unless it won in multiple different ways on one square
        {
            localWinner = winningPieceType;        
            globals.SomeoneWon = true;
            VictoryCount++;
            endMenu.SetActive(true);
            string placeFinished = "Victory";

            if (globals.playingForSecond == true)
            {
                placeFinished = "Second";
                playForSecondButton.interactable = false;
            }
            else
            {
                globals.pieceThatWon = winningPieceType;
            }

            GameObject[] boxes = GameObject.FindGameObjectsWithTag("Grid box");
            foreach (GameObject box in boxes)
            {
                if ((box.GetComponent<threeDButton>().positionFlat-1 == blockOneFlat && box.GetComponent<threeDButton>().positionDeep-1 == blockOneDeep) || (box.GetComponent<threeDButton>().positionFlat-1 == blockTwoFlat && box.GetComponent<threeDButton>().positionDeep-1 == blockTwoDeep) || (box.GetComponent<threeDButton>().positionFlat-1 == blockThreeFlat && box.GetComponent<threeDButton>().positionDeep-1 == blockThreeDeep)) //Find winning boxes
                {
                    box.GetComponent<Renderer>().material = Win;
                }
            }

            

            victoryText = endMenuText.GetComponent<Text>(); //Victory Text
            if (winningPieceType == 1)
            {
                victoryText.text = placeFinished + " for X!";
            }
            else if (winningPieceType == 2)
            {
                victoryText.text = placeFinished + " for O!";
            }
            else if (winningPieceType == 3)
            {
                victoryText.text = placeFinished + " for Torus!";
            }

            changePieceIndicator.gameWonEvent.Invoke();
        }

        
    }
    
    private void OnMouseDown() {
        if(localPiece==0 && globals.SomeoneWon==false){
            GetComponent<Renderer>().material = Click;
        }
        
    }

    private void OnMouseEnter() {
        if(localPiece==0 && globals.SomeoneWon==false){
            GetComponent<Renderer>().material = Hover;
        }
    }

    private void OnMouseExit() {
        if(localPiece==0 && globals.SomeoneWon==false){
            GetComponent<Renderer>().material = Plain;
        }
    }


    private void OnMouseUpAsButton() {
        

        if(localPiece==0 && globals.SomeoneWon==false){
            
            
            if(globals.pieceTurn==1 || globals.pieceTurn ==4) {
                globals.BoardArray[positionDeep-1, positionFlat-1] = 1;

                var newPiece = Instantiate(XPiece, transform.position, Quaternion.identity);
                newPiece.transform.parent = gameObject.transform;
                globals.pieceTurn=2;
                localPiece=1;
                GetComponent<Renderer>().material = Plain;
            }
            else if(globals.pieceTurn==2) {
                globals.BoardArray[positionDeep-1, positionFlat-1] = 2;

                var newPiece = Instantiate(OPiece, transform.position, Quaternion.identity);
                newPiece.transform.parent = gameObject.transform;
                globals.pieceTurn=3;
                localPiece=2;
                GetComponent<Renderer>().material = Plain;
            }
            else if(globals.pieceTurn==3) {
                globals.BoardArray[positionDeep-1, positionFlat-1] = 3;

                var newPiece = Instantiate(torusPiece, transform.position, Quaternion.identity);
                newPiece.transform.parent = gameObject.transform;
                globals.pieceTurn=1;
                localPiece=3;
                GetComponent<Renderer>().material = Plain;
            }

            if (globals.pieceThatWon == globals.pieceTurn)
            {
                globals.pieceTurn++;
            }
        
        changePieceIndicator.piecePlacedEvent.Invoke();
        
        }

        

        //Check for Victory
        for (int i = 0; i < 9; i++) //Staight up and down
        {
            if (globals.BoardArray[0,i] == globals.BoardArray[1,i] && globals.BoardArray[0,i] == globals.BoardArray[2,i] && globals.BoardArray[0,i] != 0)
            {
                Victory(globals.BoardArray[0,i], 0, i, 1, i, 2, i);
            }
        }

        for (int i = 0; i < 3; i++) //all regular 2-dimensional boards
        {
            for (int j = 0; j < 3; j++) //straight
            {
                    if (globals.BoardArray[i,j*3] == globals.BoardArray[i,j*3+1] && globals.BoardArray[i,j*3+2] == globals.BoardArray[i,j*3] && globals.BoardArray[i,j*3] != 0)
                    {
                        Victory(globals.BoardArray[i,j*3], i, j*3, i, j*3+1, i, j*3+2);
                    }
                    
                    if (globals.BoardArray[i,j] == globals.BoardArray[i,j+3] && globals.BoardArray[i,j+6] == globals.BoardArray[i,j] && globals.BoardArray[i,j] != 0)
                    {
                        Victory(globals.BoardArray[i,j],i,j+3,i,j+6,i,j);
                    }
            }

            if (globals.BoardArray[i,0] == globals.BoardArray[i,4] && globals.BoardArray[i,8] == globals.BoardArray[i,0] && globals.BoardArray[i,0] != 0) //diagonals
            {
                    Victory(globals.BoardArray[i,0],i,4,i,8,i,0);
            }

            if (globals.BoardArray[i,2] == globals.BoardArray[i,4] && globals.BoardArray[i,6] == globals.BoardArray[i,2] && globals.BoardArray[i,2] != 0)
            {
                    Victory(globals.BoardArray[i,2],i,4,i,6,i,2);
            }


            //This next is the remaining 2-dimensional sequences involving z. 
            //Here, i doesn't correlate to the z dimension like the last ifs, but still require a loop of 3.
            if (globals.BoardArray[0,i+0] == globals.BoardArray[1,i+3] && globals.BoardArray[2,i+6] == globals.BoardArray[0,i+0] && globals.BoardArray[0,i+0] != 0)
            {
                    Victory(globals.BoardArray[0,i+0],1,i+3,2,i+6,0,i+0);
            }

            if (globals.BoardArray[0,i+6] == globals.BoardArray[1,i+3] && globals.BoardArray[2,i+0] == globals.BoardArray[0,i+6] && globals.BoardArray[0,i+6] != 0)
            {
                    Victory(globals.BoardArray[0,i+6],1,i+3,2,i+0,0,i+6);
            }

                if (globals.BoardArray[0,i*3+0] == globals.BoardArray[1,i*3+1] && globals.BoardArray[2,i*3+2] == globals.BoardArray[0,i*3+0] && globals.BoardArray[0,i*3+0] != 0)
                {
                    Victory(globals.BoardArray[0,i*3+0],1,i*3+1,2,i*3+2,0,i*3+0);
                }
                if (globals.BoardArray[0,i*3+2] == globals.BoardArray[1,i*3+1] && globals.BoardArray[2,i*3+0] == globals.BoardArray[0,i*3+2] && globals.BoardArray[0,i*3+2] != 0)
                {
                    Victory(globals.BoardArray[0,i*3+2],1,i*3+1,2,i*3+0,0,i*3+2);
                }
        }

        //3-dimensional diagonals
            if (globals.BoardArray[0,0] == globals.BoardArray[1,4] && globals.BoardArray[2,8] == globals.BoardArray[0,0] && globals.BoardArray[0,0] != 0) //diagonals
            {
                Victory(globals.BoardArray[0,0],1,4,2,8,0,0);
            }

            if (globals.BoardArray[0,2] == globals.BoardArray[1,4] && globals.BoardArray[2,6] == globals.BoardArray[0,2] && globals.BoardArray[0,2] != 0)
            {
                Victory(globals.BoardArray[0,2],1,4,2,6,0,2);
            }
            
            if (globals.BoardArray[0,6] == globals.BoardArray[1,4] && globals.BoardArray[2,2] == globals.BoardArray[0,6] && globals.BoardArray[0,6] != 0)
            {
                Victory(globals.BoardArray[0,6],1,4,2,2,0,6);
            }
            
            if (globals.BoardArray[0,8] == globals.BoardArray[1,4] && globals.BoardArray[2,0] == globals.BoardArray[0,8] && globals.BoardArray[0,8] != 0)
            {
                Victory(globals.BoardArray[0,8],1,4,2,0,0,8);
            }

        
            int FillCount = 0;
            GameObject[] boxes = GameObject.FindGameObjectsWithTag("Grid box");
            foreach (var box in boxes)
            {
                if (box.GetComponent<threeDButton>().localPiece != 0) {
                    FillCount++;
                }
                if (FillCount == 27)
                {
                    globals.SomeoneWon = true;
                    endMenu.SetActive(true);
                    victoryText.text = "Draw!";
                }
            }
    }

    
    
    //When clicked, add a piece at that location
    //Global array of buttons and piece values
    //If filled (=0) then don't register it as a button
    //Do some algorithm to determine whether someone has won
    //Make menu and win screen
    //Check for tie and logic for playing for second
    //Pause screen? exit button on start menu
    //Make a small piece in the corner to show whose turn it is
    //make networking
    //audio?

    //Possible evolutions for the future:
    //2-player and 3-player gamemodes with the center square blocked out
    //Gravity-style gamemode: can only put a piece on top of another
    //4x4 mode
    //Timed mode/speed chess style
    //Damn, I could make a whole real-ass game out of this. Add some customization of pieces, backgrounds, mobile support?, etc.
    //Maybe later.


    
}

