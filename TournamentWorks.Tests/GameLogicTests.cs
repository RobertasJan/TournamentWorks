using TournamentWorks.Shared;
using Xunit;

namespace TournamentWorks.Tests
{
    public class GameLogicTests
    {
        [Fact]
        public void GameLogic_11Point_LeftSideVictory()
        {
            GameLogic game = new GameLogic(true, 11, 15);
            DoPoints(game, 9, true);
            var result = game.ScoreLeftSide();
            var result2 = game.ScoreLeftSide();
            Assert.True(result == Domain.Games.MatchResult.Undetermined && result2 == Domain.Games.MatchResult.Team1Victory);
        }

        [Fact]
        public void GameLogic_11Point_RightSideVictory()
        {
            GameLogic game = new GameLogic(true, 11, 15);
            DoPoints(game, 9, false);
            var result = game.ScoreRightSide();
            var result2 = game.ScoreRightSide();
            Assert.True(result == Domain.Games.MatchResult.Undetermined && result2 == Domain.Games.MatchResult.Team2Victory);
        }

        [Fact]
        public void GameLogic_15Point_LeftSideVictory()
        {
            GameLogic game = new GameLogic(true, 15, 15);
            DoPoints(game, 13, true);
            var result = game.ScoreLeftSide();
            var result2 = game.ScoreLeftSide();
            Assert.True(result == Domain.Games.MatchResult.Undetermined && result2 == Domain.Games.MatchResult.Team1Victory);
        }

        [Fact]
        public void GameLogic_15Point_RightSideVictory()
        {
            GameLogic game = new GameLogic(true, 15, 15);
            DoPoints(game, 13, false);
            var result = game.ScoreRightSide();
            var result2 = game.ScoreRightSide();
            Assert.True(result == Domain.Games.MatchResult.Undetermined && result2 == Domain.Games.MatchResult.Team2Victory);
        }
        [Fact]
        public void GameLogic_21Point_LeftSideVictory()
        {
            GameLogic game = new GameLogic(true, 21, 21);
            DoPoints(game, 19, true);
            var result = game.ScoreLeftSide();
            var result2 = game.ScoreLeftSide();
            Assert.True(result == Domain.Games.MatchResult.Undetermined && result2 == Domain.Games.MatchResult.Team1Victory);
        }

        [Fact]
        public void GameLogic_21Point_RightSideVictory()
        {
            GameLogic game = new GameLogic(true, 21, 21);
            DoPoints(game, 19, false);
            var result = game.ScoreRightSide();
            var result2 = game.ScoreRightSide();
            Assert.True(result == Domain.Games.MatchResult.Undetermined && result2 == Domain.Games.MatchResult.Team2Victory);
        }

        [Fact]
        public void GameLogic_21PointTo30_LeftSideVictory()
        {
            GameLogic game = new GameLogic(true, 21, 30);
            DoPointsEqual(game, 29);
            Assert.Equal(29, game.LeftSidePoints);
            Assert.Equal(29, game.RightSidePoints);

            var result = game.ScoreLeftSide();
            Assert.True(result == Domain.Games.MatchResult.Team1Victory);
        }

        [Fact]
        public void GameLogic_21PointTo30_RightSideVictory()
        {
            GameLogic game = new GameLogic(true, 21, 30);
            DoPointsEqual(game, 29);
            Assert.Equal(29, game.LeftSidePoints);
            Assert.Equal(29, game.RightSidePoints);
            
            var result = game.ScoreRightSide();
            Assert.True(result == Domain.Games.MatchResult.Team2Victory);
            
        }

        [Fact]
        public void GameLogic_2Points_Return()
        {
            GameLogic game = new GameLogic(true, 21, 30);
            game.ScoreLeftSide();
            game.ScoreRightSide();
            game.ScoreLeftSide();
            game.ReturnPoints();
            game.ReturnPoints();
            Assert.Equal(1, game.LeftSidePoints);
            Assert.Equal(0, game.RightSidePoints);
        }

        [Fact]
        public void GameLogic_21PointsReturn_Undetermined()
        {
            GameLogic game = new GameLogic(true, 21, 30);
            DoPointsEqual(game, 20);
            var result1 = game.ScoreLeftSide();
            var result2 = game.ScoreRightSide();
            var result3 = game.ScoreLeftSide();
            var result4 = game.ScoreLeftSide(); // victory left side
            game.ReturnPoints();
            game.ReturnPoints();
            var result5 = game.ScoreLeftSide();

            Assert.True(result1 == Domain.Games.MatchResult.Undetermined);
            Assert.True(result1 == result2);
            Assert.True(result2 == result3);
            Assert.True(result4 == Domain.Games.MatchResult.Team1Victory);
            Assert.True(result5 == result3);

        }

        [Fact]
        public void GameLogic_10Points_Equal()
        {
            GameLogic game = new GameLogic(true, 21, 30);
            DoPointsEqual(game, 9);
            var result1 = game.ScoreLeftSide();
            var result2 = game.ScoreRightSide();
            Assert.Equal(10, game.LeftSidePoints);
            Assert.Equal(10, game.RightSidePoints);
            Assert.True(result1 == Domain.Games.MatchResult.Undetermined);
            Assert.True(result2 == Domain.Games.MatchResult.Undetermined);
        }

        [Fact]
        public void GameLogic_SinglesChange_3PointsLeft()
        {
            GameLogic game = new GameLogic(true, 21, 30)
            {
                BottomLeftName = "John",
                TopRightName = "Peter"
            };
            game.ScoreLeftSide();
            game.ScoreLeftSide();
            game.ScoreLeftSide();

            Assert.Equal("John", game.TopLeftName);
            Assert.Equal("Peter", game.BottomRightName);
        }

        [Fact]
        public void GameLogic_SinglesChange_2PointsRight()
        {
            GameLogic game = new GameLogic(true, 21, 30)
            {
                BottomLeftName = "John",
                TopRightName = "Peter"
            };
            game.ScoreRightSide();
            game.ScoreRightSide();

            Assert.Equal("John", game.BottomLeftName);
            Assert.Equal("Peter", game.TopRightName);
        }

        [Fact]
        public void GameLogic_DoublesChange_2PointsLeft()
        {
            GameLogic game = new GameLogic(false, 21, 30)
            {
                BottomLeftName = "John",
                TopLeftName = "Bob",
                TopRightName = "Peter",
                BottomRightName = "Andy"
            };
            game.ScoreLeftSide();
            game.ScoreLeftSide();

            Assert.Equal("Bob", game.BottomLeftName);
            Assert.Equal("John", game.TopLeftName);
            Assert.Equal("Peter", game.TopRightName);
            Assert.Equal("Andy", game.BottomRightName);
        }

        [Fact]
        public void GameLogic_DoublesChange_2PointsRight()
        {
            GameLogic game = new GameLogic(false, 21, 30)
            {
                BottomLeftName = "John",
                TopLeftName = "Bob",
                TopRightName = "Peter",
                BottomRightName = "Andy"
            };
            game.ScoreRightSide();
            game.ScoreRightSide();

            Assert.Equal("Bob", game.TopLeftName);
            Assert.Equal("John", game.BottomLeftName);
            Assert.Equal("Peter", game.BottomRightName);
            Assert.Equal("Andy", game.TopRightName);
        }

        [Fact]
        public void GameLogic_DoublesServe_2PointsLeft()
        {
            GameLogic game = new GameLogic(false, 21, 30)
            {
                BottomLeftName = "John",
                TopLeftName = "Bob",
                TopRightName = "Peter",
                BottomRightName = "Andy"
            };
            game.ScoreLeftSide();
            game.ScoreLeftSide();

            Assert.True(game.Server == Serves.LeftSideBottom);
        }

        [Fact]
        public void GameLogic_DoublesServe_2PointsRight()
        {
            GameLogic game = new GameLogic(false, 21, 30)
            {
                BottomLeftName = "John",
                TopLeftName = "Bob",
                TopRightName = "Peter",
                BottomRightName = "Andy"
            };
            game.ScoreRightSide();
            game.ScoreRightSide();

            Assert.True(game.Server == Serves.RightSideTop);
        }

        [Fact]
        public void GameLogic_SinglesServe_3PointsLeft()
        {
            GameLogic game = new GameLogic(true, 21, 30)
            {
                BottomLeftName = "John",
                TopRightName = "Peter"
            };
            game.ScoreLeftSide();
            game.ScoreLeftSide();
            game.ScoreLeftSide();

            Assert.True(game.Server == Serves.LeftSideTop);
        }

        [Fact]
        public void GameLogic_SinglesServe_3PointsRight()
        {
            GameLogic game = new GameLogic(true, 21, 30)
            {
                BottomLeftName = "John",
                TopRightName = "Peter"
            };
            game.ScoreRightSide();
            game.ScoreRightSide();
            game.ScoreRightSide();

            Assert.True(game.Server == Serves.RightSideBottom);
        }

        private void DoPoints(GameLogic logic, int count, bool leftSide)
        {
            for (var i = 0; i < count; i++)
            {
                if (leftSide)
                {
                    logic.ScoreLeftSide();
                } else
                {
                    logic.ScoreRightSide();
                }
            }
        }

        private void DoPointsEqual(GameLogic logic, int count)
        {
            for (var i = 0; i < count; i++)
            {
                logic.ScoreLeftSide();
                logic.ScoreRightSide();
            }
        }
    }
}