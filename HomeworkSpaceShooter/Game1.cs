using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using HomeworkSpaceShooter.Classes;
using Microsoft.Win32.SafeHandles;
using System.Security.Cryptography.X509Certificates;

namespace HomeworkSpaceShooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int screenwidth = 1024;
        private int screenheight = 600;
        Space space;
        Player player;
        List<ShotGun> sguns;
        private List<Salts> salts;
        int randomsalts = new Random().Next(5, 15);

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

            _graphics.PreferredBackBufferHeight = screenheight;
            _graphics.PreferredBackBufferWidth = screenwidth;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            space = new Space();
            player = new Player();
            salts = new List<Salts>();
            sguns = new List<ShotGun>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            space.LoadContent(Content);
            player.LoadContent(Content);
            
            for (int i = 0; i < randomsalts; i++)
            {
                Salts salt = new Salts();

                salt.LoadContent(Content);
                Random rndvector = new Random();
                int x = rndvector.Next(screenwidth - salt.Width, 2048);
                int y = rndvector.Next(0, screenheight - salt.Height);

                salt.Position = new Vector2(x, y);

                salts.Add(salt);
            }
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            space.Update();
            player.Update(Content);
            
            UpdateSalt();
            CheckCollision();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            space.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            foreach (Salts salt in salts)
            {
                salt.Draw(_spriteBatch);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //sgun.Draw(_spriteBatch);
            }
            foreach (ShotGun gun in sguns)
            {
                gun.Draw(_spriteBatch);
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }


        public void LoadSalt()
        {
            Salts s = new Salts();
            s.LoadContent(Content);

            Random rndvector = new Random();
            int x = rndvector.Next(screenwidth - s.Width, 2048);
            int y = rndvector.Next(0, screenheight - s.Height);

            s.Position = new Vector2(x, y);
            s.Collision = new Rectangle(x, y, s.Width, s.Height);
            
            salts.Add(s);
        }

        private void UpdateSalt()
        {
            for (int i = 0; i < salts.Count; i++)
            {
                Salts s = salts[i];

                s.Update();


                //teleport
                if (s.Position.X < 0 - 50)
                {
                    Random rndvector = new Random();
                    int x = rndvector.Next(screenwidth - s.Width, 2048);
                    int y = rndvector.Next(0, screenheight - s.Height);

                    s.Position = new Vector2(x, y);
                }

                if (s.IsAlive == false)
                {
                    salts.RemoveAt(i);
                    i--;
                }


            }
            //загрузить доп астероид
            if (salts.Count < randomsalts)
            {
                LoadSalt();
            }
        }

        private void CheckCollision()
        {
            foreach (Salts a in salts)
            {
                if (a.Collision.Intersects(player.Collision))
                {
                    a.IsAlive = false;
                   
                }

                foreach (ShotGun b in player.Bulletlist)
                {
                    if (a.Collision.Intersects(b.Collision))
                    {
                        a.IsAlive = false;
                        b.IsAlive = false;
                        
                    }
                }
            }

        }
    }

}