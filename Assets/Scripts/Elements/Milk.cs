using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Milk : MonoBehaviour, IPointerClickHandler
{
    public Kitchen kitchen;
    private bool isPouring = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(kitchen.currentIndex == 5) 
        {
            if (isPouring) return;

            StartCoroutine(PourMilkSequence());
        }
    }

    IEnumerator PourMilkSequence()
    {
        isPouring = true;

        for (int i = 5; i < 22; i++)
        {
            kitchen.currentIndex++;
            kitchen.ShowImage(kitchen.currentIndex);

            if (i < 8)
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }

        isPouring = false;
    }
}