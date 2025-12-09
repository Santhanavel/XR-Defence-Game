using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Base Weapon Settings")]
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float speedMultiplier = 1f;
    [SerializeField] protected float damageValue = 10f;

    [SerializeField] protected string effectName = "None";

    protected Vector3 moveDirection;
    private ObjectPoolManager poolManager;

    /// <summary>
    /// Assigns direction for the projectile.
    /// </summary>
    public virtual void MoveWeapon(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    protected void SetPoolManager(ObjectPoolManager poolManager)
    {
        this.poolManager = poolManager;
    }
    /// <summary>
    /// Call this when hitting an enemy.
    /// </summary>
    protected virtual void ApplyDamage(GameObject target)
    {
        Debug.Log($"{gameObject.name} dealt {damageValue} damage to {target.name}");

        // If target has health component
     /*   var health = target.GetComponent<HealthSystem>();
        if (health != null)
        {
            health.TakeDamage(damageValue);
        }*/
    }

    public void PlayImpactEffect(Transform HitPos)
    {
        if (!string.IsNullOrEmpty(effectName))
        {
            // Get object from pool
            GameObject stoneObj = poolManager.GetFromPool(effectName);
            if (stoneObj == null)
            {
                Debug.LogWarning("Stone object not found in pool: " + effectName);
                return;
            }

            // Position & rotate to spawn point
            stoneObj.transform.position = HitPos.position;
            stoneObj.transform.rotation = HitPos.rotation;
            stoneObj.SetActive(true);

        }
    }
}
