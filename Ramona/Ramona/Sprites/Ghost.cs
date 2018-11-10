using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XELibrary;

namespace Ramona.Sprites
{
    class Ghost : Sprite , ICloneable
    {
        SpriteBatch spriteBatch;

        Player player;

        bool hasdied = false;

        float timer = 0;
        ICelAnimationManager celAnimationManager;
        

        public Ghost(Game game , Player _player) : base(game)
        {
            player = _player;

            celAnimationManager = (ICelAnimationManager)game.Services.GetService(typeof(ICelAnimationManager));
           float y= random.Next(0, Game1.ScreenHeight);
            float x= random.Next(Game1.ScreenWidth / 2, Game1.ScreenWidth);
            position = new Vector2(x, y);
            speed = 0.5f;
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
            CelCount celCount = new CelCount(3, 1);
            celAnimationManager.AddAnimation("Ghost", "Ghost", celCount, 10);
            frameheight = celAnimationManager.GetAnimationFrameHeight("Ghost");
            frameWidth = celAnimationManager.GetAnimationFrameWidth("Ghost");
            celAnimationManager.ToggleAnimation("Ghost");
        }

        public override void Update(GameTime gameTime)
        {
            celAnimationManager.ResumeAnimation("Ghost");

            if (player.position.X<position.X)
            {
                
                direction = Direction.Left;
                position.X += -speed;
            }
            else if (player.position.X > position.X)
            {
                
                direction = Direction.Right;
                position.X += +speed;
            }
            if (player.position.Y < position.Y)
            {
                
                
                position.Y += -speed;
            }
            else if (player.position.Y > position.Y)
            {
                
                
                position.Y += +speed;
            }

            

            int celWidth = celAnimationManager.GetAnimationFrameWidth("Ghost");

            

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            celAnimationManager.Draw(gameTime, "Ghost", spriteBatch, position, direction == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            spriteBatch.End();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

