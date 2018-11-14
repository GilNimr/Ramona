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

<<<<<<< HEAD
=======
        float attacking_player=0;
>>>>>>> master
        

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
<<<<<<< HEAD
            celAnimationManager.AddAnimation("Ghost", "Ghost", celCount, 10);
            frameheight = celAnimationManager.GetAnimationFrameHeight("Ghost");
            frameWidth = celAnimationManager.GetAnimationFrameWidth("Ghost");
            celAnimationManager.ToggleAnimation("Ghost");
=======
            celAnimationManager.AddAnimation("my_ghost", "my_ghost", celCount, 10);
            frameheight = celAnimationManager.GetAnimationFrameHeight("my_ghost");
            frameWidth = celAnimationManager.GetAnimationFrameWidth("my_ghost");
            celAnimationManager.ToggleAnimation("my_ghost");

            celAnimationManager.AddAnimation("Ghost_death", "Ghost_death", celCount, 10);
            frameheight = celAnimationManager.GetAnimationFrameHeight("Ghost_death");
            frameWidth = celAnimationManager.GetAnimationFrameWidth("Ghost_death");
            celAnimationManager.ToggleAnimation("Ghost_death");
>>>>>>> master
        }

        public override void Update(GameTime gameTime)
        {
<<<<<<< HEAD
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
=======
            if (!hasdied)
            {
                celAnimationManager.ResumeAnimation("my_ghost");
                if (player.position.X < position.X)
                {

                    direction = Direction.Left;
                    if (!IsTouchingRight(player) && _is_swung_timer == 0)
                    {
                       
                        life_minus = false;

                        if (!IsTouchingRight(Game1.sprites))
                        {
                            position.X += -speed;

                        }
                    }

                    else
                    {
                        attacking_player +=(float) gameTime.ElapsedGameTime.TotalSeconds;

                        if ((player.swinging_enemy&&player.direction==Direction.Right) || _is_swung_timer > 0)
                        {
                           
                            if (_is_swung_timer == 0)
                            {
                                x_damage_font_position = position.X;
                                y_damage_font_position = position.Y - 50f;
                            }
                            _is_swung_timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                            if (_is_swung_timer < 1)
                                position.X += knockOut_speed;
                            else
                                _is_swung_timer = 0;
                            if (!life_minus)
                            {
                                damage_to_life = 10;
                                life -= damage_to_life;
                                life_minus = true;
                            }
                        }
                        else if(attacking_player>0.5)
                        {
                            attacking_player = 0;
                            player.damage_to_life = 2;
                            player.life -= player.damage_to_life;
                           player. player_hit = true;
                        }
                    }
                }
                else if (player.position.X > position.X)
                {

                    direction = Direction.Right;
                    if (!IsTouchingLeft(player) && _is_swung_timer == 0)
                    {
                       
                        life_minus = false;

                        if (!IsTouchingLeft(Game1.sprites))
                        {
                            position.X += speed;

                        }
                    }
                    else
                    {
                        attacking_player += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if ((player.swinging_enemy && player.direction == Direction.Left) || _is_swung_timer > 0)
                        {
                         
                            if (_is_swung_timer == 0)
                            {
                                x_damage_font_position = position.X;
                                y_damage_font_position = position.Y - 50f;
                            }
                            _is_swung_timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                            if (_is_swung_timer < 1)
                                position.X += -knockOut_speed;
                            else
                                _is_swung_timer = 0;

                            if (!life_minus)
                            {
                                damage_to_life = 10;
                                life -= damage_to_life;
                                life_minus = true;
                            }
                        }
                        else if (attacking_player > 0.5&&!player.player_hit)
                        {
                            attacking_player = 0;
                            player.damage_to_life = 2;
                            player.life -= player.damage_to_life;
                          player.  player_hit = true;
                            
                        }
                    }
                }
                if (player.position.Y < position.Y)
                {

                    if (!IsTouchingBottom(Game1.sprites))
                        position.Y += -speed;
                }
                else if (player.position.Y > position.Y)
                {

                    if (!IsTouchingTop(Game1.sprites))
                        position.Y += +speed;
                }
            }
            if (life <= 0)
            {
                hasdied = true;
                death_on_screen +=(float) gameTime.ElapsedGameTime.TotalSeconds;
            }

          
>>>>>>> master

            

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
<<<<<<< HEAD
            celAnimationManager.Draw(gameTime, "Ghost", spriteBatch, position, direction == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            if (life_minus)
            {

                spriteBatch.DrawString(font_damage, "10", damage_font_position, Color.Red);
            }
                spriteBatch.End();
=======
            if(!hasdied)
            celAnimationManager.Draw(gameTime, "my_ghost", spriteBatch, position, direction == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            else
                celAnimationManager.Draw(gameTime, "Ghost_death", spriteBatch, position, direction == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            if (life_minus)
            {
                spriteBatch.DrawString(font_damage, damage_to_life.ToString(), Damage_font_position, Color.Red);
            }
         
            spriteBatch.End();
>>>>>>> master
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

