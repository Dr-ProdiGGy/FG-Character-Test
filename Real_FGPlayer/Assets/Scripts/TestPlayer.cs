using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

[RequireComponent(typeof(Rigidbody2D))]
public class TestPlayer : MonoBehaviour
{
    private FGController controller;
    [SerializeField] CharacterSO charStats;
    private GameObject player;
    Rigidbody rb;

    Vector2 input;
    private int inputCounter;
    private int[] inputBuffer;

    private InputStates inputStates;
    
    private enum InputStates
    {
        NEUTRAL = 5,
        FORWARD = 6,
        BACK = 4,
        DOWN = 2,
        UP = 8,
        DF = 3,
        DB = 1,
        UF = 9,
        UB = 7,
        PUNCH,
        KICK,
        SLASH,
        HS
    }

    private void Awake()
    {
        controller = new FGController();
        controller.FGControls.Enable();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }


    void Start()
    {

        AllowAirDash();
    }


    void FixedUpdate()
    {
        PlayerMove();
        InputCheck();
    }

    private void OnEnable()
    {
        controller.FGControls.Enable();
    }


    private void AllowAirDash()
    {
        if(charStats.p_Name == "Potemkin" && charStats.p_Name == "Justice")
        {
            Debug.Log("This character isn't allowed to air dash");
        }
    }

    private void PlayerMove()
    {
        rb.velocity = charStats.p_WalkSpeed * controller.FGControls.Walk.ReadValue<Vector2>();
    }

    private void PlayerJump()
    {

    }

    private InputStates InputCheck()
    {
        switch(controller.FGControls.Check.ReadValue<Vector2>()) 
        {
            case Vector2 v when v.Equals(new Vector2(0, 0)):
                inputStates = InputStates.NEUTRAL;   
                break;

            case Vector2 v when v.Equals(new Vector2(1, 0)): 
                inputStates = InputStates.FORWARD;
                break;

            case Vector2 v when v.Equals(new Vector2(-1, 0)):
                inputStates = InputStates.BACK;
                break;

            case Vector2 v when v.Equals(new Vector2(0, 1)):
                inputStates = InputStates.UP;
                break;

            case Vector2 v when v.Equals(new Vector2(0, -1)):
                inputStates = InputStates.DOWN;
                break;

            case Vector2 v when v.Equals(new Vector2(1, 1)):
                inputStates = InputStates.DF;
                break;

        }
        Debug.Log(inputStates);
        return inputStates;
    }

}
