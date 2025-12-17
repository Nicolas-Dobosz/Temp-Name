using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "GameData/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public string description;
    public GameObject prefab;

    public float baseDamage;
    public float attackCooldown; 
    public float range;
    public float criticalChance;

    public WeaponType type;
    public WeightType weight;
    public RarityType rarity;

    public StatusEffect statusEffect;
    public float effectDuration;

}

public enum WeaponType { Melee, Ranged }
public enum StatusEffect { None, Poison, Freeze, Burn, Stun, Slow, Silence }
public enum WeightType { VeryLight, Light, Normal, Heavy, VeryHeavy }
public enum RarityType { None, Common, Rare, Epic, Mythic, Legendary, Boss }