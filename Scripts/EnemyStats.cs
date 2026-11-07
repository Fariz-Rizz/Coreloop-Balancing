using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats_New", menuName = "Game/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public string enemyName;
    public float hp;
    public float damage;
    public float speed;
    public float cooldown;
    [Range(0f, 1f)] public float armor;
    public int cost;

    // Dihitung otomatis, sama dengan rumus di spreadsheet
    public float DPS => damage / cooldown;
    public float EffHP => hp / (1f - armor);
    public float PowerScore => DPS * EffHP;
}