using UnityEngine;
using System.Collections;

public static class ExtensionMethodsRect  {

	public static bool Intersects(this Rect self,Rect other){
		return (self.xMin <= other.xMax && self.xMax >= other.xMin && self.yMin <= other.yMax && self.yMax >= other.yMin);
	}

}
