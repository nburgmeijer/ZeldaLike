using UnityEngine;

public class LogController : MonoBehaviour
{
    [SerializeField] private float _chaseRadius;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _thrust;

    private Transform _target;
    private EnemyStateBase _currentState;
    private EnemyStateBase _lastState;
    private Animator _logAnimator;
    private Rigidbody2D _logRigidBody;
    private Rigidbody2D _targetRigidBody;
    private PlayerController _playerController;

    public readonly LogSleepState SleepState = new LogSleepState();
    public readonly LogChaseState ChaseState = new LogChaseState();
    public readonly LogAttackState AttackState = new LogAttackState();

    public Animator LogAnimator { get => _logAnimator;}
    public Rigidbody2D LogRigidBody { get => _logRigidBody; }
    public Transform Target { get => _target; }
    public float ChaseRadius { get => _chaseRadius; }
    public float MoveSpeed { get => _moveSpeed; }
    public float AttackRadius { get => _attackRadius; }
    public Rigidbody2D TargetRigidBody { get => _targetRigidBody;}
    public float Thrust { get => _thrust; }
    public PlayerController PlayerController { get => _playerController; }

    private void Awake()
    {
        _logAnimator = GetComponent<Animator>();
        _logRigidBody = GetComponent<Rigidbody2D>();
        _target = GameObject.FindWithTag("Player").transform;
        _targetRigidBody = _target.GetComponent<Rigidbody2D>();
        _playerController = _target.GetComponent<PlayerController>();
    }
    void Start()
    {
        TransitionToState(SleepState);
    }

    void FixedUpdate()
    {
        _currentState.FixedUpdate(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _currentState.OnCollisionEnter(this, collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _currentState.OnEnterTriggerEnter(this, collision);
    }

    public void TransitionToState(EnemyStateBase state) 
    {
        _lastState = _currentState;
        _currentState = state;
        _currentState.EnterState(this);
    }
}
