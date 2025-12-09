using UnityEngine;
public class WeaponStone : Weapon
{
    [Header("Stone Settings")]
    [SerializeField] private float lifeTime = 5f;
    private float timer;
    private void Update()
    {
        // Move forward every frame
        transform.position += moveDirection * moveSpeed * speedMultiplier * Time.deltaTime;

        // Destroy after lifetime
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
           gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ignore self-collision
        if (other.CompareTag("Player"))
        {
            Debug.Log("Stone hit: " + other.name);

            // Apply base damage logic
            //   ApplyDamage(other.gameObject);

            PlayImpactEffect(other.transform);

        }
    }
}
