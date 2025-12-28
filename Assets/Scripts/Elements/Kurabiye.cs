using UnityEngine;
using UnityEngine.EventSystems;

public class Kurabiye : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Rigidbody2D rb;
    private RectTransform rectTransform;
    private Canvas mainCanvas;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rectTransform = GetComponent<RectTransform>();

        // Canvas'ý bul (Root canvas'ý bulmak daha güvenlidir)
        mainCanvas = GetComponentInParent<Canvas>();
        if (mainCanvas != null && mainCanvas.rootCanvas != null)
        {
            mainCanvas = mainCanvas.rootCanvas;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Týkladýðýmýzda yer çekimini ve fiziði kapatýyoruz
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // ÖNEMLÝ: Tutarken nesnenin saða sola çarpýp titrememesi için:
        rb.isKinematic = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (mainCanvas == null) return;

        // Mouse hareketiyle objeyi hareket ettir
        rectTransform.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Býraktýðýmýzda fiziði ve yer çekimini geri açýyoruz
        rb.gravityScale = 1f;
        rb.isKinematic = false;
    }
}