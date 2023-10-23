using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterSO : ScriptableObject
{
    #region PrivValues and States
    [SerializeField] private string charName;
    [SerializeField] private int charHP;
    [SerializeField] private int charJumpAmount;
    [SerializeField] private int charAirDashAmount;
    [SerializeField] private float charWalkSpeed;
    [SerializeField] private float charRunSpeed;
    [SerializeField] private float charRunAccel;
    [SerializeField] private string charWeight;
    [SerializeField] private PlayerStates charStates;

    

    private enum PlayerStates 
    {
        WALKING,
        RUNNING,
        DASHING,
        JUMPING,
        SUPER_JUMP,
        CROUCHING,
        BLOCKING,
        FD,
        IB
    }
    #endregion

    #region Get Variables
    public string p_Name { get { return charName; }}
    public int p_HP { get { return charHP; }}
    public int p_JumpAmount { get { return charJumpAmount; }}
    public int p_AirDashAmount { get { return charAirDashAmount; }}
    public float p_WalkSpeed { get { return charWalkSpeed; }}
    public float p_RunSpeed { get { return charRunSpeed; }}
    public float p_RunAccel { get { return charRunAccel; }}
    public string p_Weight { get { return charWeight; }}
    //public PlayerStates p_States { get { return charStates; } set { charStates = value; } }
    #endregion



}
