(function () {
    var inputProvider = Object.create(InputProviders.Keyboard).init();
    var physicsEngine = Object.create(PhysicsEngines.StandartPhysicsEngine).init(inputProvider);
    var renderEngine = Object.create(RenderEngines.CanvasRenderer).init(900, 600);
    var scoreBoard = Object.create(ScoreBoard.StandartScoreBoard).init();
    var gameEngine = Object.create(GameEngines.StandartGameEngine).init(renderEngine, physicsEngine, scoreBoard);

    gameEngine.start();
}());