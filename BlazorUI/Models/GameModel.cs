using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUI.Models
{
    public class GameModel
    {
        public char[] Board { get; set; }
        public char Player { get; set; }

        public GameModel()
        {
            Board = new char[9];
            Array.Fill(Board, ' ');
            Player = 'X';
        }

        public void MakeMove(int index)
        {
            if (Board[index] != ' ' || !IsRunning())
            {
                return;
            }
            Board[index] = Player;
            if (FindWinner() == null)
            {
                NextTurn();
            }
        }
        private void NextTurn()
        {
            Player = Player == 'X' ? 'O' : 'X';
        }
        public int[] FindWinner()
        {
            int[,] winnerCombinations =
            {
                {0,1,2},
                {3,4,5},
                {6,7,8},
                {0,3,6},
                {1,4,7},
                {2,5,8},
                {0,4,8},
                {2,4,6}
            };

            for (int i = 0; i < winnerCombinations.GetLength(0); i++)
            {
                var result = new int[3];
                for (int j = 0; j < winnerCombinations.GetLength(1); j++)
                {
                    result[j] = winnerCombinations[i, j];
                    if (Board[result[j]] != Player && Board[result[j]] != ' ')
                    {
                        continue;
                    }
                }
                int a = result[0];
                int b = result[1];
                int c = result[2];

                if (Board[a] != ' ' && Board[a] == Board[b] && Board[a] == Board[c])
                {
                    return result;
                }
            }
            return null;
        }

        public bool IsRunning()
        {
            return FindWinner() == null && Board.Contains(' ');
        }


    }
}
