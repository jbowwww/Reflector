using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Reflector
{
	/// <summary>
	/// Reflected method.
	/// </summary>
	[XmlRoot("Method")]
	public class ReflectedMethod
		: ReflectedMember
	{
		private MethodInfo _methodInfo;
		
		[XmlIgnore]
		public override MemberInfo Member {
			get
			{
				return base.Member;
			}
			set
			{
				base.Member = value;
				_methodInfo = value as MethodInfo;
//					methodInfo.CallingConvention
				
				base.Access = _methodInfo.ReflectedType.IsInterface ? null :
					_methodInfo.IsPublic ? "public" : _methodInfo.IsPrivate ? "private" :
						_methodInfo.IsAssembly ? "internal" : "protected";
				
				List<string> modifiers = new List<string> ();
				if (_methodInfo.IsAbstract)
					modifiers.Add ("abstract");
				if (_methodInfo.IsFinal)
					modifiers.Add ("sealed");
				if (_methodInfo.IsStatic)
					modifiers.Add ("static");
				if (_methodInfo.IsVirtual)
					modifiers.Add ("virtual");
				base.Modifiers = modifiers.Count == 0 ? null : string.Join (" ", modifiers.ToArray (), 0, modifiers.Count);
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Reflector.ReflectedMethod"/> class.
		/// </summary>
		public ReflectedMethod()
		{
		}
	}
}

