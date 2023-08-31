using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Camera playerCam;
    public GameObject flagPoint;
    public eTeamColor teamColor;
    public float moveSpeed = 5f;
    public bool hasFlag = false;

    public FlagObject flagObject;
    public GameObject nearbyMine;

    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;
    Vector3 direction = Vector3.one;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            //May change this to disable the camera later in order to have spectators after death
            Destroy(playerCam.gameObject);
            this.enabled = false;
        }
    }

    void Start()
    {
        if (!TryGetComponent<Rigidbody2D>(out rb))
            throw new MissingReferenceException("No Rigidbody2D on PlayerMovement");

        if (!TryGetComponent<Animator>(out animator))
            throw new MissingReferenceException("No Animator on PlayerMovement");
    }

    void Update()
    {
        //Movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Direction
        if (movement.x < 0)
            direction.x = -1;
        else if (movement.x > 0)
            direction.x = 1;

        if (flagObject != null)
        {
            //Grab or Drop Flag
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!hasFlag) PickupFlag();
                else DropFlag();
            }
        }
        else if (nearbyMine != null)
        {
            //Mine
            if (Input.GetKey(KeyCode.E))
            {
                
            }
        }

        //Dev Action
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DevAction();
        }


        //Animator
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        transform.localScale = direction;
    }

    public void PickupFlag()
    {
        if (flagPoint.TryGetComponent<SpriteRenderer>(out SpriteRenderer flagSprite))
        {
            //Set the flag color based on what flag we grabbed
        }
        hasFlag = true;
        flagPoint.SetActive(hasFlag);

        flagObject.gameObject.SetActive(false);

        UIManager.Instance.SetActionText("Drop Loot (E)");
    }

    public void DropFlag()
    {

        flagObject.gameObject.transform.localPosition = transform.localPosition;
        flagObject.gameObject.transform.localScale = transform.localScale;

        hasFlag = false;
        flagPoint.SetActive(hasFlag);

        flagObject.gameObject.SetActive(true);

    }

    void DevAction()
    {

    }
}
