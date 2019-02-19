// Random Set Next Mission maps
// 
//

//This file is present
$GetRandomMapsLoaded = true;

//Map pool
//
//1-5
$RandomMapPick1 = "SmallCrossing"; 		$RandomMapPick2 = "OasisIntensity"; 		$RandomMapPick3 = "Blink"; 					$RandomMapPick4 = "SmallTimeCTF"; 					$RandomMapPick5 = "ArenaDome"; 
//6-10
$RandomMapPick6 = "HighOctane"; 		$RandomMapPick7 = "S5_Damnation"; 			$RandomMapPick8 = "TWL_Feign"; 				$RandomMapPick9 = "TWL2_Skylight"; 					$RandomMapPick10 = "Prismatic"; 
//11-15
$RandomMapPick11 = "Dire"; 				$RandomMapPick12 = "TWL2_JaggedClaw"; 		$RandomMapPick13 = "TWL2_Hildebrand"; 		$RandomMapPick14 = "TWL_WilderZone"; 				$RandomMapPick15 = "TWL_Stonehenge"; 
//16-20
$RandomMapPick16 = "TWL2_Ocular"; 		$RandomMapPick17 = "S8_Opus"; 				$RandomMapPick18 = "Mirage"; 				$RandomMapPick19 = "DangerousCrossing_nef"; 		$RandomMapPick20 = "S5_Massive"; 
//21-25
$RandomMapPick21 = "TheFray"; 			$RandomMapPick22 = "RoundTheMountain"; 		$RandomMapPick23 = "S5_Mordacity"; 			$RandomMapPick24 = "TWL2_CanyonCrusadeDeluxe"; 		$RandomMapPick25 = "Signal"; 
//26-30
$RandomMapPick26 = "S8_Cardiac"; 		$RandomMapPick27 = "CirclesEdge"; 			$RandomMapPick28 = "S5_Icedance"; 			$RandomMapPick29 = "Bulwark"; 						$RandomMapPick30 = "Discord"; 
//31-35
$RandomMapPick31 = "MoonDance"; 		$RandomMapPick32 = "Rollercoaster_nef"; 	$RandomMapPick33 = "Logans_Run"; 			$RandomMapPick34 = "TWL_BeachBlitz"; 				$RandomMapPick35 = "TWL2_FrozenGlory"; 
//36-40
$RandomMapPick36 = "CircleofStones"; 	$RandomMapPick37 = "TitanV"; 				$RandomMapPick38 = "TWL_Katabatic"; 		$RandomMapPick39 = "TWL2_Magnum"; 					$RandomMapPick40 = "Fenix"; 


function SetNextMapGetRandoms( %client )
{

//Get random numbers
%RandomPick1 = getRandom(1,5);
%RandomPick2 = getRandom(6,10);
%RandomPick3 = getRandom(11,15);
%RandomPick4 = getRandom(16,20);
%RandomPick5 = getRandom(21,25);
%RandomPick6 = getRandom(26,30);
%RandomPick7 = getRandom(31,35);
%RandomPick8 = getRandom(36,40);

//Deduction code
$SetNextMissionMapSlot1 = $RandomMapPick[%RandomPick1];
$SetNextMissionMapSlot2 = $RandomMapPick[%RandomPick2];
$SetNextMissionMapSlot3 = $RandomMapPick[%RandomPick3];
$SetNextMissionMapSlot4 = $RandomMapPick[%RandomPick4];
$SetNextMissionMapSlot5 = $RandomMapPick[%RandomPick5];
$SetNextMissionMapSlot6 = $RandomMapPick[%RandomPick6];
$SetNextMissionMapSlot7 = $RandomMapPick[%RandomPick7];
$SetNextMissionMapSlot8 = $RandomMapPick[%RandomPick8];

}