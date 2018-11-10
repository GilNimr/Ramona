using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ramona.Sprites;
using System.Collections.Generic;
using XELibrary;

namespace Ramona
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private CelAnimationManager celAnimationManager;

        private InputHandler inputHandler;

        private Player player;
        private Ghost ghost;
        public List<Sprite> sprites;

        public static int ScreenWidth;
        public static int ScreenHeight;

        public Game1()
        {
             
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 600;

            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            Content.RootDirectory = "Content";

            inputHandler = new InputHandler(this);
            Components.Add(inputHandler);

            celAnimationManager = new CelAnimationManager(this, "Textures\\");
            Components.Add(celAnimationManager);

            player = new Player(this);
            Components.Add(player);

            ghost = new Ghost(this,player);
            Components.Add(ghost);
        }

        protected override void Initialize()
        {
           
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player.Load(spriteBatch);
            ghost.Load(spriteBatch);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
