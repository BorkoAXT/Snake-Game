using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class Snake
    {
        private const int StartingElementsCount = 5;
        private  int MaximumSnakeSpeed = 100;
        private int MinSnakeSpeed = 0;

        public int StartingXPosition { get; set; }

        public int StartingYPosition { get; set; }

        public int Speed { get; set; }

        public Queue<Position> Elements { get; set; }

        public Position NewHeadPosition { get; set; }

        public Snake(int borderOffset, int boardHeight, int boardWidth)
        {
            Random random = new Random();
            this.StartingXPosition = random.Next(borderOffset, boardHeight - borderOffset);
            this.StartingYPosition = random.Next(borderOffset, boardWidth / 2);
            this.Speed = MinSnakeSpeed;
            this.Elements = InitialCreate();
            
        }
        private Queue<Position> InitialCreate()
        {
            if (this.StartingYPosition % 2 != 0)
            {
                this.StartingYPosition++;
            }
            Queue<Position> snakeElements = new Queue<Position>();
            for (int i = this.StartingYPosition; i < StartingElementsCount + this.StartingYPosition; i++)
            {
                snakeElements.Enqueue(new Position(this.StartingXPosition, i));
            }
            return snakeElements;
        }
        public bool isOutOfBorders(int boardHeight, int boardWidth, int bordersOffset) => this.NewHeadPosition.Row < 1 || this.NewHeadPosition.Row > boardHeight - bordersOffset
            || this.NewHeadPosition.Col < 1 || this.NewHeadPosition.Col >= boardWidth - bordersOffset;
        public bool IsBitten() => this.Elements.Any(x => x.Col == this.NewHeadPosition.Col && x.Row == this.NewHeadPosition.Row);

        public int GetReversedSpeed() => MaximumSnakeSpeed = this.Speed;


        
    }
}
