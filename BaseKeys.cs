﻿#region Using
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
    class BaseKeys
    {
        /// <summary>
        /// the keys in the game
        /// </summary>
        protected  Keys left, right, up, down, jump , select, start;

        /// <summary>
        /// a boolean to check if the key was pressed
        /// </summary>
        public Boolean pLeft, pRight, pUp, pDown, pJump , pSelect, pStart;


        #region init
        /// <summary>
        /// inits the keys for the game's control
        /// </summary>
        public BaseKeys(Keys up, Keys down, Keys left, Keys right, Keys select, Keys start , Keys jump)
        {
            this.left = left;
            pLeft = false;
            this.right = right;
            pRight = false;
            this.up = up;
            pUp = false;
            this.down = down;
            pDown = false;
            this.select = select;
            pSelect = false;
            this.start = start;
            pStart = false;
            this.jump = jump;
            pJump = false;

            Game1.CallUpdate += new SigUpdate(Update);
        }
        #endregion

        #region update
        public void Update()
        {
            pLeft = leftPressed();
            pRight = rightPressed();
            pUp = upPressed();
            pDown = downPressed();
            pSelect = selectPressed();
            pStart = startPressed();
            pJump = jumpPressed();
        }

        public virtual bool jumpPressed()
        {
            return pJump;
        }

        public virtual bool leftPressed()
        {
            return pLeft;
        }

        public virtual bool rightPressed()
        {
            return pRight;
        }

        public virtual bool upPressed()
        {
            return pUp;
        }

        public virtual bool downPressed()
        {
            return pDown;
        }

        public virtual bool selectPressed()
        {
            return pSelect;
        }

        public virtual bool startPressed()
        {
            return pStart;
        }
        #endregion
    }
}