<?php

	require __DIR__ . '/SourceQuery/bootstrap.php';
        require __DIR__ . '/MinecraftQuery/MinecraftPing.php';
        require __DIR__ . '/MinecraftQuery/MinecraftPingException.php';

	use xPaw\SourceQuery\SourceQuery;
	use xPaw\MinecraftQuery\MinecraftPing;
        use xPaw\MinecraftQuery\MinecraftPingException;
	
	// For the sake of this example
//	Header( 'Content-Type: text/plain' );
//	Header( 'X-Content-Type-Options: nosniff' );
	
	// validate input
        $ipaddr = $_POST['ip'];
        if(!preg_match('/^192\.168\.1\.[0-9]{2}$/', $ipaddr)){
                echo "Invalid IP address provided";
		return;
        }
        $portnum = $_POST['port'];
        if(!preg_match('/^26[012][0-9][0-9]$/', $portnum) && $portnum != "25565" && !preg_match('/^2701[56]$/', $portnum)) {
                echo "Invalid port number provided";
		return;
	}
	$svrtype = $_POST['svrtype'];
	if ($svrtype != "Minecraft" && $svrtype != "Source") {
                echo "Invalid server type provided";
		return;
	}

	$MCQuery = null;
	$SRCQuery = null;

	// Query server
	if ($svrtype == "Minecraft") {
		// Minecraft ping
		try {
			$MCQuery = new MinecraftPing($ipaddr, $portnum);
			print_r ($MCQuery->Query());
		} catch( MinecraftPingException $e ) {
			echo $e->getMessage();
		} finally {
			if ($MCQuery != null) {
				$MCQuery->close();
			}
		}
	} elseif ($svrtype == "Source") {
		// Valve Source engine
		try {
			$SRCQuery = new SourceQuery();
			$SRCQuery->Connect( $ipaddr, $portnum, 1, SourceQuery::SOURCE );
			print_r( $SRCQuery->GetInfo() );
//			print_r( $Query->GetPlayers( ) );
//			print_r( $Query->GetRules( ) );
		} catch( Exception $e ) {
			echo $e->getMessage();
		} finally {
			$SRCQuery->Disconnect();
		}
	} else {
		echo "Invalid server type encountered";
		return;
	}
	

