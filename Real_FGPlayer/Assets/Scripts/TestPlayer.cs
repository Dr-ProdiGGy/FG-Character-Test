using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

[RequireComponent(typeof(Rigidbody))]
public class TestPlayer : MonoBehaviour
{
    FGController controller;
    [SerializeField] CharacterSO charStats;
    Rigidbody rb;

    Vector2 input;

    private bool isDashingAllowed;
    private int inputCounter;

    private void Awake()
    {
        

        controller.FGControls.Walk.performed += ctx => PlayerMove();
        controller.FGControls.Walk.canceled += ctx => isDashingAllowed = false;
        //controller.FGControls.Move.performed += ctx => InputCheck();

    }

    // Start is called before the first frame update
    void Start()
    {
       AllowAirDash();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        controller.FGControls.Enable();
    }

    private void OnDisable()
    {
        controller.FGControls.Disable();
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
        if(!isDashingAllowed)
        {
            rb.velocity = charStats.p_WalkSpeed * controller.FGControls.Walk.ReadValue<Vector2>();
            isDashingAllowed = true;
        }
    }

    private Vector2 InputCheck()
    {

        return new Vector2(0,1);
    }
}
