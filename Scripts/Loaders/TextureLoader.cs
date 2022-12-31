using Fioponia.Scripts.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Fioponia.Scripts.Loaders
{
    public static class TextureLoader
    {
        public static Dictionary<string, Texture2D> LoadedTextures = new();
        public static Dictionary<string, GameObjectAnimation> LoadedAnimations = new();
        public static Texture2D GetTexture(string datamod, string path)
        {
            string name = datamod + "/" + path;
            if (!LoadedTextures.ContainsKey(name))
            {
                LoadedTextures.Add(
                    name,
                    Texture2D.FromFile(
                        Main.instance.GraphicsDevice,
                        "datamods/" + name + ".png"
                    )
                );
            }
            return LoadedTextures[name];
        }
        public static Rectangle GetAnimationFrame(string datamod, string path, int frame)
        {
            string name = datamod + "/" + path;
            if (!LoadedAnimations.ContainsKey(name))
            {
                LoadedAnimations.Add(
                    name,
                    JsonConvert.DeserializeObject<GameObjectAnimation>(
                        File.ReadAllText("datamods" + name + ".anim")
                    )
                );
            }
            return LoadedAnimations[name][frame];
        }
    }
}
