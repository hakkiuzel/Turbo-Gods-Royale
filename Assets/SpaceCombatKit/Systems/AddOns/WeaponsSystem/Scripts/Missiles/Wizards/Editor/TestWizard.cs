using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VSX.UniversalVehicleCombat;
using VSX.UniversalVehicleCombat.Radar;
using UnityEditor.Events;

public class TestWizard : EditorWindow
{

    [MenuItem("Space Combat Kit/Create/Test")]
    static void Init()
    {
        TestWizard window = (TestWizard)EditorWindow.GetWindow(typeof(TestWizard), true, "Test");
        window.Show();
    }

    private void Create()
    {

        // Create root gameobject

        GameObject gameObject = new GameObject("Test");
        Selection.activeGameObject = gameObject;

        TargetLocker targetLocker = gameObject.AddComponent<TargetLocker>();
        SerializedObject targetLockerSO = new SerializedObject(targetLocker);
        targetLockerSO.Update();

        UnityEventTools.AddPersistentListener(targetLocker.onLocked, targetLocker.SetTarget);

    }

    protected void OnGUI()
    {
        
        if (GUILayout.Button("Create"))
        {
            Create();
            Close();
        }
    }
}
