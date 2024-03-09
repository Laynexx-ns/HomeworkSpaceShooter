using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace HomeworkSpaceShooter.Classes
{
    internal class ShotGun
    {
        private Texture2D texture;
        private Rectangle destinationRactangle;
        private int width;
        private int height;
        private int size;
        private bool isAlive;
        
        public Vector2 Position
        {
            get { return new Vector2(destinationRactangle.X, destinationRactangle.Y); }
            set
            {
                destinationRactangle.X = (int)value.X;
                destinationRactangle.Y = (int)value.Y;
            }
        }

        public Rectangle Collision
        {
            get {  return destinationRactangle; }
        }

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public ShotGun()
        {
            texture = null;
            isAlive = true;
            width = 20;
            height = 20;
            destinationRactangle = new Rectangle(0, 0, width, height);
        }

        public ShotGun(int x, int y) : this()
        {
            destinationRactangle = new Rectangle(x, y, width, height);
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("shotgun");
        }

        public void Update()
        {
            destinationRactangle.X += 5;

            if (Position.X > 1024 + height + 10) isAlive = false;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRactangle, Color.White);
        }



    }
}
