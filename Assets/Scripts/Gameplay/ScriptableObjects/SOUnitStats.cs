using UnityEngine;

public enum Class
{
    Attacker,
    Supporter
}
[CreateAssetMenu(fileName = "Stats", menuName = "Unit Stats")]
public class SOUnitStats : ScriptableObject
{
    [Header("Info")]
    public string Name; //Lock
    public string ID; //Lock => Bester ID management
    public Sprite Portrait;
    [TextArea]
    public string Description; //Lock
    public Class Class; //Lock
    public float PreparationTime;//CanChange
    public int Clonite;//CanChange
    [Header("Health")]
    public float MaxHealth;//CanChange
    public float HealingAmountPerSecond;//CanChange
    [Header("Basic")]
    public float Morale;
    public float Charisma;//Lock
    public float Speed;
    public float Agility;
    public float DodgeChance;
    [Header("Damage Attributes")]
    public float CloseRange;
    public float FarRange;
    public float Accuracy;
    public float CriticalChance;
    public float CriticalDamage;
    [Header("Damage")]
    public float MeleeDamage;
    public float RangeDamage;
    public float PoisonDamage;
    public float FireDamage;
    public float CryoDamage;
    public float ElectrifiedDamage;
    public float ExplosionDamage;
    [Header("DamageResistance")]
    [Range(0, 100)] public float BulletResistance;
    [Range(0, 100)] public float MeleeResistance;
    [Range(0, 100)] public float PoisonResistance;
    [Range(0, 100)] public float FireResistance;
    [Range(0, 100)] public float CryoResistance;
    [Range(0, 100)] public float ElectrifiedResistance;
    [Range(0, 100)] public float ExplosionResistance;

}
