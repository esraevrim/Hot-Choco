using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour , Interactable

{
    private bool canClean;
    public Player player;
    public GameObject targetWallPanel;
    public int eraesedCount = 0;
    public void Interact()
    {
        if ( canClean == false)
        {
            canClean = true;
            player.canMove = false;
            ShowImage();
            player.timePanel.SetActive(false);
        }
        else
        {
            HideImage();
            canClean = false;
            player.canMove = true;
            player.timePanel.SetActive(true);
        }
    }
    private void Update()
    {
        if (eraesedCount==3) 
        {
            player.taskWall=true;
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    public void ShowImage()
    {
        targetWallPanel.SetActive(true);
    }

    public void HideImage()
    {
        targetWallPanel.SetActive(false);
    }
}
