﻿namespace Project.Reflection
{
	public static class ReflectionHelper
	{
		#region Methods

		public static string GetFieldName(string name)
		{
			var prefix = Environment.Version.Major == 4 ? string.Empty : "_";

			return $"{prefix}{name}";
		}

		#endregion
	}
}