using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DMonogame.Blocks.Collectable
{
    class CoinCollectable : StaticBlock,ICollectable
    {
        public CoinCollectable(ContentManager content, string name) : base(content,name)
        {
            
        }
        public bool IsCollected { get; set; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(!IsCollected)
                spriteBatch.Draw(Texture, Position, Color.AliceBlue);
        }

        /*public void Update(List<ICollide> collisionObjects, Collider collider)
        {
            collider.CollisionDetect(collisionObjects,(IMovingCollide) this);
        }*/


    }
}
