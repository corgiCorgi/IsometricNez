using Microsoft.Xna.Framework;
using Nez.PhysicsShapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nez
{
	public static class Isometric
	{
		public static Vector2 ToIsometric(this Vector2 orthogonal, float tileWidth, float tileHeight)
		{
			Vector2 unScaled = orthogonal / (new Vector2(tileWidth, tileHeight));
			unScaled = new Vector2(unScaled.X - unScaled.Y, unScaled.X + unScaled.Y);
			return unScaled * (new Vector2(tileWidth / 2, tileHeight / 2));
		}
		
		public static Vector2 FromIsometric(this Vector2 isometric, float tileWidth, float tileHeight)
		{
			Vector2 unScaled = isometric / (new Vector2(tileWidth, tileHeight));
			unScaled = new Vector2(unScaled.X + unScaled.Y, unScaled.Y - unScaled.X);
			return unScaled * (new Vector2(tileWidth, tileHeight));
		}

		public static Vector2 ToIsometricScaled(this Vector2 orthogonal, float tileWidth, float tileHeight)
		{
			Vector2 unScaled = orthogonal;
			unScaled = new Vector2(unScaled.X - unScaled.Y, unScaled.X + unScaled.Y);
			return unScaled * (new Vector2(tileWidth / 2, tileHeight / 2));
		}

		public static RectangleF ToIsometric(this RectangleF orthogonal, float tileWidth, float tileHeight)
		{
			Vector2 side1 = ToIsometric(new Vector2(orthogonal.Left, orthogonal.Top), tileWidth, tileHeight);
			Vector2 side2 = ToIsometric(new Vector2(orthogonal.Right, orthogonal.Top), tileWidth, tileHeight);
			Vector2 side3 = ToIsometric(orthogonal.Max, tileWidth, tileHeight);
			Vector2 side4 = ToIsometric(new Vector2(orthogonal.Left, orthogonal.Bottom), tileWidth, tileHeight);
			return RectangleF.RectEncompassingPoints(new Vector2[] { side1, side2, side3, side4 });
		}
		public static RectangleF FromIsometric(this RectangleF isometric, float tileWidth, float tileHeight)
		{
			Vector2 side1 = FromIsometric(new Vector2(isometric.Left, isometric.Top), tileWidth, tileHeight);
			Vector2 side2 = FromIsometric(new Vector2(isometric.Right, isometric.Top), tileWidth, tileHeight);
			Vector2 side3 = FromIsometric(isometric.Max, tileWidth, tileHeight);
			Vector2 side4 = FromIsometric(new Vector2(isometric.Left, isometric.Bottom), tileWidth, tileHeight);
			return RectangleF.RectEncompassingPoints(new Vector2[] { side1, side2, side3, side4 });
		}
	}
}
