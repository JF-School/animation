using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace animation
{
    public class Game1 : Game
    {
        Texture2D tribbleGreyTexture, tribbleCreamTexture, tribbleOrangeTexture, 
            tribbleBrownTexture, tribblePinkTexture, backTexture, tribbleIntroTexture, 
            startTexture, crashedTexture;
        Rectangle tribbleGreyRect, tribbleCreamRect, tribbleOrangeRect, 
            tribbleBrownRect, tribblePinkRect, window, backRect, startRect;
        Vector2 tribbleGreySpeed, tribbleCreamSpeed, tribbleOrangeSpeed, tribbleBrownSpeed, 
            tribblePinkSpeed;

        SpriteFont bounceFont, indBounceFont;

        int bounces = 0, greyBounces = 0, creamBounces = 0, orangeBounces = 0, brownBounces = 0, 
            pinkBounces = 0;

        SoundEffect tribbleCoo, staticSound;
        SoundEffectInstance staticSoundInstance;

        float seconds;

        Random generator = new Random();
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        MouseState mouseState;

        enum Screen
        {
            Intro,
            TribbleYard,
            Outro
        }
        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            backRect = new Rectangle(0, 0, window.Width, window.Height);
            tribbleGreyRect = new Rectangle(300, 10, 100, 100);
            tribbleCreamRect = new Rectangle(200, 50, 100, 100);
            tribbleOrangeRect = new Rectangle(350, 300, 100, 100);
            tribbleBrownRect = new Rectangle(0, 0, 100, 100);
            tribblePinkRect = new Rectangle(700, 500, 100, 100);
            startRect = new Rectangle(200, 300, 400, 300);

            tribbleGreySpeed = new Vector2(3, 3);
            tribbleCreamSpeed = new Vector2(0, 3);
            tribbleOrangeSpeed = new Vector2(4, 0);
            tribbleBrownSpeed = new Vector2(4, 7);
            tribblePinkSpeed = new Vector2(-1, -1);

            screen = Screen.Intro;
            seconds = 5;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribblegrey");
            tribbleCreamTexture = Content.Load<Texture2D>("tribblecream");
            tribbleBrownTexture = Content.Load<Texture2D>("tribblebrown");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleorange");
            tribbleIntroTexture = Content.Load<Texture2D>("tribbleintro");
            tribblePinkTexture = Content.Load<Texture2D>("tribblepink");
            crashedTexture = Content.Load<Texture2D>("crashedtv");
            backTexture = Content.Load<Texture2D>("shinystar");
            startTexture = Content.Load<Texture2D>("startbutton");

            bounceFont = Content.Load<SpriteFont>("BounceFont");
            indBounceFont = Content.Load<SpriteFont>("indBounceFont");

            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
            staticSound = Content.Load<SoundEffect>("static");
            staticSoundInstance = staticSound.CreateInstance();
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            base.Update(gameTime);
            mouseState = Mouse.GetState();

            if (screen == Screen.Intro)
            {
                this.Window.Title = "hi! click on start to go to the tribble yard.";
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (startRect.Contains(mouseState.Position))
                    {
                        screen = Screen.TribbleYard;
                        this.Window.Title = "Welcome to the tribble yard!";
                    }
                }
            }
            else if (screen == Screen.TribbleYard)
            {
                seconds -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                List<string> titles = new List<string> { "Bounce! Bounce! Bounce!", "HELP ME!", "The tribble yard is full of excitement today!", "I love tribbles bouncing!", "Don't get to 1000 bounces! I'm warning you...", "Who is the pink tribble?", "How many titles can I make?", "Peek-a-boo", "Have you been to the Casino of Aldworth?" };

                if (seconds <= 0)
                {
                    this.Window.Title = titles[generator.Next(titles.Count)];
                    seconds = 5f;
                }
                
                tribbleGreyRect.X += (int)tribbleGreySpeed.X;
                tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
                tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
                tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
                tribblePinkRect.X += (int)tribblePinkSpeed.X;

                // tribble Grey intersections (X)
                if (tribbleGreyRect.Intersects(tribbleCreamRect))
                {
                    tribbleGreyRect.X -= (int)tribbleGreySpeed.X;
                    tribbleCreamRect.X -= (int)tribbleCreamSpeed.X;
                    tribbleGreySpeed.X *= -1;
                    tribbleCreamSpeed.X *= -1;
                    bounces += 2;
                    greyBounces += 1;
                    creamBounces += 1;
                }
                if (tribbleGreyRect.Intersects(tribbleOrangeRect))
                {
                    tribbleGreyRect.X -= (int)tribbleGreySpeed.X;
                    tribbleOrangeRect.X -= (int)tribbleOrangeSpeed.X;
                    tribbleGreySpeed.X *= -1;
                    tribbleOrangeSpeed.X *= -1;
                    bounces += 2;
                    greyBounces += 1;
                    orangeBounces += 1;
                }
                if (tribbleGreyRect.Intersects(tribbleBrownRect))
                {
                    tribbleGreyRect.X -= (int)tribbleGreySpeed.X;
                    tribbleBrownRect.X -= (int)tribbleBrownSpeed.X;
                    tribbleGreySpeed.X *= -1;
                    tribbleBrownSpeed.X *= -1;
                    bounces += 2;
                    greyBounces += 1;
                    brownBounces += 1;
                }
                
                if (tribbleGreyRect.Intersects(tribblePinkRect))
                {
                    tribbleGreyRect.X -= (int)tribbleGreySpeed.X;
                    tribblePinkRect.X -= (int)tribblePinkSpeed.X;
                    tribbleGreySpeed.X *= -1;
                    tribblePinkSpeed.X *= -1;
                    bounces += 2;
                    greyBounces += 1;
                    pinkBounces += 1;
                }

                // tribble cream intersections (X)
                if (tribbleCreamRect.Intersects(tribbleOrangeRect))
                {
                    tribbleCreamRect.X -= (int)tribbleCreamSpeed.X;
                    tribbleOrangeRect.X -= (int)tribbleOrangeSpeed.X;
                    tribbleCreamSpeed.X *= -1;
                    tribbleOrangeSpeed.X *= -1;
                    bounces += 2;
                    creamBounces += 1;
                    orangeBounces += 1;
                }
                if (tribbleCreamRect.Intersects(tribbleBrownRect))
                {
                    tribbleCreamRect.X -= (int)tribbleCreamSpeed.X;
                    tribbleBrownRect.X -= (int)tribbleBrownSpeed.X;
                    tribbleCreamSpeed.X *= -1;
                    tribbleBrownSpeed.X *= -1;
                    bounces += 2;
                    creamBounces += 1;
                    brownBounces += 1;
                }
                if (tribbleCreamRect.Intersects(tribblePinkRect))
                {
                    tribbleCreamRect.X -= (int)tribbleCreamSpeed.X;
                    tribblePinkRect.X -= (int)tribblePinkSpeed.X;
                    tribbleCreamSpeed.X *= -1;
                    tribblePinkSpeed.X *= -1;
                    bounces += 2;
                    creamBounces += 1;
                    pinkBounces += 1;
                }

                // tribble orange intersections (X)
                if (tribbleOrangeRect.Intersects(tribbleBrownRect))
                {
                    tribbleOrangeRect.X -= (int)tribbleOrangeSpeed.X;
                    tribbleBrownRect.X -= (int)tribbleBrownSpeed.X;
                    tribbleOrangeSpeed.X *= -1;
                    tribbleBrownSpeed.X *= -1;
                    bounces += 2;
                    orangeBounces += 1;
                    brownBounces += 1;
                }
                if (tribbleOrangeRect.Intersects(tribblePinkRect))
                {
                    tribbleOrangeRect.X -= (int)tribbleOrangeSpeed.X;
                    tribblePinkRect.X -= (int)tribblePinkSpeed.X;
                    tribbleOrangeSpeed.X *= -1;
                    tribblePinkSpeed.X *= -1;
                    bounces += 2;
                    orangeBounces += 1;
                    pinkBounces += 1;
                }

                // tribble brown intersections (X)
                if (tribbleBrownRect.Intersects(tribblePinkRect))
                {
                    tribbleBrownRect.X -= (int)tribbleBrownSpeed.X;
                    tribblePinkRect.X -= (int)tribblePinkSpeed.X;
                    tribbleBrownSpeed.X *= -1;
                    tribblePinkSpeed *= -1;
                    bounces += 2;
                    brownBounces += 1;
                    pinkBounces += 1;
                }

                tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
                tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
                tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
                tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
                tribblePinkRect.Y += (int)tribblePinkSpeed.Y;

                // tribble grey intersections (Y)
                if (tribbleGreyRect.Intersects(tribbleCreamRect))
                {
                    tribbleGreyRect.Y -= (int)tribbleGreySpeed.Y;
                    tribbleCreamRect.Y -= (int)tribbleCreamSpeed.Y;
                    tribbleGreySpeed.Y *= -1;
                    tribbleCreamSpeed.Y *= -1;
                    bounces += 2;
                    greyBounces += 1;
                    creamBounces += 1;
                }
                if (tribbleGreyRect.Intersects(tribbleOrangeRect))
                {
                    tribbleGreyRect.Y -= (int)tribbleGreySpeed.Y;
                    tribbleOrangeRect.Y -= (int)tribbleOrangeSpeed.Y;
                    tribbleGreySpeed.Y *= -1;
                    tribbleOrangeSpeed.Y *= -1;
                    bounces += 2;
                    greyBounces += 1;
                    orangeBounces += 1;
                }
                if (tribbleGreyRect.Intersects(tribbleBrownRect))
                {
                    tribbleGreyRect.Y -= (int)tribbleGreySpeed.Y;
                    tribbleBrownRect.Y -= (int)tribbleBrownSpeed.Y;
                    tribbleGreySpeed.Y *= -1;
                    tribbleBrownSpeed.Y *= -1;
                    bounces += 2;
                    greyBounces += 1;
                    brownBounces += 1;
                }
                if (tribbleGreyRect.Intersects(tribblePinkRect))
                {
                    tribbleGreyRect.Y -= (int)tribbleGreySpeed.Y;
                    tribblePinkRect.Y -= (int)tribblePinkSpeed.Y;
                    tribblePinkSpeed.Y *= -1;
                    tribbleGreySpeed.Y *= -1;
                    bounces += 2;
                    greyBounces += 1;
                    pinkBounces += 1;
                }

                // tribble cream intersections (Y)
                if (tribbleCreamRect.Intersects(tribbleOrangeRect))
                {
                    tribbleCreamRect.Y -= (int)tribbleCreamSpeed.Y;
                    tribbleOrangeRect.Y -= (int)tribbleOrangeSpeed.Y;
                    tribbleCreamSpeed.Y *= -1;
                    tribbleOrangeSpeed.Y *= -1;
                    bounces += 2;
                    creamBounces += 1;
                    orangeBounces += 1;
                }
                if (tribbleCreamRect.Intersects(tribbleBrownRect))
                {
                    tribbleCreamRect.Y -= (int)tribbleCreamSpeed.Y;
                    tribbleBrownRect.Y -= (int)tribbleBrownSpeed.Y;
                    tribbleCreamSpeed.Y *= -1;
                    tribbleBrownSpeed.Y *= -1;
                    bounces += 2;
                    creamBounces += 1;
                    brownBounces += 1;
                }
                if (tribbleCreamRect.Intersects(tribblePinkRect))
                {
                    tribbleCreamRect.Y -= (int)tribbleCreamSpeed.Y;
                    tribblePinkRect.Y -= (int)tribblePinkSpeed.Y;
                    tribbleCreamSpeed.Y *= -1;
                    tribblePinkSpeed.Y *= -1;
                    bounces += 2;
                    creamBounces += 1;
                    pinkBounces += 1;
                }

                // tribble orange intersections (Y)
                if (tribbleOrangeRect.Intersects(tribbleBrownRect))
                {
                    tribbleOrangeRect.Y -= (int)tribbleOrangeSpeed.Y;
                    tribbleBrownRect.Y -= (int)tribbleBrownSpeed.Y;
                    tribbleOrangeSpeed.Y *= -1;
                    tribbleBrownSpeed.Y *= -1;
                    bounces += 2;
                    orangeBounces += 1;
                    brownBounces += 1;
                }
                if (tribbleOrangeRect.Intersects(tribblePinkRect))
                {
                    tribbleOrangeRect.Y -= (int)tribbleOrangeSpeed.Y;
                    tribblePinkRect.Y -= (int)tribblePinkSpeed.Y;
                    tribbleOrangeSpeed.Y *= -1;
                    tribblePinkSpeed.Y *= -1;
                    bounces += 2;
                    orangeBounces += 1;
                    pinkBounces += 1;
                }

                // tribble brown intersections (Y)
                if (tribbleBrownRect.Intersects(tribblePinkRect))
                {
                    tribbleBrownRect.Y -= (int)tribbleBrownSpeed.Y;
                    tribblePinkRect.Y -= (int)tribblePinkSpeed.Y;
                    tribbleBrownSpeed.Y *= -1;
                    tribblePinkSpeed.Y *= -1;
                    bounces += 2;
                    orangeBounces += 1;
                    pinkBounces += 1;
                }

                // tribble grey
                if (tribbleGreyRect.Right > window.Width || tribbleGreyRect.Left < 0)
                {
                    tribbleGreySpeed.X *= -1;
                    bounces += 1;
                    greyBounces += 1;
                    tribbleCoo.Play();
                }
                if (tribbleGreyRect.Bottom > window.Height || tribbleGreyRect.Top < 0)
                {
                    tribbleGreySpeed.Y *= -1;
                    bounces += 1;
                    greyBounces += 1;
                    tribbleCoo.Play();
                }

                // tribble cream
                if (tribbleCreamRect.Right > window.Width || tribbleCreamRect.Left < 0)
                {
                    tribbleCreamSpeed.X *= -1;
                    bounces += 1;
                    creamBounces += 1;
                    tribbleCoo.Play();
                }
                if (tribbleCreamRect.Bottom > window.Height || tribbleCreamRect.Top < 0)
                {
                    tribbleCreamSpeed.Y *= -1;
                    bounces += 1;
                    creamBounces += 1;
                    tribbleCoo.Play();
                }

                // tribble orange
                if (tribbleOrangeRect.Right > window.Width || tribbleOrangeRect.Left < 0)
                {
                    tribbleOrangeSpeed.X *= -1;
                    bounces += 1;
                    orangeBounces += 1;
                    tribbleCoo.Play();
                }
                if (tribbleOrangeRect.Bottom > window.Height || tribbleOrangeRect.Top < 0)
                {
                    tribbleOrangeSpeed.Y *= -1;
                    bounces += 1;
                    orangeBounces += 1;
                    tribbleCoo.Play();
                }

                // tribble brown
                if (tribbleBrownRect.Right > window.Width || tribbleBrownRect.Left < 0)
                {
                    tribbleBrownSpeed.X *= -1;
                    bounces += 1;
                    brownBounces += 1;
                    tribbleCoo.Play();
                }
                if (tribbleBrownRect.Bottom > window.Height || tribbleBrownRect.Top < 0)
                {
                    tribbleBrownSpeed.Y *= -1;
                    bounces += 1;
                    brownBounces += 1;
                    tribbleCoo.Play();
                }

                // tribble pink
                if (tribblePinkRect.Right > window.Width || tribblePinkRect.Left < 0)
                {
                    tribblePinkSpeed.X *= -1;
                    bounces += 1;
                    pinkBounces += 1;
                    tribbleCoo.Play();
                }
                if (tribblePinkRect.Bottom > window.Height || tribblePinkRect.Top < 0)
                {
                    tribblePinkSpeed.Y *= -1;
                    bounces += 1;
                    pinkBounces += 1;
                    tribbleCoo.Play();
                }
                if (bounces >= 100)
                {
                    screen = Screen.Outro;
                    staticSoundInstance.Play();
                }
            }
            else if (screen == Screen.Outro)
            {
                this.Window.Title = "WHAT DID YOU DO TO MY APPLICATION";
                IsMouseVisible = false;
                if (staticSoundInstance.State == SoundState.Stopped)
                {
                    Exit();
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntroTexture, backRect, Color.White);
                _spriteBatch.Draw(startTexture, startRect, Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(backTexture, backRect, Color.White);
                _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
                _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
                _spriteBatch.Draw(tribblePinkTexture, tribblePinkRect, Color.White);
                _spriteBatch.DrawString(bounceFont, ("Bounces: " + bounces), new Vector2(550, 500), Color.White);
                _spriteBatch.DrawString(indBounceFont, ("Grey Bounces: " + greyBounces + " | Cream Bounces: " + creamBounces + " | Orange Bounces: " + orangeBounces + " | Brown Bounces: " + brownBounces + " | Pink Bounces: " + pinkBounces), new Vector2(0, 550), Color.White);
            }
            else if (screen == Screen.Outro)
            {
                _spriteBatch.Draw(crashedTexture, backRect, Color.White);
                _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
                _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
                _spriteBatch.Draw(tribblePinkTexture, tribblePinkRect, Color.White);
            }

            _spriteBatch.End();
        }
    }
}
