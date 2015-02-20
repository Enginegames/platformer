#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

#endregion
#region Shortcuts
using GDM = Microsoft.Xna.Framework.GraphicsDeviceManager;
using GD = Microsoft.Xna.Framework.Graphics.GraphicsDevice;
using CM = Microsoft.Xna.Framework.Content.ContentManager;
using SB = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using V2 = Microsoft.Xna.Framework.Vector2;
using V3 = Microsoft.Xna.Framework.Vector3;
using MH = Microsoft.Xna.Framework.MathHelper;
using MX = Microsoft.Xna.Framework.Matrix;
using T2 = Microsoft.Xna.Framework.Graphics.Texture2D;
using F = System.Single;
using SE = Microsoft.Xna.Framework.Graphics.SpriteEffects;
using REC = Microsoft.Xna.Framework.Rectangle;
using KS = Microsoft.Xna.Framework.Input.KeyboardState;
using MS = Microsoft.Xna.Framework.Input.MouseState;
using C = Microsoft.Xna.Framework.Color;
using BSM = Microsoft.Xna.Framework.Graphics.BlendState;
using SSM = Microsoft.Xna.Framework.Graphics.SpriteSortMode;
using TITS = System.Collections.Generic.List<int>;
using REX = System.Collections.Generic.List<Microsoft.Xna.Framework.Rectangle>;
using V2L = System.Collections.Generic.List<Microsoft.Xna.Framework.Vector2>;
#endregion

namespace Flatformer
{
    public class Game1 : Game
    {
        public static event SigUpdate CallUpdate;
        public static event SigDraw CallDraw;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D tx;
        Land land;
        baseChar bs;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 768;
            graphics.PreferredBackBufferHeight = 512;
            graphics.ApplyChanges();

            base.Initialize();
        }
        
        protected override void LoadContent()
        {            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.init(spriteBatch, GraphicsDevice, graphics, Content);


            land = new Land("map");
            bs = new baseChar("Char" , new V2(100 , 300));
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            if (CallUpdate != null)
            {
                if (CallUpdate != null)
                {
                    CallUpdate();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (CallDraw != null)
            {
                CallDraw();
            }

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
