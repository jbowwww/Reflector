using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Reflector
{
	/// <summary>
	/// Reflected field.
	/// </summary>
	[XmlRoot("Field")]
	public class ReflectedField
		: ReflectedMember
	{
		private FieldInfo _fieldInfo;
		
		[XmlIgnore]
		public override MemberInfo Member {
			get { return base.Member; }
			set
			{
				base.Member = value;
				_fieldInfo = value as FieldInfo;
				base.Access = _fieldInfo.IsPublic ? "public" : _fieldInfo.IsPrivate ? "private" : _fieldInfo.IsAssembly ? "internal " : "protected";
				base.Modifiers = _fieldInfo.IsLiteral ? "const" : _fieldInfo.IsStatic ? "static" : null;		//string.Empty;
				base.Type = _fieldInfo.FieldType;
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Reflector.ReflectedField"/> class.
		/// </summary>
		public ReflectedField()
		{
		}
	}
}

