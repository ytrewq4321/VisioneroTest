using UnityEngine;

public class PlayerCombatSystem : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private float attackDistance;
    [SerializeField] private float damage;
    [SerializeField]  private Collider target;
    private PlayerAnimation animation;

    void Start()
    {
        animation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        if (target == null )
        {
            SearchTarget();
        }

        if (target != null)
        {
            transform.LookAt(target.transform);
            animation.Attacked.Invoke();
            CheckDistanceToTarget();
        }
    }

    private void Attack()
    {
        if (target != null)
        {
            target.GetComponent<IDamagable>().TakeDamage(damage);
        }
    }

    private void SearchTarget()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, attackDistance,targetLayerMask);
        if (enemies.Length > 0)
        {
            target = enemies[0];
        }
    }

    private void CheckDistanceToTarget()
    {
        var heading = target.transform.position - transform.position;

        if (!target.gameObject.activeSelf || heading.sqrMagnitude>attackDistance*attackDistance)
        {
            target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
