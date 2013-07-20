using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Reflector
{
	/// <summary>
	/// Reflected member.
	/// </summary>
	[XmlRoot("Member")]
	public class ReflectedMember
	{
		private MemberInfo _member = null;
		
		/// <summary>
		/// Gets or sets the member
		/// </summary>
		/// <exception cref="NullReferenceException">
		/// Is thrown when there is an attempt to dereference a null object reference.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
		/// </exception>
		[XmlIgnore]
		public virtual MemberInfo Member {
			get
			{
				if (_member == null)
					throw new NullReferenceException ("ReflectedMember.Member == null");
				return _member;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException ("ReflectedMember.Member.set.value");
				_member = value;
				
				MemberType = value.MemberType.ToString ();
//				Name = value.Name.StartsWith ("get_") || value.Name.StartsWith ("set_") ||
//					value.Name.StartsWith ("add_") || value.Name.StartsWith ("remove_") ? null : value.Name;
				Name = value.Name;
				
//				Access = _member.IsPublic ? "public" : _member.IsPrivate ? "private" : _member.IsAssembly ? "internal" : "protected";
//				
//				List<string> modifiers = new List<string> ();
//				if (_member.IsAbstract)
//					modifiers.Add ("abstract");
//				if (_member.IsFinal)
//					modifiers.Add ("sealed");
//				if (_member.IsStatic)
//					modifiers.Add ("static");
//				if (_member.IsVirtual)
//					modifiers.Add ("virtual");
//				Modifiers = string.Join (" ", modifiers.ToArray (), 0, modifiers.Count);
			}
		}
		
		/// <summary>
		/// Gets or sets the type of the member.
		/// </summary>
		[XmlIgnore]
		public string MemberType { get; protected set; }
		
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[XmlIgnore]
		public string Name { get; protected set; }
		
		/// <summary>
		/// Returns member name, unless it is a get/set property accessor or an event add/remove method, in which case it returns null
		/// </summary>
		[XmlAttribute("Name")]
		public string FilteredName {
			get
			{
				return (Name.StartsWith ("get_") || Name.StartsWith ("set_") ||
					Name.StartsWith ("add_") || Name.StartsWith ("remove_")) ? null : Name;
			}
			protected set {}
		}
		
		/// <summary>
		/// Gets or sets the modifiers.
		/// </summary>
		[XmlAttribute]
		public string Modifiers { get; protected set; }
		
		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		[XmlIgnore]
		public Type Type { get; protected set; }
		
		/// <summary>
		/// Gets or sets the name of the type.
		/// </summary>
		[XmlAttribute(AttributeName="Type")]
		public string TypeName { get { return Type == null ? null : Type.Name; } set { } }
		
		/// <summary>
		/// Gets or sets the access.
		/// </summary>
		[XmlAttribute]
		public string Access { get; protected set; }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Reflector.ReflectedMember"/> class.
		/// </summary>
		public ReflectedMember()
		{
		}
	}
}

