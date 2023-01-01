using Fioponia.Scripts.Engine;

namespace Fioponia.Scripts.Game
{
    [System.Serializable]
    public class Entity : GameObject
    {
        public int maxHealth;
        public int health;
        public override void Create()
        {
            health = maxHealth;
        }
        public virtual void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0)
            {
                Destroy();
            }
        }
        public virtual void Destroy() { }
    }
}
