﻿using _2DMonogame.Blocks;
using _2DMonogame.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    abstract class AbstractLevelFactory
    {
        public Block GetBlockLevel(int id, ContentManager content, int x, int y,List<ICollide> collisionObjects)
        {

            Block block = CreateBlock(id, content);
            if (block is StaticBlock)
                collisionObjects.Add((ICollide)block);
            if (block != null)
                block.Initialize(new Vector2(y * 100, x * 100));
            return block;
            
            
        }
        protected abstract Block CreateBlock(int id, ContentManager content);
    }
}
