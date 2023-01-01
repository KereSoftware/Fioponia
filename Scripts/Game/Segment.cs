using Fioponia.Scripts.Game.Entities;
using System.Collections.Generic;

namespace Fioponia.Scripts.Game
{
    [System.Serializable]
    public class Segment
    {
        public List<Entity> entities = new();
        public Dictionary<(int, int), Tile> tiles = new();
        public void Update()
        {
            foreach (var entity in entities)
            {
                if (entity is Building && !((Building)entity).builded)
                {
                    continue;
                }
                entity.Update();
            }
        }
    }
}
