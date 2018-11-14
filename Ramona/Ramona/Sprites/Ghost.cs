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
        Player player;

       // bool hasdied = false;

        
        ICelAnimationManager celAnimationManager;

        

        public Ghost(Game game , Player _player , Random random ) : base(game)
        {
            player = _player;

            celAnimationManager = (ICelAnimationManager)game.Services.GetService(typeof(ICelAnimationManager));
            
            float y= random.Next(0, Game1.ScreenHeight);
            float x= random.Next(Game1.ScreenWidth / 2, Game1.ScreenWidth);
            position = new Vector2(x, y);
            speed = 0.5f;
            knockOut_speed = 10;
            life = 30;

        }

        public override void Initialize()
        {
            base.Initialize();
        }
     /*   public void Load(SpriteBatch spriteBatch,SpriteFont _damage)
        {
            this.spriteBatch = spriteBatch;
            font_damage = _damage;
        }*/

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

         //   if(IsTouchingLeft())

            if (player.position.X<position.X)
            {
                
                direction = Direction.Left;
                if (!IsTouchingRight(player) && _is_swung_timer == 0)
                {
                    position.X += -speed;
                    life_minus = false;
                }
                
                else
                {
                    if(player.swinging_enemy||_is_swung_timer>0)
                    {
                        if (_is_swung_timer == 0)
                        {
                            x_damage_font_position = position.X;
                            y_damage_font_position = position.Y-50f;
                        }
                        _is_swung_timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (_is_swung_timer < 1)
                            position.X += knockOut_speed;
                        else
                            _is_swung_timer = 0;
                        if (!life_minus)
                        {
                            life -= 10;
                            life_minus = true;
                        }
                    }
                }
            }
            else if (player.position.X > position.X)
            {
                
                direction = Direction.Right;
                if (!IsTouchingLeft(player) && _is_swung_timer == 0)
                { 
                    position.X += +speed;
                life_minus = false;
                }
                else
                {
                    if (player.swinging_enemy || _is_swung_timer > 0)
                    {
                        if (_is_swung_timer == 0)
                        {
                            x_damage_font_position = position.X;
                            y_damage_font_position = position.Y-50f;
                        }
                        _is_swung_timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (_is_swung_timer < 1)
                            position.X += -knockOut_speed;
                        else
                            _is_swung_timer = 0;

                        if (!life_minus)
                        {
                            life -= 10;
                            life_minus = true;
                        }
                    }
                }
            }
            if (player.position.Y < position.Y)
            {

                if (!IsTouchingBottom(player))
                    position.Y += -speed;
            }
            else if (player.position.Y > position.Y)
            {

               if (!IsTouchingTop(player))
                position.Y += +speed;
            }

           

          //int celWidth = celAnimationManager.GetAnimationFrameWidth("Ghost");

            

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            celAnimationManager.Draw(gameTime, "Ghost", spriteBatch, position, direction == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            if (life_minus)
            {

                spriteBatch.DrawString(font_damage, "10", damage_font_position, Color.Red);
            }
                spriteBatch.End();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

