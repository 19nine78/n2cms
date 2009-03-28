using System.Configuration;

namespace N2.Configuration
{
	/// <summary>
	/// A collection of pattern replacements for the name editor.
	/// </summary>
	public class PatternValueCollection : ConfigurationElementCollection
	{
		public PatternValueCollection()
		{
			BaseAdd(new PatternValueElement("smallA", "[������@]", "a", true));
			BaseAdd(new PatternValueElement("capitalA", "[������]", "a", true));
			BaseAdd(new PatternValueElement("smallAE", "[�]", "ae", true));
			BaseAdd(new PatternValueElement("capitalAE", "[�]", "AE", true));
			BaseAdd(new PatternValueElement("smallO", "[����]", "o", true));
			BaseAdd(new PatternValueElement("capitalO", "[����]", "O", true));
			BaseAdd(new PatternValueElement("theRest", "[^. a-zA-Z0-9_-]", "", true));
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new PatternValueElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((PatternValueElement) element).Name;
		}
	}
}