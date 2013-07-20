using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Reflector
{
	/// <summary>
	/// Reflected property.
	/// </summary>
	[XmlRoot("Property")]
	public class ReflectedProperty
		: ReflectedMember
	{
		private PropertyInfo _propInfo;
		
		[XmlIgnore]
		public override System.Reflection.MemberInfo Member {
			get { return base.Member; }
			set
			{
				base.Member = value;
				_propInfo = value as PropertyInfo;
				
				base.Type = _propInfo.PropertyType;
//				base.Access = _propInfo.IsPublic ? "public" : _propInfo.IsPrivate ? "private" : _propInfo.IsAssembly ? "internal " : "protected";
				List<string> modifiers = new List<string> ();
//				if (_propInfo.IsAbstract) modifiers.Add ("abstract");
//				if (_propInfo.IsFinal) modifiers.Add ("sealed");
//				if (_propInfo.IsStatic) modifiers.Add ("static");
//				if (_propInfo.IsVirtual) modifiers.Add ("virtual");
//				base.Modifiers = string.Join (" ", modifiers.ToArray (), 0, modifiers.Count);
				AccessorMethods = new List<ReflectedMethod> ();
				foreach (MethodInfo accMethod in _propInfo.GetAccessors (true))
				{
					if (accMethod.Name.StartsWith ("get_"))
						GetMethod = new ReflectedMethod () { Member = accMethod };
					else if (accMethod.Name.StartsWith ("set_"))
						SetMethod = new ReflectedMethod () { Member = accMethod };
					else
						AccessorMethods.Add (new ReflectedMethod () { Member = accMethod });
				}
				if (AccessorMethods.Count == 0)
					AccessorMethods = null;
			}
		}
		
		/// <summary>
		/// Gets or sets the property accessors.
		/// </summary>
		[XmlAttribute]
		public string Accessors { get; protected set; }
		
		[XmlElement("Get")]
		public ReflectedMethod GetMethod { get; protected set; }
				
		[XmlElement("Set")]
		public ReflectedMethod SetMethod { get; protected set; }
		
		[XmlArray(null), XmlArrayItem("Accessor")]
		public List<ReflectedMethod> AccessorMethods { get; protected set; }
		
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Reflector.ReflectedProperty"/> class.
		/// </summary>
		public ReflectedProperty()
		{
		}
	}
}

