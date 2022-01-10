using TournamentWorks.Domain.Games;

namespace TournamentWorks.Shared
{
    public class GameLogic
    {
        private readonly int _pointsToWin;
        private readonly int _pointsToFinalize;
        private Stack<Point> _pointStack = new Stack<Point>();
        public GameLogic(bool isSingles, int pointsToWin, int pointsToFinalize)
        {
            Singles = isSingles;
            _pointsToWin = pointsToWin;
            _pointsToFinalize = pointsToFinalize;
        }
        public Serves Server { get; set; } = Serves.LeftSideBottom;

        public string? TopLeftName { get; set; } = "";
        public string? BottomLeftName { get; set; } = "";
        public string? TopRightName { get; set; } = "";
        public string? BottomRightName { get; set; } = "";
        public bool Singles { get; private set; }
        public int LeftSidePoints { get; private set; }
        public int RightSidePoints { get; private set; }

        public MatchResult ScoreLeftSide()
        {
            LeftSidePoints++;
            
            if (LeftSidePoints % 2 == 0)
            {
                this.Server = Serves.LeftSideBottom;
            }
            else
            {
                this.Server = Serves.LeftSideTop;
            }
            if (Singles)
            {
                SwitchPlacesLeft();
                SwitchPlacesRight();
            } else
            {
                if (_pointStack.TryPeek(out var point))
                {
                    if (point == Point.LeftSide)
                    {
                        SwitchPlacesLeft();
                        if (Singles)
                        {
                            SwitchPlacesRight();
                        }
                    }
                }
            }
            _pointStack.Push(Point.LeftSide);

            if (LeftSidePoints == _pointsToFinalize || (LeftSidePoints >= _pointsToWin && LeftSidePoints > RightSidePoints + 1))
            {
                return MatchResult.Team1Victory;
            }
            else
            {
                return MatchResult.Undetermined;
            }

        }
        public MatchResult ScoreRightSide() {
            RightSidePoints++;
            if (RightSidePoints % 2 == 0)
            {
                this.Server = Serves.RightSideTop;
            }
            else
            {
                this.Server = Serves.RightSideBottom;
            }
            if (Singles)
            {
                SwitchPlacesRight();
                SwitchPlacesLeft();
            }
            else
            {
                if (_pointStack.TryPeek(out var point))
                {
                    if (point == Point.RightSide)
                    {
                        SwitchPlacesRight();
                        if (Singles)
                        {
                            SwitchPlacesLeft();
                        }
                    }
                }
            }
            _pointStack.Push(Point.RightSide);

            if (RightSidePoints == _pointsToFinalize || (RightSidePoints >= _pointsToWin && RightSidePoints > LeftSidePoints + 1))
            {
                return MatchResult.Team2Victory;
            }
            else
            {
                return MatchResult.Undetermined;
            }
        }

        public void ReturnPoints()
        {
            if (_pointStack.Peek() == Point.LeftSide)
            {
                LeftSidePoints--;
            }
            else
            {
                RightSidePoints--;
            }

            _pointStack.TryPop(out _);
            if (_pointStack.TryPeek(out var point))
            {
                if (point == Point.LeftSide)
                {
                    if (LeftSidePoints % 2 == 0)
                    {
                        Server = Serves.LeftSideBottom;
                    }
                    else
                    {
                        Server = Serves.LeftSideTop;
                    }
                    SwitchPlacesLeft();
                    if (Singles)
                    {
                        SwitchPlacesRight();
                    }
                } 
                else
                {
                    if (RightSidePoints % 2 == 0)
                    {
                        Server = Serves.RightSideTop;
                    }
                    else
                    {
                        Server = Serves.RightSideBottom;
                    }
                    SwitchPlacesRight();
                    if (Singles)
                    {
                        SwitchPlacesLeft();
                    }
                }
            }
            else
            {
                Server = Serves.LeftSideBottom;
                SwitchPlacesLeft();
                SwitchPlacesRight();
            }
        }

        public void ChangeServer()
        {
            this.Server = this.Server == Serves.LeftSideBottom ? Serves.RightSideTop : Serves.LeftSideBottom;
        }

        public void ChangeSides()
        {
            var tmp1 = BottomLeftName;
            BottomLeftName = TopRightName;
            TopRightName = tmp1;
            var tmp2 = TopLeftName;
            TopLeftName = BottomRightName;
            BottomRightName = tmp2;
        }

        public void SwitchPlacesLeft()
        {
            var tmp = BottomLeftName;
            BottomLeftName = TopLeftName;
            TopLeftName = tmp;
            
        }
        public void SwitchPlacesRight()
        {
            var tmp = BottomRightName;
            BottomRightName = TopRightName;
            TopRightName = tmp;
        }

        private enum Point
        {
            LeftSide,
            RightSide
        }
    }

    public enum Serves
    {
        LeftSideBottom,
        LeftSideTop,
        RightSideBottom,
        RightSideTop
    }
}
