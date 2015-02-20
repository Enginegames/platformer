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
    class baseChar
    {
        T2 sprite;
        V2 pos;
        V2 actualPos;
        PlayerKeys plk;
        bool jumping;
        bool falling;
        bool movable;

        float jumpStartPower;
        float jumpDiff;
        float jumpPower;

        public baseChar(string loc, V2 startPos)
        {
            sprite = Globals.cm.Load<T2>(loc);
            plk = new PlayerKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Space, Keys.Enter , Keys.X);
            pos = startPos;
            actualPos = startPos;

            movable = true;
            jumping = false;
            falling = false;

            jumpStartPower = 3;
            jumpDiff = 0.09f;
            jumpPower = 0;

            Game1.CallUpdate+= new SigUpdate(Update);
            Game1.CallDraw += new SigDraw(Draw);
        }

        public void Update()
        {
            if (movable)
            {
                if (this.plk.pUp)
                    actualPos.Y -= Globals.regularSpeed / 2;

                if (this.plk.pDown)
                    actualPos.Y += Globals.regularSpeed / 2;

                if (this.plk.pLeft)
                    actualPos.X -= Globals.regularSpeed;

                if (this.plk.pRight)
                    actualPos.X += Globals.regularSpeed;

                if (plk.pJump && !jumping)
                {
                    jumping = true;
                    jumpPower = jumpStartPower;
                }
                else
                {
                    pos = actualPos;
                }
            }
            else if (jumping && !falling && jumpPower == 0)
            {
                startJump();
            }
           
        }

        private void startJump()
        {
            if (jumping || jumpPower < 0)
            { 
                
            }
        }



        public void Draw()
        {
            Globals.sb.Draw(sprite, pos, C.White);
        }
    }
}
