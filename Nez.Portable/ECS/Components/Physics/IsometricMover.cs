using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nez 
{ 
	public class IsometricMover : Mover
	{
	float tileW;
	float tileH;

	public IsometricMover(float tileWidth, float tileHeight)
	{
		tileW = tileWidth;
		tileH = tileHeight;
	}

		public bool Move(Vector2 motion, out CollisionResult collisionResult, bool slow = false)
		{
			Vector2 isometric;
			if (slow)
			{
				isometric = motion.ToIsometric(tileW, tileH);
			}
			else
			{
				isometric = motion.ToIsometricScaled(tileW, tileH);
			}


			return base.Move(isometric, out collisionResult);
		}


	}
}
