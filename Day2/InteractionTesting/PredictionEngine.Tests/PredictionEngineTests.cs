using LanguageModelAlgorithms;
using Moq;

namespace PredictionEngine.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Hi how are y", "y")]
    [TestCase("Hi how are you doing", "doing")]
    [TestCase("", "")]
    public void MonogramCalledWhenRequired(string inputPhrase, string lastWord)
    {
        var mockAlgo = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionEngine = new PredictionEngine(mockAlgo.Object);

        string predictedWord = predictionEngine.Predict(inputPhrase);

        mockAlgo.Verify(p => p.predictUsingMonogram(lastWord), Times.Once());

    }

    [TestCase("Hi how are ", "are")]
    [TestCase("Hi how are you ", "you")]
    [TestCase(" ", "")]
    public void BigramCalledWhenRequired(string inputPhrase, string lastWord)
    {
        var mockAlgo = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionEngine = new PredictionEngine(mockAlgo.Object);

        string predictedWord = predictionEngine.Predict(inputPhrase);

        mockAlgo.Verify(p => p.predictUsingBigram(lastWord), Times.Once());

    }

/*

    [Test]
public void Ping_invokes_DoSomething()
{
    // ARRANGE
    var mock = new Mock<ILanguageModelAlgo>();
    mock.Setup(p => p.predictUsingMonogram(It.IsAny<string>())).Returns("value");
   

    // ACT
    

    // ASSERT
    mock.Verify(p => p.predictUsingMonogram("PING"), Times.Once());
}
*/
}