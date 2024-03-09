using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HomeworkSpaceShooter.Classes
{
    internal class Salts
    {
        private Texture2D texture;
        private Vector2 position;
        private double speed;
        private bool isAlive;
        private Rectangle collision;

        public Salts()
        {
            texture  = null;
            position = new Vector2(0, 0);
            speed = 5;
            isAlive = true;
            
        }
        public int Height { get { return texture.Height; } }
        public int Width { get { return texture.Width;} }
        public Vector2 Position { get { return position; } set { position = value; } }

        public Rectangle Collision
        {
            get { return collision; }
            set { collision = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }


        public void LoadContent(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>("salt");
        }
        public void Update()
        {
            position.X -= (int)speed;
            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            speed += 0.0009;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
