using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Reflector
{
	/// <summary>
	/// Reflected <see cref="Type"/>
	/// </summary>
	[XmlRoot("Type")]
	public class ReflectedType
//		: IHtmlFormattable
	{
		private Type _type = null;

		private bool _referenceOnly = false;
		
		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <exception cref="NullReferenceException">
		/// Is thrown when there is an attempt to dereference a null object reference.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
		/// </exception>
		[XmlIgnore]
		public Type Type {
			get
			{
				if (_type == null)
					throw new NullReferenceException ("ReflectedType.Type == null");
				return _type;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException ("ReflectedType.Type.set.value");
				_type = value;
				
				Name = value.Name;
				FullName = value.FullName;
				IsInterface = value.IsInterface;
				
				if (!_referenceOnly)
				{
					Type[] ifaces = value.GetInterfaces ();
					Interfaces = ifaces.Length == 0 ? null : new ReflectedType[ifaces.Length];
					for (int i = 0; i < ifaces.Length; i++)
						Interfaces [i] = new ReflectedType (true) { Type = ifaces [i] };

					Members = new List<ReflectedMember> ();
					BindingFlags bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
					foreach (MemberInfo mi in value.GetMembers (bf))
						if (mi.MemberType != MemberTypes.Method || (!mi.Name.StartsWith ("get_") && !mi.Name.StartsWith ("set_")
						&& !mi.Name.StartsWith ("add_") && !mi.Name.StartsWith ("remove_")))
							Members.Add (
							mi.MemberType == MemberTypes.Field ? new ReflectedField () { Member = mi } :
							mi.MemberType == MemberTypes.Property ? new ReflectedProperty () { Member = mi } :
							mi.MemberType == MemberTypes.Event ? new ReflectedEvent () { Member = mi } :
							mi.MemberType == MemberTypes.Method ? new ReflectedMethod () { Member = mi } :
							mi.MemberType == MemberTypes.Constructor ? new ReflectedConstructor () { Member = mi } :
							new ReflectedMember () { Member = mi });
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[XmlIgnore]
		public string Name { get; private set; }
		
		/// <summary>
		/// Gets or sets the full name.
		/// </summary>
		[XmlAttribute]
		public string FullName { get; private set; }

		/// <summary>
		/// Gets or sets the access.
		/// </summary>
		[XmlAttribute]
		public string Access { get; private set; }
		
		/// <summary>
		/// Gets or sets the modifiers.
		/// </summary>
		[XmlAttribute]
		public string Modifiers { get; private set; }
		
		/// <summary>
		/// Gets or sets a value indicating whether this instance is value type.
		/// </summary>
		[XmlAttribute]
		public string IsValueType { get { return Type.IsValueType ? "true" : null; } private set { } }
		
		/// <summary>
		/// Gets or sets a value indicating whether this instance is interface.
		/// </summary>
		[XmlIgnore]
		public bool IsInterface { get; private set; }
		
		/// <summary>
		/// Gets or sets a value indicating whether this instance is interface.
		/// </summary>
		[XmlAttribute("IsInterface")]
		public string IsInterfaceString { get { return IsInterface && !_referenceOnly ? "true" : null; } private set { } }
		
		/// <summary>
		/// Gets or sets the type of the base.
		/// </summary>
		[XmlIgnore]
		public Type BaseType { get; private set; }
		
		/// <summary>
		/// Gets or sets the name of the base type.
		/// </summary>
		[XmlElement("BaseType", Order=2)]
		public string BaseTypeName { get; private set; }
		
		[XmlArray("Interfaces", Order=3), XmlArrayItem("Interface")]
		public ReflectedType[] Interfaces { get; private set; }
		
		/// <summary>
		/// The members.
		/// </summary>
		[XmlArray(Order=4)]
		[XmlArrayItem("Field", typeof(ReflectedField)), XmlArrayItem("Property", typeof(ReflectedProperty))]
		[XmlArrayItem("Event", typeof(ReflectedEvent)), XmlArrayItem("Method", typeof(ReflectedMethod))]
		[XmlArrayItem("Constructor", typeof(ReflectedConstructor)), XmlArrayItem("Member", typeof(ReflectedMember))]
		public List<ReflectedMember> Members { get; protected set; }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Reflector.ReflectedType"/> class.
		/// </summary>
		/// <remarks>
		/// Default constructor needed for <see cref="XmlSerializer"/>
		/// </remarks>
		public ReflectedType()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Reflector.ReflectedType"/> class.
		/// </summary>
		/// <param name="referenceOnly">
		/// Set to true if this instance should be a reference to another instance by name only (does not init <see cref="Members"/>
		/// </param>
		public ReflectedType(bool referenceOnly = false)
		{
			_referenceOnly = referenceOnly;
		}
		
		/// <summary>
		/// Writes HTML to a <see cref="XmlWriter"/>
		/// </summary>
		/// <param name="xw">A <see cref="XmlWriter"/> to write HTML to</param>
		/// <remarks>IHtmlFormattable implementation</remarks>
//		public void WriteHtml(XmlWriter xw)
//		{
//			string idBase = string.Concat ("Type", FullName);
//			xw.WriteStartElement ("div");
//			xw.WriteAttributeString ("class", "Type");
//			xw.WriteAttributeString ("id", idBase);
//			
//			xw.WriteStartElement ("span");
//			xw.WriteAttributeString ("class", "Name");
//			xw.WriteAttributeString ("id", idBase + "-Name");
//			xw.WriteValue (Name);
//			xw.WriteEndElement ();
//			
//			xw.WriteStartElement ("div");
//			xw.WriteAttributeString ("class", "Members");
//			xw.WriteAttributeString ("id", idBase + "-Members");
//			
//			BindingFlags bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
//			foreach (MemberInfo mi in Type.GetMembers (bf))
//			{
//				xw.WriteStartElement ("div");
//				xw.WriteAttributeString ("class", "Member");
//				xw.WriteAttributeString ("id", idBase + "_" + mi.Name);
//				xw.WriteStartElement ("span");
//				xw.WriteAttributeString ("class", "Name");
//				xw.WriteValue (mi.Name);
//				xw.WriteEndElement();		// span class="Name"
//				xw.WriteEndElement ();		// div class="Member" id=idBase+"_"+mi.Name
//			}
//			
//			xw.WriteEndElement ();		// div class="Members" id=idBase+"-Members"
//			xw.WriteEndElement ();		// div class="Type" id=idBase
//		}
	}
}

