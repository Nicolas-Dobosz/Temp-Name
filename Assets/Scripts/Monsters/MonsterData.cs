using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "GameData/Monster")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public string description;

    public GameObject mainSprite;
    public GameObject weaponSprite; // J'ai séparé les deux pour qu'on puisse les manipuler séparément

    public int healthPoint;
    public int baseDamage;
    public float attackCooldown; 
    public float range;
    public float criticalChance;

    public MonsterSpeedType speedType;
    public MonsterType monsterType;
    public MonsterBiome monsterBiome;
    public int monsterFloorApparition;

    public MonsterWeaponType weaponType;
    public MonsterStatusEffect statusEffect;
    public float effectDuration;
}

public enum MonsterWeaponType { Melee, Ranged }
public enum MonsterStatusEffect { None, Poison, Freeze, Burn, Stun, Slow }
public enum MonsterSpeedType { VerySlow, Slow, Normal, Fast, VeryFast }
public enum MonsterType { Week, Normal, Strong }
public enum MonsterBiome { Forest, Desert }