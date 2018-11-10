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
        
        
        SpriteBatch spriteBatch;

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
        public void Load(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        protected override void LoadContent()
        {
            CelCount celCount = new CelCount(7, 1);
            celAnimationManager.AddAnimation("Ramona_Swing", "Ramona_Swing", celCount, 10);
            celAnimationManager.PauseAnimation("Ramona_Swing");

             celCount = new CelCount(8, 1);
            celAnimationManager.AddAnimation("Ramona_run", "Ramona_run", celCount, 10);
            frameheight = celAnimationManager.GetAnimationFrameHeight("Ramona_run");
            frameWidth = celAnimationManager.GetAnimationFrameWidth("Ramona_run");
            celAnimationManager.ToggleAnimation("Ramona_run");

           
        }
        String currentAnimation = "Ramona_run";
        float swing_time = 0;

        public override void Update(GameTime gameTime)
        {
            swing_time +=(float) gameTime.ElapsedGameTime.TotalSeconds;

            if (inputHandler.KeyboardHandler.IsKeyDown(Keys.Right))
            {
                celAnimationManager.ResumeAnimation("Ramona_run");
                currentAnimation = "Ramona_run";
                direction = Direction.Right;
                position.X += speed;
            }
            else if (inputHandler.KeyboardHandler.IsKeyDown(Keys.Left))
            {
                celAnimationManager.ResumeAnimation("Ramona_run");
                currentAnimation = "Ramona_run";
                direction = Direction.Left;
                position.X -= speed;
            }
           else
               celAnimationManager.PauseAnimation("Ramona_run");

            

           if (inputHandler.KeyboardHandler.WasKeyPressed(Keys.Enter))
            {
                
                celAnimationManager.ResumeAnimation("Ramona_Swing");
                currentAnimation = "Ramona_Swing";

            }
          else  if (celAnimationManager.GetanimationFrame("Ramona_Swing") == 6)
            {
                
                celAnimationManager.PauseAnimation("Ramona_Swing");
                celAnimationManager.SetanimationFrame("Ramona_Swing", 0);
                currentAnimation = "Ramona_run";
            }

            int celWidth = celAnimationManager.GetAnimationFrameWidth("Ramona_run");

            if (position.X > (Game.GraphicsDevice.Viewport.Width - celWidth))
                position.X = (Game.GraphicsDevice.Viewport.Width - celWidth);
            if (position.X < 0)
                position.X = 0;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            celAnimationManager.Draw(gameTime, currentAnimation, spriteBatch, position, direction == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            spriteBatch.End();
        }
    }
}
