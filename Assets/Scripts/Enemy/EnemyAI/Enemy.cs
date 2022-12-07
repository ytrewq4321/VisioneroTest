using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public StateMachine EnemyBehaivorSM;
    public RunToHouseState RunToHouse;
    public AttackHouseState AttackHouse;
    public AttackPlayerState AttackPlayer;

    public Transform NearestHouse { get; private set; }
    public Transform AttackTarget { get; private set; }

    [SerializeField] private float attackDistance;
    [SerializeField] private float damage;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask houseLayer;

    private Animator animator;
    private NavMeshAgent agent;

    private void Start()
    {
        GameManager.Instance.HouseDestroyed.AddListener(FindNearestHouse);
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        EnemyBehaivorSM = new StateMachine();
        RunToHouse = new RunToHouseState(this, EnemyBehaivorSM);
        AttackHouse = new AttackHouseState(this, EnemyBehaivorSM);
        AttackPlayer = new AttackPlayerState(this, EnemyBehaivorSM);
        EnemyBehaivorSM.Initialize(RunToHouse);
    }

    private void Update()
    {
        EnemyBehaivorSM.CurrentState.LogicUpdate();
    }

    public void SetAnimationBool(string param, bool value)
    {
        animator.SetBool(param, value);
    }
    public bool CheckPlayerAround()
    {
        Collider[] playersUnits = Physics.OverlapSphere(transform.position, attackDistance, playerLayer, QueryTriggerInteraction.Ignore);
        if (playersUnits.Length > 0)
        {
            AttackTarget = playersUnits[0].transform;
            return true;
        }
        return false;
    }

    public bool CheckHouseAround()
    {
        Collider[] houses = Physics.OverlapSphere(transform.position, attackDistance, houseLayer);
        if (houses.Length > 0)
        {
            AttackTarget = houses[0].transform;
            return true;
        }
        return false;
    }

    private void Attack()
    {
        if (AttackTarget != null)
            AttackTarget.GetComponent<IDamagable>().TakeDamage(damage);
    }

    public void SetHouseTarget()
    {
        FindNearestHouse();
        agent.SetDestination(NearestHouse.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

    public bool IsPlayerOutRange()
    {  
        var distance = (AttackTarget.position - transform.position).sqrMagnitude;
        if(distance > attackDistance * attackDistance)
        {
            //currentTarget = NearestHouse
            AttackTarget = null;
            return true;
        }
        return false;
    }

    public bool IsHouseDestoyed()
    {
        return !AttackTarget.gameObject.activeSelf;
    }

    public void LookAtTarget(Transform target)
    {
        transform.LookAt(target);
    }

    public void StopMovement()
    {
        agent.isStopped = true;
    }

    public void ResumeMovement()
    {
        agent.isStopped = false;
    }

    public void FindNearestHouse()
    {
        float minDistance = float.MaxValue;
        foreach (var house in GameManager.Instance.HousesList)
        {
            var distance = (house.transform.position - transform.position).sqrMagnitude;
            if (distance < minDistance)
            {
                minDistance = distance;
                NearestHouse = house.transform;
            }
        }
    }
}

   

