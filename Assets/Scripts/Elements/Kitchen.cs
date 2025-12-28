using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kitchen : MonoBehaviour, Interactable
{
    private bool canWork = false;
    public Image kitchenImage, plate, jar, table, cookie, milk;
    public GameObject kitchenPanel;
    public Sprite[] imageArray;
    public Player player;
    public int currentIndex = 0;
    public Sprite finalKitchen;

    public void Interact()
    {
        canWork = !canWork; // Kýsa yoldan true/false deðiþimi

        if (canWork)
        {
            ShowImage(currentIndex); // Panel açýlýnca mevcut durumu göster
            player.canMove = false;
            kitchenPanel.SetActive(true);

            player.timePanel.SetActive(false);
        }
        else
        {
            HideImage();
            player.canMove = true;
            kitchenPanel.SetActive(false);
            player.timePanel.SetActive(true);
        }
    }

    private void Update()
    {
        // BURASI TEMÝZLENDÝ. Artýk Update içinde sürekli ShowImage çaðýrmýyoruz.

        // Görev tamamlandý mý kontrolü:
        if (currentIndex >= 22 && !player.taskKitchen)
        {
            GetComponent<SpriteRenderer>().sprite = finalKitchen;
            player.taskKitchen = true;
        }
    }

    // Plate scripti bu fonksiyonu çaðýracak
    public void NextStep()
    {
        currentIndex++; // Sayýyý artýr
        ShowImage(currentIndex); // Ve hemen yeni resmi göster
    }

    public void ShowImage(int imageNumber)
    {
        if (imageNumber < imageArray.Length)
        {
            kitchenImage.sprite = imageArray[imageNumber];
        }

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