
//var terrainData : TerrainData;
//var customSplatmap1 : Texture2D; 

var OrinigalTerrain : Terrain; 
var OrinigalSplatmap1 : Texture2D; 
var OrinigalSplatmap2 : Texture2D;
var TargetTerrain : Terrain;
var TargetSplatmap1 : Texture2D; 
var TargetSplatmap2 : Texture2D;


function Update () {
}

function doCopyTerrainHeights() {
	var xRes = OrinigalTerrain.terrainData.heightmapWidth; 
	var yRes = OrinigalTerrain.terrainData.heightmapHeight; 
	var heights = OrinigalTerrain.terrainData.GetHeights(0, 0, xRes, yRes); 
	TargetTerrain.terrainData.SetHeights(0, 0, heights);
}

function doCopyTerrainMaps() {
	var mapColors1 = OrinigalSplatmap1.GetPixels();
	var mapColors2 = OrinigalSplatmap2.GetPixels();
    TargetSplatmap1.SetPixels( mapColors1 );
	TargetSplatmap2.SetPixels( mapColors2 );
	TargetSplatmap1.Apply();
	TargetSplatmap2.Apply();
}

function doCopyTrees() {
	TargetTerrain.terrainData.treeInstances = OrinigalTerrain.terrainData.treeInstances;
	var i: int;
	for ( i = 0; i < OrinigalTerrain.terrainData.treeInstances.length; i++ ) { 
		TargetTerrain.terrainData.treeInstances[i].prototypeIndex = OrinigalTerrain.terrainData.treeInstances[i].prototypeIndex;
	}
}

function doCopyDetails() {
	//TargetTerrain.terrainData.detailInstances = OrinigalTerrain.terrainData.detailInstances;
}


function OnGUI () {
	if (GUI.Button (Rect (25, 25, 100, 30), "copyTerrain")) {
		doCopyTerrainHeights();
		doCopyTerrainMaps();
		doCopyTrees();
		doCopyDetails();
	}
}

//get and set detailPrototypes
//GetDetailLayer
//SetDetailLayer
//treePrototypes
//splatPrototypes
//GetDetailLayer
//SetDetailLayer
//get_treePrototypes
//set_treePrototypes