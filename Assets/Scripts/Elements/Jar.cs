using UnityEngine;
using UnityEngine.EventSystems;

public class Jar : MonoBehaviour, IPointerClickHandler
{
    public GameObject kurabiyePrefab; 
    public Transform parentPanel;
    public Kitchen kitchen;
    public bool cookieOnScreen=false;

    public void OnPointerClick(PointerEventData eventData)
    {
       if (kitchen.currentIndex<5 && !cookieOnScreen)
        {
            GameObject yeniKurabiye = Instantiate(kurabiyePrefab, parentPanel);
            yeniKurabiye.transform.position = transform.position;
            cookieOnScreen = true;
        }
    }
}
