xof 0303txt 0032
template XSkinMeshHeader {
 <3cf169ce-ff7c-44ab-93c0-f78f62d172e2>
 WORD nMaxSkinWeightsPerVertex;
 WORD nMaxSkinWeightsPerFace;
 WORD nBones;
}

template VertexDuplicationIndices {
 <b8d65549-d7c9-4995-89cf-53a9a8b031e3>
 DWORD nIndices;
 DWORD nOriginalVertices;
 array DWORD indices[nIndices];
}

template SkinWeights {
 <6f0d123b-bad2-4167-a0d0-80224f25fabb>
 STRING transformNodeName;
 DWORD nWeights;
 array DWORD vertexIndices[nWeights];
 array FLOAT weights[nWeights];
 Matrix4x4 matrixOffset;
}

template FVFData {
 <b6e70a0e-8ef9-4e83-94ad-ecc8b0c04897>
 DWORD dwFVF;
 DWORD nDWords;
 array DWORD data[nDWords];
}

template EffectInstance {
 <e331f7e4-0559-4cc2-8e99-1cec1657928f>
 STRING EffectFilename;
 [...]
}

template EffectParamFloats {
 <3014b9a0-62f5-478c-9b86-e4ac9f4e418b>
 STRING ParamName;
 DWORD nFloats;
 array FLOAT Floats[nFloats];
}

template EffectParamString {
 <1dbc4c88-94c1-46ee-9076-2c28818c9481>
 STRING ParamName;
 STRING Value;
}

template EffectParamDWord {
 <e13963bc-ae51-4c5d-b00f-cfa3a9d97ce5>
 STRING ParamName;
 DWORD Value;
}


Material skyscrapers {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

 TextureFilename {
  "Skyscrp.tga";
 }
}

Material buildz1 {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

 TextureFilename {
  "buildz1.tga";
 }
}

Material buildz3 {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

 TextureFilename {
  "buildz3.tga";
 }
}

Material buildz4 {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

 TextureFilename {
  "buildz4.tga";
 }
}

Material buildz5 {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

 TextureFilename {
  "buildz5.tga";
 }
}

Material buildz6 {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

 TextureFilename {
  "buildz6.tga";
 }
}

Material buildz2 {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

 TextureFilename {
  "buildz2.tga";
 }
}

Material roads {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

 TextureFilename {
  "roads.tga";
 }
}

Material roads-2 {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

 TextureFilename {
  "roads2.tga";
 }
}

Material tree-01 {
 1.000000;1.000000;1.000000;1.000000;;
 3.200000;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;

 TextureFilename {
  "trees-02.tga";
 }
}

Frame road-block_03 {
 

 FrameTransformMatrix {
  1.000000,0.000000,0.000000,0.000000,0.000000,-0.000000,-1.000000,0.000000,0.000000,1.000000,-0.000000,0.000000,0.000000,-12.670539,12.491668,1.000000;;
 }

 Frame {
  

  FrameTransformMatrix {
   1.000000,0.000000,0.000000,0.000000,0.000000,1.000000,0.000000,0.000000,0.000000,0.000000,1.000000,0.000000,0.000000,-0.000000,0.000000,1.000000;;
  }

  Mesh  {
   60;
   -0.075719;-4.031681;-0.000000;,
   47.302532;0.000001;0.000000;,
   -0.161801;0.000000;0.000000;,
   47.302532;0.000001;0.000000;,
   -0.075719;-4.031681;-0.000000;,
   11.604422;-15.496318;-0.000000;,
   47.302544;-15.504560;0.000000;,
   47.302532;0.000001;0.000000;,
   11.604422;-15.496318;-0.000000;,
   -47.302551;-0.000001;0.000000;,
   -47.268375;-15.469922;0.000000;,
   -11.744199;-15.481578;-0.000000;,
   -47.302551;-0.000001;0.000000;,
   -0.075719;-4.031681;-0.000000;,
   -0.161801;0.000000;0.000000;,
   -47.302551;-0.000001;0.000000;,
   -11.744199;-15.481578;-0.000000;,
   -0.075719;-4.031681;-0.000000;,
   -0.072036;-94.661545;-0.000000;,
   -11.744199;-15.481578;-0.000000;,
   -11.734275;-94.627365;-0.000000;,
   -0.072036;-94.661545;-0.000000;,
   11.589855;-94.627365;-0.000000;,
   11.604422;-15.496318;-0.000000;,
   -0.072036;-94.661545;-0.000000;,
   -0.075719;-4.031681;-0.000000;,
   -11.744199;-15.481578;-0.000000;,
   11.604422;-15.496318;-0.000000;,
   -0.075719;-4.031681;-0.000000;,
   -0.072036;-94.661545;-0.000000;,
   47.302532;0.000001;0.000000;,
   -0.075719;4.031677;-0.000000;,
   -0.161801;0.000000;0.000000;,
   -0.075719;4.031677;-0.000000;,
   47.302532;0.000001;0.000000;,
   11.604422;15.496319;-0.000000;,
   47.302532;0.000001;0.000000;,
   47.302544;15.504562;0.000000;,
   11.604422;15.496319;-0.000000;,
   -47.268375;15.469921;0.000000;,
   -47.302551;-0.000001;0.000000;,
   -11.744199;15.481579;-0.000000;,
   -0.075719;4.031677;-0.000000;,
   -47.302551;-0.000001;0.000000;,
   -0.161801;0.000000;0.000000;,
   -11.744199;15.481579;-0.000000;,
   -47.302551;-0.000001;0.000000;,
   -0.075719;4.031677;-0.000000;,
   -11.744199;15.481579;-0.000000;,
   -0.072036;94.661545;-0.000000;,
   -11.734275;94.627365;-0.000000;,
   11.589855;94.627365;-0.000000;,
   -0.072036;94.661545;-0.000000;,
   11.604422;15.496319;-0.000000;,
   -0.075719;4.031677;-0.000000;,
   -0.072036;94.661545;-0.000000;,
   -11.744199;15.481579;-0.000000;,
   -0.075719;4.031677;-0.000000;,
   11.604422;15.496319;-0.000000;,
   -0.072036;94.661545;-0.000000;;
   20;
   3;0,1,2;,
   3;3,4,5;,
   3;6,7,8;,
   3;9,10,11;,
   3;12,13,14;,
   3;15,16,17;,
   3;18,19,20;,
   3;21,22,23;,
   3;24,25,26;,
   3;27,28,29;,
   3;30,31,32;,
   3;33,34,35;,
   3;36,37,38;,
   3;39,40,41;,
   3;42,43,44;,
   3;45,46,47;,
   3;48,49,50;,
   3;51,52,53;,
   3;54,55,56;,
   3;57,58,59;;

   MeshNormals  {
    60;
    -0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    -0.000000;-0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    0.000000;-0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    -0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;;
    20;
    3;0,1,2;,
    3;3,4,5;,
    3;6,7,8;,
    3;9,10,11;,
    3;12,13,14;,
    3;15,16,17;,
    3;18,19,20;,
    3;21,22,23;,
    3;24,25,26;,
    3;27,28,29;,
    3;30,31,32;,
    3;33,34,35;,
    3;36,37,38;,
    3;39,40,41;,
    3;42,43,44;,
    3;45,46,47;,
    3;48,49,50;,
    3;51,52,53;,
    3;54,55,56;,
    3;57,58,59;;
   }

   MeshMaterialList  {
    1;
    20;
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0;
    { roads }
   }

   MeshTextureCoords  {
    60;
    0.676734;0.053726;,
    0.995094;0.003515;,
    0.676211;0.003515;,
    0.995094;0.003515;,
    0.676734;0.053726;,
    0.755125;0.196703;,
    0.995094;0.196703;,
    0.995094;0.003515;,
    0.755125;0.196703;,
    0.359501;0.003515;,
    0.359501;0.196703;,
    0.597628;0.196703;,
    0.359501;0.003515;,
    0.676734;0.053726;,
    0.676211;0.003515;,
    0.359501;0.003515;,
    0.597628;0.196703;,
    0.676734;0.053726;,
    0.331815;0.052654;,
    0.862074;0.197991;,
    0.331815;0.197991;,
    0.331815;0.052654;,
    0.331815;0.196703;,
    0.863608;0.196703;,
    0.331815;0.052654;,
    0.940718;0.052654;,
    0.862074;0.197991;,
    0.863608;0.196703;,
    0.940718;0.052654;,
    0.331815;0.052654;,
    0.995094;0.003515;,
    0.676734;0.053726;,
    0.676211;0.003515;,
    0.676734;0.053726;,
    0.995094;0.003515;,
    0.755125;0.196703;,
    0.995094;0.003515;,
    0.995094;0.196703;,
    0.755125;0.196703;,
    0.359501;0.196703;,
    0.359501;0.003515;,
    0.597628;0.196703;,
    0.676734;0.053726;,
    0.359501;0.003515;,
    0.676211;0.003515;,
    0.597628;0.196703;,
    0.359501;0.003515;,
    0.676734;0.053726;,
    0.862074;0.197991;,
    0.331815;0.052654;,
    0.331815;0.197991;,
    0.331815;0.196703;,
    0.331815;0.052654;,
    0.863608;0.196703;,
    0.940718;0.052654;,
    0.331815;0.052654;,
    0.862074;0.197991;,
    0.940718;0.052654;,
    0.863608;0.196703;,
    0.331815;0.052654;;
   }
  }
 }
}