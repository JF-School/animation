using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace animation
{
    public class Game1 : Game
    {
        Texture2D tribbleGreyTexture, tribbleCreamTexture, tribbleOrangeTexture, tribbleBrownTexture, backTexture;
        Rectangle tribbleGreyRect, tribbleCreamRect, tribbleOrangeRect, tribbleBrownRect, window, backRect;
        Vector2 tribbleGreySpeed, tribbleCreamSpeed, tribbleOrangeSpeed, tribbleBrownSpeed;
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

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

            tribbleGreySpeed = new Vector2(2, 2);
            tribbleCreamSpeed = new Vector2(0, 3);
            tribbleOrangeSpeed = new Vector2(4, 0);
            tribbleBrownSpeed = new Vector2(3, 5);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribblegrey");
            tribbleCreamTexture = Content.Load<Texture2D>("tribblecream");
            tribbleBrownTexture = Content.Load<Texture2D>("tribblebrown");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleorange");
            backTexture = Content.Load<Texture2D>("shinystar");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;

            if (tribbleGreyRect.Intersects(tribbleCreamRect))
            {
                tribbleGreyRect.X -= (int)tribbleGreySpeed.X;
                tribbleCreamRect.X -= (int)tribbleCreamSpeed.X;
                tribbleGreySpeed.X *= -1;
                tribbleCreamSpeed.X *= -1;
            }
            if (tribbleGreyRect.Intersects(tribbleOrangeRect))
            {
                tribbleGreyRect.X -= (int)tribbleGreySpeed.X;
                tribbleOrangeRect.X -= (int)tribbleOrangeSpeed.X;
                tribbleGreySpeed.X *= -1;
                tribbleOrangeSpeed.X *= -1;
            }
            if (tribbleGreyRect.Intersects(tribbleBrownRect))
            {
                tribbleGreyRect.X -= (int)tribbleGreySpeed.X;
                tribbleBrownRect.X -= (int)tribbleBrownSpeed.X;
                tribbleGreySpeed.X *= -1;
                tribbleBrownSpeed.X *= -1;
            }
            if (tribbleCreamRect.Intersects(tribbleOrangeRect))
            {
                tribbleCreamRect.X -= (int)tribbleCreamSpeed.X;
                tribbleOrangeRect.X -= (int)tribbleOrangeSpeed.X;
                tribbleCreamSpeed.X *= -1;
                tribbleOrangeSpeed.X *= -1;
            }
            if (tribbleCreamRect.Intersects(tribbleBrownRect))
            {
                tribbleCreamRect.X -= (int)tribbleCreamSpeed.X;
                tribbleBrownRect.X -= (int)tribbleBrownSpeed.X;
                tribbleCreamSpeed.X *= -1;
                tribbleBrownSpeed.X *= -1;
            }
            if (tribbleOrangeRect.Intersects(tribbleBrownRect))
            {
                tribbleOrangeRect.X -= (int)tribbleOrangeSpeed.X;
                tribbleBrownRect.X -= (int)tribbleBrownSpeed.X;
                tribbleOrangeSpeed.X *= -1;
                tribbleBrownSpeed.X *= -1;
            }

            // tribble grey
            if (tribbleGreyRect.Right > window.Width || tribbleGreyRect.Left < 0)
                tribbleGreySpeed.X *= -1;
            if (tribbleGreyRect.Bottom > window.Height || tribbleGreyRect.Top < 0)
                tribbleGreySpeed.Y *= -1;


            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;

            if (tribbleGreyRect.Intersects(tribbleCreamRect))
            {
                tribbleGreyRect.Y -= (int)tribbleGreySpeed.Y;
                tribbleCreamRect.Y -= (int)tribbleCreamSpeed.Y;
                tribbleGreySpeed.Y *= -1;
                tribbleCreamSpeed.Y *= -1;
            }
            if (tribbleGreyRect.Intersects(tribbleOrangeRect))
            {
                tribbleGreyRect.Y -= (int)tribbleGreySpeed.Y;
                tribbleOrangeRect.Y -= (int)tribbleOrangeSpeed.Y;
                tribbleGreySpeed.Y *= -1;
                tribbleOrangeSpeed.Y *= -1;
            }
            if (tribbleGreyRect.Intersects(tribbleBrownRect))
            {
                tribbleGreyRect.Y -= (int)tribbleGreySpeed.Y;
                tribbleBrownRect.Y -= (int)tribbleBrownSpeed.Y;
                tribbleGreySpeed.Y *= -1;
                tribbleBrownSpeed.Y *= -1;
            }
            if (tribbleCreamRect.Intersects(tribbleOrangeRect))
            {
                tribbleCreamRect.Y -= (int)tribbleCreamSpeed.Y;
                tribbleOrangeRect.Y -= (int)tribbleOrangeSpeed.Y;
                tribbleCreamSpeed.Y *= -1;
                tribbleOrangeSpeed.Y *= -1;
            }
            if (tribbleCreamRect.Intersects(tribbleBrownRect))
            {
                tribbleCreamRect.Y -= (int)tribbleCreamSpeed.Y;
                tribbleBrownRect.Y -= (int)tribbleBrownSpeed.Y;
                tribbleCreamSpeed.Y *= -1;
                tribbleBrownSpeed.Y *= -1;
            }
            if (tribbleOrangeRect.Intersects(tribbleBrownRect))
            {
                tribbleOrangeRect.Y -= (int)tribbleOrangeSpeed.Y;
                tribbleBrownRect.Y -= (int)tribbleBrownSpeed.Y;
                tribbleOrangeSpeed.Y *= -1;
                tribbleBrownSpeed.Y *= -1;
            }




            // tribble cream
            if (tribbleCreamRect.Bottom > window.Height || tribbleCreamRect.Top < 0)
                tribbleCreamSpeed.Y *= -1;

            // tribble orange
            if (tribbleOrangeRect.Right > window.Width || tribbleOrangeRect.Left < 0)
                tribbleOrangeSpeed.X *= -1;

            // tribble brown
            if (tribbleBrownRect.Right > window.Width || tribbleBrownRect.Left < 0)
                tribbleBrownSpeed.X *= -1;
            if (tribbleBrownRect.Bottom > window.Height || tribbleBrownRect.Top < 0)
                tribbleBrownSpeed.Y *= -1;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            _spriteBatch.Begin();

            _spriteBatch.Draw(backTexture, backRect, Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.End();
        }
    }
}
