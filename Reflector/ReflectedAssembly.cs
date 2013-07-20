using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Reflector
{
	/// <summary>
	/// Reflected assembly.
	/// </summary>
	[XmlRoot("Assembly")]
	public class ReflectedAssembly
	{
		private Assembly _assembly = null;

		/// <summary>
		/// Gets the assembly.
		/// </summary>
		[XmlIgnore]
		public Assembly Assembly {
			get
			{
				if (_assembly == null)
					throw new NullReferenceException ("ReflectedAssembly.Assembly == null");
				return _assembly;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException ("ReflectedAssembly.set.value");
//				if (!value.GetType().IsTypeOf(typeof(Assembly)))
//					throw new InvalidCastException(string.Format ("Assembly.set: typeof(value).FullName={0}", value.GetType().FullName));
				_assembly = value;
				
				Name = value.GetName ();
				foreach (Type T in value.GetTypes())
					Types.Add (new ReflectedType () { Type = T });
				foreach (Type T in value.GetTypes())
					ExportedTypes.Add (new ReflectedType () { Type = T });
				foreach (Module m in value.GetModules(true))
					Modules.Add (new ReflectedModule () { Module = m });
			}
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		[XmlIgnore]
		public AssemblyName Name { get; private set; }
		
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[XmlAttribute("Name")]
		public string ShortName { get { return Name.Name; } set { } }
		
		/// <summary>
		/// Gets the name of the assembly.
		/// </summary>
		[XmlElement(Order = 1)]
		public string FullName { get { return Name.FullName; } set {} }
		
		/// <summary>
		/// Gets the modules.
		/// </summary>
		[XmlArray("Modules", Order = 2), XmlArrayItem("Module")]
		public List<ReflectedModule> Modules = new List<ReflectedModule> ();

		/// <summary>
		/// Gets the types.
		/// </summary>
		[XmlArray("Types", Order = 3), XmlArrayItem("Type")]
		public List<ReflectedType> Types = new List<ReflectedType> ();

		/// <summary>
		/// Gets the exported types.
		/// </summary>
		[XmlArray("ExportedTypes", Order = 4), XmlArrayItem("Type")]
		public List<ReflectedType> ExportedTypes = new List<ReflectedType> ();
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Reflector.ReflectedAssembly"/> class.
		/// </summary>
		public ReflectedAssembly() {}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="AssemblyReflector.ReflectedAssembly"/> class.
		/// </summary>
		public ReflectedAssembly (string assemblyPath)
		{
			Assembly = Assembly.LoadFile(assemblyPath);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AssemblyReflector.ReflectedAssembly"/> class.
		/// </summary>
		/// <param name="assembly">Assembly</param>
		public ReflectedAssembly (Assembly assembly)
		{
			Assembly = assembly;
		}
	}
}
