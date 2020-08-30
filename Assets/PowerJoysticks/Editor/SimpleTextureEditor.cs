using UnityEditor;
using UnityEngine;
using System.IO;

namespace TLGFPowerJoysticks {

	public class SimpleTextureEditor : EditorWindow {


		private Texture2D overlayTextureA;
		private Texture2D overlayTextureB;
		private Texture2D overlayResultTexture;

		private Texture2D combineTextureA;
		private Texture2D combineTextureB;
		private Texture2D combineTextureResult;

		private Texture2D tintTextureA;
		private Texture2D tintTextureResult;
		private Color tintColor = Color.white;

		private Texture2D brightnessContrastTextureA;
		private Texture2D brightnessContrastTextureResult;
		private float brightness;
		private float contrast;

		private Texture2D invertTexture;
		private Texture2D invertTextureResult;

		private string filename;
		private GUIStyle style, styleCentered;
		private Vector2 scrollPosition;


		void Awake () {
			style = new GUIStyle ();
			style.normal.textColor = new Color (0.975f,0.975f,0.975f);
			style.alignment = TextAnchor.MiddleLeft;
			styleCentered = new GUIStyle ();
			styleCentered.normal.textColor = new Color (0.975f,0.975f,0.975f);
			styleCentered.alignment = TextAnchor.MiddleCenter;
			styleCentered.fontStyle = FontStyle.Normal;
		}
			
		// Add menu item named "My Window" to the Window menu
		[MenuItem("Window/The Little Game Factory/Power Joysticks/Simple Texture Editor")]
		public static void ShowWindow() {
			//Show existing window instance. If one doesn't exist, make one.
			EditorWindow.GetWindow(typeof(SimpleTextureEditor), false, "Simple Texture Editor");
		}

		void OnGUI() {
			scrollPosition = EditorGUILayout.BeginScrollView (scrollPosition);
			// OVERLAY
			EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.BeginVertical (GUILayout.MaxWidth(256),GUILayout.Width(256));
			GUI.backgroundColor = new Color ((1f/255f) * 31f, (1f/255f) * 120f, (1f/255f) * 163f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Overlay Texture", styleCentered, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			GUI.backgroundColor = new Color ((1f/255f) * 0f, (1f/255f) * 66f, (1f/255f) * 99f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Texture", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			EditorGUI.BeginChangeCheck ();
			overlayTextureA = (Texture2D) EditorGUILayout.ObjectField (overlayTextureA, typeof (Texture2D), true);
			if(EditorGUI.EndChangeCheck() && overlayTextureA != null && overlayTextureB != null) {
				CreateOverlay (overlayTextureA,overlayTextureB);
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("Overlay Texture", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			EditorGUI.BeginChangeCheck ();
			overlayTextureB = (Texture2D) EditorGUILayout.ObjectField (overlayTextureB, typeof (Texture2D), true);
			if(EditorGUI.EndChangeCheck() && overlayTextureA != null && overlayTextureB != null) {
				CreateOverlay (overlayTextureA,overlayTextureB);
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			GUI.backgroundColor = new Color ((1f/255f) * 0f, (1f/255f) * 66f, (1f/255f) * 99f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Filename", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			filename = EditorGUILayout.TextField (filename);
			if(GUILayout.Button("Save Texture")) {
				if (overlayResultTexture != null && filename != null && filename != "") {
					SaveOverlayTexture ();
				}
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			if (overlayResultTexture != null) {
				GUILayout.Label (overlayResultTexture, GUILayout.Width (256), GUILayout.Height (256));
			}
			EditorGUILayout.EndVertical ();

			// COMBINE

			EditorGUILayout.BeginVertical (GUILayout.MaxWidth(256),GUILayout.Width(256));
			GUI.backgroundColor = new Color ((1f/255f) * 120f, (1f/255f) * 31f, (1f/255f) * 163f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Combine 2 Textures", styleCentered, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			GUI.backgroundColor = new Color ((1f/255f) * 75f, (1f/255f) * 19f, (1f/255f) * 102f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Texture A", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			EditorGUI.BeginChangeCheck ();
			combineTextureA = (Texture2D) EditorGUILayout.ObjectField (combineTextureA, typeof (Texture2D), true);
			if(EditorGUI.EndChangeCheck() && combineTextureA != null && combineTextureB != null) {
				CombineTextures (combineTextureA, combineTextureB);
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("Texture B", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			EditorGUI.BeginChangeCheck ();
			combineTextureB = (Texture2D) EditorGUILayout.ObjectField (combineTextureB, typeof (Texture2D), true);
			if(EditorGUI.EndChangeCheck() && combineTextureA != null && combineTextureB != null) {
				CombineTextures (combineTextureA, combineTextureB);
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			GUI.backgroundColor = new Color ((1f/255f) * 75f, (1f/255f) * 19f, (1f/255f) * 102f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Filename", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			filename = EditorGUILayout.TextField (filename);
			if(GUILayout.Button("Save Texture")) {
				if (combineTextureResult != null && filename != null && filename != "") {
					SaveCombinedTexture ();
				}
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			if (combineTextureResult != null) {
				GUILayout.Label (combineTextureResult, GUILayout.Width (256), GUILayout.Height (256));
			}
			EditorGUILayout.EndVertical ();

			// TINT

			EditorGUILayout.BeginVertical (GUILayout.MaxWidth(256),GUILayout.Width(256));
			GUI.backgroundColor = new Color ((1f/255f) * 110f, (1f/255f) * 150f, (1f/255f) * 29f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Tint Texture", styleCentered, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			GUI.backgroundColor = new Color ((1f/255f) * 100f, (1f/255f) * 136f, (1f/255f) * 26f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Texture", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			EditorGUI.BeginChangeCheck ();
			tintTextureA = (Texture2D) EditorGUILayout.ObjectField (tintTextureA, typeof (Texture2D), true);
			if(EditorGUI.EndChangeCheck() && tintTextureA != null) {
				CreateTintTextures ();
			}
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Tint", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			EditorGUI.BeginChangeCheck ();
			tintColor = EditorGUILayout.ColorField (tintColor);
			if(EditorGUI.EndChangeCheck() && tintTextureResult != null && tintTextureA != null) {
				TintTexture ();
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			GUI.backgroundColor = new Color ((1f/255f) * 100f, (1f/255f) * 136f, (1f/255f) * 26f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Filename", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			filename = EditorGUILayout.TextField (filename);
			if(GUILayout.Button("Save Texture")) {
				if (tintTextureResult != null && filename != null && filename != "") {
					SaveTintedTexture ();
				}
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			if (tintTextureResult != null) {
				GUILayout.Label (tintTextureResult, GUILayout.Width (256), GUILayout.Height (256));
			}
			EditorGUILayout.EndVertical ();

			// BRIGHTNESS AND CONTRAST

			EditorGUILayout.BeginVertical (GUILayout.MaxWidth(256),GUILayout.Width(256));
			GUI.backgroundColor = new Color ((1f/255f) * 176f, (1f/255f) * 75f, (1f/255f) * 75f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Change Texture Brightness and Contrast", styleCentered, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			GUI.backgroundColor = new Color ((1f/255f) * 156f, (1f/255f) * 55f, (1f/255f) * 55f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Texture", style, GUILayout.Height (20));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			EditorGUI.BeginChangeCheck ();
			brightnessContrastTextureA = (Texture2D) EditorGUILayout.ObjectField (brightnessContrastTextureA, typeof (Texture2D), true);
			if(EditorGUI.EndChangeCheck() && brightnessContrastTextureA != null) {
				CreateBrightnessContrastTexture ();
			}
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Brightness", style, GUILayout.Height (10));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			EditorGUI.BeginChangeCheck ();
			brightness = EditorGUILayout.Slider (brightness, -1,1);
			if(EditorGUI.EndChangeCheck() && brightnessContrastTextureResult != null && brightnessContrastTextureA != null) {
				AdjustBrightnessContrast ();
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("Contrast", style, GUILayout.Height (10));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			EditorGUI.BeginChangeCheck ();
			contrast = EditorGUILayout.Slider (contrast, -0.5f,0.5f);
			if(EditorGUI.EndChangeCheck() && brightnessContrastTextureResult != null && brightnessContrastTextureA != null) {
				AdjustBrightnessContrast ();
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			GUI.backgroundColor = new Color ((1f/255f) * 156f, (1f/255f) * 55f, (1f/255f) * 55f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Filename", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			filename = EditorGUILayout.TextField (filename);
			if(GUILayout.Button("Save Texture")) {
				if (brightnessContrastTextureResult != null && filename != null && filename != "") {
					SaveBrightnessContrastTexture ();
				}
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			if (brightnessContrastTextureResult != null) {
				GUILayout.Label (brightnessContrastTextureResult, GUILayout.Width (256), GUILayout.Height (256));
			}
			EditorGUILayout.EndVertical ();

			// INVERT

			EditorGUILayout.BeginVertical (GUILayout.MaxWidth(256),GUILayout.Width(256));
			GUI.backgroundColor = new Color ((1f/255f) * 175f, (1f/255f) * 120f, (1f/255f) * 50f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Invert Texture", styleCentered, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			GUI.backgroundColor = new Color ((1f/255f) * 160f, (1f/255f) * 110f, (1f/255f) * 45f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Texture", style, GUILayout.Height (80));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			EditorGUI.BeginChangeCheck ();
			invertTexture = (Texture2D) EditorGUILayout.ObjectField (invertTexture, typeof (Texture2D), true);
			if(EditorGUI.EndChangeCheck() && invertTexture != null) {
				InvertTexture ();
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			GUI.backgroundColor = new Color ((1f/255f) * 160f, (1f/255f) * 110f, (1f/255f) * 45f);
			EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.BeginHorizontal ();
			GUI.backgroundColor = Color.white;
			GUILayout.Label ("Filename", style, GUILayout.Height (30));
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.BeginHorizontal ();
			filename = EditorGUILayout.TextField (filename);
			if(GUILayout.Button("Save Texture")) {
				if (invertTextureResult != null && filename != null && filename != "") {
					SaveInvertedTexture ();
				}
			}
			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndVertical ();

			if (invertTextureResult != null) {
				GUILayout.Label (invertTextureResult, GUILayout.Width (256), GUILayout.Height (256));
			}
			EditorGUILayout.EndVertical ();


			EditorGUILayout.EndHorizontal ();
			EditorGUILayout.EndScrollView ();
		}
			
		// OVERLAY
		private void CreateOverlay(Texture2D a, Texture2D b) {
			overlayResultTexture = new Texture2D (a.width, a.height);
			int startX = (b.width - a.width) / 2;
			int startY = (b.height - a.height) / 2;
			for (int x = 0; x < a.width; x++) {
				for (int y = 0; y < a.height; y++) {
					Color bColor = b.GetPixel (x + startX, y + startY);
					Color aColor = a.GetPixel (x, y);
					Color final_color = bColor * aColor;
					overlayResultTexture.SetPixel (x, y, final_color);
				}
			}
			overlayResultTexture.Apply ();
		}
		private void SaveOverlayTexture () {
			// Encode texture into PNG and save to disk
			byte[] bytes = overlayResultTexture.EncodeToPNG();
			File.WriteAllBytes (Application.dataPath + "/PowerJoysticks/UserTextures/" + filename + "_powerjoysticks.png", bytes);
			// Refresh
			AssetDatabase.Refresh();
		}

		// COMBINE
		private void CombineTextures(Texture2D a, Texture2D b) {
			if (a.width >= b.width) {
				combineTextureResult = new Texture2D (a.width, a.height);
				for (int x = 0; x < a.width; x++) {
					for (int y = 0; y < a.height; y++) {
						Color aColor = a.GetPixel (x, y);
						combineTextureResult.SetPixel (x, y, aColor);
					}
				}
			} else {
				combineTextureResult = new Texture2D (b.width, b.height);
				for (int x = 0; x < b.width; x++) {
					for (int y = 0; y < b.height; y++) {
						Color bColor = b.GetPixel (x, y);
						combineTextureResult.SetPixel (x, y, bColor);
					}
				}
			}
			combineTextureResult.Apply ();
			if (a.width >= b.width) {
				int startX = (a.width - b.width) / 2;
				int startY = (a.height - b.height) / 2;
				for (int x = startX; x < a.width; x++) {
					for (int y = startY; y < a.height; y++) {
						Color aColor = a.GetPixel (x, y);
						Color bColor = b.GetPixel (x - startX, y - startY);
						Color final_color = Color.Lerp (aColor, bColor, bColor.a / 1.0f);
						if (aColor.a > 0) {
							final_color = new Color (final_color.r, final_color.g, final_color.b, aColor.a);
						}
						combineTextureResult.SetPixel (x, y, final_color);
					}
				}
			} else {
				int startX = (b.width - a.width) / 2;
				int startY = (b.height - a.height) / 2;
				for (int x = startX; x < b.width; x++) {
					for (int y = startY; y < b.height; y++) {
						Color bColor = b.GetPixel (x, y);
						Color aColor = a.GetPixel (x - startX, y - startY);
						Color final_color = Color.Lerp (bColor, aColor, aColor.a / 1.0f);
						combineTextureResult.SetPixel (x, y, final_color);
					}
				}
			}
			combineTextureResult.Apply ();
		}
		private void SaveCombinedTexture () {
			// Encode texture into PNG and save to disk
			byte[] bytes = combineTextureResult.EncodeToPNG();
			File.WriteAllBytes (Application.dataPath + "/PowerJoysticks/UserTextures/" + filename + "_powerjoysticks.png", bytes);
			// Refresh
			AssetDatabase.Refresh();
		}
			
		// TINT
		private void  CreateTintTextures() {
			tintTextureResult = new Texture2D (tintTextureA.width, tintTextureA.height);
			for (int x = 0; x < tintTextureA.width; x++) {
				for (int y = 0; y < tintTextureA.height; y++) {
					Color aColor = tintTextureA.GetPixel (x, y);
					tintTextureResult.SetPixel (x, y, aColor);
				}
			}
			tintTextureResult.Apply ();
		}
		private void TintTexture () {
			for (int x = 0; x < tintTextureA.width; x++) {
				for (int y = 0; y < tintTextureA.height; y++) {
					Color color = tintTextureA.GetPixel (x, y);
					Color final_color = color * tintColor;
					tintTextureResult.SetPixel (x, y, final_color);
				}
			}
			tintTextureResult.Apply ();
		}

		private void SaveTintedTexture () {
			// Encode texture into PNG and save to disk
			byte[] bytes = tintTextureResult.EncodeToPNG();
			File.WriteAllBytes (Application.dataPath + "/PowerJoysticks/UserTextures/" + filename + "_powerjoysticks.png", bytes);
			// Refresh
			AssetDatabase.Refresh();
		}

		// BRIGHTNESS AND CONTRAST
		private void  CreateBrightnessContrastTexture() {
			brightnessContrastTextureResult = new Texture2D (brightnessContrastTextureA.width, brightnessContrastTextureA.height);
			for (int x = 0; x < brightnessContrastTextureA.width; x++) {
				for (int y = 0; y < brightnessContrastTextureA.height; y++) {
					Color aColor = brightnessContrastTextureA.GetPixel (x, y);
					brightnessContrastTextureResult.SetPixel (x, y, aColor);
				}
			}
			brightnessContrastTextureResult.Apply ();
		}
		private void AdjustBrightnessContrast () {
			float factor = (1.0156862f * (contrast + 1f)) / (1f * (1.0156862f - contrast));
			for (int x = 0; x < brightnessContrastTextureA.width; x++) {
				for (int y = 0; y < brightnessContrastTextureA.height; y++) {
					Color color = brightnessContrastTextureA.GetPixel (x, y);
					Color final_color = new Color(Mathf.Clamp((factor * color.r + brightness - 0.5f) + 0.5f,0,1),Mathf.Clamp((factor * color.g + brightness - 0.5f) + 0.5f,0,1),Mathf.Clamp((factor * color.b + brightness - 0.5f) + 0.5f,0,1),color.a);
					brightnessContrastTextureResult.SetPixel (x, y, final_color);
				}
			}
			brightnessContrastTextureResult.Apply ();
		}
		private void SaveBrightnessContrastTexture () {
			// Encode texture into PNG and save to disk
			byte[] bytes = brightnessContrastTextureResult.EncodeToPNG();
			File.WriteAllBytes (Application.dataPath + "/PowerJoysticks/UserTextures/" + filename + "_powerjoysticks.png", bytes);
			// Refresh
			AssetDatabase.Refresh();
		}

		// INVERT
		private void  InvertTexture() {
			invertTextureResult = new Texture2D (invertTexture.width, invertTexture.height);
			for (int x = 0; x < invertTexture.width; x++) {
				for (int y = 0; y < invertTexture.height; y++) {
					Color color = invertTexture.GetPixel (x, y);
					Color final_color = new Color (1f - color.r, 1f - color.g, 1f - color.b, color.a);
					invertTextureResult.SetPixel (x, y, final_color);
				}
			}
			invertTextureResult.Apply ();
		}
		private void SaveInvertedTexture () {
			// Encode texture into PNG and save to disk
			byte[] bytes = invertTextureResult.EncodeToPNG();
			File.WriteAllBytes (Application.dataPath + "/PowerJoysticks/UserTextures/" + filename + "_powerjoysticks.png", bytes);
			// Refresh
			AssetDatabase.Refresh();
		}
	}
}
