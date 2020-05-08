using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


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
        StartCoroutine(AttackCo());
    }

    private IEnumerator AttackCo()
    {
        _attack.Disable();
        _animator.SetBool("Attacking", true);
        yield return null;
        _playerManager.CurrentState = State.ATTACKING;  
        yield return new WaitForSeconds(0.14f);
        _animator.SetBool("Attacking", false);
        _playerManager.CurrentState = _playerManager.LastState;
        yield return new WaitForSeconds(0.2f);
        _attack.Enable();
    }


}
