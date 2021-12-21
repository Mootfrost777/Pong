using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;
using Microsoft.Xna.Framework.Audio;

namespace Pong.Classes
{
    class Ball
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(750, 450);
        private Vector2 def_pos;
        private Vector2 Speed = new Vector2(11, -11);

        private SoundEffect GameOver;
        private SoundEffect Lose;

        public Ball()
        {
            def_pos = position;
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("ball");
            GameOver = Content.Load<SoundEffect>("GameOver");
            Lose = Content.Load<SoundEffect>("Lose");
        }

        public void Update()
        {
            position -= Speed;
        }

        public void Draw(SpriteBatch _sprirteBatch)
        {
            _sprirteBatch.Draw(texture, position, Color.White);
        }

        public void Collide(Player player1, Player player2)
        {
            Rectangle Bound = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (position.Y <= 0 || position.Y >= 900 - texture.Height)
            {
                VerticalBounce();
            }

            if (position.X <= 0)
            {
                if (player2.score < 10)
                {
                    player1.position.Y = 450 - 80;
                    player2.position.Y = 450 - 80;
                    player2.score++;
                    Lose.Play();
                }
                if (player2.score == 10)
                {
                    player2.score = 0;
                    player1.score = 0;
                    Game1.Winner = 1;
                    GameOver.Play();
                    Game1.gameState = GameState.Win;
                }
                else
                {
                    position = def_pos;
                }
            }
            else if (position.X >= 1500 - texture.Width)
            {
                if (player1.score < 10)
                {
                    player1.position.Y = 450 - 80;
                    player2.position.Y = 450 - 80;
                    player1.score++;
                    Lose.Play();
                }
                if (player1.score == 10)
                {
                    player2.score = 0;
                    player1.score = 0;
                    Game1.Winner = 2;
                    GameOver.Play();
                    Game1.gameState = GameState.Win;
                }
                else
                {
                    position = def_pos;
                }
            }

            if (Bound.Intersects(player1.boundingBox) || Bound.Intersects(player2.boundingBox))
            {
                HorizontalBounce();
            }
        }

        public void VerticalBounce()
        {
            Speed.Y = -Speed.Y;
        }

        public void HorizontalBounce()
        {
            Speed.X = -Speed.X;
        }
    }
}
