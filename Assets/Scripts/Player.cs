using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [Header("Movement")]
    [SerializeField] float movementSpeed = 5f;
    [Header("Padding")]
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    //BoundingBox
    Vector2 minBounds;
    Vector2 maxBounds;
    //Shooter
    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds() //find boudaries of the screen
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0)); //lower left
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1)); //upper right
    }

    void Move() // takes movement called by OnMove, and applies it continuously
    {
        Vector2 delta   = rawInput * movementSpeed * Time.deltaTime;
        Vector2 newPos  = new Vector2();

        newPos.x        = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft  , maxBounds.x - paddingRight); // restrict x to Viewport, taking into account padding value
        newPos.y        = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop); // restrict y to Viewport, taking into account padding value

        transform.position = newPos;
    }

    void OnMove(InputValue value) // we need continuous movement, this is dont by the move () function
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
