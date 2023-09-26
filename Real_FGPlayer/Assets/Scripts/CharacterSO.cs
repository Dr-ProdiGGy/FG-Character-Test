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
    [SerializeField] private string charWeight;
    

    private enum States 
    {
        WALK,
        RUN,
        DASH,
        JUMP,
        SUPER_JUMP,
        CROUCH,
        ATTACK,
        BLOCK,
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
    public string p_Weight { get {  return charWeight; }}
    #endregion



}
