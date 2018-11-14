using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XELibrary;

namespace Ramona.Sprites
{
    public class Player : Sprite
    {


        //SpriteBatch spriteBatch;

        public bool swinging_enemy;
        public bool dealing_damage;

        ICelAnimationManager celAnimationManager;
        IInputHandler inputHandler;

        public Player(Game game) : base(game)
        {
            

            celAnimationManager = (ICelAnimationManager)game.Services.GetService(typeof(ICelAnimationManager));
            inputHandler = (IInputHandler)game.Services.GetService(typeof(IInputHandler));

            position = new Vector2(100f, 500f);
            speed = 5f;
            life = 100;

        }

        public override void Initialize()
        {
            base.Initialize();
        }

       /* public void Load(SpriteBatch spriteBatch,SpriteFont _damage)
        {
            this.spriteBatch = spriteBatch;
            font_damage = _damage;
        }*/

        protected override void LoadContent()
        {
            CelCount celCount = new CelCount(8, 1);
            celAnimationManager.AddAnimation("Ramona_Swing", "Ramona_Swing", celCount, 10);
            celAnimationManager.PauseAnimation("Ramona_Swing");
            celCount = new CelCount(8, 1);
            celAnimationManager.AddAnimation("Ramona_Slam", "Ramona_Slam", celCount, 10);
            celAnimationManager.PauseAnimation("Ramona_Slam");

            celCount = new CelCount(8, 1);
            celAnimationManager.AddAnimation("Ramona_run", "Ramona_run", celCount, 10);

            frameheight = celAnimationManager.GetAnimationFrameHeight("Ramona_run");
            frameWidth = celAnimationManager.GetAnimationFrameWidth("Ramona_run");

            celAnimationManager.ToggleAnimation("Ramona_run");
  
        }

        String currentAnimation = "Ramona_run";
        
       // float swing_time = 0;

        public override void Update(GameTime gameTime)
        {
            

            if (inputHandler.KeyboardHandler.IsKeyDown(Keys.Right))
            {
                celAnimationManager.ResumeAnimation("Ramona_run");
                currentAnimation = "Ramona_run";
                direction = Direction.Right;
                position.X += speed;
                swinging_enemy = false;

                if (position.X > 600)
                    position.X = 600;

            }
            else if (inputHandler.KeyboardHandler.IsKeyDown(Keys.Left))
            {
                celAnimationManager.ResumeAnimation("Ramona_run");
                currentAnimation = "Ramona_run";
                direction = Direction.Left;
                position.X -= speed;
                swinging_enemy = false;

                if (position.X < 20)
                    position.X = 20;
            }
            else if (inputHandler.KeyboardHandler.IsKeyDown(Keys.Up))
            {
                celAnimationManager.ResumeAnimation("Ramona_run");
                currentAnimation = "Ramona_run";

                position.Y -= speed;

                if (position.Y < 320)
                    position.Y = 320;
            }

            else if (inputHandler.KeyboardHandler.IsKeyDown(Keys.Down))
            {
                celAnimationManager.ResumeAnimation("Ramona_run");
                currentAnimation = "Ramona_run";

                position.Y += speed;

                if (position.Y > 520)
                    position.Y = 520;
            }

            else
               celAnimationManager.PauseAnimation("Ramona_run");

            

           if (inputHandler.KeyboardHandler.WasKeyPressed(Keys.Enter))
            {
                
                celAnimationManager.ResumeAnimation("Ramona_Swing");
                currentAnimation = "Ramona_Swing";
                swinging_enemy = false;

            }

          else  if (celAnimationManager.GetanimationFrame("Ramona_Swing") >= 3)
                swinging_enemy = true;

             if (celAnimationManager.GetanimationFrame("Ramona_Swing") == 7)
            {

                celAnimationManager.PauseAnimation("Ramona_Swing");
                celAnimationManager.SetanimationFrame("Ramona_Swing", 0);
                currentAnimation = "Ramona_run";
                swinging_enemy = false;
            }
            if (inputHandler.KeyboardHandler.WasKeyPressed(Keys.Space))
            {
                celAnimationManager.ResumeAnimation("Ramona_Slam");
                currentAnimation = "Ramona_Slam";
                swinging_enemy = false;
                
            }
            else if (celAnimationManager.GetanimationFrame("Ramona_Slam") >= 3)
                dealing_damage = true;

            if (celAnimationManager.GetanimationFrame("Ramona_Slam") == 7)
            {

                celAnimationManager.PauseAnimation("Ramona_Slam");
                celAnimationManager.SetanimationFrame("Ramona_Slam", 0);
                currentAnimation = "Ramona_run";
                swinging_enemy = false;
            }

            

            if (position.X > (Game.GraphicsDevice.Viewport.Width - frameWidth))
                position.X = (Game.GraphicsDevice.Viewport.Width - frameWidth);
            if (position.X < 0)
                position.X = 0;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
        //    spriteBatch.Begin();
            celAnimationManager.Draw(gameTime, currentAnimation, spriteBatch, position, direction == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
          //  spriteBatch.End();
        }
    }
}
