using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats stats;   // diisi dengan asset SO
    private float currentHp;

    void Start()
    {
        currentHp = stats.hp;
        Debug.Log($"{stats.enemyName} | HP {stats.hp} | DPS {stats.DPS:F1} | PowerScore {stats.PowerScore:F0}");
    }

   void Update()
    {
        if (transform.position.x > -6f)
            transform.Translate(Vector3.left * stats.speed * Time.deltaTime);
    }

    public void TakeDamage(float dmg)
    {
        currentHp -= dmg * (1f - stats.armor);
        if (currentHp <= 0f)
        {
            CoinManager.Instance.AddCoin(Mathf.RoundToInt(stats.cost * 0.5f));
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        TakeDamage(9999f); // klik enemy = langsung mati (untuk demo)
    }
}