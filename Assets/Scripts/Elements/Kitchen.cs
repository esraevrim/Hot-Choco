using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Kitchen : MonoBehaviour,Interactable
{
    private bool canWork = false;
    public Image kitchenImage, plate,jar,table, cookie,milk;
    public Sprite[] imageArray;
    public Player player;
    public int currentIndex =0;
    public Jar jarController;
    public void Interact()
    {
        if (canWork == false)
        {
            ShowImage(currentIndex);
            canWork = true;
            player.canMove = false;
        }
        else
        {
            HideImage();
            canWork = false;
            player.canMove = true;
        }
    }
    private void Update()
    {
        if (canWork == true) {
            ShowImage(currentIndex);
        }
    }

    public void ShowImage(int imageNumber)
    {
        kitchenImage.sprite = imageArray[imageNumber];
        kitchenImage.gameObject.SetActive(true);
        jar.gameObject.SetActive(true);
        table.gameObject.SetActive(true); 
        plate.gameObject.SetActive(true);
        cookie.gameObject.SetActive(true);
        milk.gameObject.SetActive(true);    
    }

    public void HideImage()
    {
        kitchenImage.gameObject.SetActive(false);
        jar.gameObject.SetActive(false);
        table.gameObject.SetActive(false);
        plate.gameObject.SetActive(false);
        cookie.gameObject.SetActive(false); 
        milk.gameObject.SetActive(false);
    }
}
