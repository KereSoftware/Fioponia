using Microsoft.Xna.Framework.Input;

namespace Fioponia.Scripts.Game.Entities
{
    [System.Serializable]
    public sealed class Player : Entity
    {
        public Storage inventory;
        public override void Update()
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W)) position.Y -= 1;
            if (state.IsKeyDown(Keys.S)) position.Y += 1;
            if (state.IsKeyDown(Keys.A)) position.X -= 1;
            if (state.IsKeyDown(Keys.D)) position.X += 1;
        }
    }
}
