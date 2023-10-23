using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

[RequireComponent(typeof(Rigidbody2D))]
public class TestPlayer : MonoBehaviour
{
    #region Player Variables
    private FGController controller;
    [SerializeField] CharacterSO charStats;
    private GameObject player;
    Rigidbody rb;

    private bool onP1Side;
    private bool isGrounded;
    private bool otgState;

    private Vector2 input;
    [SerializeField] private int maxBufferLength = 10;
    private InputStates inputStates;
    private InputStates[] inputBuffer;
    private InputStates[] inputIterator; 

    public enum InputStates
    {
        NONE,
        NEUTRAL = 5,
        FORWARD = 6,
        BACK = 4,
        DOWN = 2,
        UP = 8,
        DF = 3,
        DB = 1,
        UF = 9,
        UB = 7
    }
    #endregion

    private void Awake()
    {
        controller = new FGController();
        controller.FGControls.Enable();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }


    void Start()
    {
        onP1Side = true;
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


    private void AllowAirDash() //Some characters shouldn't be allowed to do air dashes cuz that would be cheap :)
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

    private InputStates InputCheck() //Checks which input is being down with either the attack buttons or the movement input keys
    {
        switch(controller.FGControls.Check.ReadValue<Vector2>()) 
        {
            case Vector2 v when v.Equals(new Vector2(0, 0)):
                inputStates = InputStates.NEUTRAL;   
                break;

            case Vector2 v when v.Equals(new Vector2(1, 0)): 
                inputStates = InputStates.FORWARD;
                PushIntoBuffer(inputStates);
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

            case Vector2 v when v.Equals(new Vector2(1, -1)):
                inputStates = InputStates.DF;
                break;
            
            case Vector2 v when v.Equals (new Vector2(-1, -1)):
                inputStates = InputStates.DB;
                break;

            case Vector2 v when v.Equals(new Vector2(1, 1)):
                inputStates = InputStates.UF;
                break;

            case Vector2 v when v.Equals(new Vector2 (-1, 1)):
                inputStates = InputStates.UB;
                break;
        }
        Debug.Log(inputStates);
        return inputStates;
    }

    public void PushIntoBuffer(InputStates input) //Pushes the current input that's being done into the inputBuffer array list
    {
        
        for(int i = 0; i < maxBufferLength; i++) 
        {
            if (i == 0) //First input should be nothing
            {
                inputBuffer[0] = InputStates.NONE;
            }

            else //From then on
            {
                //What I want rn: inputBuffer is equal to the current input that's being done. 
                inputBuffer[i] = input;
                Debug.Log(inputBuffer[i]);
            }
        }
    }

    //LOAD MOVELIST FUNCTION HERE
}
