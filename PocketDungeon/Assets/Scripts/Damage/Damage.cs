/// <summary>   
/// Damage base component   
/// </summary>   
public interface IDamage
{
    float GetDamage();
}

/// <summary>   
/// Concrete damage   
/// </summary>   
public class BaseDamage : IDamage
{
    public float GetDamage() => 0f;
}

/// <summary>   
/// Abstract Decorator   
/// </summary>   
public abstract class OverDamageDecorator : IDamage
{
    private IDamage _damage;
    public OverDamageDecorator(IDamage aDamage) => this._damage = aDamage;
    public virtual float GetDamage() => this._damage.GetDamage();
}

/// <summary>   
/// Concrete Decorator
/// </summary>   
public class PhysicalDamage : OverDamageDecorator
{
    private float _damage;
    public float Damage
    {
        get => _damage < 0 ? 0 : _damage;
        set => _damage = value;
    }
    public PhysicalDamage(IDamage aDamage) : base(aDamage) { }
    public override float GetDamage() => base.GetDamage() + Damage;
}

/// <summary>   
/// Concrete Decorator   
/// </summary>   
public class FireDamage : OverDamageDecorator
{
    private float _damage;
    public float Damage
    {
        get => _damage < 0 ? 0 : _damage;
        set => _damage = value;
    }

    public FireDamage(IDamage aDamage) : base(aDamage) { }
    public override float GetDamage() => base.GetDamage() + Damage;
}

/// <summary>   
/// Concrete Decorator   
/// </summary>   
public class WaterDamage : OverDamageDecorator
{
    private float _damage;
    public float Damage
    {
        get => _damage < 0 ? 0 : _damage;
        set => _damage = value;
    }
    public WaterDamage(IDamage aDamage) : base(aDamage) { }
    public override float GetDamage() => base.GetDamage() + Damage;
}