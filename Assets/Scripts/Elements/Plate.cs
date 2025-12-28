using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Kitchen kitchen;
    public Jar jar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        kitchen.currentIndex++;
        collision.gameObject.SetActive(false);
        jar.cookieOnScreen = false;
    }
}
