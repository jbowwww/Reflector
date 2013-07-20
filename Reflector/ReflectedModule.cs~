using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Reflector
{
	/// <summary>
	/// Reflected <see cref="Module"/>
	/// </summary>
	[XmlRoot("Module")]
	public class ReflectedModule
	{
		private Module _module = null;

		/// <summary>
		/// Gets the assembly.
		/// </summary>
		[XmlIgnore]
		public Module Module {
			get
			{
				if (_module == null)
					throw new NullReferenceException ("ReflectedModule.Module == null");
				return _module;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException ("ReflectedModule.set.value");
				_module = value;
				
				FullyQualifiedName = value.FullyQualifiedName;
				Name = value.Name;
				ScopeName = value.ScopeName;
				MDStreamVersion = value.MDStreamVersion;
				VersionId = value.ModuleVersionId;
			}
		}
		
		[XmlAttribute]
		public string Name { get; private set; }
		
		/// <summary>
		/// Gets or sets the name of the fully qualified.
		/// </summary>
		public string FullyQualifiedName { get; private set; }
		
		/// <summary>
		/// Gets or sets the name of the scope.
		/// </summary>
		public string ScopeName { get; private set; }
		
		/// <summary>
		/// Gets or sets the MD stream version.
		/// </summary>
		[XmlAttribute]
		public int MDStreamVersion { get; private set; }
		
		/// <summary>
		/// Gets or sets the version identifier.
		/// </summary>
		[XmlAttribute]
		public Guid VersionId { get; private set; }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Reflector.ReflectedModule"/> class.
		/// </summary>
		public ReflectedModule()
		{
		}
	}
}

