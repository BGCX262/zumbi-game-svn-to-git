using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Projeto3D
{
    class Camera3D
    {
        public Matrix projection;
        public Vector3 position, lookAt;

        public static Camera3D self;

        public Camera3D()
        {
            this.projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, 
                Game1.self.GraphicsDevice.Viewport.AspectRatio,
                1f, 
                50f);

            this.position = new Vector3(0, 50, -2);
            this.lookAt = new Vector3(0, 0, 0);

            self = this;
        }

        public Matrix View
        {
            get
            {
                Matrix view = Matrix.CreateLookAt(this.position, this.lookAt, Vector3.Up);

                return view;
            }
        }

        public Vector3 MousePosition(MouseState ms)
        {
            Vector3 nearScreenPoint = new Vector3(ms.X, ms.Y, 0);
            Vector3 farScreenPoint = new Vector3(ms.X, ms.Y, 1);
            Vector3 nearWorldPoint = Game1.self.GraphicsDevice.Viewport.Unproject(nearScreenPoint, this.projection, this.View, Matrix.Identity);
            Vector3 farWorldPoint = Game1.self.GraphicsDevice.Viewport.Unproject(farScreenPoint, this.projection, this.View, Matrix.Identity);

            Vector3 direction = farWorldPoint - nearWorldPoint;

            float zFactor = -nearWorldPoint.Y / direction.Y;
            Vector3 zeroWorldPoint = nearWorldPoint + direction * zFactor;

            return zeroWorldPoint;
        }
    }
}
