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
    public class Sprite : DrawableGameComponent
    {
        protected SpriteBatch spriteBatch;

        public SpriteFont font_damage;

        public SpriteFont font_life;
        public float x_damage_font_position;
        public float y_damage_font_position;
        public Vector2 Damage_font_position {get { return new Vector2(x_damage_font_position, y_damage_font_position); } }


        public Vector2 position;
        public float speed;
        public float knockOut_speed;
        protected float _is_swung_timer;
        protected bool life_minus = false;


        public enum Direction { Left, Right };

        public Direction direction = Direction.Right;

        public Texture2D texture;
        public int frameWidth;
        public int frameheight;


        public int life;
        public bool hasdied=false;
        public int damage_to_life;
        public float death_on_screen = 0;




        public Sprite(Game game)
            : base(game)
        {


        }

        public Rectangle Rectangle
        {
            get
            {

                return new Rectangle((int)position.X, (int)position.Y, frameWidth, frameheight);

            }
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        
        public void Load(SpriteBatch spriteBatch, SpriteFont _damage)
        {
            this.spriteBatch = spriteBatch;
            font_damage = _damage;
        }


        public void Load(SpriteBatch spriteBatch, SpriteFont _damage, SpriteFont _life)
        {
            this.spriteBatch = spriteBatch;
            font_damage = _damage;
            font_life = _life;
        }

        #region Colloision
        protected bool IsTouchingLeft(Sprite sprite)  
        {
            return this.Rectangle.Right + this.speed*3 > sprite.Rectangle.Left &&
              this.Rectangle.Left<sprite.Rectangle.Left &&
              this.Rectangle.Bottom> sprite.Rectangle.Top &&
              this.Rectangle.Top<sprite.Rectangle.Bottom;
        }
    
    
        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.Rectangle.Left - this.speed*3 < sprite.Rectangle.Right &&

              this.Rectangle.Right > sprite.Rectangle.Right &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.Rectangle.Bottom + this.speed > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Top &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right;
        }

        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.Rectangle.Top + this.speed < sprite.Rectangle.Bottom &&
              this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right;
        }


        protected bool IsTouchingLeft(List<Sprite> sprites)
        {
            foreach(Sprite sprite in sprites) {
                if (this.Rectangle.Right + this.speed > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Left &&
                  this.Rectangle.Bottom > sprite.Rectangle.Top &&
                  this.Rectangle.Top < sprite.Rectangle.Bottom)
                    return true;

            }
            return false;
        }


        protected bool IsTouchingRight(List<Sprite> sprites)
        {
            foreach (Sprite sprite in sprites)
            {
                if (this.Rectangle.Left + this.speed < sprite.Rectangle.Right &&
              this.Rectangle.Right > sprite.Rectangle.Right &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom)
                    return true;
            }
            return false;
            }

        protected bool IsTouchingTop(List<Sprite> sprites)
        {
            foreach (Sprite sprite in sprites)
            {
                if (this.Rectangle.Bottom + this.speed > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Top &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right)
                    return true;
            }
            return false;
        }

        protected bool IsTouchingBottom(List<Sprite> sprites)
        {
                foreach (Sprite sprite in sprites)
                {
                    if (this.Rectangle.Top + this.speed < sprite.Rectangle.Bottom &&
              this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right)
                        return true;
                }
                return false;
            }

        #endregion

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Begin();
            spriteBatch.Draw(texture, position, Color.White);

            spriteBatch.End();

        }


    }
}
