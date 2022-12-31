using Fioponia.Scripts.Engine;
using Fioponia.Scripts.Loaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Fioponia
{
    public class Main : Game
    {
        #region Instances
        public static Main instance;
        #endregion

        #region Framerate
        public const double FramerateTime = 1d / 50d;
        public double updateTimer;
        public double drawTimer;
        #endregion

        #region Screen
        public static Vector2 screenSize;
        public static float screenScale;

        public static Vector2 cameraPosition = Vector2.Zero;
        public static float cameraZoom = 1;
        #endregion

        #region Graphics
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        #endregion

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            instance = this;

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            Window.AllowUserResizing = true;

            base.Initialize();

            testObject = new GameObject() { datamod = "core", path = "graphics/test/test" };
        }

        GameObject testObject;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        #region Engine Update & Draw
        public void EngineUpdate()
        {

        }
        public void EngineDraw()
        {
            screenSize = Window.ClientBounds.Size.ToVector2();
            screenScale = MathF.Max(screenSize.X, screenSize.Y) / 1280f;


            GraphicsDevice.Clear(Color.Gray);

            _spriteBatch.Begin();
            DrawObject(testObject);
            _spriteBatch.End();
        }
        public void DrawObject(GameObject obj)
        {
            var texture = TextureLoader.GetTexture(obj.datamod, obj.path);
            if (!obj.animated)
            {
                var offset = texture.Bounds.Size.ToVector2() / 2 - obj.position + cameraPosition;
                _spriteBatch.Draw(texture, screenSize / 2, null, Color.White, obj.rotation, offset, screenScale * cameraZoom, SpriteEffects.None, 0);
            }
            else
            {
                var rect = TextureLoader.GetAnimationFrame(obj.datamod, obj.path, obj.frame);
                var offset = rect.Size.ToVector2() / 2 - obj.position + cameraPosition;
                _spriteBatch.Draw(texture, screenSize / 2, rect, Color.White, obj.rotation, offset, screenScale * cameraZoom, SpriteEffects.None, 0);
            }
        }
        #endregion

        #region Base Update & Draw
        protected override void Update(GameTime gameTime)
        {
            updateTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (updateTimer >= FramerateTime)
            {
                updateTimer %= FramerateTime;
                EngineUpdate();
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            drawTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (drawTimer >= FramerateTime)
            {
                drawTimer %= FramerateTime;
                EngineDraw();
            }
            base.Draw(gameTime);
        }
        #endregion
    }
}