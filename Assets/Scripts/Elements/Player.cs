using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D _rb;
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
    }

    void Update()
    {
        if (canMove) 
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement * speed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactableObj = other.GetComponent<Interactable>();

        if (interactableObj != null)
        {
            currentInteractable = interactableObj;
            Debug.Log("Etkileþime girmek için E'ye bas.");
        }
    }
    public void GameOver()
    {
        canMove = false;
        targetImageObject.sprite = gameOverScreen;
        gameOverButton.gameObject.SetActive(true);
        targetImageObject.gameObject.SetActive(true);

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