﻿using System;
using System.Collections.Generic;
using System.Web;
using N2.Engine;
using N2.Plugin;
using N2.Edit.FileSystem;
using N2.Edit;
using N2.Web;
using N2.Configuration;
using Management.N2.Files;

namespace N2.Management.Files
{
	[Service]
	public class UploadedFilesResizer : IAutoStart
	{
		IFileSystem files;
		ImageResizer resizer;
		ImagesElement images;

		public UploadedFilesResizer(IFileSystem files, ImageResizer resizer, EditSection config)
		{
			this.files = files;
			this.resizer = resizer;
			this.images = config.Images;
		}

		void files_FileWritten(object sender, FileEventArgs e)
		{
			if (!ImagesUtility.IsImagePath(e.VirtualPath))
				return;
			
			foreach (ImageSizeElement size in images.Sizes)
			{
				Url url = e.VirtualPath;
				string resizedPath = ImagesUtility.GetResizedPath(url, size.Name);
				resizer.Resize(files.OpenFile(e.VirtualPath), url.Extension, size.Width, size.Height, files.OpenFile(resizedPath));
			}
		}

		void files_FileMoved(object sender, FileEventArgs e)
		{
			if (!ImagesUtility.IsImagePath(e.VirtualPath))
				return;
			
			foreach (ImageSizeElement size in images.Sizes)
			{
				string source = ImagesUtility.GetResizedPath(e.SourcePath, size.Name);
				if (files.FileExists(source))
				{
					string destination = ImagesUtility.GetResizedPath(e.VirtualPath, size.Name);
					files.MoveFile(source, destination);
				}
			}
		}

		void files_FileDeleted(object sender, FileEventArgs e)
		{
			if (!ImagesUtility.IsImagePath(e.VirtualPath))
				return;

			foreach (ImageSizeElement size in images.Sizes)
			{
				string resizedPath = ImagesUtility.GetResizedPath(e.VirtualPath, size.Name);

				if (files.FileExists(resizedPath))
					files.DeleteFile(resizedPath);
			}
		}

		#region IAutoStart Members

		public void Start()
		{
			if (!images.ResizeUploadedImages)
				return;

			files.FileWritten += files_FileWritten;
			files.FileMoved += files_FileMoved;
			files.FileDeleted += files_FileDeleted;
		}

		public void Stop()
		{
			if (!images.ResizeUploadedImages)
				return;

			files.FileWritten -= files_FileWritten;
			files.FileMoved += files_FileMoved;
			files.FileDeleted += files_FileDeleted;
		}

		#endregion
	}
}