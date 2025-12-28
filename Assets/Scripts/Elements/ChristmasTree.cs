using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChristmasTree : MonoBehaviour, Interactable
{
    public Image targetImageObject,krampusImage,BacgroundImage;
    public Sprite[] imageArray;
    public Player player;
    public int currentIndex = 0;
    public bool canDecorate, krampus,timeRunning=false;
    public Sprite finalTree;
    private Vector2 startPos, currentPos, differencePos;
    private float xPosition,remainingTime=15, timePassed=0f;
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
        }
        else if(!krampus)
        { 
            HideImage();
            canDecorate = false;
            player.canMove = true;
            BacgroundImage.gameObject.SetActive(false);
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
                GetComponent<SpriteRenderer>().sprite = finalTree;
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
                    }
                    remainingTime -= Time.deltaTime;
                }
               else if (remainingTime <= 0) 
                {
                    player.GameOver();
                }
                if (timePassed < 6f)
                {
                    krampusImage.transform.Translate(Vector2.right * 75f * Time.deltaTime);
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