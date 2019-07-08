// GetCounts was made to accurately keep track of how many players
// are on teams, on the server, on each team, spectator, etc.
// It runs every 5 seconds.
// It has since evolved into the place to inject other services
// and aspects within the server.
// 
//
// To control whether the server auto resets when empty
// $Host::EmptyServerReset = 0;

$GetCountsClientTeamChange = true;


package StartTeamCounts 
{

function CreateServer( %mission, %missionType )
{
	parent::CreateServer( %mission, %missionType );
	//Call for a GetTeamCount update
	GetTeamCounts( %game, %client, %respawn );

	//Whether the server auto restarts when empty or not
	$Host::Dedicated = $Host::EmptyServerReset;
}

};

// Prevent package from being activated if it is already
if (!isActivePackage(StartTeamCounts))
    activatePackage(StartTeamCounts);

function GetTeamCounts( %game, %client, %respawn )
{	
	//Get teamcounts
	if( $GetCountsClientTeamChange && $countdownStarted && $MatchStarted ) 
	{	
		//Team Count code by Keen
		$PlayerCount[0] = 0;
		$PlayerCount[1] = 0;
		$PlayerCount[2] = 0;
		
		//For autobalance
		%lastclient1 = "";
		%lastclient2 = "";

		for(%i = 0; %i < ClientGroup.getCount(); %i++)
		{
			%client = ClientGroup.getObject(%i);
    
			//Pick a client for autobalance
			%team = %client.team;
			if(%client.score < %lastclient[%team].score || %lastclient[%team] $= "") { 
				%teamcanidate[%team] = %client; 
			}
			%lastclient[%team] = %client;
			
			//Check ver
			if(!%client.isAIControlled()) //No bots
				CheckVerObserver(%client);
				
			//if(!%client.isAIControlled())
				$PlayerCount[%client.team]++;
		}
		
		$team1canidate = %teamcanidate1;
		$team2canidate = %teamcanidate2;
		
		//echo ("$PlayerCount[0] " @  $PlayerCount[0]);
		//echo ("$PlayerCount[1] " @  $PlayerCount[1]);
		//echo ("$PlayerCount[2] " @  $PlayerCount[2]);

		//Amount of players on teams
		$TotalTeamPlayerCount = $PlayerCount[1] + $PlayerCount[2];
		//Amount of all players including observers
		$AllPlayerCount = $PlayerCount[1] + $PlayerCount[2] + $PlayerCount[0];
		//Difference Variables
		$Team1Difference = $PlayerCount[1] - $PlayerCount[2];
		$Team2Difference = $PlayerCount[2] - $PlayerCount[1];
		
		//Start Base Rape Notify
		schedule(500, 0, "NBRStatusNotify", %game);
		//Start Team Balance Notify
		schedule(1000, 0, "TeamBalanceNotify", %game );
		//Start AntiCloak
		schedule(1500, 0, "ActivateAntiCloak", %game);
		//Start MapRepetitionChecker
		schedule(2000, 0, "MapRepetitionChecker", %game);
		
		
		//Set so counter wont run when it doesnt need to.
		$GetCountsClientTeamChange = false;
	}
		
	//Call itself again. Every 5 seconds.
	schedule(5000, 0, "GetTeamCounts");	
}

//Run at DefaultGame::clientJoinTeam, DefaultGame::clientChangeTeam, DefaultGame::assignClientTeam in evo defaultgame.ovl
//Also Run at DefaultGame::onClientEnterObserverMode, DefaultGame::AIChangeTeam, DefaultGame::onClientLeaveGame, DefaultGame::forceObserver in evo defaultgame.ovl
//And finally GameConnection::onConnect in evo server.ovl
//Added so the bulk of GetCounts doesnt run when it doesnt need to causing unnecessary latency that may or may not have existed, but probably is good practice.
//GetCounts still runs every 5 seconds as it did, but whether or not someone has changed teams, joined obs, left, etc etc will decide whether or not the bulk of it runs.

//Let GetTeamCounts run if there is a Teamchange.
function ResetClientChangedTeams() 
{
   $GetCountsClientTeamChange = true;
}
