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
    class PlayerKeys : BaseKeys
    {
        public PlayerKeys(Keys up, Keys down, Keys left, Keys right, Keys select, Keys start , Keys jump) :
            base(up, down, left, right, select, start , jump)
        {
            
        }

        public override bool leftPressed()
        {
            if (!Globals.controlerMode)
            {
                if (Globals.ks.IsKeyDown(left))
                {
                    return true;
                }
                return false;
            }
            return Globals.gps.DPad.Left == ButtonState.Pressed;
        }

        public override bool rightPressed()
        {
            if (!Globals.controlerMode)
            {
                if (Globals.ks.IsKeyDown(right))
                {
                    return true;
                }
                return false;
            }
            return Globals.gps.DPad.Right == ButtonState.Pressed;
        }

        public override bool upPressed()
        {
            if (!Globals.controlerMode)
            {
                if (Globals.ks.IsKeyDown(up))
                {
                    return true;
                }
                return false;
            }
            return Globals.gps.DPad.Up == ButtonState.Pressed;
        }

        public override bool downPressed()
        {
            if (!Globals.controlerMode)
            {
                if (Globals.ks.IsKeyDown(down))
                {
                    return true;
                }
                return false;
            }
            return Globals.gps.DPad.Down == ButtonState.Pressed;
        }

        public override bool selectPressed()
        {
            if (!Globals.controlerMode)
            {
                if (Globals.ks.IsKeyDown(select))
                {
                    return !Globals.pks.IsKeyDown(select);
                }
                return false;
            }

                return (Globals.gps.Buttons.Back == ButtonState.Pressed);
 
        }

        public override bool startPressed()
        {
            if (!Globals.controlerMode)
            {
                if (Globals.ks.IsKeyDown(start))
                {
                    return !Globals.pks.IsKeyDown(start);

                }
                return false;
            }

                return (Globals.gps.Buttons.Start == ButtonState.Pressed);

        }


        public override bool jumpPressed()
        {
            if (!Globals.controlerMode)
            {
                if (Globals.ks.IsKeyDown(jump))
                {
                    return !Globals.pks.IsKeyDown(jump);

                }
                return false;
            }
            return (Globals.gps.Buttons.B == ButtonState.Pressed);

        }
    }
}
