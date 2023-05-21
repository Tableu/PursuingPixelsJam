using Systems.Modifiers;
using UnityEngine;

[CreateAssetMenu(fileName = "New Regen Effect", menuName = "Effects/Regen", order = 0)]
public class HealthPeriodicEffect : PeriodicEffect
{
    public float BaseHeal;
    public override PeriodicEffectInstance CreateInstance(ModifiableTarget target)
    {
        return new RegenEffect(target.GetComponent<Health>(),tickPeriod, BaseHeal);
    }

    public override void Apply(ModifiableTarget target)
    {
        
    }

    public override void Remove(ModifiableTarget target)
    {
        
    }
    private class RegenEffect : PeriodicEffectInstance
    {
        private readonly float _baseHeal;
        private readonly Health _health;
        public RegenEffect(Health health, float tickPeriod, float baseHeal) : base(tickPeriod)
        {
            _health = health;
            _baseHeal = baseHeal;
        }
        protected override void Tick()
        {
            _health.Heal(_baseHeal);
        }
    }
}


