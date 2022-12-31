using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Fioponia.Scripts.Engine
{
    [Serializable]
    public class GameObject
    {
        public string datamod;
        public string name;

        public string path;
        public bool animated;
        public int frame;

        public Vector2 position = Vector2.Zero;
        public float rotation;
        public Rectangle hitbox;

        public virtual void Create() { }
        public virtual void Update() { }
    }
    [Serializable]
    public class GameObjectAnimation : List<Rectangle> { }
}
