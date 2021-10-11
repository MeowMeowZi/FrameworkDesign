using CountApp.Scripts;
using FrameworkDesign.Framework.Architecture;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class EditorCounterApp : EditorWindow, IController
    {
        [MenuItem("EditorCounterApp/Open")]
        static void Open()
        {
            CountApp.Scripts.CountApp.OnRegisterPatch += app =>
            {
                app.RegisterUtility<IStorage>(new EditorPresStorage());
            };
            
            var editorCounterApp = GetWindow<EditorCounterApp>();
            editorCounterApp.name = nameof(EditorCounterApp);
            editorCounterApp.position = new Rect(100, 100, 400, 600);
            editorCounterApp.titleContent = new GUIContent(nameof(EditorCounterApp));
            editorCounterApp.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                GetArchitecture().SendCommand<AddCountCommand>();
            }

            GUILayout.Label(CountApp.Scripts.CountApp.Get<ICountModel>().Count.Value.ToString());
            
            if (GUILayout.Button("-"))
            {
                GetArchitecture().SendCommand<SubCountCommand>();
            }
        }

        public IArchitecture GetArchitecture()
        {
            return CountApp.Scripts.CountApp.Interface;
        }
    }
}
