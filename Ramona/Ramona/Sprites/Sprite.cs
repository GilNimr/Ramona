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
        public Vector2 position;
        public float speed;
       public enum Direction { Left,Right};
        public Direction direction = Direction.Right;
        public Texture2D texture;
        public int frameWidth;
        public int frameheight;
        Texture2D _texture;
        public int life;
        public Random random =new Random();


        public Sprite(Game game )
            :base(game)
        {
            
            
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, frameWidth,frameheight);
            }
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
