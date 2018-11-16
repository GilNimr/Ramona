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

        ScrollingBackgroundManager scrollingBackgroundManager;



        public SpriteFont font_damage;
        public SpriteFont font_life;

        public static float map_position = 0 ;

        private CelAnimationManager celAnimationManager;

        private InputHandler inputHandler;

        Random random;

        private Player player;

        Ghost ghost_for_cloning ;
        Ghost ghosty;

        public static List<Sprite> sprites;


        public static int ScreenWidth;
        public static int ScreenHeight;

        public Game1()
        {
            random = new Random();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 600;


            scrollingBackgroundManager = new ScrollingBackgroundManager(this, "Textures\\");
            Components.Add(scrollingBackgroundManager);




            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            Content.RootDirectory = "Content";

            inputHandler = new InputHandler(this);
            Components.Add(inputHandler);

            celAnimationManager = new CelAnimationManager(this, "Textures\\");
            Components.Add(celAnimationManager);

            

            player = new Player(this);
            ghost_for_cloning = new Ghost(this, player, random);
            sprites = new List<Sprite>()
            {
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                new Ghost(this,player,random),
                ghost_for_cloning,
                player
            };
            
            foreach(Sprite sprite in sprites)
            {
                Components.Add(sprite);
                
            }

            Components.Remove(ghost_for_cloning);//we dont want to draw this ghost

        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font_damage = Content.Load<SpriteFont>("Font");

            scrollingBackgroundManager.AddBackground("Street_2", "Street_2", new Vector2(0, 0), new Rectangle(0, 0, 1065, 644), 70, 0.5f, Color.White);
           // scrollingBackgroundManager.AddBackground("street", "Street", new Vector2(0, 0), new Rectangle(0, 0, 1065, 392), 70, 0.5f, Color.White);
            scrollingBackgroundManager.AddBackground("road", "Road", new Vector2(0, 390), new Rectangle(0, 0, 1066, 356), 100, 0.1f, Color.White);


    font_life = Content.Load<SpriteFont>("Font");

            foreach (Sprite sprite in sprites)
            {
                sprite.Load(spriteBatch, font_damage,font_life);
            }
           

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            if (inputHandler.KeyboardHandler.IsKeyDown(Keys.Right) && player.position.X >= (ScreenWidth / 1.25f))
            {
                scrollingBackgroundManager.ScrollRate = -2.0f;

                map_position += player.speed;


                foreach (Sprite sprite in sprites)
                {
                    if (sprite is Ghost)
                    {
                        sprite.position.X -= player.speed;
                    }
                }
            }
            else if (inputHandler.KeyboardHandler.IsKeyDown(Keys.Left) && player.position.X <= 21)
            {
                scrollingBackgroundManager.ScrollRate = 2.0f;

                map_position -= player.speed ;
                foreach (Sprite sprite in sprites)
                {
                    if (sprite is Ghost)
                    {
                        sprite.position.X += player.speed;
                    }
                }
            }
            else
            {
                scrollingBackgroundManager.ScrollRate = 0.0f;
                
            }
            if (map_position >= 500)
            {
                map_position = 0;
               ghosty=(Ghost) ghost_for_cloning.Clone();
                ghosty.position.X = ScreenWidth + 75;
                ghosty.position.Y = random.Next(0, Game1.ScreenHeight);
                sprites.Add(ghosty);
                Components.Add(ghosty);
            }
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


            spriteBatch.Begin();
            scrollingBackgroundManager.Draw("Street_2", spriteBatch);
            //  scrollingBackgroundManager.Draw("street", spriteBatch);
            // scrollingBackgroundManager.Draw("road", spriteBatch);



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
