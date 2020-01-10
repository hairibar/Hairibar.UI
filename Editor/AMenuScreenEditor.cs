using UnityEditor;

namespace Hairibar.UI.MenuScreenManagement
{
    [CustomEditor(typeof(AMenuScreen), true)]
    class AMenuScreenEditor : Editor
    {
        private bool HasManagerAsParent => (target as AMenuScreen).GetComponentInParent<MenuScreenManager>();

        public override void OnInspectorGUI()
        {
            if (!HasManagerAsParent) EditorGUILayout.HelpBox("AMenuScreens must be children of a MenuScreenManager to be functional.", MessageType.Error);
            else DrawDefaultInspector();
        }
    }
}