﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LudoGameEngine
{
    public class LudoGame : ILudoGame
    {
        public List<Player> _players = new List<Player>();
        public GameState checkState = GameState.NotStarted;
        public int currentPlayerId = 0;
        public IDice _dice = null;

        public LudoGame()
        {
            _dice = new Dice();
        }

        public LudoGame(IDice dice)
        {
            _dice = dice;
        }

        public Player AddPlayer(string name, int colorID)
        {
            PlayerColor color = GetColor(colorID);
            if (checkState != GameState.NotStarted)
            {
                throw new Exception($"Unable to add player since game is {checkState}");
            }

            if (_players.Where(p => p.PlayerColor == color).Count() > 0)
            {
                return null;
            }

            Player player = new Player()
            {
                PlayerId = _players.Count(),
                Name = name,
                PlayerColor = color,
                Pieces = new Piece[]
                {
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 0, PieceColor=color},
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 1, PieceColor=color},
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 2, PieceColor=color},
                    new Piece{ Position = 0, State = PieceGameState.HomeArea, PieceId = 3, PieceColor=color}
                }
            };

            _players.Add(player);

            return player;
        }

        public void EndTurn(Player player)
        {
            if (player.PlayerId != currentPlayerId)
            {
                throw new Exception($"Wrong player, it's currently {currentPlayerId}");
            }

            int numberOfPlayers = _players.Count();
            int nextPlayerId = player.PlayerId + 1;

            if (nextPlayerId <= numberOfPlayers - 1)
            {
                currentPlayerId = nextPlayerId;
            }
            else
            {
                currentPlayerId = nextPlayerId - numberOfPlayers;
            }

            // Check for a winner
            foreach (var xplayer in _players)
            {
                if (xplayer.Pieces.All(p => p.State == PieceGameState.Goal))
                {
                    checkState = GameState.Ended;
                }
            }
        }

        public Piece[] GetAllPiecesInGame()
        {
            int numberOfPieces = _players.Count() * 4;
            Piece[] pieces = new Piece[numberOfPieces];

            int pieceIndex = 0;
            foreach (var player in _players)
            {
                foreach (var piece in player.Pieces)
                {
                    pieces[pieceIndex] = piece;
                    pieceIndex++;
                }
            }

            return pieces;
        }

        public Player GetCurrentPlayer()
        {
            return _players.Where(p => p.PlayerId == currentPlayerId).FirstOrDefault();
        }

        public GameState GetGameState()
        {
            return checkState;
        }

        public Player[] GetPlayers()
        {
            return _players.ToArray();
        }

        public Piece MovePiece(Player player, int pieceId, int numberOfFields)
        {
            if (checkState == GameState.Ended)
            {
                throw new Exception("Game is ended, and a winner is found");
            }

            if (checkState == GameState.NotStarted)
            {
                throw new Exception("Game is not yet started, please start the game");
            }

            var piece = player.Pieces.First(p => p.PieceId == pieceId);

            if (piece.State == PieceGameState.Goal)
            {
                throw new Exception("Piece is in Goal and unable to move");
            }

            var currentPosition = piece.Position;

            var newPosition = currentPosition += numberOfFields;
            piece.State = PieceGameState.InGame;
            piece.Position = newPosition;

            if (newPosition > 39)
            {
                piece.State = PieceGameState.GoalPath;
            }

            if (newPosition > 43)
            {
                piece.State = PieceGameState.Goal;
            }

            return piece;
        }

        public int RollDice()
        {
            if (_dice == null)
            {
                throw new NullReferenceException("Dice is not set to an instance");
            }

            if (checkState != GameState.Started)
            {
                throw new Exception($"Unable roll dice since the game is not started, it's current state is: {checkState}");
            }

            return _dice.RollDice();
        }

        public bool StartGame()
        {
            if (checkState != GameState.NotStarted)
            {
                throw new Exception($"Unable to start game since it has the state {checkState} only NotStarted games can be started");
            }

            if (_players.Count < 2)
            {
                throw new Exception("Atleast two players is needed to start the game");
            }

            if (_players.Count > 4)
            {
                throw new Exception("A max of four players can be in the game");
            }

            checkState = GameState.Started;
            return true;
        }

        public Player GetWinner()
        {
            foreach (var player in _players) { 
                if(player.Pieces.All(p => p.State == PieceGameState.Goal))
                {
                    checkState = GameState.Ended;
                    return player;
                }
            }
            return null;
        }

        public bool RemovePlayer(int colorID)
        {
            bool removed = false;
            foreach (var player in _players)
            {
                if (player.PlayerColor == GetColor(colorID) && removed == false)
                {
                    _players.Remove(player);
                    removed = true;

                    return removed;
                }
            }

            return removed;
        }

        public PlayerColor GetColor(int colorID)
        {
            if (colorID == 0)
            {
                return PlayerColor.Red;
            }
            if (colorID == 1)
            {
                return PlayerColor.Green;
            }
            if (colorID == 2)
            {
                return PlayerColor.Blue;
            }
            if (colorID == 3)
            {
                return PlayerColor.Yellow;
            }
            else
            {
                return PlayerColor.Red;
            }
        }

        public Player UpdatePlayer(int oldColorID, string name, int colorID)
        {
            Player p1 = _players.First(x => x.PlayerId == oldColorID);

            if (p1.PlayerId != 9)
            {
                p1.PlayerColor = GetColor(colorID);
            }
            if(p1.Name != "")
            {
                p1.Name = name;
            }

            return p1;
        }

        public Player GetPlayer(int colorID)
        {
            return _players.Find(c => c.PlayerColor == GetColor(colorID));
        }
    }
}