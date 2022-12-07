using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Animator animator;
    public UnityEvent Attacked = new();

    private readonly int  moveState = Animator.StringToHash("Base Layer.Move");
    private readonly int attackState = Animator.StringToHash("Base Layer.Attack");
    private readonly int idleState = Animator.StringToHash("Base Layer.Idle");
    private int currentState;

    private bool isAttacked;
    private bool isMoved;
    private bool isIdled;

    private void Start()
    {
        Attacked.AddListener(() => isAttacked = true);
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        CheckMovement();
        var state = GetState();

        isIdled = false;
        isMoved = false;
        isAttacked = false;

        if (state == currentState) return;
        animator.CrossFade(state, 0.5f, 0);
        currentState = state;
    }

    private int GetState()
    {
        if (isAttacked) return attackState;
        if (isIdled) return idleState;
        if (isMoved) return moveState;
        return currentState;
    }

    private void CheckMovement()
    {
        if (agent.hasPath)
            isMoved = true;
        else
            isIdled = true;
    }
}
