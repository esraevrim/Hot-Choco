using UnityEngine;
using UnityEngine.UI;

public class Bed : MonoBehaviour,Interactable
{
    public Image targetBedImage;
    public Sprite[] imageArray;
    public Player player;
    private float xPosition,yPosition;
    public bool canTidy=false,completed=false;
    public Sprite finalBed;
    private Vector2 startPos, currentPos, differencePos;

    private void Start()
    {
        targetBedImage.gameObject.SetActive(false);
    }
    public void Interact() 
    {
        if (canTidy == false)
        {
            ShowImage((int)xPosition+(int)yPosition);
            canTidy = true;
            player.canMove = false;
        }
        else
        {
            HideImage();
            canTidy = false;
            player.canMove = true;
        }
    }

    public void ShowImage(int imageNumber)
    {
        targetBedImage.sprite = imageArray[imageNumber];
        targetBedImage.gameObject.SetActive(true);
    }

    public void HideImage()
    {
        targetBedImage.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (canTidy && !completed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;

            }
            if (Input.GetMouseButton(0))
            {
                currentPos = Input.mousePosition;
                differencePos = currentPos - startPos;
                xPosition = ((float)differencePos.x / Screen.width) * -5;
                yPosition = ((float)(differencePos.y / Screen.height) * 5);
              
            }
            if ((int)xPosition+(int)yPosition < imageArray.Length)
            {
                ShowImage((int)xPosition+(int)yPosition);
            }
            if((int)xPosition+(int)yPosition == 4)
            {
                completed = true;
                GetComponent<SpriteRenderer>().sprite = finalBed;
            }
        }
        
    }
}
