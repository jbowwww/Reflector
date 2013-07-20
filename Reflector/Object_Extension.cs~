using System;

namespace Reflector
{
	public static class Object_Extension
	{
		public static bool IsTypeOf(this object o, Type superType)
		{
			Type t = o.GetType ();
			return (t.Equals (superType) || t.IsSubclassOf (superType));
		}
	}
}

