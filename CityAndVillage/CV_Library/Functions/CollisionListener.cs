using Box2D.XNA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Functions
{
    public class CollisionListener : IContactListener
    {
        public void BeginContact(Contact contact)
        {
            //Player p;
            //if (contact.GetFixtureA().GetBody().GetUserData() is Player)
            //{
            //    p = contact.GetFixtureA().GetBody().GetUserData() as Player;
            //}
            //else
            //{
            //    p = contact.GetFixtureB().GetBody().GetUserData() as Player;
            //}
            if (contact.GetFixtureA().GetBody().GetUserData() is Player || contact.GetFixtureB().GetBody().GetUserData() is Player)
            {
                Console.WriteLine("Test good");
            }
        }

        public void EndContact(Contact contact)
        {
        }

        public void PreSolve(Contact contact, ref Manifold oldManifold)
        {
        }

        public void PostSolve(Contact contact, ref ContactImpulse impulse)
        {
        }
    }
}
