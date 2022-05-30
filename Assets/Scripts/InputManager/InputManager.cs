using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    //Asset
    public PlayerControls playerControls;

    //Unity component
    public PlayerInput playerInput;

    //Check if its playing with gamepad
    public bool isGamePad;

    private bool isInteractingUI, pausedUI;

    public static InputManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        InteractingWithUI();
    }
    

    private void InteractingWithUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            playerControls.Controls.Disable();
        }
        else
        {
            playerControls.Controls.Enable();   
        }
    }
    


    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void OnDeviceChange(PlayerInput playerInput)
    {
        isGamePad = playerInput.currentControlScheme.Equals("Gamepad");
    }
}