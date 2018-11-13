using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ramona.Sprites;
using System;
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

        public SpriteFont font_damage;

        private CelAnimationManager celAnimationManager;

        private InputHandler inputHandler;

        Random random;

        private Player player;
     
        
        public static List<Sprite> sprites;

        public static int ScreenWidth;
        public static int ScreenHeight;

        public Game1()
        {
            random = new Random();
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
          
            
            sprites = new List<Sprite>()
            {
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                player
            };
            
            foreach(Sprite sprite in sprites)
            {
                Components.Add(sprite);
                
            }
            
            
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font_damage = Content.Load<SpriteFont>("Font");

            foreach(Sprite sprite in sprites)
            {
                sprite.Load(spriteBatch, font_damage);
            }
           
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            for(int i=0; i< sprites.Count;i++)
            {
                if (sprites[i].death_on_screen > 3)
                {
                    Components.Remove(sprites[i]);
                    sprites.RemoveAt(i);
                    i--;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
