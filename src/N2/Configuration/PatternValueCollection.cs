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
			BaseAdd(new PatterValueElement("[������@]", "a", true));
			BaseAdd(new PatterValueElement("[������]", "a", true));
			BaseAdd(new PatterValueElement("[�]", "ae", true));
			BaseAdd(new PatterValueElement("[�]", "AE", true));
			BaseAdd(new PatterValueElement("[����]", "o", true));
			BaseAdd(new PatterValueElement("[����]", "O", true));
			BaseAdd(new PatterValueElement("[^ a-zA-Z0-9_-]", "", true));
		}
		protected override ConfigurationElement CreateNewElement()
		{
			return new PatterValueElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((PatterValueElement) element).Pattern;
		}
	}
}