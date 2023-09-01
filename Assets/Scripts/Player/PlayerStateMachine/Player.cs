using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Core core { get; private set; }
    public PlayerMachine playerMachine { get; private set; }
    public PlayerData playerData;
    public PlayerInput playerInput { get; private set; }
    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }


    #region PlayerState
    public P_IdleState p_IdleState;
    public P_MoveState p_MoveState;
    public P_JumpState p_JumpState;
    public P_LandState p_LandState;
    public P_InAirState p_InAirState;
    public P_WallClimb p_WallClimb;
    public P_WallGrabState p_WallGrabState;
    public P_WallSlideState P_WallSlideState;
    public P_WallJumpState P_WallJumpState;
    public P_LedgeClimb p_LedgeClimb;
    public P_DashState p_DashState;
    public P_AttackState p_AttackState;
    #endregion

    public PlayerWeaponGet weapons { get; private set; }
    public Transform DashDirectionIndicator;

    private void Awake()
    {
        core = GetComponentInChildren<Core>();
        playerMachine = new PlayerMachine();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

        p_IdleState = new P_IdleState(playerMachine, this, playerData);
        p_MoveState = new P_MoveState(playerMachine, this, playerData);
        p_JumpState = new P_JumpState(playerMachine, this, playerData);
        p_LandState = new P_LandState(playerMachine, this, playerData);
        p_InAirState = new P_InAirState(playerMachine, this, playerData);
        p_WallClimb = new P_WallClimb(playerMachine, this, playerData);
        p_WallGrabState = new P_WallGrabState(playerMachine, this, playerData);
        P_WallSlideState = new P_WallSlideState(playerMachine, this, playerData);
        P_WallJumpState = new P_WallJumpState(playerMachine, this, playerData);
        p_LedgeClimb = new P_LedgeClimb(playerMachine, this, playerData);
        p_DashState = new P_DashState(playerMachine, this, playerData);
        p_AttackState = new P_AttackState(playerMachine, this, playerData);


        playerMachine.keyValuePairs.Add(PlayerStateId.Move, p_MoveState);
        playerMachine.keyValuePairs.Add(PlayerStateId.Idle, p_IdleState);
        playerMachine.keyValuePairs.Add(PlayerStateId.Jump, p_JumpState);
        playerMachine.keyValuePairs.Add(PlayerStateId.InAir, p_InAirState);
        playerMachine.keyValuePairs.Add(PlayerStateId.Land, p_LandState);
        playerMachine.keyValuePairs.Add(PlayerStateId.WallClimb, p_WallClimb);
        playerMachine.keyValuePairs.Add(PlayerStateId.WallGrab, p_WallGrabState);
        playerMachine.keyValuePairs.Add(PlayerStateId.WallSlide, P_WallSlideState);
        playerMachine.keyValuePairs.Add(PlayerStateId.WallJump, P_WallJumpState);
        playerMachine.keyValuePairs.Add(PlayerStateId.Ledge, p_LedgeClimb);
        playerMachine.keyValuePairs.Add(PlayerStateId.Dash, p_DashState);
        playerMachine.keyValuePairs.Add(PlayerStateId.Attack, p_AttackState);

    }

    private void Start()
    {
        weapons = GetComponent<PlayerWeaponGet>();

        p_AttackState.SitWeapon(weapons.weapon[(int)PlayerInput.attackInput.primaryAttack],core);

        playerMachine.Begin(PlayerStateId.Idle);

    }   

    private void Update()
    {
        playerMachine.currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        playerMachine.currentState.PhysicsUpdate();
    }

    private void AnimationTrigger()
    {
        playerMachine.currentState.AnimationTrigger();
    }

    private void AnimationFinish()
    {
        playerMachine.currentState.AnimationFinish();
    }


}
