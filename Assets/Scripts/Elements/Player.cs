using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 movement;

    public bool isDecorationCollected;
    private Interactable currentInteractable;
    public bool canMove = true, notedGrabbed = false;
    //public float remainingTime;

    public Image targetImageObject;
    public Sprite gameOverScreen;
    public Button gameOverButton;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        // remainingTime = 20;
    }

    void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement.y != 0)
            {
                _anim.SetFloat("Vertical", movement.y);
                _anim.SetFloat("Horizontal", 0);
            }
            else if (movement.x != 0)
            {
                _anim.SetFloat("Horizontal", movement.x);
                _anim.SetFloat("Vertical", 0);
                Flip();
            }
            else
            {
                _anim.SetFloat("Vertical", 0);
                _anim.SetFloat("Horizontal", 0);
            }
            _anim.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            _anim.SetFloat("Speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
        /*if (notedGrabbed == true) 
        {
            remainingTime -= Time.deltaTime;
        }
        if (remainingTime < 0)
        {
            GameOver();
        }*/
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void Flip()
    {
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