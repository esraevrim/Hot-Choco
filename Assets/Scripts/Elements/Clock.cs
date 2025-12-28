using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Player player;
    public Image clockImage;
    public Sprite[] clockArray;
    public int x;
    private void Update()
    {
        x = (int)player.remainingTime / 10;
        updateSprite();
    }
    public void updateSprite()
    {
        clockImage.sprite = clockArray[x];
    }
}
