using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : IPlayerState
{
    private PlayerControls _playerControls;
    private InputAction _moveAction;
    private InputAction _attackAction;
    private InputAction _interactAction;
    private Vector2 _change;

    public PlayerIdleState()
    {
        _playerControls = new PlayerControls();
        _moveAction = _playerControls.PlayerControlsActionMap.Move;
        _attackAction = _playerControls.PlayerControlsActionMap.Attack;
        _interactAction = _playerControls.PlayerControlsActionMap.Interaction;
        _moveAction.performed += OnMove;
        _moveAction.canceled += OnMove;
        _attackAction.performed += OnAttack;
        _interactAction.performed += OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext obj)
    {
       
    }

    private void OnAttack(InputAction.CallbackContext obj)
    {
       
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _change = context.ReadValue<Vector2>();
    }


    public void EnterState(PlayerController player)
    {
 
        _moveAction.Enable();
        
    }

    public void FixedUpdate(PlayerController player)
    {
        
    }

    public void OnCollisionEnter(PlayerController player, Collision2D collision)
    {
        
    }

    public void Update(PlayerController player)
    {
        if(_change != Vector2.zero)
        {
            player.Change = _change;
            player.TransitionToState(player.MoveState);
        }
    }
}
