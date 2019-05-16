﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ValidationTestProject.Helpers
{
	[ContentProperty("Placeholder")]
	public class TranslateExtension : IMarkupExtension
	{
		readonly CultureInfo ci = null;
		const string ResourceId = "ValidationTestProject.Resext.AppResources";

		static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(
			() => new ResourceManager(ResourceId, IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));

		public string Placeholder { get; set; }

		public TranslateExtension()
		{
			//if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
			
				ci = System.Globalization.CultureInfo.CurrentCulture;
			
		}

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Placeholder == null)
				return string.Empty;

			var translation = ResMgr.Value.GetString(Placeholder, ci);
			if (translation == null)
			{
#if DEBUG
				throw new ArgumentException(
					string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Placeholder, ResourceId, ci.Name),
					"Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
			}
			return translation;
		}
	}
}
