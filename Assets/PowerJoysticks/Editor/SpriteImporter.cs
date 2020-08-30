using UnityEngine;
using UnityEditor;

namespace TLGFPowerJoysticks {
	
	class Spriteimporter : AssetPostprocessor {
		void OnPreprocessTexture() {
			if (assetPath.Contains("_powerjoysticks.png")) {
				TextureImporter importer  = (TextureImporter)assetImporter;
				importer.textureType = TextureImporterType.Sprite;
				importer.spriteImportMode = SpriteImportMode.Single;
				importer.spritePackingTag = "PowerJoysticks";
				importer.alphaIsTransparency = true;
				importer.isReadable = true;
				importer.mipmapEnabled = true;
				importer.filterMode = FilterMode.Bilinear;
				importer.npotScale = TextureImporterNPOTScale.None;
				importer.wrapMode = TextureWrapMode.Clamp;
			}
		}
	}

}