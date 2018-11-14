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
<<<<<<< HEAD
        ScrollingBackgroundManager scrollingBackgroundManager;

        public SpriteFont font_damage;
=======

        public SpriteFont font_damage;
        public SpriteFont font_life;
>>>>>>> master

        private CelAnimationManager celAnimationManager;

        private InputHandler inputHandler;

        Random random;

        private Player player;
<<<<<<< HEAD


        public List<Sprite> sprites;
=======
     
        
        public static List<Sprite> sprites;
>>>>>>> master

        public static int ScreenWidth;
        public static int ScreenHeight;

        public Game1()
        {
            random = new Random();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 600;

<<<<<<< HEAD
            scrollingBackgroundManager = new ScrollingBackgroundManager(this, "Textures\\");
            Components.Add(scrollingBackgroundManager);


=======
>>>>>>> master
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            Content.RootDirectory = "Content";

            inputHandler = new InputHandler(this);
            Components.Add(inputHandler);

            celAnimationManager = new CelAnimationManager(this, "Textures\\");
            Components.Add(celAnimationManager);



            player = new Player(this);
<<<<<<< HEAD


=======
          
            
>>>>>>> master
            sprites = new List<Sprite>()
            {
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
<<<<<<< HEAD
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                player
            };

            foreach (Sprite sprite in sprites)
            {
                Components.Add(sprite);

            }


=======

                player
            };
            
            foreach(Sprite sprite in sprites)
            {
                Components.Add(sprite);
                
            }
            
            
>>>>>>> master
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font_damage = Content.Load<SpriteFont>("Font");
<<<<<<< HEAD

            scrollingBackgroundManager.AddBackground("street", "Street", new Vector2(0, 0), new Rectangle(0, 0, 1065, 392), 10, 0.5f, Color.White);
            scrollingBackgroundManager.AddBackground("road", "Road", new Vector2(0, 390), new Rectangle(0, 0, 1066, 356), 100, 0.1f, Color.White);


            foreach (Sprite sprite in sprites)
            {
                sprite.Load(spriteBatch, font_damage);
            }

=======
            font_life = Content.Load<SpriteFont>("Font");

            foreach (Sprite sprite in sprites)
            {
                sprite.Load(spriteBatch, font_damage,font_life);
            }
           
>>>>>>> master
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
<<<<<<< HEAD

            if (inputHandler.KeyboardHandler.IsKeyDown(Keys.Right) && player.position.X >= (graphics.GraphicsDevice.Viewport.Width / 2.0f))
                scrollingBackgroundManager.ScrollRate = -2.0f;
            else if (inputHandler.KeyboardHandler.IsKeyDown(Keys.Left) && player.position.X <= 21)
            {
                scrollingBackgroundManager.ScrollRate = 2.0f;
            }
            else
                scrollingBackgroundManager.ScrollRate = 0.0f;

=======
            for(int i=0; i< sprites.Count;i++)
            {
                if (sprites[i].death_on_screen > 3)
                {
                    Components.Remove(sprites[i]);
                    sprites.RemoveAt(i);
                    i--;
                }
            }
>>>>>>> master

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

<<<<<<< HEAD
            spriteBatch.Begin();
            
            scrollingBackgroundManager.Draw("street", spriteBatch);
            scrollingBackgroundManager.Draw("road", spriteBatch);


           
            spriteBatch.End();
=======
>>>>>>> master
            base.Draw(gameTime);
        }
    }
}
