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
    public delegate void SigUpdate();
    public delegate void SigDraw();

    class Globals
    {
        #region data
        public static SB sb;
        public static GD gd;
        public static GDM gdm;
        public static CM cm;

        public static float regularSpeed = 2.5f;

        public static KeyboardState ks, pks;

        public static GamePadState gps, pgps;

        public static bool controlerMode;
        #endregion

        public static void init(SB sb, GD gd, GDM gdm, CM cm)
        {
            Globals.cm = cm;
            Globals.gd = gd;
            Globals.gdm = gdm;
            Globals.sb = sb;

            controlerMode = false;

            Game1.CallUpdate += new SigUpdate(Update);
        }

        public static void Update()
        {
            pks = ks;
            ks = Keyboard.GetState();
            pgps = gps;
            gps = GamePad.GetState(PlayerIndex.One);

            controlerMode = GamePad.GetState(PlayerIndex.One).IsConnected;
        }
    }
}
