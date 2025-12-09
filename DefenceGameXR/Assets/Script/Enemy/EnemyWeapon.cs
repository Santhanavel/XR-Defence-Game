using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private Transform stoneSpawnPos;   // where stone will spawn
    [SerializeField] private ObjectPoolManager spawner; // your pool manager
    [SerializeField] private string weaponName = "Stone"; // pool key

    [Header("Attack Settings")]
    [SerializeField, Range(0f, 10f)] private float attackDelay = 2f;
    [SerializeField, Range(1f, 10f)] private int attackCount = 1;
    [SerializeField, Range(0f, 10f)] private float destroyDelay = 2f;

    private bool isAttacking = false;

    /// <summary>
    /// Call this from enemy AI when attack starts.
    /// </summary>
    public void Attack()
    {
        if (!isAttacking)
            StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        isAttacking = true;

        for (int i = 0; i < attackCount; i++)
        {
            SpawnWeaponStone();

            yield return new WaitForSeconds(attackDelay);
        }

        isAttacking = false;
    }

    private void SpawnWeaponStone()
    {
        // Get object from pool
        GameObject stoneObj = spawner.GetFromPool(weaponName);

        if (stoneObj == null)
        {
            Debug.LogWarning("Stone object not found in pool: " + weaponName);
            return;
        }

        // Position & rotate to spawn point
        stoneObj.transform.position = stoneSpawnPos.position;
        stoneObj.transform.rotation = stoneSpawnPos.rotation;
        stoneObj.SetActive(true);

        // Get weapon script
        WeaponStone stone = stoneObj.GetComponent<WeaponStone>();
        if (stone != null)
        {
            // Assign direction → forward direction of spawn point
            stone.MoveWeapon(stoneSpawnPos.forward);
        }

    }
}