﻿using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UnityAnimationRecorder))]
public class UnityAnimationRecorderEditor : Editor {

	// save file path
	SerializedProperty savePath;
	SerializedProperty fileName;

	SerializedProperty startRecordKey;
	SerializedProperty stopRecordKey;

	// options
	SerializedProperty showLogGUI;
	SerializedProperty recordLimitedFrames;
	SerializedProperty recordFrames;
	SerializedProperty recordBlendShape;

	SerializedProperty changeTimeScale;
	SerializedProperty timeScaleOnStart;
	SerializedProperty timeScaleOnRecord;


	void OnEnable () {

		savePath = serializedObject.FindProperty ("savePath");
		fileName = serializedObject.FindProperty ("fileName");

		startRecordKey = serializedObject.FindProperty ("startRecordKey");
		stopRecordKey = serializedObject.FindProperty ("stopRecordKey");

		showLogGUI = serializedObject.FindProperty ("showLogGUI");
		recordLimitedFrames = serializedObject.FindProperty ("recordLimitedFrames");
		recordFrames = serializedObject.FindProperty ("recordFrames");
		recordBlendShape = serializedObject.FindProperty ("recordBlendShape");

		changeTimeScale = serializedObject.FindProperty ("changeTimeScale");
		timeScaleOnStart = serializedObject.FindProperty ("timeScaleOnStart");
		timeScaleOnRecord = serializedObject.FindProperty ("timeScaleOnRecord");
	
	}

	public override void OnInspectorGUI () {
		serializedObject.Update ();

		EditorGUILayout.LabelField ("== Path Settings ==");

		if (GUILayout.Button ("Set Save Path")) {
			string defaultName = serializedObject.targetObject.name + "-Animation";
			string targetPath = EditorUtility.SaveFilePanelInProject ("Save Anim File To ..", defaultName, "", "please select a folder and enter the file name");

			int lastIndex = targetPath.LastIndexOf ("/");
			savePath.stringValue = targetPath.Substring (0, lastIndex + 1);
			string toFileName = targetPath.Substring (lastIndex + 1);

			fileName.stringValue = toFileName;
		}
		EditorGUILayout.PropertyField (savePath);
		EditorGUILayout.PropertyField (fileName);


		EditorGUILayout.Space ();

		// keys setting
		EditorGUILayout.LabelField( "== Control Keys ==" );
		EditorGUILayout.PropertyField (startRecordKey);
		EditorGUILayout.PropertyField (stopRecordKey);

		EditorGUILayout.Space ();

		// Other Settings
		EditorGUILayout.LabelField( "== Other Settings ==" );
		recordBlendShape.boolValue = EditorGUILayout.Toggle ("Record BlendShapes", recordBlendShape.boolValue);
		bool timeScaleOption = EditorGUILayout.Toggle ( "Change Time Scale", changeTimeScale.boolValue);
		changeTimeScale.boolValue = timeScaleOption;

		if (timeScaleOption) {
			timeScaleOnStart.floatValue = EditorGUILayout.FloatField ("TimeScaleOnStart", timeScaleOnStart.floatValue);
			timeScaleOnRecord.floatValue = EditorGUILayout.FloatField ("TimeScaleOnRecord", timeScaleOnRecord.floatValue);
		}

		// gui log message
		showLogGUI.boolValue = EditorGUILayout.Toggle ("Show Debug On GUI", showLogGUI.boolValue);

		// recording frames setting
		recordLimitedFrames.boolValue = EditorGUILayout.Toggle( "Record Limited Frames", recordLimitedFrames.boolValue );

		if (recordLimitedFrames.boolValue)
			EditorGUILayout.PropertyField (recordFrames);

		serializedObject.ApplyModifiedProperties ();

		//DrawDefaultInspector ();
	}
}
