using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        #region Engine Update & Draw
        public void EngineUpdate()
        {

        }
        public void EngineDraw()
        {

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