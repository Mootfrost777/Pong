using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pong.Classes.UI
{
    class Score
    {
        private SpriteFont spriteFont;

        public void LoadContent(ContentManager Content)
        {
            spriteFont = Content.Load<SpriteFont>("GameFont");
        }

        public void Draw(SpriteBatch _spriteBatch, Player player1, Player player2)
        {
            _spriteBatch.DrawString(spriteFont, Convert.ToString(player1.score), new Vector2(700, 10), Color.White);
            _spriteBatch.DrawString(spriteFont, Convert.ToString(player2.score), new Vector2(770, 10), Color.White);
        }
    }
}
