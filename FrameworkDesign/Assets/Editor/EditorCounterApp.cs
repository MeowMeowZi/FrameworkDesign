using System;
using CountApp.Scripts;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class EditorCounterApp : EditorWindow
    {
        [MenuItem("EditorCounterApp/Open")]
        static void Open()
        {
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
                new AddCountCommand()
                    .Execute();
            }

            GUILayout.Label(CountApp.Scripts.CountApp.Get<ICountModel>().Count.Value.ToString());
            
            if (GUILayout.Button("-"))
            {
                new SubCountCommand()
                    .Execute();
            }
        }
    }
}
