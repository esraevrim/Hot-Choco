using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Kitchen kitchen;
    public Jar jar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Sadece "Cookie" etiketli obje çarparsa iþlem yap (Güvenlik önlemi)
        if (collision.gameObject.CompareTag("Cookie"))
        {
            // Kitchen scriptine "Bir sonraki adýma geç" diyoruz
            kitchen.NextStep();

            // Kurabiyeyi kapat
            collision.gameObject.SetActive(false);

            // Kavanoza "Artýk yeni kurabiye üretilebilir" diyoruz
            jar.cookieOnScreen = false;
        }
    }
}