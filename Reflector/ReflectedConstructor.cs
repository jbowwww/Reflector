using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Reflector
{
	/// <summary>
	/// Reflected constructor.
	/// </summary>
	[XmlRoot("Constructor")]
	public class ReflectedConstructor
		: ReflectedMember
	{
		private ConstructorInfo _ctorInfo;
		
		[XmlIgnore]
		public override MemberInfo Member {
			get { return base.Member; }
			set
			{
				base.Member = value;
				_ctorInfo = value as ConstructorInfo;
				
				base.Access = _ctorInfo.IsPublic ? "public" : _ctorInfo.IsPrivate ? "private" : _ctorInfo.IsAssembly ? "internal" : "protected";
				
				List<string> modifiers = new List<string> ();
				if (_ctorInfo.IsAbstract) modifiers.Add ("abstract");
				if (_ctorInfo.IsFinal) modifiers.Add ("sealed");
				if (_ctorInfo.IsStatic) modifiers.Add ("static");
				if (_ctorInfo.IsVirtual) modifiers.Add ("virtual");
				base.Modifiers = string.Join (" ", modifiers.ToArray (), 0, modifiers.Count);

			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Reflector.ReflectedConstructor"/> class.
		/// </summary>
		public ReflectedConstructor()
		{
		}
	}
}

