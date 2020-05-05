using UnityEngine.InputSystem;
using UnityEngine;
using System;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    private PlayerControls _playerControls;
    private InputAction _attack;
    private PlayerManager _playerManager;
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerManager = GetComponent<PlayerManager>();
        _playerControls = new PlayerControls();
        _attack = _playerControls.PlayerControlsActionMap.Attack;
        _attack.performed += OnAttack;
       
    }
    private void OnEnable()
    {
        _attack.Enable();
    }
    private void OnDisable()
    {
        _attack.Disable();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        //_playerManager.CanMove = false;
        _playerManager.CurrentState = State.ATTACKING;
        
        StartCoroutine(AttackCo());
    }

    private IEnumerator AttackCo()
    {
        _animator.SetBool("Walking", false);
        _animator.SetBool("Attacking", true); 
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Attacking", false);
        _playerManager.CurrentState = State.IDLE;
        _playerManager.CanMove = true;
    }
}
