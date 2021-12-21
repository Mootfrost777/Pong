using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Classes.UI
{
    class Win
    {
        private SpriteFont spriteFont;
        private Color defaultColor;
        public string Text { get; set; }
        private KeyboardState keyboardState;
        private KeyboardState prevKeyboardState;

        public void LoadContent(ContentManager Content)
        {
            spriteFont = Content.Load<SpriteFont>("GameFont");
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (Game1.Winner == 1)
            {
                _spriteBatch.DrawString(spriteFont, "First player wins!", new Vector2(650, 430), Color.White);
            }
            else if (Game1.Winner == 2)
            {
                _spriteBatch.DrawString(spriteFont, "Second player wins!", new Vector2(650, 430), Color.White);
            }
        }

        public void Update()
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter) && (keyboardState != prevKeyboardState))
            {
                Game1.gameState = GameState.Menu;
            }
            keyboardState = prevKeyboardState;
        }
    }
}
