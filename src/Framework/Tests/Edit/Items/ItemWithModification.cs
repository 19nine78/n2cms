using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace N2.Tests.Edit.Items
{
	public class ItemWithModification : N2.ContentItem
	{
		[N2.Details.EditableTextBox("Essay", 10)]
		[N2.Web.UI.EditorModifier("TextMode", TextBoxMode.MultiLine)]
		[N2.Web.UI.EditorModifier("Rows", 10)]
		public virtual string Essay
		{
			get { return (string)(GetDetail("Essay") ?? string.Empty); }
			set { SetDetail("Essay", value); }
		}
	}
}
