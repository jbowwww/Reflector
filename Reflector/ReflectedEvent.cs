using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Reflector
{
	/// <summary>
	/// Reflected event.
	/// </summary>
	[XmlRoot("Event")]
	public class ReflectedEvent
		: ReflectedMember
	{
		private EventInfo _eventInfo;
		
		[XmlIgnore]
		public override System.Reflection.MemberInfo Member {
			get { return base.Member; }
			set
			{
				base.Member = value;
				_eventInfo = value as EventInfo;
				base.Type = _eventInfo.EventHandlerType;
//						_eventInfo.EventHandlerType
				AddMethod = new ReflectedMethod () { Member = _eventInfo.GetAddMethod (true) };
				RemoveMethod = new ReflectedMethod () { Member = _eventInfo.GetRemoveMethod (true) };
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Reflector.ReflectedEvent"/> class.
		/// </summary>
		public ReflectedEvent()
		{
		}
		
		[XmlElement("Add")]
		public ReflectedMethod AddMethod { get; protected set; }
		
		[XmlElement("Remove")]
		public ReflectedMethod RemoveMethod { get; protected set; }
	}
}

