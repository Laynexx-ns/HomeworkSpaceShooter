using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HomeworkSpaceShooter.Classes
{
    internal class Player
    {

        private Vector2 position;
        private float speed;
        private Texture2D texture;
        private Rectangle collision;

        private List<ShotGun> bulletlist;
        private int time;
        private int maxtime = 60;

        public Rectangle Collision
        {
            get { return collision; }
        }
        public List<ShotGun> Bulletlist
        {
            get { return bulletlist; }
        }
        
        public Player()
        {
            this.position = new Vector2(50, 50);
            this.texture = null;
            this.speed = 10;
            bulletlist = new List<ShotGun>(); 
        }

        public int X { get { return (int)position.X; } }
        public int Y { get { return (int)(position.Y); } }
        public int Height { get { return texture.Height; } }    
        public int Width { get { return texture.Width; } }


        public void LoadContent(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>("Dota2VEmojiBySnep_004");
            collision = new Rectangle(X, Y, Width, Height);
        }
        public void Update(ContentManager contentManager)
        {
            time += 1;
             KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.D)) position.X += speed;
            if (keyboardState.IsKeyDown(Keys.S)) position.Y += speed;
            if (keyboardState.IsKeyDown(Keys.A)) position.X -= speed;
            if (keyboardState.IsKeyDown(Keys.W)) position.Y -= speed;

            if (position.X <= 0) position.X = 0;
            if (position.X >= 1024 - texture.Width) position.X = 1024 - texture.Width;
            if (position.Y <= 0) position.Y = 0;
            if (position.Y >= 600 - texture.Height) position.Y = 600 - texture.Height;

            if (time > maxtime)
            {
                ShotGun shot = new ShotGun();
                shot.LoadContent(contentManager);
                shot.Position = new Vector2(X + texture.Width/2, Y + texture.Height / 2);
                bulletlist.Add(shot);
                time = 0;
            }
            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

           


            for (int i = 0; i < bulletlist.Count; i++)
            {
                bulletlist[i].Update();
            }
            /*for (int i= 0; i<bulletlist.Count; i++)
            {
                if (bulletlist[i].IsAlive == false) bulletlist.RemoveAt(i); i--;
            }*/// и тут прога подыхает((((
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            for (int i = 0; i < bulletlist.Count; i++)
            {
                bulletlist[i].Draw(spriteBatch);   
            }
        }
    }
}
