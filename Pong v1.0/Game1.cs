using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Classes;
using Pong.Classes.UI;

namespace Pong
{
    public enum GameState {Game, Menu, Win, Info, LogIn, Exit};
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        private Texture2D line;

        public static GameState gameState = GameState.Menu;
        public static int Winner;

        Menu menu = new Menu();
        Win win = new Win();
        Score score = new Score();

        Player player1 = new Player(new Vector2(30, 450 - 80));
        Player player2 = new Player(new Vector2(1470 - 15, 450 - 80));
        Ball ball = new Ball();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1500;
            _graphics.PreferredBackBufferHeight = 900;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            line = Content.Load<Texture2D>("line");

            menu.LoadContent(Content);
            win.LoadContent(Content);
            score.LoadContent(Content);

            player1.LoadContent(Content);
            player2.LoadContent(Content);
            ball.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game1.gameState = GameState.Menu;

            // TODO: Add your update logic here
            switch (gameState)
            {
                case GameState.Game:
                    player1.UpdateFirst();
                    player2.UpdateSecond();
                    ball.Update();
                    ball.Collide(player1, player2);
                    break;
                case GameState.Menu:
                    menu.Update();
                    break;
                case GameState.Win:
                    win.Update();
                    break;
                case GameState.Info:
                    break;
                case GameState.Exit:
                    Exit();
                    break;
                default:
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

            // TODO: Add your drawing code here
            switch (gameState)
            {
                case GameState.Game:
                    _spriteBatch.Draw(line, new Vector2(740, 0), Color.White);
                    player1.Draw(_spriteBatch);
                    player2.Draw(_spriteBatch);
                    ball.Draw(_spriteBatch);
                    score.Draw(_spriteBatch, player1, player2);
                    break;
                case GameState.Menu:
                    menu.Draw(_spriteBatch);
                    break;
                case GameState.Win:
                    win.Draw(_spriteBatch);
                    break;
                case GameState.Info:
                    break;
                default:
                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
