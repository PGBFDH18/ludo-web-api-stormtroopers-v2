Links to Ludo API


POST: Create a new Ludo game with a GUID ID
 https://localhost:44370/ludo/newludogame


DELETE: To delete a game wich is already created.
 https://localhost:44370/ludo/{id}/deletgame


POST: To add players to existing game.
 https://localhost:44370/ludo/{id}/players/addplayer?name={input}&colorID={input<=1,4=>}


DELETE: To Delete players
 https://localhost:44370/ludo/{id}/players



GET: To all ctreated Games.
 https://localhost:44370/ludo/getallgames


GET: To gat inforamtion about an existing game.
 https//localhost:44370/ludo/{id}/getgamedetails


GET:
 https://localhost:44370/ludo/{id}/players/getplayers/players?colorID={input}


PUT: To chane details of a game
 https://localhost:44370/ludo/{id}/changeplayer


PUT: To start a game
 https://localhost:44370/ludo/{id}/startgame


GET: To throw the dice
 https://localhost:44370/ludo/{id}/throwdice


PUT: To move pieces in the game.
 https://localhost:44370/ludo/{id}/movepiece


PUT: To end the game
 https://localhost:44370/ludo/{id}/endgame


GET: To get the winner of the game.
 https://localhost:44370/ludo/{id}/getwinner