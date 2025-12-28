using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTest : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 movement;

    public bool isDecorationCollected;
    private Interactable currentInteractable;
    public bool canMove = true;

    public Image targetImageObject;
    public Sprite gameOverScreen;
    public Button gameOverButton;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove)
        {
            // GetAxisRaw kullanarak tuþun yumuþatýlmasýný engelliyoruz, direkt 1 veya -1 alýyoruz
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // ANÝMASYON ÖNCELÝK SÝSTEMÝ
            // Bir yöne basýlýrken diðerini TAM 0 yaparak geçiþ gecikmesini önlüyoruz
            if (movement.y != 0) // Eðer yukarý veya aþaðý basýlýyorsa
            {
                _anim.SetFloat("Vertical", movement.y);
                _anim.SetFloat("Horizontal", 0);
            }
            else if (movement.x != 0) // Sadece saða veya sola basýlýyorsa
            {
                _anim.SetFloat("Horizontal", movement.x);
                _anim.SetFloat("Vertical", 0);
                Flip(); // Karakteri çevir
            }
            else // Hiçbir tuþa basýlmýyorsa
            {
                _anim.SetFloat("Vertical", 0);
                _anim.SetFloat("Horizontal", 0);
            }

            // Speed parametresi 0 olduðu an Idle'a geçiþi tetikler
            _anim.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            _anim.SetFloat("Speed", 0);
        }

        // E tuþu etkileþimi
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void FixedUpdate()
    {
        // Karakteri hareket ettiriyoruz (normalized kullanarak çapraz hýzlanmayý önlüyoruz)
        _rb.MovePosition(_rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        // Saða bakarken x = 1, sola bakarken x = -1 yaparak görüntüyü aynalýyoruz
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void GameOver()
    {
        canMove = false;
        _anim.SetFloat("Speed", 0);
        targetImageObject.sprite = gameOverScreen;
        gameOverButton.gameObject.SetActive(true);
        targetImageObject.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactableObj = other.GetComponent<Interactable>();
        if (interactableObj != null)
        {
            currentInteractable = interactableObj;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Interactable interactableObj = other.GetComponent<Interactable>();
        if (interactableObj != null && interactableObj == currentInteractable)
        {
            currentInteractable = null;
        }
    }
}