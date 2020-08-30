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

Frame misc_lamppost_03 {
 

 FrameTransformMatrix {
  1.000000,0.000000,0.000000,0.000000,0.000000,-0.000000,-1.000000,0.000000,0.000000,1.000000,-0.000000,0.000000,-0.004512,-12.658485,12.751022,1.000000;;
 }

 Frame {
  

  FrameTransformMatrix {
   1.000000,0.000000,0.000000,0.000000,0.000000,1.000000,0.000000,0.000000,0.000000,0.000000,1.000000,0.000000,0.000000,-0.000000,0.000000,1.000000;;
  }

  Mesh  {
   138;
   -0.225630;0.147020;7.275969;,
   -0.230512;-0.142019;7.275969;,
   0.058527;-0.146900;7.275969;,
   0.058527;-0.146900;7.275969;,
   0.063408;0.142138;7.275969;,
   -0.225630;0.147020;7.275969;,
   0.063408;0.142138;7.275969;,
   0.058527;-0.146900;7.275969;,
   0.108813;-0.195303;0.000000;,
   0.108813;-0.195303;0.000000;,
   0.115300;0.188815;0.000000;,
   0.063408;0.142138;7.275969;,
   -0.225630;0.147020;7.275969;,
   0.063408;0.142138;7.275969;,
   0.115300;0.188815;0.000000;,
   0.115300;0.188815;0.000000;,
   -0.268817;0.195302;0.000000;,
   -0.225630;0.147020;7.275969;,
   -0.230512;-0.142019;7.275969;,
   -0.225630;0.147020;7.275969;,
   -0.268817;0.195302;0.000000;,
   -0.268817;0.195302;0.000000;,
   -0.275305;-0.188815;0.000000;,
   -0.230512;-0.142019;7.275969;,
   0.058527;-0.146900;7.275969;,
   -0.230512;-0.142019;7.275969;,
   -0.275305;-0.188815;0.000000;,
   -0.275305;-0.188815;0.000000;,
   0.108813;-0.195303;0.000000;,
   0.058527;-0.146900;7.275969;,
   0.030460;2.108199;7.756588;,
   -0.072016;2.108199;8.028038;,
   -0.085304;0.027046;7.567130;,
   -0.085304;0.027046;7.567130;,
   0.045098;0.027046;7.248357;,
   0.030460;2.108199;7.756588;,
   -0.198597;2.108199;7.756325;,
   0.030460;2.108199;7.756588;,
   0.045098;0.027046;7.248357;,
   0.045098;0.027046;7.248357;,
   -0.238684;0.027046;7.248036;,
   -0.198597;2.108199;7.756325;,
   -0.085304;0.027046;7.567130;,
   -0.072016;2.108199;8.028038;,
   -0.198597;2.108199;7.756325;,
   -0.198597;2.108199;7.756325;,
   -0.238684;0.027046;7.248036;,
   -0.085304;0.027046;7.567130;,
   -0.228580;2.142646;8.057505;,
   -0.317493;2.041145;7.746110;,
   0.181443;2.041993;7.741303;,
   0.181443;2.041993;7.741303;,
   0.095595;2.143493;8.052697;,
   -0.228580;2.142646;8.057505;,
   0.095595;2.143493;8.052697;,
   0.181443;2.041993;7.741303;,
   0.268247;3.817066;7.736681;,
   0.268247;3.817066;7.736681;,
   0.097528;3.536188;8.077197;,
   0.095595;2.143493;8.052697;,
   -0.228580;2.142646;8.057505;,
   0.095595;2.143493;8.052697;,
   0.097528;3.536188;8.077197;,
   0.097528;3.536188;8.077197;,
   -0.220731;3.535061;8.083587;,
   -0.228580;2.142646;8.057505;,
   -0.317493;2.041145;7.746110;,
   -0.228580;2.142646;8.057505;,
   -0.220731;3.535061;8.083587;,
   -0.220731;3.535061;8.083587;,
   -0.394814;3.815940;7.743070;,
   -0.317493;2.041145;7.746110;,
   0.181443;2.041993;7.741303;,
   -0.317493;2.041145;7.746110;,
   -0.394814;3.815940;7.743070;,
   -0.394814;3.815940;7.743070;,
   0.268247;3.817066;7.736681;,
   0.181443;2.041993;7.741303;,
   -0.394814;3.815940;7.743070;,
   -0.220731;3.535061;8.083587;,
   0.097528;3.536188;8.077197;,
   0.097528;3.536188;8.077197;,
   0.268247;3.817066;7.736681;,
   -0.394814;3.815940;7.743070;,
   -0.072016;-2.054106;8.028038;,
   0.030460;-2.054106;7.756588;,
   -0.085304;0.027046;7.567130;,
   0.045098;0.027046;7.248357;,
   -0.085304;0.027046;7.567130;,
   0.030460;-2.054106;7.756588;,
   0.030460;-2.054106;7.756588;,
   -0.198597;-2.054106;7.756325;,
   0.045098;0.027046;7.248357;,
   -0.238684;0.027046;7.248036;,
   0.045098;0.027046;7.248357;,
   -0.198597;-2.054106;7.756325;,
   -0.072016;-2.054106;8.028038;,
   -0.085304;0.027046;7.567130;,
   -0.198597;-2.054106;7.756325;,
   -0.238684;0.027046;7.248036;,
   -0.198597;-2.054106;7.756325;,
   -0.085304;0.027046;7.567130;,
   -0.317492;-1.987052;7.746110;,
   -0.228579;-2.088553;8.057505;,
   0.181444;-1.987900;7.741303;,
   0.095595;-2.089401;8.052697;,
   0.181444;-1.987900;7.741303;,
   -0.228579;-2.088553;8.057505;,
   0.181444;-1.987900;7.741303;,
   0.095595;-2.089401;8.052697;,
   0.268248;-3.762974;7.736681;,
   0.097529;-3.482095;8.077197;,
   0.268248;-3.762974;7.736681;,
   0.095595;-2.089401;8.052697;,
   0.095595;-2.089401;8.052697;,
   -0.228579;-2.088553;8.057505;,
   0.097529;-3.482095;8.077197;,
   -0.220730;-3.480969;8.083587;,
   0.097529;-3.482095;8.077197;,
   -0.228579;-2.088553;8.057505;,
   -0.228579;-2.088553;8.057505;,
   -0.317492;-1.987052;7.746110;,
   -0.220730;-3.480969;8.083587;,
   -0.394814;-3.761847;7.743070;,
   -0.220730;-3.480969;8.083587;,
   -0.317492;-1.987052;7.746110;,
   -0.317492;-1.987052;7.746110;,
   0.181444;-1.987900;7.741303;,
   -0.394814;-3.761847;7.743070;,
   0.268248;-3.762974;7.736681;,
   -0.394814;-3.761847;7.743070;,
   0.181444;-1.987900;7.741303;,
   -0.220730;-3.480969;8.083587;,
   -0.394814;-3.761847;7.743070;,
   0.097529;-3.482095;8.077197;,
   0.268248;-3.762974;7.736681;,
   0.097529;-3.482095;8.077197;,
   -0.394814;-3.761847;7.743070;;
   46;
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
   3;57,58,59;,
   3;60,61,62;,
   3;63,64,65;,
   3;66,67,68;,
   3;69,70,71;,
   3;72,73,74;,
   3;75,76,77;,
   3;78,79,80;,
   3;81,82,83;,
   3;84,85,86;,
   3;87,88,89;,
   3;90,91,92;,
   3;93,94,95;,
   3;96,97,98;,
   3;99,100,101;,
   3;102,103,104;,
   3;105,106,107;,
   3;108,109,110;,
   3;111,112,113;,
   3;114,115,116;,
   3;117,118,119;,
   3;120,121,122;,
   3;123,124,125;,
   3;126,127,128;,
   3;129,130,131;,
   3;132,133,134;,
   3;135,136,137;;

   MeshNormals  {
    138;
    0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    0.000000;0.000000;1.000000;,
    0.999833;-0.016886;0.007022;,
    0.999833;-0.016886;0.007022;,
    0.999833;-0.016887;0.007022;,
    0.999833;-0.016887;0.007022;,
    0.999833;-0.016887;0.007022;,
    0.999833;-0.016886;0.007022;,
    0.016886;0.999836;0.006535;,
    0.016886;0.999836;0.006535;,
    0.016887;0.999836;0.006535;,
    0.016887;0.999836;0.006535;,
    0.016887;0.999836;0.006535;,
    0.016886;0.999836;0.006535;,
    -0.999839;0.016887;0.006047;,
    -0.999839;0.016887;0.006047;,
    -0.999839;0.016887;0.006047;,
    -0.999839;0.016887;0.006047;,
    -0.999839;0.016887;0.006047;,
    -0.999839;0.016887;0.006047;,
    -0.016886;-0.999836;0.006535;,
    -0.016886;-0.999836;0.006535;,
    -0.016887;-0.999836;0.006535;,
    -0.016887;-0.999836;0.006535;,
    -0.016887;-0.999836;0.006535;,
    -0.016886;-0.999836;0.006535;,
    0.931378;-0.084054;0.354216;,
    0.932256;-0.083895;0.351938;,
    0.926347;0.000000;0.376671;,
    0.926347;0.000000;0.376671;,
    0.925552;0.000000;0.378619;,
    0.931378;-0.084054;0.354216;,
    0.001113;0.237242;-0.971450;,
    0.001114;0.237242;-0.971450;,
    0.001130;-0.000000;-0.999999;,
    0.001130;-0.000000;-0.999999;,
    0.001129;-0.000000;-0.999999;,
    0.001113;0.237242;-0.971450;,
    -0.901702;-0.000000;0.432357;,
    -0.902993;-0.087400;0.420671;,
    -0.902518;-0.087465;0.421677;,
    -0.902518;-0.087465;0.421677;,
    -0.901286;-0.000000;0.433225;,
    -0.901702;-0.000000;0.432357;,
    0.005512;-0.950786;0.309801;,
    0.004591;-0.951142;0.308720;,
    0.005812;-0.950669;0.310153;,
    0.005812;-0.950669;0.310153;,
    0.007106;-0.950164;0.311671;,
    0.005512;-0.950786;0.309801;,
    0.953201;-0.041795;0.299436;,
    0.959049;-0.046171;0.279452;,
    0.500177;0.539585;0.677252;,
    0.500177;0.539585;0.677252;,
    0.595472;0.448696;0.666398;,
    0.953201;-0.041795;0.299436;,
    0.015627;-0.017784;0.999720;,
    0.014872;-0.017608;0.999734;,
    0.019368;-0.018658;0.999638;,
    0.019368;-0.018658;0.999638;,
    0.020136;-0.018838;0.999620;,
    0.015627;-0.017784;0.999720;,
    -0.952299;-0.007237;0.305081;,
    -0.961594;0.000279;0.274475;,
    -0.909146;-0.034867;0.415017;,
    -0.909146;-0.034867;0.415017;,
    -0.902266;-0.038573;0.429451;,
    -0.952299;-0.007237;0.305081;,
    -0.009631;-0.002132;-0.999951;,
    -0.009630;-0.002132;-0.999951;,
    -0.009631;-0.002132;-0.999951;,
    -0.009631;-0.002132;-0.999951;,
    -0.009631;-0.002132;-0.999951;,
    -0.009631;-0.002132;-0.999951;,
    0.006845;0.771661;0.635997;,
    0.009974;0.773885;0.633248;,
    0.595472;0.448696;0.666398;,
    0.595472;0.448696;0.666398;,
    0.500177;0.539585;0.677252;,
    0.006845;0.771661;0.635997;,
    0.932256;0.083896;0.351938;,
    0.931378;0.084054;0.354216;,
    0.926347;0.000000;0.376671;,
    0.925552;0.000000;0.378619;,
    0.926347;0.000000;0.376671;,
    0.931378;0.084054;0.354216;,
    0.001114;-0.237242;-0.971450;,
    0.001113;-0.237242;-0.971450;,
    0.001130;-0.000000;-0.999999;,
    0.001129;-0.000000;-0.999999;,
    0.001130;-0.000000;-0.999999;,
    0.001113;-0.237242;-0.971450;,
    -0.902993;0.087399;0.420672;,
    -0.901702;-0.000000;0.432357;,
    -0.902518;0.087465;0.421677;,
    -0.901286;-0.000000;0.433225;,
    -0.902518;0.087465;0.421677;,
    -0.901702;-0.000000;0.432357;,
    0.004591;0.951142;0.308720;,
    0.005512;0.950786;0.309801;,
    0.005813;0.950669;0.310153;,
    0.007106;0.950164;0.311670;,
    0.005813;0.950669;0.310153;,
    0.005512;0.950786;0.309801;,
    0.959049;0.046171;0.279452;,
    0.953201;0.041794;0.299436;,
    0.500177;-0.539585;0.677252;,
    0.595472;-0.448695;0.666398;,
    0.500177;-0.539585;0.677252;,
    0.953201;0.041794;0.299436;,
    0.014872;0.017608;0.999734;,
    0.015627;0.017784;0.999720;,
    0.019368;0.018658;0.999638;,
    0.020136;0.018838;0.999620;,
    0.019368;0.018658;0.999638;,
    0.015627;0.017784;0.999720;,
    -0.961594;-0.000279;0.274475;,
    -0.952299;0.007237;0.305081;,
    -0.909145;0.034867;0.415017;,
    -0.902266;0.038573;0.429451;,
    -0.909145;0.034867;0.415017;,
    -0.952299;0.007237;0.305081;,
    -0.009630;0.002132;-0.999951;,
    -0.009631;0.002132;-0.999951;,
    -0.009631;0.002132;-0.999951;,
    -0.009631;0.002132;-0.999951;,
    -0.009631;0.002132;-0.999951;,
    -0.009631;0.002132;-0.999951;,
    0.009974;-0.773885;0.633248;,
    0.006845;-0.771661;0.635997;,
    0.595472;-0.448695;0.666398;,
    0.500177;-0.539585;0.677252;,
    0.595472;-0.448695;0.666398;,
    0.006845;-0.771661;0.635997;;
    46;
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
    3;57,58,59;,
    3;60,61,62;,
    3;63,64,65;,
    3;66,67,68;,
    3;69,70,71;,
    3;72,73,74;,
    3;75,76,77;,
    3;78,79,80;,
    3;81,82,83;,
    3;84,85,86;,
    3;87,88,89;,
    3;90,91,92;,
    3;93,94,95;,
    3;96,97,98;,
    3;99,100,101;,
    3;102,103,104;,
    3;105,106,107;,
    3;108,109,110;,
    3;111,112,113;,
    3;114,115,116;,
    3;117,118,119;,
    3;120,121,122;,
    3;123,124,125;,
    3;126,127,128;,
    3;129,130,131;,
    3;132,133,134;,
    3;135,136,137;;
   }

   MeshMaterialList  {
    1;
    46;
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
    138;
    0.999163;0.722927;,
    0.999165;0.705445;,
    0.541139;0.705445;,
    0.541139;0.705445;,
    0.541139;0.722927;,
    0.999163;0.722927;,
    0.999163;0.722927;,
    0.999165;0.705445;,
    0.541139;0.705445;,
    0.541139;0.705445;,
    0.541139;0.722927;,
    0.999163;0.722927;,
    0.999163;0.722927;,
    0.999165;0.705445;,
    0.541139;0.705445;,
    0.541139;0.705445;,
    0.541139;0.722927;,
    0.999163;0.722927;,
    0.999163;0.722927;,
    0.999165;0.705445;,
    0.541139;0.705445;,
    0.541139;0.705445;,
    0.541139;0.722927;,
    0.999163;0.722927;,
    0.999163;0.722927;,
    0.999165;0.705445;,
    0.541139;0.705445;,
    0.541139;0.705445;,
    0.541139;0.722927;,
    0.999163;0.722927;,
    0.854321;0.722927;,
    0.853417;0.705445;,
    0.708144;0.705445;,
    0.708144;0.705445;,
    0.712346;0.722927;,
    0.854321;0.722927;,
    0.854244;0.722927;,
    0.854322;0.705445;,
    0.712347;0.705445;,
    0.712347;0.705445;,
    0.712253;0.722927;,
    0.854244;0.722927;,
    0.708143;0.722927;,
    0.853416;0.722927;,
    0.854245;0.705445;,
    0.854245;0.705445;,
    0.712253;0.705445;,
    0.708143;0.722927;,
    0.999163;0.722927;,
    0.999165;0.705445;,
    0.541139;0.705445;,
    0.541139;0.705445;,
    0.541139;0.722927;,
    0.999163;0.722927;,
    0.897650;0.781118;,
    0.897651;0.813367;,
    0.790309;0.813367;,
    0.790309;0.813367;,
    0.790309;0.781119;,
    0.897650;0.781118;,
    0.897650;0.813367;,
    0.897651;0.781119;,
    0.790309;0.781118;,
    0.790309;0.781118;,
    0.790309;0.813367;,
    0.897650;0.813367;,
    0.897650;0.813367;,
    0.897651;0.781119;,
    0.790309;0.781118;,
    0.790309;0.781118;,
    0.790309;0.813367;,
    0.897650;0.813367;,
    0.797245;0.746995;,
    0.797244;0.735603;,
    0.833017;0.734375;,
    0.833017;0.734375;,
    0.831095;0.748106;,
    0.797245;0.746995;,
    0.803229;0.812495;,
    0.805075;0.781990;,
    0.847526;0.781119;,
    0.847526;0.781119;,
    0.847526;0.813367;,
    0.803229;0.812495;,
    0.853417;0.705445;,
    0.854321;0.722927;,
    0.708144;0.705445;,
    0.712346;0.722927;,
    0.708144;0.705445;,
    0.854321;0.722927;,
    0.854322;0.705445;,
    0.854244;0.722927;,
    0.712347;0.705445;,
    0.712253;0.722927;,
    0.712347;0.705445;,
    0.854244;0.722927;,
    0.853416;0.722927;,
    0.708143;0.722927;,
    0.854245;0.705445;,
    0.712253;0.705445;,
    0.854245;0.705445;,
    0.708143;0.722927;,
    0.999165;0.705445;,
    0.999163;0.722927;,
    0.541139;0.705445;,
    0.541139;0.722927;,
    0.541139;0.705445;,
    0.999163;0.722927;,
    0.897651;0.813367;,
    0.897650;0.781118;,
    0.790309;0.813367;,
    0.790309;0.781119;,
    0.790309;0.813367;,
    0.897650;0.781118;,
    0.897651;0.781119;,
    0.897650;0.813367;,
    0.790309;0.781118;,
    0.790309;0.813367;,
    0.790309;0.781118;,
    0.897650;0.813367;,
    0.897651;0.781119;,
    0.897650;0.813367;,
    0.790309;0.781118;,
    0.790309;0.813367;,
    0.790309;0.781118;,
    0.897650;0.813367;,
    0.797244;0.735603;,
    0.797245;0.746995;,
    0.833017;0.734375;,
    0.831095;0.748106;,
    0.833017;0.734375;,
    0.797245;0.746995;,
    0.805075;0.781990;,
    0.803229;0.812495;,
    0.847526;0.781119;,
    0.847526;0.813367;,
    0.847526;0.781119;,
    0.803229;0.812495;;
   }
  }
 }
}