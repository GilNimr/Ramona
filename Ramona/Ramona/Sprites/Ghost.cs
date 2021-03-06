﻿using Microsoft.Xna.Framework;
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


        float attacking_player=0;

        

        public Ghost(Game game , Player _player , Random random ) : base(game)
        {
            player = _player;

            celAnimationManager = (ICelAnimationManager)game.Services.GetService(typeof(ICelAnimationManager));
            
            float y= random.Next(0, Game1.ScreenHeight);
            float x= random.Next(Game1.ScreenWidth / 2, Game1.ScreenWidth);
            position = new Vector2(x, y);
            //map_position = position.X;
            speed = 1f;
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

            celAnimationManager.AddAnimation("my_ghost", "my_ghost", celCount, 10);
            frameheight = celAnimationManager.GetAnimationFrameHeight("my_ghost");
            frameWidth = celAnimationManager.GetAnimationFrameWidth("my_ghost");
            celAnimationManager.ToggleAnimation("my_ghost");

            celAnimationManager.AddAnimation("Ghost_death", "Ghost_death", celCount, 10);
            frameheight = celAnimationManager.GetAnimationFrameHeight("Ghost_death");
            frameWidth = celAnimationManager.GetAnimationFrameWidth("Ghost_death");
            celAnimationManager.ToggleAnimation("Ghost_death");

        }

        public override void Update(GameTime gameTime)
        {
            

            if (!hasdied)
            {
                celAnimationManager.ResumeAnimation("my_ghost");
                if (player.position.X < position.X)
                {

                    direction = Direction.Left;
                    if (!IsTouchingRight(player) && _is_swung_timer==0 )
                    {
                       
                        life_minus_swing = false;

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
                            if (_is_swung_timer < 0.5)
                                position.X += knockOut_speed;
                            else
                                _is_swung_timer = 0;
                            if (!life_minus_swing)
                            {
                                damage_to_life = 10;
                                life -= damage_to_life;
                                life_minus_swing = true;
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
                    if (!IsTouchingLeft(player) && _is_swung_timer == 0 )
                    {
                       
                        life_minus_swing = false;

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
                            if (_is_swung_timer < 0.5)
                                position.X += -knockOut_speed;
                            else
                                _is_swung_timer = 0;

                            if (!life_minus_swing)
                            {
                                damage_to_life = 10;
                                life -= damage_to_life;
                                life_minus_swing = true;
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
                
                if (IsTouchingBottom(player) || IsTouchingLeft(player) 
                    || IsTouchingRight(player) || IsTouchingTop(player) || _is_slamed_timer > 0)
                {
                    if (player.slaming_enemy && player.slaming_enemy )
                    {

                        if (_is_slamed_timer == 0)
                        {
                            x_damage_font_position = position.X;
                            y_damage_font_position = position.Y - 50f;
                        }
                        _is_slamed_timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (_is_slamed_timer < 0.2)
                        {
                            if (player.position.X < position.X)
                                position.X += knockOut_speed ;
                            else
                                position.X -= knockOut_speed ;

                            if (player.position.Y < position.Y)
                                position.Y += knockOut_speed ;
                            else
                                position.Y -= knockOut_speed ;
                        }
                        else
                            _is_slamed_timer = 0;

                        if (!life_minus_swing_slam)
                        {
                            damage_to_life = 6;
                            life -= damage_to_life;
                            life_minus_swing_slam = true;
                        }
                    }
                    else
                        life_minus_swing_slam = false;
                }
            }
            
            if (life <= 0)
            {
                
                hasdied = true;
                death_on_screen +=(float) gameTime.ElapsedGameTime.TotalSeconds;
            }

          


            

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            if(!hasdied)
            celAnimationManager.Draw(gameTime, "my_ghost", spriteBatch, position, direction == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            else
                celAnimationManager.Draw(gameTime, "Ghost_death", spriteBatch, position, direction == Direction.Right ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            if (life_minus_swing||life_minus_swing_slam)
            {
                spriteBatch.DrawString(font_damage, damage_to_life.ToString(), Damage_font_position, Color.Red);
            }
         
            spriteBatch.End();

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

