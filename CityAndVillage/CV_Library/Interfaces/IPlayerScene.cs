using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Interfaces
{
    public interface IPlayerScene
    {
        string GetMap();

        void Draw(SpriteBatch b);

        Rectangle GetCollider();

        GameObject GetInstance();

        string GetIntanceType();

        string GetSaveParameter();

        Rectangle[] GetEffiveClickArea();
    }
}
