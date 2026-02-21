namespace DesiShadow.Gameplay
{
    public interface IDamageable
    {
        void TakeDamage(int damageAmount);
        bool IsDead { get; }
    }
}
