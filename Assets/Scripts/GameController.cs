using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Player
{
    public Image panel;
    //public Text text;
    public Button button;
    public Sprite playerImage;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{

    public GridSpace[] gridSpaceList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;
    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public GameObject startInfo;

    private string playerSide;
    private int moveCount;

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        moveCount = 0;
        restartButton.SetActive(false);
        RestartGame();
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < gridSpaceList.Length; i++)
        {
            gridSpaceList[i].SetGameControllerReference(this);
        }
    }

    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }

        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        if (gridSpaceList[0].text == playerSide && gridSpaceList[1].text == playerSide && gridSpaceList[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (gridSpaceList[3].text == playerSide && gridSpaceList[4].text == playerSide && gridSpaceList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (gridSpaceList[6].text == playerSide && gridSpaceList[7].text == playerSide && gridSpaceList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (gridSpaceList[0].text == playerSide && gridSpaceList[3].text == playerSide && gridSpaceList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (gridSpaceList[1].text == playerSide && gridSpaceList[4].text == playerSide && gridSpaceList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (gridSpaceList[2].text == playerSide && gridSpaceList[5].text == playerSide && gridSpaceList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (gridSpaceList[0].text == playerSide && gridSpaceList[4].text == playerSide && gridSpaceList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (gridSpaceList[2].text == playerSide && gridSpaceList[4].text == playerSide && gridSpaceList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (moveCount >= 9)
        {
            GameOver("draw");
        }
        else
        {
            ChangeSides();
        }
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        //newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        //oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);
        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a Draw!");
            SetPlayerColorsInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        restartButton.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        startInfo.SetActive(true);

        for (int i = 0; i < gridSpaceList.Length; i++)
        {
            gridSpaceList[i].ResetGridSpace();
        }
        
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < gridSpaceList.Length; i++)
        {
            gridSpaceList[i].button.interactable = toggle;
        }
    }

    void SetPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    void SetPlayerColorsInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        //playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        //playerO.text.color = inactivePlayerColor.textColor;
    }
    public Sprite GetPlayerSideImage()
    {
        if (playerSide == "X")
        {
            return playerX.playerImage;
        }
        else
        {
            return playerO.playerImage;
        }
    }
}