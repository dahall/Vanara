using System.Collections.Generic;
using System.Text;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.Windows.Shell
{
	public class ShellAssociation
	{
		private IQueryAssociations qassoc;

		internal ShellAssociation(string ext) { Extension = ext; }

		public static IReadOnlyDictionary<string, ShellAssociation> FileAssociations { get; } = new ShellAssociationDictionary(true);

		public string AppId => GetString(ASSOCSTR.ASSOCSTR_APPID);

		public string Command => GetString(ASSOCSTR.ASSOCSTR_COMMAND);

		public string ContentType => GetString(ASSOCSTR.ASSOCSTR_CONTENTTYPE);

		public string DefaultIcon => GetString(ASSOCSTR.ASSOCSTR_DEFAULTICON);

		public string Extension { get; }

		public string FriendlyAppName => GetString(ASSOCSTR.ASSOCSTR_FRIENDLYAPPNAME);

		public string FriendlyDocName => GetString(ASSOCSTR.ASSOCSTR_FRIENDLYDOCNAME);

		public string OpenWithPath => GetString(ASSOCSTR.ASSOCSTR_EXECUTABLE);

		public static IReadOnlyDictionary<string, CommandVerb> Verbs { get; }

		//public static ShellAssociation CreateFromCLSID(Guid classId) {  }
		//public static ShellAssociation CreateFromProgId(string progId) {  }
		public static ShellAssociation CreateFromFileExtension(string ext)
		{
			var ret = new ShellAssociation(ext);

			if (false) //Environment.OSVersion.Version.Major >= 6)
			{
				//var elements = new[] { new ASSOCIATIONELEMENT { ac = ASSOCCLASS.ASSOCCLASS_PROGID_STR, pszClass = progId } };
				//AssocCreateForClasses(elements, (uint)elements.Length, typeof(IQueryAssociations).GUID, out var iq).ThrowIfFailed();
				//ret.qassoc = (IQueryAssociations)iq;
			}
			else
			{
				AssocCreate(CLSID_QueryAssociations, typeof(IQueryAssociations).GUID, out ret.qassoc).ThrowIfFailed();
				ret.qassoc.Init(ASSOCF.ASSOCF_INIT_DEFAULTTOSTAR, ext);
			}

			return ret;
		}

		private string GetString(ASSOCSTR astr)
		{
			const ASSOCF flags = ASSOCF.ASSOCF_NOTRUNCATE | ASSOCF.ASSOCF_REMAPRUNDLL;
			var sz = 0U;
			qassoc.GetString(flags, astr, null, null, ref sz);
			var sb = new StringBuilder((int)sz, (int)sz);
			qassoc.GetString(flags, astr, null, sb, ref sz);
			return sb.ToString();
		}
	}
}