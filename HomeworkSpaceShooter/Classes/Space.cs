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
    public class Space
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 position2;


        private float speed;
        
        public Space()
        {
            texture = null;
            position = new Vector2(0, 0);
            position2 = new Vector2(1024, 0);
            speed = 5;
        }

        

        public void LoadContent(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>("Untitled 02-19-2024 02-31-18");
        }
        
        public void Update()
        {
            position.X -= speed;
            position2.X -= speed;
            if (position2.X <= 0)
            {
                position.X = 0;
                position2.X = 1024;
            }
            speed += (int)0.001;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White); 
            spriteBatch.Draw(texture, position2, Color.White);
        }

    }
}
