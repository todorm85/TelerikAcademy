using System;

public class CSharpExam : Exam
{
    public const int CsharpMinScore = 0;
    public const int CsharpMaxScore = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < CsharpMinScore || CsharpMaxScore < value)
            {
                throw new ArgumentOutOfRangeException("Score must be between 0 and 100!");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, CsharpMinScore, CsharpMaxScore, "Exam results calculated by score.");
    }
}
