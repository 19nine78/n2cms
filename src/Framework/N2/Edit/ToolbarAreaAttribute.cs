﻿using System;
using System.Collections.Generic;
using System.Text;
using N2.Definitions;
using System.Web.UI;
using System.Security.Principal;

namespace N2.Edit
{
	public abstract class ToolbarAreaAttribute : Attribute, IContainable
	{
		private string containerName;
		private int sortOrder;
		private string name;

		public int SortOrder
		{
			get { return sortOrder; }
			set { sortOrder = value; }
		}

		public string ContainerName
		{
			get { return containerName; }
			set { containerName = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}


		public void AddTo(ContainableContext context)
		{
			throw new NotImplementedException();
		}

		public bool IsAuthorized(IPrincipal user)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(IContainable other)
		{
			throw new NotImplementedException();
		}
	}
}
