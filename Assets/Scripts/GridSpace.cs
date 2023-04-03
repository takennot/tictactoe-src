using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public string text;
    private GameController gameController;
    public Image image;
    public void SetSpace()
    {
        text = gameController.GetPlayerSide();
        image.sprite = gameController.GetPlayerSideImage();
        button.interactable = false;
        image.color = Color.white;
        gameController.EndTurn();
    }
    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }
    public void ResetGridSpace()
    {
        text = "";
        image.color = Color.clear;
    }
}
