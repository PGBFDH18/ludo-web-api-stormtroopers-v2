Links to Ludo API


POST: Create a new Ludo game with a GUID ID
 http://ludoapp.azurewebsites.net/ludo/newludogame


DELETE: To delete a game wich is already created.
 http://ludoapp.azurewebsites.net/ludo/{id}/deletgame


POST: To add players to existing game.
 http://ludoapp.azurewebsites.net/ludo/{id}/players/addplayer?name={input}&colorID={input<=1,4=>}


DELETE: To Delete players
 http://ludoapp.azurewebsites.net/ludo/{id}/players



GET: To all ctreated Games.
 http://ludoapp.azurewebsites.net/ludo/getallgames


GET: To gat inforamtion about an existing game.
 https//localhost:44370/ludo/{id}/getgamedetails


GET:
 http://ludoapp.azurewebsites.net/ludo/{id}/players/getplayers/players?colorID={input}


PUT: To chane details of a game
 http://ludoapp.azurewebsites.net/ludo/{id}/changeplayer


PUT: To start a game
 http://ludoapp.azurewebsites.net/ludo/{id}/startgame


GET: To throw the dice
 http://ludoapp.azurewebsites.net/ludo/{id}/throwdice


PUT: To move pieces in the game.
 http://ludoapp.azurewebsites.net/ludo/{id}/movepiece


PUT: To end the game
 http://ludoapp.azurewebsites.net/ludo/{id}/endgame


GET: To get the winner of the game.
 http://ludoapp.azurewebsites.net/ludo/{id}/getwinner