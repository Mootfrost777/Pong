using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Classes
{
    class Player
    {
        private Texture2D texture;

        public int score = 0;
        public string name;

        public Vector2 position;

        private KeyboardState keyboardState;
        public Rectangle boundingBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        public Player(Vector2 position)
        {
            this.position = position;
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("player");
        }

        public void UpdateFirst()
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.S) && position.Y <= 900 - texture.Height)
            {
                position.Y += 12;
            }

            if (keyboardState.IsKeyDown(Keys.W) && position.Y >= 0)
            {
                position.Y -= 12;
            }
        }

        public void UpdateSecond()
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Down) && position.Y <= 900 - texture.Height)
            {
                position.Y += 12;
            }

            if (keyboardState.IsKeyDown(Keys.Up) && position.Y >= 0)
            {
                position.Y -= 12;
            }
        }

        public void Draw(SpriteBatch _sprirteBatch)
        {
            _sprirteBatch.Draw(texture, position, Color.White);
        }
    }
}
