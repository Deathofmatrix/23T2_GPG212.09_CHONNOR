using Cinemachine;
using EasyAudioSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    private PlayerController playerActionAsset;
    private InputAction move;

    private bool canBoatRunSoundPlay = false;

    private Rigidbody rb;
    public float movementForce = 1f;
    public float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField] private Camera playerCamera;

    [SerializeField] private GameObject inventoryCanvas;
    [SerializeField] private GameObject inventoryTutorial;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        playerActionAsset = new PlayerController();
    }

    private void OnEnable()
    {
        move = playerActionAsset.Player.Move;
        playerActionAsset.Player.OpenInventory.started += OpenInventory;
        playerActionAsset.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionAsset.Player.OpenInventory.started -= OpenInventory;
        playerActionAsset.Player.Enable();
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (move.ReadValue<Vector2>() != Vector2.zero)
        {
            if (canBoatRunSoundPlay)
            {
                canBoatRunSoundPlay = false;
                Debug.Log("Boat Running");
                FindObjectOfType<AudioManager>().Pause("BoatIdle");
                FindObjectOfType<AudioManager>().Play("BoatRunning");
            }
        }
        else
        {
            if (!canBoatRunSoundPlay)
            {
                canBoatRunSoundPlay = true;
                Debug.Log("Boat Idle");
                FindObjectOfType<AudioManager>().Pause("BoatRunning");
                FindObjectOfType<AudioManager>().Play("BoatIdle");
            }
        }
    }

    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0f;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }

        LookAt();
    }

    private void OpenInventory(InputAction.CallbackContext obj)
    {
        inventoryTutorial.SetActive(false);
        FindObjectOfType<AudioManager>().Play("OpenInventory");
        bool isInvOpen = inventoryCanvas.activeInHierarchy;
        inventoryCanvas.SetActive(!isInvOpen);
        Cursor.visible = !isInvOpen;
        if (!isInvOpen)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
}
