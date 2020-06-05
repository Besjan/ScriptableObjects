namespace Cuku.ScriptableObject
{
	using Sirenix.OdinInspector;
	using Sirenix.OdinInspector.Editor;
	using Sirenix.Utilities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;

	public class SOPathDrawer : OdinAttributeProcessor<StringSO>
	{
		public override bool CanProcessChildMemberAttributes(InspectorProperty parentProperty, MemberInfo member)
		{
			var objectName = parentProperty.ValueEntry.WeakSmartValue.ToString();
			var hasPathInName = objectName.Contains("path", StringComparison.OrdinalIgnoreCase);

			return hasPathInName;
		}

		public override void ProcessChildMemberAttributes(
			InspectorProperty parentProperty,
			MemberInfo member,
			List<Attribute> attributes)
		{
			if (member.Name == "Value")
			{
				var folderPathAttribute = new FolderPathAttribute();
				folderPathAttribute.AbsolutePath = true;
				folderPathAttribute.RequireExistingPath = true;

				attributes.Add(folderPathAttribute);
			}
		}
	}
}