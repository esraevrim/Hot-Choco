using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChristmasTree : MonoBehaviour, Interactable
{
    public Image targetImageObject,krampusImage, BacgroundImage;
    public Sprite[] imageArray;
    public Player player;
    public int currentIndex = 0;
    public bool canDecorate, krampus,timeRunning=false;
    public GameObject deco1,deco2,deco3,deco4,deco5,christmasPanel;
    private Vector2 startPos, currentPos, differencePos;
    private float xPosition,remainingTime=10, timePassed=0f;
    private void Start()
    {
        targetImageObject.gameObject.SetActive(false);
    }
    public void Interact()
    {
        if (canDecorate == false && !krampus)
        {
            ShowImage(currentIndex);
            canDecorate = true;
            player.canMove = false;
            BacgroundImage.gameObject.SetActive(true);
            christmasPanel.SetActive(true);
            player.timePanel.SetActive(false);
        }
        else if(!krampus)
        { 
            HideImage();
            canDecorate = false;
            player.canMove = true;
            BacgroundImage.gameObject.SetActive(false);
            christmasPanel.SetActive(false);
            player.timePanel.SetActive(true);
        }

    }
    private void Update()
    {
        if (canDecorate && player.isDecorationCollected)
        {
            if (Input.GetMouseButtonDown(0) && currentIndex != imageArray.Length-1 && !krampus)
            {
                currentIndex++;
                ShowImage(currentIndex);
                if(currentIndex ==3)
                {
                    krampus = true;
                    krampusImage.gameObject.SetActive(true);
                }

            }
            else if(currentIndex  == imageArray.Length-1) 
            { 
                
                deco3.SetActive(true);
                deco4.SetActive(true);
                player.taskTree = true;
            }
            if (krampus) 
            {
               if ( remainingTime>0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        startPos = Input.mousePosition;

                    }
                    if (Input.GetMouseButton(0))
                    {
                        currentPos = Input.mousePosition;
                        differencePos = currentPos - startPos;
                        xPosition = ((float)differencePos.x / Screen.width) * -10;

                    }
                    if ((int)xPosition < imageArray.Length)
                    {
                        if (xPosition > 0)
                        {
                            ShowImage(currentIndex + (int)xPosition);
                        }
                    }
                    if (currentIndex + (int)xPosition == 6)
                    {
                        currentIndex = currentIndex + (int)xPosition;
                        krampusImage.gameObject.SetActive(false);
                        krampus = false;
                        deco1.SetActive(true);
                        deco2.SetActive(true);
                        deco5.SetActive(true);
                    }
                    remainingTime -= Time.deltaTime;
                }
               else if (remainingTime <= 0) 
                {
                    player.GameOver();
                }
                if (timePassed < 2.5f)
                {
                    krampusImage.transform.Translate(Vector2.right * 1f * Time.deltaTime);
                    timePassed += Time.deltaTime;
                }

            }
        }
    }
    public void ShowImage(int imageNumber)
    {
        targetImageObject.sprite = imageArray[imageNumber];
        targetImageObject.gameObject.SetActive(true);
    }

    public void HideImage()
    {
        targetImageObject.gameObject.SetActive(false);
    }
}